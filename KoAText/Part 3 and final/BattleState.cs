using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part_3_and_final.Monsters;
using static Part_3_and_final.Constants;

namespace Part_3_and_final
{
    public class BattleState
    {
        //battlestate with player and list of monsters
        private Player _player;
        private List<Monster>? _monsters;
        private Queue<IActor> _turnQueue;
        private bool _battleOver = false;

        public BattleState(Player player, List<Monster> monsters)
        {
            _player = player;
            _monsters = monsters;
            _turnQueue = new Queue<IActor>();
            InitializeTurnOrder();
        }

        //turn order
        private List<IActor> InitializeTurnOrder()
        {
            var actors= new List<IActor>() { _player };
            if(_monsters ==null) throw new ArgumentNullException(nameof(_monsters));           
            actors.AddRange(_monsters.Where(m => m.Vitals.CurrentHP > 0));

            var sorted = actors.OrderByDescending(a => a.GetVitals().CurrentSpeed).ToList();
            _turnQueue.Clear();
            foreach (var actor in sorted)
            {
                _turnQueue.Enqueue(actor);
            }
            return sorted;

        }
        //startbattle
        public void StartBattle()
        {
            DisplayStatus();
            if (_monsters == null) throw new ArgumentNullException(nameof(_monsters));
            while (!_battleOver)
            {
                if (_turnQueue.Count == 0)
                {
                    InitializeTurnOrder(); // Only refill the queue when it's empty
                    DisplayQuickStatus();


                }

                var currentActor = _turnQueue.Dequeue();

                if (!currentActor.isAlive()) continue;

                currentActor.TurnStart();

                if (!currentActor.isAlive()) continue;

                currentActor.TakeTurn(_player, _monsters);
                
                CheckBattleEnd();
            }
        }
        private void CheckBattleEnd()
        {
            if (!_player.isAlive())
            {
                _battleOver = true;
                Scribe.WriteLineColor("You have been defeated....", ConsoleColor.Red);
            }
            if (_monsters != null && !_monsters.Any(m => m.isAlive()))
            {
                _battleOver = true;
                Scribe.WriteLineColor("You defeated all foes!", ConsoleColor.Cyan);
            }
        }
        private void DisplayStatus()
        {
            string turnText = $"----BattleStats----";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (asciiDrawing.line.Length / 2)) + "}", asciiDrawing.line));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (turnText.Length / 2)) + "}", turnText));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (asciiDrawing.line.Length / 2)) + "}", asciiDrawing.line));
            _player.DisplayHP();
            
            if(_monsters != null)
            foreach (var m in _monsters)
            {
                    m.DisplayHP();
            }
            Console.WriteLine();
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (asciiDrawing.line.Length / 2)) + "}", asciiDrawing.line));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (asciiDrawing.line.Length / 2)) + "}", asciiDrawing.line));

        }
        private void DisplayQuickStatus()
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (asciiDrawing.line.Length / 2)) + "}", asciiDrawing.line));

            _player.DisplayHP();
            if (_monsters != null)
                foreach (var m in _monsters)
                {
                    m.DisplayHP();
                }
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (asciiDrawing.line.Length / 2)) + "}", asciiDrawing.line));

        }



        //choosing targets
        //ending battle
    }
}
