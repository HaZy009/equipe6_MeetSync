using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gestion_des_horaires
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            
        }

        private void Ajt_Btn_Click(object sender, RoutedEventArgs e)
        {
            // Créez une instance de la fenêtre du Ajt_disponibilite
            Ajt_disponibilite AjtDispo = new Ajt_disponibilite();
            // Affichez la fenêtre du Ajt_disponibilite
            AjtDispo.Show();
            // Cacher la fenêtre Ajt_disponibilite
            this.Hide();
        }

        private void Rechercher_Btn_Click(object sender, RoutedEventArgs e)
        {
            // Créez une instance de la fenêtre du Rechercher_disponibilite
            Rechercher_disponibilite RchercherDispo = new Rechercher_disponibilite();
            // Affichez la fenêtre du Rechercher_disponibilite
            RchercherDispo.Show();
            // Cacher la fenêtre Rechercher_disponibilite
            this.Hide();
        }

        private void Lister_Btn_Click(object sender, RoutedEventArgs e)
        {
            // Créez une instance de la fenêtre du Rechercher_disponibilite
            Rechercher_disponibilite RchercherDispo = new Rechercher_disponibilite();
            // Affichez la fenêtre du Rechercher_disponibilite
            RchercherDispo.Show();
            // Cacher la fenêtre Rechercher_disponibilite
            this.Hide();
        }

        private void Lister_Btn_Click_1(object sender, RoutedEventArgs e)
        {
            // Créez une instance de la fenêtre du Lister_disponibilite
            Lister_disponibilite ListerDispo = new Lister_disponibilite();
            // Affichez la fenêtre du Rechercher_disponibilite
            ListerDispo.Show();
            // Cacher la fenêtre Rechercher_disponibilite
            this.Hide();
        }
    }
}
