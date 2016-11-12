using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logique d'interaction pour User.xaml
    /// </summary>
    public partial class User : Window
    {
        private string _name2;
        public string Name2
        {
            get { return _name2; }
            set { _name2 = value; }
        }


        public User()
        {
            MV_Pilot pilote = ApplicationState.GetValue<MV_Pilot>("User"); 
            string tostring = pilote.ToString();
            Name2 = tostring;
            DataContext = this;

            InitializeComponent();
        }
          
           

        private void button_Click(object sender, RoutedEventArgs e)
        {
        

            BookPlace book  = new BookPlace();

            book.ShowDialog();
        }
    }
}
