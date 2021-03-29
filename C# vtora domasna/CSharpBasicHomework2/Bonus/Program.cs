using System;

namespace Bonus
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, space, rows = 0, k, num = 1;
            Console.Write("input number of rows : ");
            int.TryParse(Console.ReadLine(), out rows);
            if (rows != 0)
            {
                space = rows + 1;
                for (i = 1; i <= rows; i++)
                {
                    for (k = space; k >= 1; k--)
                    {
                        Console.Write(" ");
                    }
                    for (j = 1; j <= i; j++)
                        Console.Write($"{num++} ");
                    Console.Write("\n");
                    space--;
                }
            }
            else
            {
                Console.WriteLine("Invalid number !!!");
            }
            Console.ReadLine();
        }
    }
}
