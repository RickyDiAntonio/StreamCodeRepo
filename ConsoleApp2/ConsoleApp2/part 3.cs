

//using IField;
//using McDroid;

//string level = "Level 33";
//string level33 = "The Feud";
//Console.WriteLine(level + $": {level33,40}");
//Console.WriteLine();

//Sheep sheep=new Sheep();
//Cow cow = new Cow();
//IField.Pig pig = new IField.Pig();

//Console.WriteLine(pig.number); 
//namespace IField
//{
//    public class Sheep { }
//    public class Pig {
//        public int number { get; set; } = 2;
//    }
//}
//namespace McDroid
//{
//    public class Cow { }
//    public class Pig {
//        public int number {  get; set; }   = 1;
//    }
//}


//string level = "Level 34";
//string level34 = "The Safer number crunching";
//Console.WriteLine(level + $": {level34,40}");
//Console.WriteLine();

//int number;
//double number2;
//bool trueFalseValue;

//do
//{
//    Console.Write("Enter a number that is an int: ");
//}while(!int.TryParse(Console.ReadLine(), out number));
//Console.WriteLine(number);

//do
//{
//    Console.Write("Enter a number: ")
//}while(!double.TryParse(Console.ReadLine(), out number2));
//Console.WriteLine(number2);
//do
//{
//    Console.Write("True or False? ");
//}while(!bool.TryParse(Console.ReadLine(),out trueFalseValue));
//Console.WriteLine(trueFalseValue);




//try
//{
//    int targetNumber = new Random().Next(10);
//    List<int> previousGuesses = new List<int>();

//    while (true)
//    {
//        int number;
//        bool previouslyGuessed;
//        do
//        {
//            Console.Write("Pick a number between 0 and 9 (inclusive): ");
//            number = Convert.ToInt32(Console.ReadLine());
//            previouslyGuessed = previousGuesses.Contains(number);
//            if (previouslyGuessed) Console.WriteLine("That number has been guessed before.");
//        } while (previouslyGuessed);

//        if (number == targetNumber) throw new Exception();

//        previousGuesses.Add(number);
//    }
//}
//catch (Exception)
//{
//    Console.WriteLine("That was the bad number! You lose!");
//}



string level = "Level 36";
string level36 = "The Sieve";
Console.WriteLine(level + $": {level36,40}");
Console.WriteLine();

Console.Write("Which filter do you want to use? (1=Even, 2=Positive, 3=MultipleOfTen) ");
int choice = Convert.ToInt32(Console.ReadLine());

Sieve sieve = choice switch
{
    1 => new Sieve(IsEven),
    2 => new Sieve(IsPositive),
    3 => new Sieve(IsTenMultiple)
};


bool IsEven(int number)=> number % 2==0;
bool IsTenMultiple(int number)=> number%10==0;
bool IsPositive(int number)=> number >0;

public class Sieve
{
    private Func<int,bool> _func;

    public Sieve( Func<int,bool> func )=>_func = func;
    public bool IsGood(int number)
    {
        return _func(number);
    }
}