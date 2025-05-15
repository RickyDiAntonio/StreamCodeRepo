// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;

//Console.WriteLine("Hello, World!");
// string name;
// Console.WriteLine("what is your name?");
// name=Console.ReadLine();
// Console.WriteLine("hello there "+name);

// byte a=2;
// System.Console.WriteLine(a);

// short b= -5000;
// Console.WriteLine(b);
// int c=34;
// Console.WriteLine(c);
// long d =-9000000000000000000;
// Console.WriteLine(d);
// sbyte e =-128;
// Console.WriteLine(e);

//Console.BackgroundColor = ConsoleColor.Yellow;
//Console.ForegroundColor = ConsoleColor.Black;
//Console.WriteLine("did it work?");
//Console.WriteLine("\"");
//Console.Beep();
//Console.Beep(440, 1000);


//string level8Name = "Defense of Consolas";
//Console.WriteLine($"Level 8: {level8Name,40}");
//Console.WriteLine();
//Console.WriteLine("The city is under assault, identify the x and y coordinates of the incoming fireball and we will calculate deployments for the movable magical barrier");
//Console.WriteLine();
//Console.WriteLine("Target Row?");
//int rowTarget = Convert.ToInt32( Console.ReadLine());
//Console.WriteLine("Target column?");
//int colTarget = Convert.ToInt32(Console.ReadLine());

//Console.WriteLine($"incoming attack at({rowTarget},{colTarget})");

//Console.ForegroundColor = ConsoleColor.Cyan;

//Console.WriteLine($"({rowTarget},{colTarget-1})");
//Console.WriteLine($"({rowTarget},{colTarget +1})");
//Console.WriteLine($"({rowTarget-1},{colTarget})");
//Console.WriteLine($"({rowTarget +1},{colTarget})");



//string level9Name = "Watchtower";
//Console.WriteLine($"Level 9: {level9Name,40}");
//Console.WriteLine();
//Console.WriteLine("Watchtowers surround the city, if you tell them the X and Y position of the enemy they will tell you the direction they are coming from" +
//    "One spy has the X and the other has the Y coordinates of the enemy");
//Console.WriteLine();
//Console.Write("x: ");
//int x = Convert.ToInt32(Console.ReadLine());
//Console.Write("y: ");
//int y = Convert.ToInt32(Console.ReadLine());

//if (x < 0 && y > 0) Console.WriteLine("The enemy is to the north west!");
//if (x == 0 && y > 0) Console.WriteLine("The enemy is to the north!");
//if (x > 0 && y > 0) Console.WriteLine("The enemy is to the north east!");
//if (x < 0 && y == 0) Console.WriteLine("The enemy is to the west!");
//if (x == 0 && y == 0) Console.WriteLine("The enemy is here!");
//if (x > 0 && y == 0) Console.WriteLine("The enemy is to the east!");
//if (x < 0 && y < 0) Console.WriteLine("The enemy is to the south west!");
//if (x == 0 && y < 0) Console.WriteLine("The enemy is to the south!");
//if (x > 0 && y < 0) Console.WriteLine("The enemy is to the south east!");

//string level10_a = "Buying Inventory";
//Console.WriteLine($"Level 10-A: {level10_a,40}");
//Console.WriteLine();
//Console.WriteLine("The following items are available:");
//Console.WriteLine("1 - Rope");
//Console.WriteLine("2 - Torches");
//Console.WriteLine("3 - Climbing Equipment");
//Console.WriteLine("4 - Clean Water");
//Console.WriteLine("5 - Machete");
//Console.WriteLine("6 - Canoe");
//Console.WriteLine("7 - Food Supplies");
//Console.Write("What number do you want to see the price of? ");

//int selectionNumber = Convert.ToInt32(Console.ReadLine());

//string item = selectionNumber switch
//{
//    1 => "Rope",
//    2 => "Torches",
//    3 => "Climbing Equipment",
//    4 => "Clean Water",
//    5 => "Machete",
//    6 => "Canoe",
//    7 => "Food Supplies"
//};

//int price = item switch
//{
//    "Rope" => 10,
//    "Torches" => 15,
//    "Climbing Equipment" => 25,
//    "Clean Water" => 1,
//    "Machete" => 20,
//    "Canoe" => 200,
//    "Food Supplies" => 1
//};
//Console.WriteLine($"{item} costs {price} gold");


//string level11 = "the prototype(number guessing game)";
//Console.WriteLine($"Level 11: {level11,40}");
//Console.WriteLine();
//bool isGuessCorrect =false;
//int number;
//do
//{
//    Console.WriteLine("player 1 enter a number between 0 and 100");
//    number = Convert.ToInt32(Console.ReadLine());
//}
//while (number<0|| number>100);
//Console.Clear();

//Console.WriteLine("Player 2 neds to  guess the number");
//while(true)
//{
//    Console.WriteLine("What is your guess?");
//    int guess  = Convert.ToInt32(Console.ReadLine());
//    if (guess > number)
//    {
//        Console.WriteLine($"{guess} isGuessCorrect too high!");
//    }
//    else if (guess < number) Console.WriteLine($"{guess} is too low");
//    else break;
//Console.WriteLine("You guessed the number!");


//string level11_2 = "The magic cannon(Thats what she said";
//Console.WriteLine($"Level 11: {level11_2,40}");
//Console.WriteLine();
//Console.WriteLine("Soldier, here is the cannon order, don't be afraid, but if we fire more than 100 shots, be very afraid");
//Console.WriteLine();

//for (int i = 1; i <= 100; i++)
//{
//    if (i % 5 == 0 && i % 3 == 0)
//    {
//        Console.ForegroundColor = ConsoleColor.DarkMagenta;
//        Console.WriteLine($"{i}: Electric and fire");
//        Console.ForegroundColor = ConsoleColor.Black;
//    }
//    else if (i % 5 == 0)
//    {
//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.WriteLine($"{i}: Electric");
//        Console.ForegroundColor = ConsoleColor.Black;
//    }
//    else if (i % 3 == 0)
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine($"{i}: Fire");
//        Console.ForegroundColor = ConsoleColor.Black;
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.Gray;
//        Console.WriteLine($"{i}: normal");
//    }
//}

//string level = "Level 12";
//string level12 = "The Replicator of D'to";
//Console.WriteLine(level+$": {level12,40}");
//Console.WriteLine();

//int[] startingArray= new int[5];
//int[] copyArray= new int[5];

//for(int i=0; i<startingArray.Length; i++)
//{
//    Console.Write("Enter a number:");
//    startingArray[i]=Convert.ToInt32(Console.ReadLine());
//    copyArray[i]=startingArray[i];
//}
//for(int i=0;i<5;i++)
//Console.WriteLine($"{startingArray[i]} and {copyArray[i]}");


//string level = "Level 12-2";
//string level12 = "The Laws of Freach";
//Console.WriteLine(level + $": {level12,40}");
//Console.WriteLine();
//int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };
//int currentSmallest = int.MaxValue;
//foreach (int i in array)
//{
//    if (i < currentSmallest) currentSmallest = i;
//}
//Console.WriteLine(currentSmallest);
//Console.WriteLine();
//int total = 0;
//foreach (int i in array)
//    total+=i;
//float average = (float)total / (float)array.Length;
//Console.WriteLine(average);

//string level = "Level 13";
//string level13 = "Taking a number redoing guessing game";
//Console.WriteLine(level + $": {level13,40}");
//Console.WriteLine();

//int secretNumber = AskForNumberInRange("Player 1, give me a number between 0 and 100", 100, 0);
//Console.Clear();
//Console.WriteLine("Player 2 needs to guess this secret");
//while(true)
//{
//    int guess = AskForNumber("What is your guess?");
//    if (guess > secretNumber) Console.WriteLine($"{guess} is too high");
//    if (guess < secretNumber) Console.WriteLine($"{guess} is too low");
//    else break;
//}
//Console.WriteLine("YOU GUESSED THE NUMBER!!!!!");

//int AskForNumber(string prompt)
//{
//    Console.Write(prompt + " ");
//    int number = Convert.ToInt32(Console.ReadLine());
//    return number;
//}
//int AskForNumberInRange(string prompt, int max, int min)
//{
//    while (true)
//    {
//        int number = AskForNumber(prompt);
//        if (number >= min && number <= max) return number;
//    }
//}

//void Countdown(int number)
//{
//    if (number == 0) return;
//    Console.WriteLine(number);
//    Countdown(number - 1);
//}

//Countdown(10);

