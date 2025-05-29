using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Part_3_and_final.Abilities;
using static System.Net.Mime.MediaTypeNames;

namespace Part_3_and_final
{
    public class DestinyBase
    {

        public string Name { get; }
        public int startingHP { get; }       
        public  int startingAttack { get; }
        public  int startingDefense { get; }
        public int startingMagicAttack { get; }
        public int startingMagicDefense {  get; }
        public int startingSpeed { get; }
        public int startingMana { get; }

        public List<Ability> AbilitiesByLevel = new List<Ability>();
       
        public DestinyBase(string Name,int HP,int Att, int Def,int magicatt,int magicDef, int sp, int mana)
        {
            this.Name = Name;
            this.startingHP = HP;
            this.startingSpeed = sp;
            this.startingAttack = Att;
            this.startingDefense = Def;
            this.startingMagicAttack = magicatt;
            this.startingMagicDefense = magicDef;
            this.startingMana = mana;
        }
        //AbilitiesByLevel.Where(ability => ability.level =< characterLevel)
        public List<Ability> getAbilitiesByLevel(int level)
        {
            AbilitiesByLevel.Where(ability => ability.baseDamage <= level);
            return AbilitiesByLevel;
        }
        public virtual void ApplyLevelUpGrowth(Vitals vitals)
        {
            vitals.BaseHP += 10;
            vitals.BaseAttack += 2;
            vitals.BaseDefense += 2;
            vitals.BaseMagicAttack += 2;
            vitals.BaseMagicDefense += 2;
            vitals.BaseMana += 10;
        }
    }
   
    public class Sorcery:DestinyBase {

        // public DestinyBase(string Name,int HP,int Att, int Def,int magicatt,int magicDef, int sp, int mana)
        public Sorcery() : base("Sorcery", 80,5,5,5,15,15,200) {
            AbilitiesByLevel.Add(AbilityFactory.CreateAbility(AbilityNames.stormbolt));
            AbilitiesByLevel.Add(AbilityFactory.CreateAbility(AbilityNames.healingSurge));
            AbilitiesByLevel.Add(AbilityFactory.CreateAbility(AbilityNames.flameMark));            
        }
        public override void ApplyLevelUpGrowth(Vitals vitals)
        {
            base.ApplyLevelUpGrowth(vitals);
            vitals.BaseMagicAttack += 10;
            vitals.BaseMagicDefense += 10;
            vitals.BaseMana += 50;
        }
    }

    public class Might : DestinyBase
    {
        public Might() : base("Might", 120, 8, 20,5,5, 12, 50) { }              
    }
    public class Finesse : DestinyBase
    {
        public Finesse() : base("Finesse", 100, 12, 10,8,8, 10, 100) { }       
    }
}
