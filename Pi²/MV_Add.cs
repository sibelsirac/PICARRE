using bin_packing_a_etoile;
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
        string[,] tableau;
        string id_hangar;

        public MV_Add(string name, string plane, string length, string width)
        {
            this.gestion = new M_BDD(); //lien avec le modèle qulie la base de donnée
            this.name = name;
            this.plane = plane;
            this.length = length;
            this.width = width;
           
        }
        public MV_Add(string id_hangar)
        {
            this.gestion = new M_BDD(); //lien avec le modèle qulie la base de donnée
            this.id_hangar = id_hangar;
        }
        public MV_Add(string name, string plane, string length, string width, string id_hangar)
        {
            this.gestion = new M_BDD(); //lien avec le modèle qulie la base de donnée
            this.name = name;
            this.plane = plane;
            this.length = length;
            this.width = width;
            this.id_hangar = id_hangar;

        }
        public MV_Add(string[,] tableau, string id_hangar)
        {
            this.gestion = new M_BDD(); //lien avec le modèle qulie la base de donnée
            this.tableau = tableau;
            this.id_hangar = id_hangar;
        }
        public void Ajout()
        {//ajoute un avion avec comme parametre son nom, le type d'avion, la longeur et la latgeur correspondant aux variablename, plane, lengthb, widthb
            int lengthb = Int32.Parse(length);
            int widthb = Int32.Parse(width);
            int id_han = Int32.Parse(id_hangar);
            gestion.Add_plane(name, plane, lengthb, widthb,id_han);
        }

        public List<IImageInfo> Recherche_avion()
        {//ajoute un avion avec comme parametre son nom, le type d'avion, la longeur et la latgeur correspondant aux variablename, plane, lengthb, widthb
            List<IImageInfo> liste = new List<IImageInfo>();
            int id_han = Int32.Parse(id_hangar);
            int[,] tableau=gestion.tableau_avion(id_han);
            for(int i = 0; i < tableau.GetLength(0); i++)
            {
                ImageInfo image = new ImageInfo(tableau[i,0],tableau[i,1],tableau[i,2]);
                liste.Add(image);
            }
            return liste; 
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

        public void Add_opti()
        {//ajoute un pilote avc les parametres nom, prenom, numéro de license, son numero avion  associé aux variablesname, plane, widthb, lengthb
            int[,] tab = new int[tableau.GetLength(0), tableau.GetLength(1)];
            for (int i = 0; i < tableau.GetLength(0); i++)
            {
                int x = Int32.Parse(tableau[i,0]);
                int y = Int32.Parse(tableau[i,1]);
            }
            int id_han = Int32.Parse(id_hangar);
            gestion.Add_optimisation(tab,id_han);
        }
    }
}
