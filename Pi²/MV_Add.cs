using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi_
{
    class MV_Add
    {
        M_BDD gestion;
        string name;
        string plane;
        string width;
        string length;
       
        public MV_Add(string name, string plane, string length, string width)
        {
            this.gestion = new M_BDD(); //lien avec le modèle qulie la base de donnée
            this.name = name;
            this.plane = plane;
            this.length = length;
            this.width = width;
           
        }
     
        public void Ajout()
        {//ajoute un avion avec comme parametre son nom, le type d'avion, la longeur et la latgeur correspondant aux variablename, plane, lengthb, widthb
            int lengthb = Int32.Parse(length);
            int widthb = Int32.Parse(width);
            gestion.Add_plane(name, plane, lengthb, widthb);
        }
        public void Add_hangar()
        {//ajoute un hangar avec les parametres nom, ville, longueur, largeur, associé aux variable : name, plane, lengthb, widthb
            int lengthb = Int32.Parse(length);
            int widthb = Int32.Parse(width);
            gestion.Add_Hangar(name, plane, lengthb, widthb);
        }
        public void Add_pilot()
        {//ajoute un pilote avc les parametres nom, prenom, numéro de license, son numero avion  associé aux variablesname, plane, widthb, lengthb
            int lengthb = Int32.Parse(length);
            int widthb = Int32.Parse(width);
            gestion.Add_pilot(name, plane, lengthb, widthb);
        }

    }
}
