using System;

namespace CSharpBasicHomework1_Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number:");
            string num1 = Console.ReadLine();
            int parsedNumber1, parsedNumber2, temp;
            Console.WriteLine("Enter the second number:");
            string num2 = Console.ReadLine();

            bool n1Success = int.TryParse(num1, out parsedNumber1);
            bool n2Success = int.TryParse(num2, out parsedNumber2);
            if (n1Success && n2Success)
            {
                temp = parsedNumber1;
                parsedNumber1 = parsedNumber2;
                parsedNumber2 = temp;
                Console.WriteLine($"After swaping the numbers are : first number={parsedNumber1} and second number={parsedNumber2} ");
            }
            else
            {
                Console.WriteLine("ERROR");
            }
            Console.ReadLine();
        }
    }
}
