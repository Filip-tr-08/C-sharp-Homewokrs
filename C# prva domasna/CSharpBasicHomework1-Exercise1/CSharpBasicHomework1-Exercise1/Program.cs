using System;

namespace CSharpBasicHomework1_Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number:");
            string num1 = Console.ReadLine();
            Console.WriteLine("Enter the second number:");
            string num2 = Console.ReadLine();
            Console.WriteLine("Enter the operation:");
            string operation = Console.ReadLine();
            int num1Parsed;
            int num2Parsed;
            bool firstSuccess = int.TryParse(num1, out num1Parsed);
            bool secondSuccess = int.TryParse(num2, out num2Parsed);
            if(firstSuccess && secondSuccess)
            {
                DisplayResult(num1Parsed, num2Parsed, operation);
                
            }
            else
            {
                Console.WriteLine("You have entered string that cannot be parsed!");
            }
            Console.ReadLine();
        }
        private static void DisplayResult(int number1, int number2, string operation)
        {
            int result;
            if (operation == "+")
            {
                result = number1 + number2;
                Console.WriteLine($"The result is {result}");
            }
            else if(operation == "-")
            {
                result = number1 - number2;
                Console.WriteLine($"The result is {result}");
              }
            else if (operation == "*")
            {
                result = number1 * number2;
                Console.WriteLine($"The result is {result}");
            }
            else if (operation == "/")
            {
                result = number1 / number2;
                Console.WriteLine($"The result is {result}");
            }
            else
            {
                Console.WriteLine("ERROR, wrong opeation!!!");
            }
        }
    }
    
}

