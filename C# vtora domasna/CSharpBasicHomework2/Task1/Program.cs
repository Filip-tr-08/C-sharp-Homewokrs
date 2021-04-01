using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i,number=0,result=0;
            int[] numbers = new int[6];
            for (i = 0; i <= numbers.Length-1; i++)
            {
                Console.WriteLine($"Input number {i+1}:");
                int.TryParse(Console.ReadLine(), out number);
                if (number != 0)
                {
                    numbers[i] = number;
                }
                else {
                    Console.WriteLine("ERROR");
                    continue;
                }
            }
            for (i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 0)
                {
                    continue;
                }
               if (numbers[i] % 2 == 0)
                {
                    result += numbers[i];
                }
              
                }
            if (result != 0)
            {
                Console.WriteLine($"The result is: {result}");
            }
            else
            {
                Console.WriteLine("There aren't any even numbers!!");
            }
            Console.ReadLine();
        }
    }
}
