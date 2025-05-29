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
    }
}