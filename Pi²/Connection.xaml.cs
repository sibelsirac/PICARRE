using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
    /// Logique d'interaction pour Connection.xaml
    /// </summary>
    public partial class Connection : Window
    {
        public Connection()
        {
            InitializeComponent();
        }
        public void pass_TextInput(object sender, TextCompositionEventArgs e)
        {
         //  pass = pass.ToString();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            string mot = pass.Password;//recuperation du mot de passe
             
            int password = int.Parse(mot); //parse du mot de passe
            MV_Recherche recherche = new MV_Recherche(boxName.Text);//recherche les données d'un pilot associé au nom donné en parametre
            MV_Pilot pilot = recherche.Pilot; //pilote associé au nom donne dans le textbox
            if (pilot.Pilot.ID==0 && pilot.Pilot.Name=="")
            {
                MessageBox.Show("Utilisateur non connu");
            }
            else if (pilot.Pilot.Plane ==password)
            {
                ApplicationState.SetValue("User", pilot);//utilisation de las classe applicationstate pour creer une variable de session reutilisable dans une autre classe
                User user = new User();

                user.ShowDialog(); //redirection vers la fenetre utilisateur lorsque les mot de passe et l'utilisateur sont correct

            }
            else
            {
                MessageBox.Show("Mauvais Mot de Passe");
            }

        }
    }
}
