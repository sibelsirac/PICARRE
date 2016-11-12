using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi_
{
    class M_Pilot
    {
        int id;
        int license;
        string name;
        string firstname;
       int plane;
        public M_Pilot(int id,string name,string firstname,int plane, int license)
        {
            this.id = id;
            this.name = name;
            this.firstname = firstname;
            this.plane = plane;
            this.license = license;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string FN
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public int Plane
        {
            get { return plane; }
            set { plane= value; }
        }
        public int License
        {
            get { return license; }
            set { license = value; }
        }

    }
}
