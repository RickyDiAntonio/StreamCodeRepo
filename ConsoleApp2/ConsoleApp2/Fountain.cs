
//FountainOfObjects game = CreateGame();
//game.Run();

//FountainOfObjects CreateGame()
//{
//    Map map = new Map(8, 8);
//    Location start = new Location(0, 0);
//    map.SetRoomTypeAtLocation(start, RoomType.Entrance);
//    map.SetRoomTypeAtLocation(new Location(0, 2), RoomType.Fountain);
//    map.SetRoomTypeAtLocation(new Location(1, 2), RoomType.Pit);


//    Monster[] monsters = new Monster[]
//    {
//        new Maelstrom(new Location(2, 5))
//    };

//    return new FountainOfObjects(map, new Player(start), monsters);
//}
////game loop here
//public class FountainOfObjects
//{
//    public Map Map { get; }
//    public Monster[] Monsters { get; set; }
//    public bool IsFountainOn { get; set; }
//    public Player Player { get; }
//    public readonly ISense[] _senses;

//    public FountainOfObjects(Map map, Player player, Monster[] monsters)
//    {
//        Map = map; Player = player; Monsters = monsters;
//        _senses = new ISense[]
//        {
//            new LightInEntranceSense(),
//            new FountainSense()
//        };


//    }

//    public void Run()
//    {
//        Console.WriteLine(Monsters);
//        //game loop
//        while (!HasWon && Player.IsAlive)
//        {
//            DisplayStatus();
//            ICommand command = GetCommand();
//            command.Execute(this);

//            //pit trap
//            if (CurrentRoom == RoomType.Pit)
//            {
//                Player.kill("You fell into a pit and cannot climb out.");
//            }
//            //monster Mash check
//            foreach (Monster monster in Monsters)
//            {
//                if (monster.Location == Player.Location && monster.IsAlive) monster.Activate(this);
//            }


//        }
//        if (HasWon)
//        {
//            ConsoleHelper.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!", ConsoleColor.DarkGreen);
//            ConsoleHelper.WriteLine("You win!", ConsoleColor.DarkGreen);
//        }
//        else
//        {
//            ConsoleHelper.WriteLine(Player.CauseOfDeath, ConsoleColor.Red);
//            ConsoleHelper.WriteLine("Better luck next time", ConsoleColor.Red);
//        }



//    }
//    private void DisplayStatus()
//    {
//        ConsoleHelper.WriteLine("--------------------------------------------------------------------------------", ConsoleColor.Gray);
//        ConsoleHelper.WriteLine($"You are in the room at (Row={Player.Location.Row}, Column={Player.Location.Col}).", ConsoleColor.Gray);
//        foreach (ISense sense in _senses)
//            if (sense.CanSense(this))
//                sense.DisplaySense(this);
//    }

//    private ICommand GetCommand()
//    {
//        while (true)
//        {

//            ConsoleHelper.Write("What do you want to do? ", ConsoleColor.White);
//            Console.ForegroundColor = ConsoleColor.Cyan;
//            string? input = Console.ReadLine()?.Trim().ToLower();

//            if (string.IsNullOrEmpty(input))
//            {
//                ConsoleHelper.WriteLine("Please enter a command. Type help for a list of commands", ConsoleColor.Red);
//                continue;
//            }

//            // Check for a match with each known command.
//            if (input == "move north" || input == "n") return new MoveCommand(Direction.North);
//            if (input == "move south" || input == "s") return new MoveCommand(Direction.South);
//            if (input == "move east" || input == "e") return new MoveCommand(Direction.East);
//            if (input == "move west" || input == "w") return new MoveCommand(Direction.West);
//            if (input == "help")
//            {
//                ConsoleHelper.WriteLine("Commands:", ConsoleColor.Yellow);
//                ConsoleHelper.WriteLine("  n, s, e, w           - Move north, south, east, or west", ConsoleColor.Gray);
//                ConsoleHelper.WriteLine("  fountain             - Enable the fountain (must be in the fountain room)", ConsoleColor.Gray);
//                continue;
//            }
//            if (input == "fountain") return new EnableFountainCommand();

//            ConsoleHelper.WriteLine($"I did not understand '{input}'. Type help for a list of valid commands", ConsoleColor.Red);
//        }
//    }

//    public bool HasWon => CurrentRoom == RoomType.Entrance && IsFountainOn;
//    public RoomType CurrentRoom => Map.GetRoomTypeAtLocation(Player.Location);

//}

//public class Player
//{
//    public Location Location { get; set; }
//    public Player(Location start) => Location = start;
//    public bool IsAlive { get; set; } = true;
//    public string CauseOfDeath { get; set; } = "";
//    public void kill(string cause)
//    {
//        IsAlive = false;
//        CauseOfDeath = cause;
//    }
//}

//public abstract class Monster
//{
//    public Location Location { set; get; }
//    public bool IsAlive { get; set; } = true;
//    public Monster(Location start) => Location = start;

//    //Activates when player in same room, what happens
//    public abstract void Activate(FountainOfObjects game);
//}
////maelstrom monster
//public class Maelstrom : Monster
//{
//    public Maelstrom(Location start) : base(start) { }
//    public override void Activate(FountainOfObjects game)
//    {
//        ConsoleHelper.WriteLine("You have encountered a maelstrom and have been swept away to another room!", ConsoleColor.Magenta);
//        game.Player.Location = Clamp(new Location(game.Player.Location.Row + 1, game.Player.Location.Col + 2), game.Map.Rows, game.Map.Cols);
//        Location = Clamp(new Location(Location.Row + 1, Location.Col - 2), game.Map.Rows, game.Map.Cols);

//    }

//    private Location Clamp(Location location, int totalRows, int totalCols)
//    {
//        int row = location.Row;
//        if (row < 0) row = 0;
//        if (row >= totalRows) row = totalRows - 1;

//        int column = location.Col;
//        if (column < 0) column = 0;
//        if (column >= totalCols) column = totalCols - 1;

//        return new Location(row, column);
//    }

//}


//public interface ICommand
//{
//    void Execute(FountainOfObjects game);
//}
//public interface ISense
//{
//    bool CanSense(FountainOfObjects game);
//    void DisplaySense(FountainOfObjects game);

//}
//public class LightInEntranceSense : ISense
//{
//    public bool CanSense(FountainOfObjects game) => game.Map.GetRoomTypeAtLocation(game.Player.Location) == RoomType.Entrance;

//    public void DisplaySense(FountainOfObjects game) => ConsoleHelper.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.", ConsoleColor.Yellow);
//}



//public class FountainSense : ISense
//{
//    public bool CanSense(FountainOfObjects game) => game.Map.GetRoomTypeAtLocation(game.Player.Location) == RoomType.Fountain;

//    public void DisplaySense(FountainOfObjects game)
//    {
//        if (game.IsFountainOn) ConsoleHelper.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!", ConsoleColor.DarkCyan);
//        else ConsoleHelper.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!", ConsoleColor.DarkCyan);
//    }
//}

//public static class ConsoleHelper
//{
//    public static void WriteLine(string text, ConsoleColor color)
//    {
//        Console.ForegroundColor = color;
//        Console.WriteLine(text);
//    }
//    public static void Write(string text, ConsoleColor color)
//    {
//        Console.ForegroundColor = color;
//        Console.Write(text);
//    }
//}
//public class MoveCommand : ICommand
//{
//    public Direction Direction { get; }
//    public MoveCommand(Direction direction)
//    {
//        Direction = direction;
//    }
//    public void Execute(FountainOfObjects game)
//    {
//        Location currentLocation = game.Player.Location;
//        Location newLocation = Direction switch
//        {
//            Direction.North => new Location(currentLocation.Row - 1, currentLocation.Col),
//            Direction.South => new Location(currentLocation.Row + 1, currentLocation.Col),
//            Direction.East => new Location(currentLocation.Row, currentLocation.Col + 1),
//            Direction.West => new Location(currentLocation.Row, currentLocation.Col - 1)
//        };
//        if (game.Map.IsOnMap(newLocation))
//            game.Player.Location = newLocation;
//        else
//            ConsoleHelper.WriteLine("There is a wall there", ConsoleColor.Red);
//    }
//}
//public class EnableFountainCommand : ICommand
//{
//    public void Execute(FountainOfObjects game)
//    {
//        if (game.Map.GetRoomTypeAtLocation(game.Player.Location) == RoomType.Fountain) game.IsFountainOn = true;
//        else ConsoleHelper.WriteLine("The fountain is not in this room. There was no effect", ConsoleColor.Red);
//    }
//}
//public class Map
//{
//    private readonly RoomType[,] _rooms;

//    public int Rows { get; }
//    public int Cols { get; }
//    public Map(int rows, int columns)
//    {
//        Rows = rows; Cols = columns;
//        _rooms = new RoomType[Rows, Cols];
//    }
//    public RoomType GetRoomTypeAtLocation(Location location) => IsOnMap(location) ? _rooms[location.Row, location.Col] : RoomType.OffMap;

//    public bool HasNeighborWithType(Location location, RoomType roomType)
//    {
//        if (GetRoomTypeAtLocation(new Location(location.Row - 1, location.Col - 1)) == roomType) return true;
//        if (GetRoomTypeAtLocation(new Location(location.Row - 1, location.Col)) == roomType) return true;
//        if (GetRoomTypeAtLocation(new Location(location.Row - 1, location.Col + 1)) == roomType) return true;
//        if (GetRoomTypeAtLocation(new Location(location.Row, location.Col - 1)) == roomType) return true;
//        if (GetRoomTypeAtLocation(new Location(location.Row, location.Col)) == roomType) return true;
//        if (GetRoomTypeAtLocation(new Location(location.Row, location.Col + 1)) == roomType) return true;
//        if (GetRoomTypeAtLocation(new Location(location.Row + 1, location.Col - 1)) == roomType) return true;
//        if (GetRoomTypeAtLocation(new Location(location.Row + 1, location.Col)) == roomType) return true;
//        if (GetRoomTypeAtLocation(new Location(location.Row + 1, location.Col + 1)) == roomType) return true;
//        return false;
//    }
//    public bool IsOnMap(Location location) =>
//        location.Row >= 0 &&
//        location.Col >= 0 &&
//        location.Row < _rooms.GetLength(0) &&
//        location.Col < _rooms.GetLength(1);

//    public void SetRoomTypeAtLocation(Location location, RoomType type) => _rooms[location.Row, location.Col] = type;
//}
//public record Location(int Row, int Col);


//public enum Direction { North, South, East, West }
//public enum RoomType { Normal, Fountain, Entrance, OffMap, Pit }
