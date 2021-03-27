using System;

namespace CSharpBasicHomework1_Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int parsedNum1, parsedNum2, operation,number1,number2;
            Console.WriteLine("Enter the first number:");
            string num1 = Console.ReadLine();
            Console.WriteLine("Enter the second number:");
            string num2 = Console.ReadLine();

            bool n1Success = int.TryParse(num1, out parsedNum1);
            bool n2Success = int.TryParse(num2, out parsedNum2);

            if(n1Success && n2Success)
            {
                number1 = parsedNum1 % 2;
                number2 = parsedNum2 % 2;
                if(number1==0 && number2 == 0)
                {
                    operation = parsedNum1 + parsedNum2;
                    Console.WriteLine($"The two numbers are even. The operation and result are {parsedNum1} + {parsedNum2} = {operation}");

                }
                else if(number1!=0 ^ number2 != 0)
                {
                    operation = parsedNum1 - parsedNum2;
                    Console.WriteLine($"One of the numbers is odd. The operation and result are {parsedNum1} - {parsedNum2} = {operation}");
                }
                else if(number1 != 0 && number2 != 0)
                {
                    operation = parsedNum1 * parsedNum2;
                    Console.WriteLine($"The two numbers are odd. The operation and result are {parsedNum1} * {parsedNum2} = {operation}");
                }
                else
                {
                    Console.WriteLine("Something is wrong!");
                }
            }
            else
            {
                Console.WriteLine("One or two of the numbers can't be parsed!!!");
            }


        }
   

    }
}
