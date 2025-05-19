using System;

namespace Part_3_and_final
{
    
        public  class Player:IActor,Actions
        {
        private Vitals playerStats;

        public  string PlayerName { get; set; }
        public DestinyBase DestinyType { get; set; }


            public int HP { get; set; }
            public int Speed { get; set; }
            public int Attack { get; set; }
            public int Defense { get; set; }
            public int Mana { get; set; }


        public int Level { get; set; }

        public string Name => throw new NotImplementedException();

        public Player(string Name,DestinyBase dest)
        {
            playerStats = new Vitals(dest.startingHP, dest.startingAttack, dest.startingDefense, dest.startingSpeed, dest.startingMana);
            PlayerName = Name;
            DestinyType = dest;
            HP = dest.startingHP;
            Speed = dest.startingSpeed;
            Attack = dest.startingAttack;
            Defense = dest.startingDefense;
            Mana = dest.startingMana;
            Level = 1;
                       
        }
        public void Levelup(Player player)
        {

        }
        public void CombatCleanup()
        {

        }
        public void BasicAttackText()
        {
            Console.WriteLine($"{PlayerName} performs a basic attack");
        }

        public void TakeDamage(int amount)
        {
            playerStats.ModifyCurrentHP(-amount);
            Console.WriteLine($"{Name} took {amount} damage, current HP: {playerStats.CurrentHP}/{playerStats.BaseHP}");
        }
        public Dictionary<string, Action> GetAvailableMoves()
        {
            var actions = new Dictionary<string, Action>();

            actions["Basic Attack"] = () => BasicAttackText();

            var specialMoves = DestinyType.GetSpecialMovesByLevel(Level);
            foreach (var move in specialMoves)
            {
                actions[move.Key] = () => move.Value(PlayerName);
            }

            return actions;
        }
        public void StatDump()
        {
            Console.WriteLine($"HP: {playerStats.CurrentHP}/{playerStats.BaseHP}");
            Console.WriteLine($"Speed: {playerStats.CurrentSpeed}/{playerStats.BaseSpeed}");
            Console.WriteLine($"Attack: {playerStats.CurrentAttack}/{playerStats.BaseAttack}");
            Console.WriteLine($"Defense: {playerStats.CurrentDefense}/{playerStats.BaseDefense}");
            Console.WriteLine($"Mana: {playerStats.CurrentMana}/{playerStats.BaseMana}");

        }
        public void ActionOptions(DestinyBase destiny, int level)
        {

            Console.WriteLine("Choose your move:");
            var actions = GetAvailableMoves();
            int index = 1;
            foreach (var move in actions.Keys)
            {
                Console.WriteLine($"{index}. {move}");
                index++;
            }
        }

        public void DisplayHP()
        {
          
            Console.WriteLine($"{PlayerName} HP: { playerStats.CurrentHP}/{ playerStats.BaseHP}");
        }

        public void SetHP(int value)
        {
            playerStats.ModifyCurrentHP(value);
        }

        public void BaseAttack(IActor attacker, IActor target)
        {
            targettedAction(target, EffectTypes.damage);
        }

        public void TakeTurn(Player player,IActor target)
        {
            var actions = GetAvailableMoves();
            bool IsValidAction = false;
            while (!IsValidAction) 
            {
                ActionOptions(this.DestinyType, this.Level);

                string input = Console.ReadLine();

                IsValidAction = int.TryParse(input, out int choice);
                if ((!IsValidAction || choice < 1 || choice > actions.Count))
                {
                    Console.WriteLine("Invalid input.Try again");
                }

                switch (input) {
                    case "1": player.BasicAttackText(); player.BaseAttack(player, target);
                    break;
                }
                
            }
            
            

        }
        public void targettedAction(IActor affectedActor, EffectTypes type)
        {

            switch (type)
            {
               case EffectTypes.damage:
                    int damage = this.playerStats.CurrentAttack;
                    affectedActor.TakeDamage(damage);
                    break;
               


               throw new NotImplementedException();
            }
            
        }

        public void TakeTurn(IActor attacker, IActor target)
        {
            throw new NotImplementedException();
        }
    }
        
   
}

