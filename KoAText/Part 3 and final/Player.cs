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
                                public int Level { get; set; }
                                public List<Ability> Abilities;
        public int Experience { get; private set; } = 0;
        public int ExperienceToNextLevel => Level * 100;
        public int[] DestinySpread= new int[3];

        public Player(string Name,DestinyBase dest)
        {
            Vitals = new Vitals(dest.startingHP, dest.startingAttack, dest.startingDefense,dest.startingMagicAttack,dest.startingMagicDefense, dest.startingSpeed, dest.startingMana);
            PlayerName = Name;
            DestinyType = dest;
           
            Level = 1;
            Ability basicAttack = AbilityFactory.CreateAbility(AbilityNames.basicAttack);
            Abilities = new List<Ability>();
            Abilities.Add(basicAttack);
            AddAbilityList(dest.getAbilitiesByLevel(1));


        }
        public void GainExperience(int amount)
        {
            Experience += amount;
            Scribe.WriteLineColor($"{PlayerName} gains {amount} XP!", ConsoleColor.Green);
            while (Experience >= ExperienceToNextLevel)
            {
                Experience -= ExperienceToNextLevel;
                Levelup();
            }
        }
        public void Levelup()
        {
            Level++;
            Scribe.WriteLineColor($"{PlayerName} leveled up to {Level}!", ConsoleColor.Cyan);
            DestinyType.ApplyLevelUpGrowth(Vitals);

            Vitals.ResetCurrentStats();
            AddAbilityList(DestinyType.getAbilitiesByLevel(Level));
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
                Scribe.WriteLine(m.monsterArt);
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
        public string GetName()
        {
            return PlayerName;
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
        public void TurnStart()
        {
            //dots?
            foreach (Ability ability in this.Vitals.Effects.ToList())
            {
                turnStartDot(ability, ability.baseDamage);

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
                    Scribe.WriteRightColor($"{PlayerName} took {amount} damage, current HP: {Vitals.CurrentHP}/{Vitals.BaseHP}", ConsoleColor.DarkRed);
                    break;
                case EffectTypes.heal:
                    Vitals.ModifyCurrentHP(amount);
                    Scribe.WriteLineColor($"{PlayerName} has been healed for {amount} HP, current HP:{Vitals.CurrentHP}/{Vitals.BaseHP}", ConsoleColor.Green);
                    break;
                case EffectTypes.statChangeSpeed:
                    Vitals.ModifyCurrentSpeed(amount);
                    Scribe.WriteLineColor($"{PlayerName} has been slowed! speed reduced to {Vitals.CurrentSpeed}/{Vitals.BaseSpeed}" ,ConsoleColor.DarkMagenta);
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
            Console.WriteLine($"Magic attack: {Vitals.CurrentMagicAttack}/{Vitals.BaseMagicAttack}");
            Console.WriteLine($"Magic defense: {Vitals.CurrentMagicDefense}/{Vitals.BaseMagicDefense}");
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
            Scribe.WriteLineColor($" MP: {Vitals.CurrentMana}/{Vitals.BaseMana}",ConsoleColor.Blue);
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
                bool isValidAction = false;
            while (!isValidAction)
            {
                ActionOptions(Abilities); // Show available actions
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int choice)
                    && choice >= 1 && choice <= Abilities.Count)
                {
                    Ability chosenAbility = Abilities[choice - 1];

                    if (chosenAbility.manaCost > Vitals.CurrentMana)
                    {
                        Scribe.WriteLineColor("Not enough mana. Try another move.", ConsoleColor.Red);
                        continue;
                    }

                    Console.Clear();
                    player.targettedAction(target, chosenAbility);
                    isValidAction = true;
                }
                else
                {
                    Scribe.WriteLineColor("Invalid input. Try again.", ConsoleColor.DarkRed);
                }

            }

            }
            
            

        
        public void targettedAction(IActor affectedActor,Ability ability)
        {
            

            bool wasTextSent = false;
            foreach (EffectTypes effect in ability.Effects)
            {
                int damageModifier = ability.isMagicBased() ? Vitals.CurrentMagicAttack : Vitals.CurrentAttack;
                damageModifier=(int)Math.Round(damageModifier*ability.scalingMultiplier);

                switch (effect)
                {                                 
                    case EffectTypes.damage:
                        if (!wasTextSent) { Scribe.WriteLine(PlayerName + ability.text); }
                        int damage = ability.baseDamage +damageModifier;
                        affectedActor.TakeEffectType(EffectTypes.damage, damage );//calc defense here
                        this.Vitals.ModifyCurrentMana(-ability.manaCost);
                        break;
                    case EffectTypes.heal:
                        if (!wasTextSent) { Scribe.WriteLine(PlayerName + ability.text); }
                        int healing = ability.baseDamage + damageModifier;
                        this.TakeEffectType(EffectTypes.heal, healing);
                        this.Vitals.ModifyCurrentMana(-ability.manaCost);
                        break;
                    case EffectTypes.DoT:
                        if (!wasTextSent) { Scribe.WriteLine(PlayerName + ability.text); }
                        Ability newAbility = AbilityFactory.CreateAbilityEffect(ability, this);                        
                        affectedActor.GetVitals().addEffect(ability);
                        Console.WriteLine($"Added {ability.name} to {affectedActor.GetName()}'s effects.");
                        this.Vitals.ModifyCurrentMana(-ability.manaCost);
                        break;
                }
                wasTextSent = true;
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
                        this.TakeDamage(damage + (ability.baseDamage * Vitals.CurrentAttack));
                        break;

                    case EffectTypes.heal:
                        Scribe.WriteLine(this.PlayerName + $" healed {amount} damage from " + ability.name);
                        int healing = this.Vitals.CurrentAttack + this.Vitals.CurrentAttack * ability.baseDamage;
                        this.TakeEffectType(EffectTypes.heal, healing);
                        break;
                    case EffectTypes.shield:
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