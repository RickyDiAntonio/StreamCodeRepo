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
            AbilitiesByLevel.Where(ability => ability.reqLevel <= level);
            return AbilitiesByLevel;
        }

    }
   
    public class Sorcery:DestinyBase {

        // public DestinyBase(string Name,int HP,int Att, int Def,int magicatt,int magicDef, int sp, int mana)
        public Sorcery() : base("Sorcery", 80,5,5,12,15,8,200) {
            AbilitiesByLevel.Add(AbilityFactory.CreateAbility(AbilityNames.stormbolt));
            AbilitiesByLevel.Add(AbilityFactory.CreateAbility(AbilityNames.healingSurge));
            AbilitiesByLevel.Add(AbilityFactory.CreateAbility(AbilityNames.flameMark));
            
        }


     


        //private  Ability SpecialMove1()
        //{
        //    string text = "hurls a bolt of arcane energy ";
        //    Ability specialdestinyMove1 =new Ability("storm bolt", EffectTypes.damage, text,1);
        //    return specialdestinyMove1 ;  
        //}
        //private Ability SpecialMove2()
        //{
        //    string text =" lets loose a fireball ";
        //    Ability specialdestinyMove1 = new Ability("fire ball", EffectTypes.damage, text,2);
        //    return specialdestinyMove1;
        //}



    }

    public class Might : DestinyBase
    {
        public Might() : base("Might", 120, 8, 20,5,5, 12, 50) { }

        //public override void SpecialMove1(string PlayerName)
        //{
        //    Console.WriteLine($"{PlayerName} performs a brutal strike");
        //}
    }
    public class Finesse : DestinyBase
    {
        public Finesse() : base("Finesse", 100, 12, 10,8,8, 10, 100) { }
        //public override void SpecialMove1(string PlayerName)
        //{
        //    Console.WriteLine($"{PlayerName} attacks with assassins arts.");
        //}
    }
}
