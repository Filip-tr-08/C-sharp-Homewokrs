using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a string:");
            string someString = Console.ReadLine();
            char[] charsArray = someString.ToCharArray();
            Array.Reverse(charsArray);
            Console.WriteLine(String.Join("\n", charsArray));
            Console.ReadLine();
        }
    }
}
