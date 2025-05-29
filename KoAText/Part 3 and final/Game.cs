using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Part_3_and_final.Abilities;
using Part_3_and_final.Monsters;
using static Part_3_and_final.Constants;

namespace Part_3_and_final
{
    public class Game
    {
        public void Start()
        {
            Player mainCharacter = createCharacter();
           
            
          

          
           
            Encounter firstEncounter = new Encounter(mainCharacter, [MonsterTypes.goblin,MonsterTypes.wolf]);
            firstEncounter.StartEncounter();

                      



        }
        public Player createCharacter()
        {
            DestinyBase destinyChoice = new DestinyBase("oopsis", 1, 1, 1, 1, 1,1,1);
            Scribe.WriteLineColor("Welcome Hero! What is your name?",ConsoleColor.Cyan);
            string? name = "Ricky";
            //string? name = Console.ReadLine();

            bool validDestinyChoice = false;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (asciiDrawing.line.Length / 2)) + "}", asciiDrawing.line));


            while (name != null && !validDestinyChoice)
            {
                Console.Write("Choose your destiny tree ");
                Scribe.WriteColor(" [1] Might ", ConsoleColor.Red);
                Scribe.WriteColor(" [2] Sorcery ", ConsoleColor.Blue);
                Scribe.WriteLineColor(" [3] Finesse ", ConsoleColor.DarkYellow);
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (asciiDrawing.line.Length / 2)) + "}", asciiDrawing.line));
                switch ("2")
                //switch (Console.ReadLine())
                {
                    //case "1":
                    //    destinyChoice = new Might();
                    //    validDestinyChoice = true;
                    //    break;
                    case "2":
                        destinyChoice = new Sorcery();
                        validDestinyChoice = true;
                        break;
                    //case "3":
                    //    destinyChoice = new Finesse();
                    //    validDestinyChoice = true;
                    //    break;
                    //default:
                    //    Console.WriteLine("Invalid choice.Try again");
                    //    continue;
                }
            }

            Player createdChar = new Player(name ?? "Doesn't know name", destinyChoice);
            Console.Clear();
            return createdChar;
        }
        public void displayBasicTown()
        {
            Scribe.BasicTownRow([asciiDrawing.Building, asciiDrawing.Inn, asciiDrawing.Building,asciiDrawing.Store, asciiDrawing.Building, asciiDrawing.Building, asciiDrawing.Building]);
        }

    }
}
