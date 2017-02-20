using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi_
{

    class M_Optimisation
    {
        int id_plane;
        int x;
        int y;
        public M_Optimisation(int id_plane,int x,int y)
        {
            this.x = x;
            this.y = y;
            this.id_plane = id_plane;

        }
        public int ID
        {
            get { return id_plane; }
            set { id_plane = value; }
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

    }
}
