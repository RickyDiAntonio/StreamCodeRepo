// See https://aka.ms/new-console-template for more information


//CharberryTree tree = new CharberryTree();

//Notifier announcer = new Notifier(tree);
//Harvester harvester = new Harvester(tree);
//while (true)
//    tree.MaybeGrow();


//public class Harvester
//{
//    private int harvestCount;
//    private CharberryTree CharberryTree;
//    public Harvester(CharberryTree tree)
//    {
//        CharberryTree = tree;
//        CharberryTree.Ripened += OnTreeRipened;
//    }
//    public void OnTreeRipened()
//    {
//        harvestCount++;
//        CharberryTree.Ripe = false;
//        Console.WriteLine($"The tree has been harvested {harvestCount} times.");
//    }
//}
//public class Notifier
//{
//    public Notifier(CharberryTree tree)
//    {
//        tree.Ripened += OnTreeRipened;
//    }
//    public void OnTreeRipened() => Console.WriteLine("Get to picking, because the tree is ripe!!!");
//}
//public class CharberryTree
//{
//    private Random _random = new Random();
//    public bool Ripe { get; set; }
//    public event Action? Ripened;

//    public void MaybeGrow()
//    {
//        // Only a tiny chance of ripening each time, but we try a lot!
//        if (_random.NextDouble() < 0.00000001 && !Ripe)
//        {
//            Ripe = true;
//            Ripened?.Invoke();

//        }
//    }
//}

//Console.Write("what is your name?");
//string? name=Console.ReadLine();
//int score = 0;

//if(File.Exists(name+".txt"))
//{
//    score = Convert.ToInt32(File.ReadAllText(name + ".txt"));
//    Console.WriteLine($"Continue the grind, {name}. Score is currently {score}");
//}

//while(true)
//{
//    ConsoleKey key = Console.ReadKey().Key;
//    if (key == ConsoleKey.Enter)
//        break;
//    score++;
//    Console.WriteLine(score);
//}
//File.WriteAllText(name+".txt",score.ToString());


//PotionType potion = PotionType.Water;

//while (true)
//{
//    Console.WriteLine($"Current Potion: {potion}");

//    Console.WriteLine("Do you want to add more ingredients? ");
//    string? input = Console.ReadLine();
//    if (input == "no") break;

//    Console.WriteLine("Available ingredients: stardust, snake venom, dragon breath, shadow glass, eyeshine gem");

//    Ingredients ingredient = Console.ReadLine() switch
//    {
//        "stardust" => Ingredients.Stardust,
//        "snake venom" => Ingredients.SnakeVenom,
//        "dragon breath" => Ingredients.DragonBreath,
//        "shadow glass" => Ingredients.ShadowGlass,
//        "eyeshine gem" => Ingredients.EyeshineGem
//    };

//    potion = (ingredient, potion) switch
//    {
//        (Ingredients.Stardust, PotionType.Water) => PotionType.Elixir,               // Adding stardust to water turns it into an elixir.
//        (Ingredients.SnakeVenom, PotionType.Elixir) => PotionType.Poison,            // Adding snake venom to an elixir turns it into a poison potion.
//        (Ingredients.DragonBreath, PotionType.Elixir) => PotionType.Flying,          // Adding dragon breath to an elixir turns it into a flying potion.
//        (Ingredients.ShadowGlass, PotionType.Elixir) => PotionType.Invisibility,     // Adding shadow glass to an elixir turns it into an invisibility potion.
//        (Ingredients.EyeshineGem, PotionType.Elixir) => PotionType.NightSight,       // Adding an eyeshine gem to an elixir turns it into a night sight potion.
//        (Ingredients.ShadowGlass, PotionType.NightSight) => PotionType.CloudyBrew,   // Adding shadow glass to a night sight potion turns it into a cloudy brew.
//        (Ingredients.EyeshineGem, PotionType.Invisibility) => PotionType.CloudyBrew, // Adding an eyeshine gem to an invisibility potion turns it into a cloudy brew.
//        (Ingredients.Stardust, PotionType.CloudyBrew) => PotionType.Wraith,          // Adding stardust to a cloudy brew turns it into a wraith potion.
//        (_, _) => PotionType.Ruined,                                                 // Anything else results in a ruined potion.
//    };

//    if (potion == PotionType.Ruined)
//    {
//        Console.WriteLine("Oh no! The potion is ruined! Lets start over.");
//        potion = PotionType.Water;
//    }
//}


//public enum Ingredients { Stardust, SnakeVenom, DragonBreath, ShadowGlass, EyeshineGem }
//public enum PotionType { Water, Elixir, Poison, Flying, Invisibility, NightSight, CloudyBrew, Wraith, Ruined }
//BlockCoordinate coordinate = new BlockCoordinate(4, 3);
//Console.WriteLine(coordinate[0]);
//Console.WriteLine(coordinate[1]);
//public record BlockOffset(int RowOffset, int ColumnOffset);
//public enum Direction { North, East, South, West }
//public record BlockCoordinate(int Row, int Column)
//{
//   public int this[int index]=> index switch { 0=> Row, 1=> Column};
//}



