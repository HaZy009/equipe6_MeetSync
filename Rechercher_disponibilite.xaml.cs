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
    /// Interaction logic for Rechercher_disponibilite.xaml
    /// </summary>
    public partial class Rechercher_disponibilite : Window
    {
        public Rechercher_disponibilite()
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
    }
}
