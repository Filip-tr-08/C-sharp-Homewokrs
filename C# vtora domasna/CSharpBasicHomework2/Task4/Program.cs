using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, number = 0,size=0,counter=0;
            Console.WriteLine("Enter the size of the Array");
            int.TryParse(Console.ReadLine(), out size);
            if (size != 0)
            {
                int[] numbers = new int[size];
                for (i = 0; i <= numbers.Length - 1; i++)
                {
                    Console.WriteLine($"Input number {i + 1}:");
                    int.TryParse(Console.ReadLine(), out number);
                    if (number != 0)
                    {
                        numbers[i] = number;
                    }
                    else
                    {
                        Console.WriteLine("ERROR");
                        break;
                    }
                }
                for (i = 1; i < numbers.Length; i++)
                {
                    if(numbers[i]==3 && numbers[i - 1] == 3)
                    {
                        counter++;
                    }
                }
                Console.WriteLine($"There are {counter} times threes next to each other");
            }


            else
            {
                Console.WriteLine("You have entered wrong number of elements");
            }
            Console.ReadLine();
        }
    }
}
