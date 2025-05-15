//int manticoreHealth = 10;
//int consolasHealth = 15;
//int secretDistance;
//int distanceGuess;
//int roundNumber=1;


//int AskForNumberInRange(string prompt, int max, int min)
//{
//    while (true)
//    {
//        int number = AskForNumber(prompt);
//        if (number >= min && number <= max) return number;
//    }
//}
//    int AskForNumber(string prompt)
//    {
//        Console.Write(prompt + " ");
//        int number = Convert.ToInt32(Console.ReadLine());
//        return number;
//    }

//secretDistance = AskForNumberInRange("Player 1, how far away from the city are you stationing the Manticore? (0-100)", 100, 0);

////loop game game until city is gone or manticore is dead
//while(consolasHealth>0 && manticoreHealth > 0)
//{
//    //game state
//    Console.ForegroundColor = ConsoleColor.White;
//    Console.WriteLine("-----------------------------------------------------------");
//    DisplayStatus(roundNumber,consolasHealth,manticoreHealth);
//    Console.Clear();


//    //expected damage
   

//    Console.Write("The cannon damage is expected to be ");
//    int cannonDamage = damageThisRound(roundNumber);


//    //enter range
//    distanceGuess = AskForNumber("What cannon range are we using this round?");

//    //outcome, so too high or low
//    DisplayOverOrUnder(distanceGuess,secretDistance);

//    //deal damage if hit
//    if(secretDistance ==distanceGuess) manticoreHealth-=cannonDamage;

//    //always deal damage to city if manticore is alive 
//    consolasHealth -= 1;

//    //iterate count/round number
//    roundNumber++;
//}
//bool won = consolasHealth > 0;
//DisplayWinOrLose(won);

//void DisplayStatus(int round, int cityHealth, int manticoreHealth)=>
//    Console.WriteLine($"STATUS: Round:{round}  City: {cityHealth}/15 Manticore {manticoreHealth}/10");

//int damageThisRound(int roundNumber)
//{
//    if (roundNumber % 5 == 0 && roundNumber % 3 == 0)
//    {
//        Console.ForegroundColor = ConsoleColor.DarkMagenta;
//        Console.WriteLine("10 Electric and fire");
//        Console.ForegroundColor = ConsoleColor.Gray;
//        return 10;
//    }
//    else if (roundNumber % 5 == 0)
//    {
//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.WriteLine("3 Electric");
//        Console.ForegroundColor = ConsoleColor.Gray;

//        return 3;
//    }
//    else if (roundNumber % 3 == 0)
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("3 Fire");
//        Console.ForegroundColor = ConsoleColor.Gray;

//        return 3;
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.Gray;
//        Console.WriteLine("1 normal");

//        return 1;
//    }
//}

//void DisplayOverOrUnder(int targetRange, int range)
//{
//    if (targetRange < range) Console.WriteLine("That round FELL SHORT of the target.");
//    else if (targetRange > range) Console.WriteLine("That round OVERSHOT the target.");
//    else Console.WriteLine("That round was a DIRECT HIT!");
//}

//void DisplayWinOrLose(bool won)
//{
//    if (won)
//    {
//        Console.ForegroundColor = ConsoleColor.Blue;
//        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("The city has been destroyed. The Manticore and the Uncoded One have won.");
//    }
//}