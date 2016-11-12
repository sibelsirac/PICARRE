using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi_
{
    class MV_Recherche
    {
        MV_Pilot pilot;
        private M_BDD gestion;
        string nom;
        
        public MV_Recherche(string nom)
        {//permet la recherche d'un pilot associé à un nom donné en parametre et retourne un élément Pilot grace à la methode verif_name
            this.nom = nom;
           
            gestion = new M_BDD();

           M_Pilot pilote= gestion.Verif_name(nom);//recherche un pilot dans la bdd associé à un nom

             this.pilot = new MV_Pilot(pilote);
             }
        public MV_Pilot Pilot
        {//accessibilité de pilot en dehors de cette classe
            get { return pilot; }
            set { pilot = value; }
        }

}
}
