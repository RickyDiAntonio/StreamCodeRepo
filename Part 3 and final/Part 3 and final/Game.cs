using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Part_3_and_final.Monsters;

namespace Part_3_and_final
{
    internal class Game
    {
        public void Start()
        {

            Console.WriteLine("Welcome Hero! What is your name?");
            string? name = Console.ReadLine();
            string input;
            DestinyBase destinyChoice = null;
            bool validDestinyChoice = false;

            while (name != null && !validDestinyChoice)
            {
                Console.WriteLine("Choose your destiny tree ([1] Might,[2] Sorcery or [3] Finesse");
                 input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "1":
                        destinyChoice = new Might();
                        validDestinyChoice = true;
                        break;
                    case "2":
                        destinyChoice = new Sorcery();
                        validDestinyChoice = true;
                        break;
                    case "3":
                        destinyChoice = new Finesse();
                        validDestinyChoice = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.Try again");
                        continue;
                }
            }

            Player mainCharacter = new Player(name, destinyChoice);
            Console.WriteLine("basic starting stats!!!");
            mainCharacter.StatDump();


            Console.WriteLine("OMG a goblin!");
            
             Goblin goblin = new Goblin();

            mainCharacter.TakeTurn(mainCharacter,goblin);
            

            mainCharacter.DisplayHP();
            goblin.DisplayHP();
            



        }
    }
}
