using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi_
{
    class MV_Plane
    {
        M_Plane avion;
        public MV_Plane(M_Plane avion)
        {
            this.avion = avion;
        }
        public override string ToString()
        {
            return avion.ID +" name: " + avion.Name + " plane: "+ avion.Plane + " width : " + avion.Width+" Length: "+avion.Length;
        }
    }
}
