using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            Console.WriteLine("Enter a number");
            string number = Console.ReadLine();
            char[] numArray = number.ToCharArray();
            foreach(char digit in numArray)
            {
               bool success=int.TryParse(digit.ToString(), out int dig);
                if (success)
                {
                    result += dig;

                }

                else{
                    Console.WriteLine($"{digit} is not a digit");
                    continue;
                }
            }
            Console.WriteLine($"The result is: {result}");
            Console.ReadLine();
        }
    }
}
