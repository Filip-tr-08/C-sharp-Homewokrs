using System;

namespace Task4
{
    class Program
    {
        #region The Main method
        static void Main(string[] args)
        {
            Console.WriteLine("Enter operator");
            string operand= Console.ReadLine();
            Console.WriteLine("Enter first number");
            bool success1 = int.TryParse(Console.ReadLine(), out int num1);
            Console.WriteLine("Enter second number");
            bool success2 = int.TryParse(Console.ReadLine(), out int num2);
            if (success1 && success2)
            {
                double result = Calculator(operand, num1, num2);
                if (result != 0)
                {
                    Console.WriteLine($"The result is {result}");
                }
                else
                {
                    Console.WriteLine("You have entered invalid operand or for division you have entered 0!!");
                }
            }
            else
            {
                Console.WriteLine("Invalid number(s)");
            }
            Console.ReadLine();
        }
        #endregion
        #region Here is the Calculator method 
        static double Calculator(string operand, int number1, int number2)
        {
            if (operand == "+")
            {
                return Sum(number1, number2);
            }
            else if(operand=="-")
            {
                return Sub(number1,number2);
            }
            else if (operand == "*")
            {
                return Mul(number1, number2);
            }
            else if (operand == "/")
            {
                return Div(number1, number2);

            }
            else
            {
                return 0;
            }
            

           }
        #endregion
        #region Here are the methods for different operations
        static int Sum(int number1, int number2)
        {
            return number1 + number2;
        }
        static int Sub(int number1, int number2)
        {
            return number1 - number2;
        }
        static int Mul(int number1, int number2)
        {
            return number1 * number2;
        }
        static double Div(int number1, int number2)
        {
            if (number1 == 0 || number2 == 0)
            {
                return 0;
            }
            else
            {
                return number1 / (double)number2;
            }
        }
        #endregion
    }
}
