using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_3_and_final.Monsters
{
    public class Monster : IActor
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public Vitals Stats { get; private set; }

        public Monster(string name,string description, Vitals vitals)
        {
            this.Name = name;
            this.Description = description;
            this.Stats = vitals;
        }

        public void TakeDamage(int amount)
        {
            Stats.ModifyCurrentHP(-amount);
            Console.WriteLine($"{Name} took {amount} damage, current HP: {Stats.CurrentHP}/{Stats.BaseHP}");
        }

        public void BaseAttack(IActor attacker, IActor target)
        {
            throw new NotImplementedException();
        }

        public void DisplayHP()
        {
            Console.Write($"{Name} HP: {Stats.CurrentHP}/{Stats.BaseHP} ");
        }

        public void SetHP(int value)
        {
            throw new NotImplementedException();
        }

        public void TakeTurn(IActor attacker, IActor target)
        {
            throw new NotImplementedException();
        }
    }
    public class Goblin:Monster
    {
        
        public Goblin() : base("Goblin", "A small but nasty creature", new Vitals(25, 5, 5, 5, 0))
        {

        }
        public void SpecialAttack()
        {
            Console.WriteLine($"{Name} lunges at you with a rusty dagger!");
        }
       

    }
    public class Wolf : Monster
    {
        public Wolf(): base("Wolf","Not as cuddly as you thought", new Vitals(50, 8, 5, 10, 0))
        {

        }
        public void SpecialAttack()
        {
            Console.WriteLine($"{Name} bites at your ankles!");
        }
    }

}
