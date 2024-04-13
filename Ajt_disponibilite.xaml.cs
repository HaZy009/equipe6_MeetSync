using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.SqlClient;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gestion_des_horaires
{
    /// <summary>
    /// Interaction logic for Ajt_disponibilite.xaml
    /// </summary>
    public partial class Ajt_disponibilite : Window
    {
        public Ajt_disponibilite()
        {
            InitializeComponent();
        }

        private void Retour_Btn_Click(object sender, RoutedEventArgs e)
        {
            // Créez une nouvelle instance de votre fenêtre de menu
            Menu menuWindow = new Menu();

            // Affichez la fenêtre de menu
            menuWindow.Show();

            // Fermez la fenêtre de disponibilité
            this.Hide();
        }

        private void Enregister_Btn_Click(object sender, RoutedEventArgs e)
        {
            // Récupérez les valeurs des contrôles
            string prenom = TxtboxPrenom.Text.Trim();
            string nom = TxtboxNom.Text.Trim();
            string courriel = TxtboxCourriel.Text.Trim();
            string telephone = TxtboxTelephone.Text.Trim();
            ComboBoxItem selectedJour = (ComboBoxItem)ComboJour.SelectedItem;
            ComboBoxItem selectedHeureDebut = (ComboBoxItem)ComboHeureDebut.SelectedItem;
            ComboBoxItem selectedHeureFin = (ComboBoxItem)ComboHeureFin.SelectedItem;

            // Validation des champs
            if (string.IsNullOrEmpty(prenom) ||
                string.IsNullOrEmpty(nom) ||
                string.IsNullOrEmpty(courriel) ||
                string.IsNullOrEmpty(telephone) ||
                selectedJour == null ||
                selectedHeureDebut == null ||
                selectedHeureFin == null)
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; // Arrête l'exécution si la validation échoue
            }

            string jour = selectedJour.Content.ToString();
            string heureDebut = selectedHeureDebut.Content.ToString();
            string heureFin = selectedHeureFin.Content.ToString();

            // Convertissez les heures en TimeSpan
            TimeSpan debutTimeSpan = TimeSpan.Parse(heureDebut + ":00");
            TimeSpan finTimeSpan = TimeSpan.Parse(heureFin + ":00");

            // La chaîne de connexion à votre base de données
            string connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=Gestion_Des_Horaires; Integrated Security=True;";

            // Créez la requête SQL pour insérer les données dans la table Utilisateur
            string queryUtilisateur = "INSERT INTO Utilisateur (Nom, Prenom, Courriel, Telephone) OUTPUT INSERTED.UtilisateurId VALUES (@Nom, @Prenom, @Courriel, @Telephone)";

            // Créez la requête SQL pour insérer les données dans la table Disponibilite
            string queryDisponibilite = "INSERT INTO Disponibilite (Date, HeureDebut, HeureFin, UtilisateurId) VALUES (@Date, @HeureDebut, @HeureFin, @UtilisateurId)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Commencez une transaction pour assurer que les deux inserts soient traités comme une opération atomique
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        // Insérez dans Utilisateur et récupérez l'ID utilisateur inséré
                        using (SqlCommand cmdUtilisateur = new SqlCommand(queryUtilisateur, conn, transaction))
                        {
                            cmdUtilisateur.Parameters.AddWithValue("@Nom", nom);
                            cmdUtilisateur.Parameters.AddWithValue("@Prenom", prenom);
                            cmdUtilisateur.Parameters.AddWithValue("@Courriel", courriel);
                            cmdUtilisateur.Parameters.AddWithValue("@Telephone", telephone);

                            var utilisateurId = (int)cmdUtilisateur.ExecuteScalar();

                            // Insérez dans Disponibilite en utilisant l'ID utilisateur récupéré
                            using (SqlCommand cmdDisponibilite = new SqlCommand(queryDisponibilite, conn, transaction))
                            {
                                cmdDisponibilite.Parameters.AddWithValue("@Date", DateTime.Now);
                                cmdDisponibilite.Parameters.AddWithValue("@HeureDebut", debutTimeSpan);
                                cmdDisponibilite.Parameters.AddWithValue("@HeureFin", finTimeSpan);
                                cmdDisponibilite.Parameters.AddWithValue("@UtilisateurId", utilisateurId);

                                cmdDisponibilite.ExecuteNonQuery();
                            }
                        }

                        // Si tout est bon, on valide la transaction
                        transaction.Commit();
                    }

                    MessageBox.Show("Les informations ont été enregistrées avec succès.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                    // Vider les TextBox
                    TxtboxPrenom.Clear();
                    TxtboxNom.Clear();
                    TxtboxCourriel.Clear();
                    TxtboxTelephone.Clear();

                    // Videz les Combobox
                    ComboJour.SelectedIndex = -1;
                    ComboHeureDebut.SelectedIndex = -1;
                    ComboHeureFin.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
