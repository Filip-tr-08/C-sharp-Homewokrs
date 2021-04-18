using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<double> numbers = new List<double>();
           for(int i = 0; i < 10; i++)
            {
                double x = 0;
                x = Math.Round(rand.NextDouble()*100,2);
                Console.WriteLine(x);
                numbers.Add(x);
            }

            List<double> newNumbers = (numbers.Select(n => Math.Round(Math.Pow(n,2.0),2))).ToList();
            foreach(double number in newNumbers)
            {
                Console.Write($" {number}");
            }
        }
    }
}
