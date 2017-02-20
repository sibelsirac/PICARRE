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

namespace Pi_
{
    /// <summary>
    /// Logique d'interaction pour Plane.xaml
    /// </summary>
    public partial class Plane : Window
    {
        public Plane()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {

            MV_Add ajout = new MV_Add(boxName.Text, boxPlane.Text, boxLong.Text, boxLarg.Text,textidhan.Text);
            ajout.Ajout();
        }
    }
}
