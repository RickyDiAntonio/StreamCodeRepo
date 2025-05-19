using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_3_and_final
{
    internal interface Actions
    {
        


        //who its effecting, effect
        void  targettedAction(IActor affectedActor,EffectTypes type  );
    }
}
