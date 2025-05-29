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
        public List<Ability> Abilities { get; private set; } = new List<Ability>();
        public string monsterArt = "TBD";
        public string basicAttackText;


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
        public string GetName()
        {
            return Name;
        }
        public bool isAlive()
        {
            //would like to remove the zero stat kill for monsters later
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
                    Scribe.WriteLineColor(($"{Name} took {amount} damage, current HP: {Vitals.CurrentHP}/{Vitals.BaseHP}"),ConsoleColor.Red);
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
            bool wasTextSent = false;
            foreach (EffectTypes effect in ability.Effects)
            {
                int damageModifier = ability.isMagicBased() ? Vitals.CurrentMagicAttack : Vitals.CurrentAttack;
                damageModifier = (int)Math.Round(damageModifier * ability.scalingMultiplier);

                if (!wasTextSent)
                {
                    string text = $"{Name}{ability.text}";
                   Scribe.WriteRight(text);
                }

                switch (effect)
                {
                    case EffectTypes.damage:
                        int damage = ability.baseDamage + damageModifier;
                        affectedActor.TakeEffectType(EffectTypes.damage, damage);
                        this.Vitals.ModifyCurrentMana(-ability.manaCost);
                        break;

                    case EffectTypes.heal:
                        int healing = ability.baseDamage + damageModifier;
                        this.TakeEffectType(EffectTypes.heal, healing);
                        this.Vitals.ModifyCurrentMana(-ability.manaCost);
                        break;

                    case EffectTypes.DoT:
                        Ability newAbility = AbilityFactory.CreateAbilityEffect(ability, this);
                        affectedActor.GetVitals().addEffect(newAbility);
                        this.Vitals.ModifyCurrentMana(-ability.manaCost);
                        Console.WriteLine($"Added {ability.name} to {affectedActor.GetName()}'s effects.");
                        break;
                }

                wasTextSent = true;
            }
        }

        public void DisplayHP()
        {
            Scribe.WriteLineColor($"{Name} HP: {Vitals.CurrentHP}/{Vitals.BaseHP} ",ConsoleColor.DarkYellow);
        }

        public void SetHP(int value)
        {
            throw new NotImplementedException();
        }

        public void TakeTurn(Player player, List<Monster> monsters)
        {
            
                if (!Abilities.Any()) return;              
                int index = rand.Next(Abilities.Count);
                Ability chosenAbility = Abilities[index];

                targettedAction(player, chosenAbility);
            
        }
        public void TurnStart()
        {
            //dots?
            foreach (Ability ability in this.Vitals.Effects.ToList())
            {
                turnStartDot(ability, ability.baseDamage);

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
                        this.TakeDamage(amount); //calculate defenses here
                        break;

                    case EffectTypes.heal:
                        Scribe.WriteLine(this.Name + $" healed {amount} damage from " + ability.name);
                        int healing = this.Vitals.CurrentAttack + this.Vitals.CurrentAttack * ability.baseDamage;
                        this.TakeEffectType(EffectTypes.heal, healing);
                        break;
                    
                }
            }
        }
        
    }
    public class Goblin:Monster
    {
        
        public Goblin() : base("Goblin", "A small but nasty creature", new Vitals(25, 5, 5,2,2, 5, 0))
        {
            this.monsterArt = asciiMonsters.goblin;
            this.basicAttackText = " lunges at you with a rusty dagger!";
            Abilities.Clear();

            Abilities.Add(AbilityFactory.CreateAbility(AbilityNames.basicAttack,basicAttackText ));
        }
       

    }
    public class Wolf : Monster
    {

        public Wolf(): base("Wolf","Not as cuddly as you thought", new Vitals(50, 8, 5,1,4, 10, 0))
        {
            this.monsterArt = asciiMonsters.wolf;
            this.basicAttackText = " bites at your ankles!";
            Abilities.Clear();

            Abilities.Add(AbilityFactory.CreateAbility(AbilityNames.basicAttack, basicAttackText));

        }
        public void SpecialAttack()
        {
            Console.WriteLine($"{Name} bites at your ankles!");
        }
    }

}
