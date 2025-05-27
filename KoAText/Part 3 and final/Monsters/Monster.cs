using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part_3_and_final.Abilities;
using static Part_3_and_final.Constants;

namespace Part_3_and_final.Monsters
{
    public class Monster : IActor,Actions
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public Vitals Vitals { get; private set; }
        public string basicAttackText = "";
        public List<Ability> Abilities { get; private set; } = new List<Ability>();
        

        public Monster(string name,string description, Vitals vitals)
        {
            this.Name = name;
            this.Description = description;
            this.Vitals = vitals;
            Abilities.Add(AbilityFactory.CreateAbility(AbilityNames.basicAttack));
        }
        public Vitals GetVitals()
        {
            return this.Vitals;
        }
        public bool isAlive()
        {
            if (this.GetVitals().CheckForZeroStats(this.GetVitals()) || Vitals.CurrentHP <= 0)
            {
                return false;
            }
            return (Vitals.CurrentHP > 0);
        }
        public void TakeDamage(int amount)
        {
            Vitals.ModifyCurrentHP(-amount);
            Console.WriteLine($"{Name} took {amount} damage, current HP: {Vitals.CurrentHP}/{Vitals.BaseHP}");
        }
        public void TakeEffectType(EffectTypes effectType, int amount)
        {
            switch(effectType)
            {
                case EffectTypes.damage:
                    Vitals.ModifyCurrentHP(-amount);
                    Console.WriteLine($"{Name} took {amount} damage, current HP: {Vitals.CurrentHP}/{Vitals.BaseHP}");
                    break;
                case EffectTypes.heal:
                    Vitals.ModifyCurrentHP(amount);
                    Scribe.WriteLineColor($"{Name} has been healed for {amount} HP, current HP:{Vitals.CurrentHP}/{Vitals.BaseHP}", ConsoleColor.Green);
                    break;
                case EffectTypes.DoT:
                    Vitals.ModifyCurrentHP(amount);

                    break;
                }
            }
        public void targettedAction(IActor affectedActor, Ability ability)
        {
            foreach (EffectTypes e in ability.Effects)
            {
                switch (e)
                {
                    case EffectTypes.damage:
                        Scribe.WriteLine(this.Name + ability.text);
                        int damage = this.Vitals.CurrentAttack;
                        affectedActor.TakeDamage(damage);
                        break;

                    case EffectTypes.heal:
                        Scribe.WriteLine(this.Name + ability.text);
                        int healing = this.Vitals.CurrentAttack + this.Vitals.CurrentAttack * ability.reqLevel;
                        this.TakeEffectType(EffectTypes.heal, healing);
                        break;
                }


            }

        }

        public void DisplayHP()
        {
            Console.Write($"{Name} HP: {Vitals.CurrentHP}/{Vitals.BaseHP} ");
        }

        public void SetHP(int value)
        {
            throw new NotImplementedException();
        }

        public void TakeTurn(Player player, List<Monster> monsters)
        {
            foreach (Monster m in monsters) {
                isAlive();
            }


        }
        public void turnStartDot(Ability ability, int amount)
        {
            foreach (EffectTypes e in ability.Effects)
            {
                switch (e)
                {
                    case EffectTypes.damage:
                        Scribe.WriteLine(this.Name + $" took {amount} damage from " + ability.name);
                        int damage = this.Vitals.CurrentAttack;
                        this.TakeDamage(damage + (ability.reqLevel * Vitals.CurrentAttack));
                        break;

                    case EffectTypes.heal:
                        Scribe.WriteLine(this.Name + $" healed {amount} damage from " + ability.name);
                        int healing = this.Vitals.CurrentAttack + this.Vitals.CurrentAttack * ability.reqLevel;
                        this.TakeEffectType(EffectTypes.heal, healing);
                        break;
                }
            }
        }
        public void TurnStart(Vitals vitals)
        {
            foreach (Ability ability in vitals.Effects)
            {
                turnStartDot(ability,ability.reqLevel);
            }
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
