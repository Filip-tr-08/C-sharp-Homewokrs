using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = new List<double>();
           for(int i = 0; i < 10; i++)
            {
                startAgain:
               
                Console.WriteLine("Enter a number!");
                bool success = double.TryParse(Console.ReadLine(), out double number);
                if (success)
                {
                    numbers.Add(number);
                }
                else {
                    Console.WriteLine("Wrong input try again");
                    goto startAgain;
                    
                }
            }

            List<double> newNumbers = (numbers.Select(n => n * n)).ToList();
            foreach(int number in newNumbers)
            {
                Console.Write($" {number}");
            }
        }
    }
}
