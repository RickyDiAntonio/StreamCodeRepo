//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Part_3_and_final
//{
//    public class MonsterBase:IActor
//    {
//        public string Name { get; set; }
//        public string Description { get; set; }
//        public int startingHP { get; set; }
//        public int startingAttack { get; set; }
//        public int startingDefense { get; set; }
//        public int startingSpeed { get; set; }
//        public int startingMana { get; set; }

//        //call currents after creation
//        public int currentHP { get; set; }
//        public int currentAttack { get; set; }
//        public int currentDefense { get; set; }
//        public int currentSpeed { get; set; }
//        public int currentMana {  get; set; }


//        public MonsterBase(string name,string description,int HP,int attack,int defense, int speed, int mana)
//        {
//            Name = name;
//            Description = description;
//            startingHP = HP;
//            startingAttack = attack;
//            startingDefense = defense;                     
//            startingSpeed = speed;
//            startingMana = mana;
//        }

//        public int GetHP()
//        {
//            throw new NotImplementedException();
//        }

//        public void SetHP(int value)
//        {
//            throw new NotImplementedException();
//        }

//        public void TakeTurn()
//        {
//            throw new NotImplementedException();
//        }

//        public void BaseAttack(IActor attacker, IActor target)
//        {
//            throw new NotImplementedException();
//        }
//    }

    
//}
