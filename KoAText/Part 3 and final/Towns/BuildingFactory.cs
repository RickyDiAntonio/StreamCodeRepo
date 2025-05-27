using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_3_and_final
{
    public static  class TownFactory
    {
        public static Town createTown(params TownBuildingTypes[] townBuildings)
        {

            return new Town();
        }
    }
}
