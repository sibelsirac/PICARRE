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

namespace Pi_
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private MV_Recherche mv_recherche;
        //private MV_Ajout mv_ajout;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Plane recherche = new Plane();

            recherche.ShowDialog();
        }

        private void button_Click2(object sender, RoutedEventArgs e)
        {
            Pilot pilot = new Pilot();

            pilot.ShowDialog();

        }

        private void button_Click3(object sender, RoutedEventArgs e)
        {
            Hangar Hangar = new Hangar();

            Hangar.ShowDialog();
        }
        private void button_Click4(object sender, RoutedEventArgs e)
        {
            Connection Hangar = new Connection();

            Hangar.ShowDialog();
        }
        private void button_Click5(object sender, RoutedEventArgs e)
        {
            Parking_window Hangar = new Parking_window();

            Hangar.ShowDialog();
        }
    }
}