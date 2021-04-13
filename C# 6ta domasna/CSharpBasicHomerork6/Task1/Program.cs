using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> numbers = new Queue<int>();
            Console.WriteLine("Enter N:");
            bool success = int.TryParse(Console.ReadLine(), out int n);
            if (success)
            {
                for(int i = 0; i < n; i++)
                {
                    startAgain:
                    Console.WriteLine($"Enter the {i+1} number");
                    bool success2 = int.TryParse(Console.ReadLine(), out int number);
                    if (success2)
                    {
                        numbers.Enqueue(number);
                    }
                    else
                    {
                        Console.WriteLine("Wrong input");
                        goto startAgain;
                    }

                }
                Console.Write("The queue is: ");
                foreach(var number in numbers)
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
