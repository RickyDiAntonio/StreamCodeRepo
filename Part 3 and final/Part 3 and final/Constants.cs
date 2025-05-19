using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_3_and_final
{
    internal class Constants
    {
        
        public static class Destinies
        {
            public const string Might = "Might";
            public const string Sorcery = "Sorcery";
            public const string Finesse = "Finesse";
            public const string Battlemage = "Battlemage";
            public const string Spellcloak = "Spellcloak";
            public const string Blademaster = "Blademaster";
            public const string Universalist = "Universalist";
        }
               
    }
    //global-ish enums
    public enum Stats { hp, att, def, spd, mp }
    public enum MonsterTypes { goblin,wolf}
    public enum EffectTypes {damage,heal }
    
        
    
}
