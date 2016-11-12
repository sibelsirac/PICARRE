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
            this.gestion = new M_BDD();
            this.name = name;
            this.plane = plane;
            this.length = length;
            this.width = width;
           
        }
     
        public void Ajout()
        {
            int lengthb = Int32.Parse(length);
            int widthb = Int32.Parse(width);
            gestion.Add_plane(name, plane, lengthb, widthb);
        }
        public void Add_hangar()
        {
            int lengthb = Int32.Parse(length);
            int widthb = Int32.Parse(width);
            gestion.Add_Hangar(name, plane, lengthb, widthb);
        }
        public void Add_pilot()
        {
            int lengthb = Int32.Parse(length);
            int widthb = Int32.Parse(width);
            gestion.Add_pilot(name, plane, lengthb, widthb);
        }

    }
}
