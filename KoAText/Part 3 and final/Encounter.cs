using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part_3_and_final.Abilities;
using Part_3_and_final.Monsters;
using static Part_3_and_final.Constants;

namespace Part_3_and_final
{
    internal class Encounter
    {
        private Player _player;
        private List<Monster> _monsters;
        MonsterFactory encounterMonsters = new MonsterFactory();

        public Encounter(Player player, params MonsterTypes[] types)
        {
            encounterMonsters = new MonsterFactory();
            _player = player;
            _monsters = GenerateMonsters(types);
                       
            
        }
        private List<Monster> GenerateMonsters(params MonsterTypes[] types)
        {
            List<Monster> monsters = new List<Monster>();
            foreach (var type in types)
            {
                monsters.Add(encounterMonsters.CreateMonster(type));
            }

            return monsters;
        }
        public void StartEncounter()
        {
            Console.WriteLine("Prepare for battle!");
            var battle = new BattleState(_player, _monsters);
            battle.StartBattle();
           
            
        }
        private void DisplayStatus(int turnNumber)
        {
            string turnText = $"----Turn {turnNumber}----";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (asciiDrawing.line.Length / 2)) + "}", asciiDrawing.line));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (turnText.Length / 2)) + "}", turnText));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (asciiDrawing.line.Length / 2)) + "}", asciiDrawing.line));
            _player.DisplayHP();
            Console.WriteLine("Foes:");
            foreach (var m in _monsters)
            {
                Console.WriteLine($"{m.Name}: {m.Vitals.CurrentHP}/{m.Vitals.BaseHP} HP");
            }
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (asciiDrawing.line.Length / 2)) + "}", asciiDrawing.line));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (asciiDrawing.line.Length / 2)) + "}", asciiDrawing.line));

        }
       
      
        //chooseTarget always returns player for monsters, putting here if we want to make a party later
        private IActor ChooseTarget()
        {
            return _player;
        }
        private Monster? ChooseMonsterTarget()
        {
            var target = _monsters.First(m => m.Vitals.CurrentHP > 0);
            if (target == null)
            {
                EndOfTurns();
            }

            //auto targetting the first monster who is alive for now
                        return target;
        }
        private bool DoesPlayerActFirst()
        {
            foreach (Monster monster in _monsters.Where(m => m.isAlive()))
            {
                if (monster.Vitals.CurrentSpeed > _player.Vitals.CurrentSpeed)
                {
                    return false;
                }
            }
            return true;
        }

        private void EndOfTurns()
        {

        }
    }
}