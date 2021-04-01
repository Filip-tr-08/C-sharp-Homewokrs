using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, number, maximum = int.MinValue, minimum = int.MaxValue;
            int[] numbers = new int[10];
            for (i = 0; i <= numbers.Length - 1; i++)
            {
                Console.WriteLine($"Input number {i + 1}:");
                bool success=int.TryParse(Console.ReadLine(), out number);
                if (success)
                {
                    numbers[i] = number;
                }
                else
                {
                    Console.WriteLine("ERROR");
                    continue;
                }
            }
            for (i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > maximum)
                {
                    maximum = numbers[i];
                }
                if (numbers[i] < minimum)
                {
                    minimum = numbers[i];
                }
            }
            Console.WriteLine($"The minumum number is :{minimum} and the maximum number is:{maximum}");
            Console.ReadLine();
        }
    }
}
