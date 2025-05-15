
//string level = "Level 16";
//string level16 = "Simula's test";
//Console.WriteLine(level + $": {level16,40}");
//Console.WriteLine();


//ChestState chestState = ChestState.Locked;


//while (true)
//{
//    Console.Write($"The chest is {chestState}. What do you want to do?");

//    string input = Console.ReadLine();
//    if (chestState == ChestState.Locked && input =="unlock") chestState = ChestState.Closed;
//    if (chestState == ChestState.Closed && input =="open") chestState = ChestState.Open;
//    if (chestState == ChestState.Open && input == "close") chestState = ChestState.Closed;
//    if (chestState == ChestState.Closed && input == "lock") chestState = ChestState.Locked;

//}

//enum ChestState
//{
//    Open,
//    Closed,
//    Locked
//}




//string level = "Level 17";
//string level17 = "Simula's soup";
//Console.WriteLine(level + $": {level17,40}");
//Console.WriteLine();

//(SoupType type, MainIngredient ingredient, Seasoning seasoning) soup = GetSoup();
//Console.WriteLine($"{soup.seasoning} {soup.ingredient} {soup.type}");



//(SoupType,MainIngredient,Seasoning) GetSoup()
//{
//    SoupType type = GetSoupType();
//    MainIngredient mainIngredient = GetMainIngredient();
//    Seasoning seasoning = GetSeasoning();
//    return (type, mainIngredient, seasoning);
//}

//MainIngredient GetMainIngredient()
//{
//    Console.Write("Main ingredient (Mushroom, Chicken, Carrot, Potato): ");
//    string input =   Console.ReadLine().ToLower();
//    return input switch
//    {
//        "mushroom" => MainIngredient.Mushroom,
//        "chicken" => MainIngredient.Chicken,
//        "carrot" => MainIngredient.Carrot,
//        "potato" => MainIngredient.Potato
//    };
//}

//SoupType GetSoupType()
//{
//    Console.Write("Soup type (soup, stew, gumbo): ");
//    string input = Console.ReadLine().ToLower();
//    return input switch
//    {
//        "soup" => SoupType.Soup,
//        "stew" => SoupType.Stew,
//        "gumbo" => SoupType.Gumbo
//    };
//}
//Seasoning GetSeasoning()
//{
//    Console.Write("Seasoning type (Spicy, Salty, Sweet): ");
//    string input = Console.ReadLine().ToLower();
//    return input switch
//    {
//        "spicy" => Seasoning.Spicy,
//        "salty" => Seasoning.Salty,
//        "sweet" => Seasoning.Sweet
//    };
//}
//enum SoupType { Soup,Stew, Gumbo }
//enum MainIngredient { Mushroom, Chicken, Carrot, Potato}
//enum Seasoning { Spicy, Salty, Sweet}




//string level = "Level 18-22";
//string level18 = "Vin Fletcher inability to function without help";
//Console.WriteLine(level + $": {level18,40}");
//Console.WriteLine();

//Console.WriteLine("What kind of arrow are you looking for today?");
//Console.WriteLine("Elite Arrow(1)");
//Console.WriteLine("Marksman Arrow (2)");
//Console.WriteLine("Beginner Arrow (3)");
//Console.WriteLine("Custom Arrow (4)");
//string selection= Console.ReadLine();

//Arrow arrow = selection switch
//{
//    "1" => Arrow.CreateEliteArrow(),
//    "2" => Arrow.CreateMarksmanArrow(),
//    "3" => Arrow.CreateBeginnerArrow(),
//    _ => GetArrow()

//};

//Console.WriteLine($"That arrow costs {arrow.Cost} gold.");
//string why = Console.ReadLine();

//Arrow GetArrow()
//{
//Arrowhead arrowhead = GetArrowheadType();
//Fletching fletching = GetFletchingType();
//float length = GetLength();
//return new Arrow(arrowhead, fletching, length);
//}

//Arrowhead GetArrowheadType()
//{
//Console.Write("arrowhead type (steel,wood,obsidian):");
//string input = Console.ReadLine().ToLower();
//return input switch
//{
//"steel" => Arrowhead.Steel,
//"wood" => Arrowhead.Wood,
//"obsidian" => Arrowhead.Obsidian
//};
//}

//Fletching GetFletchingType()
//{
//Console.Write("Fletching type (plastic, turkey feather, goose feather): ");
//string input = Console.ReadLine();
//return input switch
//{
//"plastic" => Fletching.Plastic,
//"turkey feather" => Fletching.TurkeyFeathers,
//"goose feather" => Fletching.GooseFeathers
//};
//}

//float GetLength()
//{
//float length = 0;

//while (length < 60 || length > 100)
//{
//Console.Write("Arrow length (between 60 and 100): ");
//length = Convert.ToSingle(Console.ReadLine());
//}

//return length;
//}
//class Arrow
//{
//    private Arrowhead _arrowhead { get; }
//    private Fletching _fletching {  get; }
//    private float _length {  get; }

//    public Arrow(Arrowhead arrowhead, Fletching fletching, float length)
//    {
//        _arrowhead = arrowhead;
//        _fletching = fletching;
//        _length = length;
//    }

//    public float Cost
//    {
//        get
//            {
//            float arrowheadCost = _arrowhead switch
//            {
//                Arrowhead.Steel => 10,
//                Arrowhead.Wood => 3,
//                Arrowhead.Obsidian => 5
//            };

//            float fletchingCost = _fletching switch
//            {
//                Fletching.Plastic => 10,
//                Fletching.TurkeyFeathers => 5,
//                Fletching.GooseFeathers => 3
//            };

//            float shaftCost = 0.05f * _length;

//            return arrowheadCost + fletchingCost + shaftCost;
//        }
//    }

//    public static Arrow CreateEliteArrow() => new Arrow(Arrowhead.Steel, Fletching.Plastic, 95);
//    public static Arrow CreateBeginnerArrow() => new Arrow(Arrowhead.Wood, Fletching.GooseFeathers, 75);
//    public static Arrow CreateMarksmanArrow() => new Arrow(Arrowhead.Steel, Fletching.GooseFeathers, 65);
//}

//enum Arrowhead { Steel, Wood, Obsidian }
//enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }



//string level = "Level 24";
//string level24 = "Catacombs of the class: POINT";
//Console.WriteLine(level + $": {level24,40}");
//Console.WriteLine();

//Point a = new Point(2,3);
//Point b = new Point(-4,0);
//Console.WriteLine($"({a.X},{a.Y})");
//Console.WriteLine($"({b.X},{b.Y})");


//Color random = new Color(2, 200, 20);
//Color fixedColor = Color.Orange;

//Console.WriteLine($"R={random.R} G={random.G} B={random.B}");
//Console.WriteLine($"R={fixedColor.R} G={fixedColor.G} B={fixedColor.B}");




//public class Point
//{
//    public float X { get; }
//    public float Y { get; }



//    public Point(float x, float y)
//    {
//        this.X = x;
//        this.Y = y;
//    }

//    public Point() : this(0, 0) { }
//}
//public class Color
//{
//    public byte R { get; }
//    public byte G { get; }
//    public byte B { get; }

//    public Color(byte r, byte g, byte b)
//    {
//        R = r;
//        G = g;
//        B = b;
//    }

//    public static Color White { get; } = new Color(255, 255, 255);
//    public static Color Black { get; } = new Color(0, 0, 0);
//    public static Color Red { get; } = new Color(255, 0, 0);
//    public static Color Orange { get; } = new Color(255, 165, 0);
//    public static Color Yellow { get; } = new Color(255, 255, 0);
//    public static Color Green { get; } = new Color(0, 128, 0);
//    public static Color Blue { get; } = new Color(0, 0, 255);
//    public static Color Purple { get; } = new Color(128, 0, 128);
//}



//Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow };
//Rank[] ranks = new Rank[] { Rank.One, Rank.Two, Rank.Three, Rank.Four, Rank.Five, Rank.Six, Rank.Seven, Rank.Eight, Rank.Nine, Rank.Ten, Rank.DollarSign, Rank.Percent, Rank.Caret, Rank.Ampersand };

//foreach (Color color in colors)
//{
//    foreach (Rank rank in ranks)
//    {
//        Card card = new Card(rank, color);
//        Console.WriteLine($"The {card.Color} {card.Rank}");
//    }
//}


//public class Card
//{
//    public Rank Rank { get; }
//    public Color Color { get; }

//    public Card(Rank rank, Color color)
//    {
//        Rank = rank;
//        Color = color;
//    }

//    public bool IsSymbol => Rank == Rank.Ampersand || Rank == Rank.Caret || Rank == Rank.DollarSign || Rank == Rank.Percent;
//    public bool IsNumber => !IsSymbol;
//}




//public enum Color { Red, Green, Blue, Yellow }
//public enum Rank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, DollarSign, Percent, Caret, Ampersand }


//int startPassword = GetInputNumber("What is the starting code?");

//Door door = new Door(startPassword);

//while (true)
//{
//    Console.Write($"the door is currently {door.State}. What verb will you do?(open,close,lock,unlock,change pass)");
//    string? verb = Console.ReadLine();

//    switch (verb)
//    {
//        case "open":
//            door.Open(); break;
//        case "close":
//            door.Close(); break;
//        case "lock":
//            door.Lock(); break;
//        case "unlock":
//            int pass = GetInputNumber("Well, then what is the password????");
//            door.Unlock(pass); break;
//        case "change pass":
//            int currentCode = GetInputNumber("what is the current pass");
//            int newCode = GetInputNumber("what do you want it to be?");
//            door.ChangeCode(currentCode, newCode); break;
//    }
//}
//int GetInputNumber(string text)
//{
//    Console.WriteLine(text);
//    return Convert.ToInt32( Console.ReadLine() );
//}
//public class Door
//{
//    public DoorState State {  get; private set; }
//    private int _passcode;

//    public Door(int passcode)
//    {
//        this._passcode = passcode;
//        State = DoorState.Closed;
//    }
//    public void ChangeCode(int oldCode, int newCode)
//    {
//        if (oldCode == _passcode) _passcode = newCode; 
//    }
//    public void Close()
//    {
//        if(State ==DoorState.Open) State = DoorState.Closed;
//    }
//    public void Open()
//    {
//        if(State==DoorState.Closed) State = DoorState.Open;
//    }
//    public void Lock()
//    {
//        if(State == DoorState.Closed) State = DoorState.Locked;
//    }
//    public void Unlock(int passcode)
//    {
//        if(State ==DoorState.Locked && passcode ==_passcode)State = DoorState.Closed;
//    }
//}
//public enum DoorState { Open,Locked,Closed}



//using System.Security.Cryptography.X509Certificates;
//using Microsoft.VisualBasic;

//string level = "Level 25";
//string level25 = "Packing Inventory";
//Console.WriteLine(level + $": {level25,40}");
//Console.WriteLine();

//Pack pack = new Pack(10, 20, 30);
//while ( true)
//{
//    Console.WriteLine(pack);

//    Console.WriteLine($"Pack is currently holding {pack.CurrentCount}/{pack.MaxCount} items," +
//        $"{pack.CurrentVolume}/{pack.MaxVolume} volume," +
//        $"{pack.CurrentWeight}/{pack.MaxWeight} weight");

//    Console.WriteLine("What are you stuffing in your pack now???");
//    Console.WriteLine("1 - Arrow");
//    Console.WriteLine("2 - Bow");
//    Console.WriteLine("3 - Rope");
//    Console.WriteLine("4 - Water");
//    Console.WriteLine("5 - Food");
//    Console.WriteLine("6 - Sword");

//    int choice = Convert.ToInt32(Console.ReadLine());

//    InventoryItem newItem = choice switch
//    { 1=>new Arrow(),
//        2 => new Bow(),
//        3 => new Rope(),
//        4 => new Water(),
//        5 => new Food(),
//        6 => new Sword()
//    };
//    if (!pack.Add(newItem))
//        Console.WriteLine("Stop overstuffing, you won't cross the parapet with that");
//}

//public class InventoryItem
//{
//    public float volume { get; }
//    public float weight { get; }
//    public InventoryItem(float weight, float volume  )
//    {
//        this.volume = volume;
//        this.weight = weight;
//    }
//}

//public class Pack
//{
//    public int MaxCount {  get; }
//    public float MaxVolume { get; }
//    public float MaxWeight { get; }

//    private InventoryItem[] items;

//    public int CurrentCount {  get; private set; }
//    public float CurrentVolume { get; private set; }
//    public float CurrentWeight { get; private set; }

//    public Pack(int maxCount, float maxVolume,float maxWeight)
//    {
//        MaxCount = maxCount;
//        MaxVolume = maxVolume;
//        MaxWeight = maxWeight;
//        items = new InventoryItem[maxCount];
//    }
//    public bool Add(InventoryItem item)
//    {
//        if (CurrentCount>= MaxCount) return false;
//        if(CurrentVolume +item.volume > MaxVolume) return false;
//        if(CurrentWeight +item.weight > MaxWeight) return false;

//        items[CurrentCount] = item;
//        CurrentCount++;
//        CurrentVolume += item.volume;
//        CurrentWeight += item.weight;
//        return true;            

//    }
//    public override string ToString()
//    {
//        if (CurrentCount == 0)
//            return "Pack containing Nothing";

//        string containing = "Pack containing ";
//        for (int i = 0; i < CurrentCount; i++)
//        {
//            containing += items[i].ToString();
//        }
//        return containing;
//    }

//}

//public class Arrow : InventoryItem { public Arrow() : base(.1f,.05f) { }
//    public override string ToString()
//    {
//        return "Arrow ";
//    }
//}
//public class Rope : InventoryItem { public Rope() : base(1,1.5f) { }
//    public override string ToString()
//    {
//        return "Rope ";
//    }
//}
//public class Bow : InventoryItem { public Bow() : base(1, 4) { }
//    public override string ToString()
//    {
//        return "Bow ";
//    }
//}
//public class Sword: InventoryItem { public Sword(): base(5,3) { }
//    public override string ToString()
//    {
//        return "Sword ";
//    }
//}
//public class Food : InventoryItem { public Food() : base(1, 0.5f) { }
//    public override string ToString()
//    {
//        return "Food ";
//    }
//}
//public class Water: InventoryItem { public Water() : base(2, 3) { }
//    public override string ToString()
//    {
//        return "Water ";
//    }
//}





//using System;
//using System.Drawing;
//using System.Security.Cryptography.X509Certificates;
//using Microsoft.VisualBasic;


//Robot robot = new Robot();
//for(int i = 0; i <robot.Commands.Length; i++)
//{
//    string? input = Console.ReadLine();
//    IRobotCommand newCommand = input switch
//    {
//        "on" => new OnCommand(),
//        "off" => new OffCommand(),
//        "north" => new NorthCommand(),
//        "south" => new SouthCommand(),
//        "east" => new EastCommand(),
//        "west" => new WestCommand(),
//    };
//    robot.Commands[i] = newCommand;
//}
//Console.WriteLine();
//robot.Run();


//public class OnCommand : IRobotCommand
//{
//    public  void Run(Robot robot)
//    {
//        robot.IsPowered = true;
//    }
//}
//public class OffCommand : IRobotCommand
//{
//    public  void Run(Robot robot)
//    {
//        robot.IsPowered= false;
//    }
//}
//public class NorthCommand : IRobotCommand
//{
//    public  void Run(Robot robot)
//    {
//        if (robot.IsPowered) robot.Y++;
//    }
//}
//public class SouthCommand : IRobotCommand
//{
//    public  void Run(Robot robot)
//    {
//        if (robot.IsPowered) robot.Y--;
//    }
//}
//public class WestCommand : IRobotCommand
//{
//    public  void Run(Robot robot)
//    {
//        if (robot.IsPowered) robot.X--;
//    }
//}
//public class EastCommand : IRobotCommand
//{
//    public  void Run(Robot robot)
//    {
//        if (robot.IsPowered) robot.X++;
//    }
//}

//public interface IRobotCommand
//{
//     void Run(Robot robot);
//}
//public class Robot
//{    public int X { get; set; }
//    public int Y { get; set; }
//    public bool IsPowered { get; set; }
//    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
//    public void Run()
//    {
//        foreach (IRobotCommand? command in Commands)
//        {
//            command?.Run(this);
//            Console.WriteLine($"[{X} {Y} {IsPowered}]");
//        }
//    }
//}


//Coordinate a = new Coordinate(3, 3);
//Coordinate b = new Coordinate(2, 3);
//Coordinate c = new Coordinate(2, 2);

//Console.WriteLine(Coordinate.AreAdjacent(a, b)); // Should be True
//Console.WriteLine(Coordinate.AreAdjacent(b, c)); // Should be True
//Console.WriteLine(Coordinate.AreAdjacent(a, c)); // Should be False

//public struct Coordinate
//{
//    public int Row { get; }
//    public int Column { get; }

//    public Coordinate(int row, int column)
//    {
//        Row = row;
//        Column = column;
//    }

//    public static bool AreAdjacent(Coordinate a, Coordinate b)
//    {
//        int rowChange = a.Row - b.Row;
//        int columnChange = a.Column - b.Column;

//        if (Math.Abs(rowChange) <= 1 && columnChange == 0) return true;
//        if (Math.Abs(columnChange) <= 1 && rowChange == 0) return true;

//        return false;
//    }
//}



//Point p1 = new Point(-2, 5);
//Point p2 = p1 with { X=0};
//Console.WriteLine(p2);
//public record Point(float X, float Y)
//{
//    public override string ToString()
//    {
//        return $"({X},{Y})";
//    }
//}


//string level = "Level 29";
//string level29 = "War Preparations";
//Console.WriteLine(level + $": {level29,40}");
//Console.WriteLine();



//Sword basic = new Sword(Material.iron, Gemstone.none, 4, .2f);
//Console.WriteLine(basic);
//Sword basicFireSword = basic with {gemstone= Gemstone.amber };
//Console.WriteLine(basicFireSword);
//Sword thiccBasicSword = basic with { crossgaurdWidth = 1.5f };
//Console.WriteLine(thiccBasicSword);
//public enum Material { wood,bronze,iron,steel,binarium};
//public enum Gemstone { emerald,amber,sapphire,diamond,bitstone,none};
//public record Sword(Material Material,Gemstone gemstone,float length,float crossgaurdWidth);



//string level = "Level 30";
//string level30 = "Colored Items";
//Console.WriteLine(level + $": {level30,40}");
//Console.WriteLine();

//ColoredItem<Axe> axe = new ColoredItem<Axe>(new Axe(), ConsoleColor.Green);
//ColoredItem<Bow> bow = new ColoredItem<Bow>(new Bow(), ConsoleColor.Red);
//ColoredItem<Sword> sword = new ColoredItem<Sword>(new Sword(), ConsoleColor.Blue);

//sword.Display();
//axe.Display(); bow.Display();



//public class ColoredItem<T>
//{
//    public T item { get; }
//    public ConsoleColor color { get; }
//    public ColoredItem(T item, ConsoleColor color)
//    {
//        this.item = item;
//        this.color = color;
//    }

//    public void Display()
//    {
//        Console.ForegroundColor = color;
//        Console.Write(item);
//    }
//}

//public class Sword { }
//public class Bow { }
//public class Axe { }