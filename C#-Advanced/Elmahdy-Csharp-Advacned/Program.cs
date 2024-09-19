using Elmahdy_Csharp_Advacned.Extension;


string str = "Ammar Hammad is the best programmer";

Console.WriteLine(str.RemoveWhiteSpaces().Reverse() + '\n');


int percentage = -10;

if (percentage.NumberIsBetweenRange(0 , 100))
    Console.WriteLine("Percentage is valid");
else
    Console.WriteLine("Invalid Percentage");







Console.ReadKey();


