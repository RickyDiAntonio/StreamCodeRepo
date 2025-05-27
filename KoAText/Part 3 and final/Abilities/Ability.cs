using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_3_and_final
{
    public class Ability
    {
        //elements, manacosts
        public string name { get; private set; }
       
        public string text = "";
        public int reqLevel { get; }
        public int manaCost { get; private set; }
        public EffectTypes[] Effects { get; private set; }
        
        public Ability(string name, string text,int reqLevel,int manaCost =0,params EffectTypes[] extraEffects) { 
            this.name = name;
            this.text = text;
            this.reqLevel = reqLevel;
            this.Effects = extraEffects ?? new EffectTypes[0];
            this.manaCost = manaCost;
        }
       

    }
}
