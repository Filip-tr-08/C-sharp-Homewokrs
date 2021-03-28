using System;

namespace CSharpBasicHomework1_Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            int parsedNumber;
            Console.WriteLine("Choose a number (1,2 or 3):");
            string number = Console.ReadLine();
            bool Success = int.TryParse(number, out parsedNumber);
            if (Success)
            {
                switch (parsedNumber)
                {
                    case 1: Console.WriteLine("You got a new car!");
                        break;
                    case 2: Console.WriteLine("You got a new plane!");
                        break;
                    case 3:Console.WriteLine("You got a new bike!");
                        break;
                    default:Console.WriteLine("ERROR!! You entered number that is not 1,2 or 3");
                        break;
                } 
            }
            else
            {
                Console.WriteLine("The string can't be parsed!");
            }
            Console.ReadLine();
        }
    }
}
