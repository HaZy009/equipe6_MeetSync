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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gestion_des_horaires
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Commencer_Click(object sender, RoutedEventArgs e)
        {
            // Créez une instance de la fenêtre du Menu
            Menu menuWindow = new Menu();
            // Affichez la fenêtre du Menu
            menuWindow.Show();
            // Cacher la fenêtre principale
            this.Hide();
        }
    }
}
