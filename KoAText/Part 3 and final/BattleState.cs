using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part_3_and_final.Monsters;

namespace Part_3_and_final
{
    public class BattleState
    {
        //battlestate with player and list of monsters
        private Player _player;
        private List<Monster>? _monsters;
        private Queue<IActor> _turnQueue;

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
            var sorted = actors.OrderByDescending(a => a.GetVitals().CurrentSpeed);
            foreach (var actor in actors)
            {
                _turnQueue.Enqueue(actor);
            }
            return actors;

        }
        //startbattle
        public void StartBattle()
        {
            if (_monsters == null) throw new ArgumentNullException(nameof(_monsters));
            while (_player.isAlive() && _monsters.Any(m => m.isAlive()))
            {
                var turnOrder = InitializeTurnOrder();

                foreach (var actor in turnOrder)
                {
                    if (!actor.isAlive()) continue;
                        HandleDotEffects(actor);
                    if(!actor.isAlive()) continue;
                    if (actor is Player)
                    {
                      actor.TakeTurn(_player, _monsters);
                    }
                }
                    

            }
        }

        public void TakeTurn(IActor actor) {
        
          
        }
        //handle DOT effects/buffs
        public void HandleDotEffects(IActor actor) { }
        //choosing targets
        //ending battle
    }
}
