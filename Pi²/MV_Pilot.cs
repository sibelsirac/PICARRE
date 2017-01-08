using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi_
{
    class MV_Pilot
    {
        M_Pilot pilot;
        M_BDD gestion;
        public MV_Pilot(M_Pilot pilot)
        {
            this.pilot = pilot;
            gestion = new M_BDD();
        }

        public M_Pilot Pilot
        {
            get { return pilot; }
            set { pilot = value; }
        }
        public override string ToString()
        {
            MV_Plane plane = new MV_Plane(gestion.Recherche_plane(pilot.Plane));
            return pilot.Name + " " + pilot.FN + "votre Avion: " + plane.ToString() + "votre license " + pilot.License;

        }


    }
}
