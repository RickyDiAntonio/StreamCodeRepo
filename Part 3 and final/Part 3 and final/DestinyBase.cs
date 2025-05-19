using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_3_and_final
{
    public  class DestinyBase
    {
        public  string Name { get; }
        public int startingHP { get; }
        public int startingSpeed { get; }
        public  int startingAttack { get; }
        public  int startingDefense { get; }
        public int startingMana { get; }
        
        public DestinyBase(string Name,int HP,int sp,int Att, int Def, int mana)
        {
            this.Name = Name;
            this.startingHP = HP;
            this.startingSpeed = sp;
            this.startingAttack = Att;
            this.startingDefense = Def;
            this.startingMana = mana;
        }
        
        public virtual Dictionary<string, Action<string>> GetSpecialMovesByLevel(int level)
        {
            var moves=new Dictionary<string, Action<string>>();
            if (level >= 1)
                moves.Add("Special Move 1", SpecialMove1);
            if (level >= 2)
                moves.Add("Special Move 2", SpecialMove2);
            if (level >= 3)
                moves.Add("Special Move 3", SpecialMove3);
            if (level >= 4)
                moves.Add("Special Move 4", SpecialMove4);
            if (level >= 4)
                moves.Add("Special Move 5", SpecialMove5);
            return moves;
        }

        public virtual void SpecialMove1(string PlayerName) { }
        public void SpecialMove2(string PlayerName) { }
        public void SpecialMove3(string PlayerName) { }
        public void SpecialMove4(string PlayerName) { }
        public void SpecialMove5(string PlayerName) { }

    }

    public class Sorcery:DestinyBase {
        public Sorcery() : base("Sorcery", 80, 10, 5, 8,200) { }
        public override void SpecialMove1(string PlayerName)
        {
            Console.WriteLine($"{PlayerName} casts a storm bolt!");
        }


    }

    public class Might :DestinyBase {
        public Might() : base("Might", 120, 8, 20, 12, 50) { }

        public override void SpecialMove1(string PlayerName)
        {
            Console.WriteLine($"{PlayerName} performs a brutal strike");
        }
    }
    public class Finesse : DestinyBase
    {
        public Finesse() : base("Finesse", 100, 12, 10,10, 100) { }
        public override void SpecialMove1(string PlayerName)
        {
            Console.WriteLine($"{PlayerName} attacks with assassins arts.");
        }
    }
}
