using System;

namespace CSharpBasicHomework1_Exercise2
{
    class Program
    {
      
            static void Main(string[] args)
            {
                string number;
                int parsedNumber;
                int result = 0;
                string parsedNumbers = "";
                string[] numerations = { "First", "Second", "Third", "Forth" };
                for (int i = 0; i < numerations.Length; i++)
                {
                    Console.WriteLine($"Write the {numerations[i]} number");
                    number = Console.ReadLine();
                    bool Success = int.TryParse(number, out parsedNumber);
                    if (Success && parsedNumber >= 0)
                    {
                        result += parsedNumber;
                        if (numerations[i] == "Forth")
                        {
                            parsedNumbers += number;
                        }
                        else
                        {
                            parsedNumbers += number + ", ";
                        }
                    }
                    else
                    {
                        Console.WriteLine("The string can't be parsed or your number is negative");
                    }
                }


                double average = result / (double)numerations.Length;
                Console.WriteLine($"The average of {parsedNumbers} is {average}");
            }
        }
    }




