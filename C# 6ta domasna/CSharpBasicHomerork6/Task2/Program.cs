using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(12);
            numbers.Add(25);
            numbers.Add(3);
            numbers.Add(9);
            numbers.Add(6);
            numbers.Add(17);
            numbers.Add(8);
            numbers.Add(23);
            numbers.Add(31);

            List<int> newNumbers = (numbers.Select(n => n * n)).ToList();
            foreach(int number in newNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
