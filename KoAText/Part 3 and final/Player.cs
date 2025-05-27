using System;
using System.Linq;
using System.Numerics;
using Part_3_and_final.Abilities;
using Part_3_and_final.Monsters;
using static Part_3_and_final.Constants;

namespace Part_3_and_final
{
    
        public  class Player:IActor,Actions
        {
                                public Vitals Vitals { get; private set; }
                                public  string PlayerName { get; set; }
                                public DestinyBase DestinyType { get; set; }
                                public int HP { get; set; }
                                public int Speed { get; set; }
                                public int Attack { get; set; }
                                public int Defense { get; set; }
                                public int Mana { get; set; }
                                public int Level { get; set; }
                                public List<Ability> Abilities;


        public Player(string Name,DestinyBase dest)
        {
            Vitals = new Vitals(dest.startingHP, dest.startingAttack, dest.startingDefense, dest.startingSpeed, dest.startingMana);
            PlayerName = Name;
            DestinyType = dest;
            HP = dest.startingHP;
            Speed = dest.startingSpeed;
            Attack = dest.startingAttack;
            Defense = dest.startingDefense;
            Mana = dest.startingMana;
            Level = 1;
            Ability basicAttack = AbilityFactory.CreateAbility(AbilityNames.basicAttack);
            Abilities = new List<Ability>();
            Abilities.Add(basicAttack);
            AddAbilityList(dest.getAbilitiesByLevel(1));


        }
        public void Levelup(Player player)
        {

        }
        private Monster? ChooseMonsterTarget(List<Monster> monsters)
        {
            var aliveMonsters = monsters.Where(m => m.isAlive()).ToList();
            if(aliveMonsters.Count() ==0) return null;

            Scribe.WriteLine("Choose a target:");
            for (int i = 0; i < aliveMonsters.Count(); i++)
            {
                var m = aliveMonsters[i];
                Scribe.WriteLineColor($"{i + 1}. {m.Name} - {m.Vitals.CurrentHP}/{m.Vitals.BaseHP} HP", ConsoleColor.Yellow);
            }
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int choice) &&
                    choice >= 1 && choice <= aliveMonsters.Count)
                {
                    return aliveMonsters[choice - 1];
                }
                Scribe.WriteLineColor("Invalid choice. Try again.",ConsoleColor.Red);
            } 

        }
        public void AddAbility(Ability ability)
        {
            this.Abilities.Add(ability);
        }
        public void AddAbilityList(List<Ability> abilities)
        {
            foreach (Ability a in abilities)
            {
               this.Abilities.Add(a);
            }
        }
        public void TurnStart(Vitals vitals)
        {

            foreach (Ability ability in vitals.Effects)
            {
                targettedAction(this, ability);
            }
        }

        public void CombatCleanup()
        {
            Vitals.ResetCurrentStats();
        }
        public bool isAlive()
        {
            if (this.GetVitals().CheckForZeroStats(this.GetVitals())||Vitals.CurrentHP<=0)
            {
                return false;
            }
            return (Vitals.CurrentHP > 0);
        }        
        public void TakeDamage(int amount)
        {
            Vitals.ModifyCurrentHP(-amount);
            Console.WriteLine($"{PlayerName} took {amount} damage, current HP: {Vitals.CurrentHP}/{Vitals.BaseHP}");
        }
        public void TakeEffectType(EffectTypes effectType, int amount)
        {
            switch (effectType)
            {
                case EffectTypes.damage:
                 Vitals.ModifyCurrentHP(-amount);
                 Console.WriteLine($"{PlayerName} took {amount} damage, current HP: {Vitals.CurrentHP}/{Vitals.BaseHP}");
                    break;
                case EffectTypes.heal:
                    Vitals.ModifyCurrentHP(amount);
                    Scribe.WriteLineColor($"{PlayerName} has been healed for {amount} HP, current HP:{Vitals.CurrentHP}/{Vitals.BaseHP}", ConsoleColor.Green);
                    break;
            }
        }
        public void Healing(int amount)
        {
            Vitals.ModifyCurrentHP(amount);
            Scribe.WriteLineColor($"{PlayerName} has been healed for {amount} HP, current HP:{Vitals.CurrentHP}/{Vitals.BaseHP}", ConsoleColor.Green);
        }
        public void StatDump()
        {
            Console.WriteLine($"HP: {Vitals.CurrentHP}/{Vitals.BaseHP}");
            Console.WriteLine($"Speed: {Vitals.CurrentSpeed}/{Vitals.BaseSpeed}");
            Console.WriteLine($"Attack: {Vitals.CurrentAttack}/{Vitals.BaseAttack}");
            Console.WriteLine($"Defense: {Vitals.CurrentDefense}/{Vitals.BaseDefense}");
            Console.WriteLine($"Mana: {Vitals.CurrentMana}/{Vitals.BaseMana}");

        }
        public void ActionOptions(List<Ability> Abilities)
        {
            Scribe.WriteLineColor("Choose your move",ConsoleColor.Green);
            
            int index = 0;
            foreach (var ability in Abilities)
            {
                Console.WriteLine($"{index+1}.{ability.name}");
                index++;
            }
        }
        public void DisplayHP()
        {
          
            Scribe.WriteColor($"{PlayerName} HP: { Vitals.CurrentHP}/{ Vitals.BaseHP}",ConsoleColor.Red);
            Scribe.WriteLineColor($"MP: {Vitals.CurrentMana}/{Vitals.BaseMana}",ConsoleColor.Blue);
        }
        public void SetHP(int value)
        {
            Vitals.ModifyCurrentHP(value);
        }
       
        public void TakeTurn(Player player, List<Monster> monsters)
        {
            var  target = ChooseMonsterTarget(monsters);
            if (target == null)
            {
                Scribe.WriteLineColor("There are no valid targets to attack.", ConsoleColor.Yellow);
                return;
            }
                bool IsValidAction = false;
            while (!IsValidAction)
            {
                ActionOptions(player.Abilities);
                Ability chosenAbility;
                string? input = Console.ReadLine();

                IsValidAction = int.TryParse(input, out int choice);

                if ((!IsValidAction || choice < 1 || choice > Abilities.Count))
                {
                    Scribe.WriteLineColor("Invalid input.Try again",ConsoleColor.DarkRed);
                }
                else
                {
                    chosenAbility = Abilities[choice - 1];
                    switch (input)
                    {
                        //want to call the text and then have the ability happen. so we want text since the text is decided here
                        case "1":
                            player.targettedAction(target, chosenAbility);
                            break;
                        case "2":
                            player.targettedAction(target, chosenAbility);
                            break;
                        case "3":
                            player.targettedAction(target, chosenAbility);
                            break;
                        case "4":
                            player.targettedAction(target,chosenAbility);
                            break;

                    }
                    
                }

            }
            
            

        }
        public void targettedAction(IActor affectedActor,Ability ability)
        {
            foreach (EffectTypes effect in ability.Effects)
            {
                Scribe.WriteLine("Ability Type: " + effect.ToString());
                switch (effect)
                {
                    case EffectTypes.damage:
                        Scribe.WriteLine(PlayerName + ability.text);
                        int damage = this.Vitals.CurrentAttack;
                        affectedActor.TakeEffectType(EffectTypes.damage, damage + (ability.reqLevel * Vitals.CurrentAttack));
                        this.Vitals.ModifyCurrentMana(-ability.manaCost);
                        break;
                    case EffectTypes.heal:
                        Scribe.WriteLine(PlayerName + ability.text);
                        int healing = this.Vitals.CurrentAttack + this.Vitals.CurrentAttack * ability.reqLevel;
                        this.TakeEffectType(EffectTypes.heal, healing);
                        this.Vitals.ModifyCurrentMana(-ability.manaCost);
                        break;
                    case EffectTypes.DoT:
                        Scribe.WriteLine(PlayerName + ability.text);
                        affectedActor.TakeEffectType(EffectTypes.DoT, this.Vitals.CurrentAttack * ability.reqLevel);
                        affectedActor.GetVitals().addEffect(ability);
                        this.Vitals.ModifyCurrentMana(-ability.manaCost);
                        break;

                }
            }
           
            
        }
        public void turnStartDot(Ability ability, int amount)
        {
            foreach (EffectTypes e in ability.Effects)
            {
                switch (e)
                {
                    case EffectTypes.damage:
                        Scribe.WriteLine(this.PlayerName + $" took {amount} damage from " + ability.name);
                        int damage = this.Vitals.CurrentAttack;
                        this.TakeDamage(damage + (ability.reqLevel * Vitals.CurrentAttack));
                        break;

                    case EffectTypes.heal:
                        Scribe.WriteLine(this.PlayerName + $" healed {amount} damage from " + ability.name);
                        int healing = this.Vitals.CurrentAttack + this.Vitals.CurrentAttack * ability.reqLevel;
                        this.TakeEffectType(EffectTypes.heal, healing);
                        break;
                }
            }
        }

        public Vitals GetVitals()
        {
            return this.Vitals;
        }
    }     
}