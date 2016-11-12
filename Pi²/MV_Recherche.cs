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
        {
            this.nom = nom;
           
            gestion = new M_BDD();

           M_Pilot pilote= gestion.Verif_name(nom);

             this.pilot = new MV_Pilot(pilote);
             }
        public MV_Pilot Pilot
        {
            get { return pilot; }
            set { pilot = value; }
        }

}
}
