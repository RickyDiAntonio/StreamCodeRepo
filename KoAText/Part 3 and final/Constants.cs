using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_3_and_final
{
    public static class Constants
    {
        public static class asciiDrawing
        {
            public const string line =
        "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
            public const string Open =
        @"       " + "\n" +
        @"       " + "\n" +
        @"       " + "\n" +
        @"       ";
            public const string Town =
                @"╔══ ══╗" + "\n" +
                @"║▀▀ ▀▀║" + "\n" +
                @"║▄▄ ▄▄║" + "\n" +
                @"╚══ ══╝";
            public const string Castle =
                @"╔══ ══╗" + "\n" +
                @"║╔═══╗║" + "\n" +
                @"║╚═══╝║" + "\n" +
                @"╚══ ══╝";
            public const string Building =
                @" /---\ " + "\n" +
                @"/-----\" + "\n" +
                @"|     |" + "\n" +
                @"|  █  |";
            public const string Inn =
                @" /---\ " + "\n" +
                @"/-Inn-\" + "\n" +
                @"|     |" + "\n" +
                @"|  █  |";
            public const string Store =
                @" /---\ " + "\n" +
                @"/Store\" + "\n" +
                @"|     |" + "\n" +
                @"|  █  |";
            public const string Chest =
                @"       " + "\n" +
                @"  _._  " + "\n" +
                @" |___| " + "\n" +
                @"       ";
            public const string EmptyChest =
                @"       " + "\n" +
                @"       " + "\n" +
                @" |___| " + "\n" +
                @"       ";
        }
        public static class Destinies
        {
            public const string Might = "Might";
            public const string Sorcery = "Sorcery";
            public const string Finesse = "Finesse";
            public const string Battlemage = "Battlemage";
            public const string Spellcloak = "Spellcloak";
            public const string Blademaster = "Blademaster";
            public const string Universalist = "Universalist";
        }
        

        public static class Scribe
        {
            public static void WriteLine(string message)
            {
                Console.WriteLine(message);
            }
            public static void WriteLineColor(string message, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(message);
                Console.ResetColor();
            }

            public static void WriteColor(string message, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.Write(message);
                Console.ResetColor();
            }
            public static void BasicTownRow(params string[] buildings)
            {
                //split the buildings rows up and put them in array
                var splitBuildings = buildings
                    .Select(b => b.Split('\n'))
                    .ToArray();
                int lineCount = splitBuildings[0].Length;

                for (int i = 0; i < lineCount; i++)
                {
                    foreach (var piece in splitBuildings)
                    {
                        Console.Write(piece[i] + " ");
                    }
                    Console.WriteLine();
                }

            }

        }
        //global-ish enums and console?
       



    }
    public enum WeaponTypes { longsword,greatsword,hammer,daggers,longbow,faeBlades,staff,chakrams,sceptre}
    public enum Stats { hp, att, def,magAtt,magDef, spd, mp }
    public enum MonsterTypes { goblin, wolf }
    public enum EffectTypes { damage,heal,DoT,shield, onHit }
    public enum AbilityNames { stormbolt,basicAttack,sphereOfProtection,flameMark, flameMarkDoT,healingSurge }
    public enum TownBuildingTypes { inn, shop,smith,tavern,apothicary }
}
