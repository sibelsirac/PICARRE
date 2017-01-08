using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi_
{
    class M_Plane
    {
        string name;
        string plane;
        int length;
        int width;
        int id;
        public M_Plane(int id,string name, string plane, int length, int width){
            this.id = id;
            this.name = name;
            this.plane = plane;
            this.length = length;
            this.width = width;


        }



        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public int Length
        {
            get { return length; }
            set { width = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Plane
        {
            get { return plane; }
            set { plane = value; }
        }
    }

}
