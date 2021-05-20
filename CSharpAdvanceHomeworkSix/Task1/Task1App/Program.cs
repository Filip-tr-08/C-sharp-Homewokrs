using System;
using System.IO;

namespace Task1App
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Exercise";
            string filePath = folderPath + @"\calculations.txt";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine("Directory created");
            }
           
                WriteReadInFile(filePath);
            Console.ReadLine();
        }
        public static string Calculator (double number1,double number2)
        {
            return $"{number1}+{number2}={number1 + number2}";
        }
        public static double InputNumber(string numOrder)
        {
            bool validNum = false;
            double number=0;
            do 
            {
                Console.WriteLine($"Enter the {numOrder} number:");
                validNum = double.TryParse(Console.ReadLine(), out number);
                if (!validNum)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter a number!!!");
                    Console.ResetColor();
                }
            }while (!validNum) ;
            return number;
        }
        public static void WriteReadInFile(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{Calculator(InputNumber("first"), InputNumber("second"))} {DateTime.Now}");
            }
            using (StreamReader sr = new StreamReader(filePath))
            {
                string result = sr.ReadToEnd();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(result);
                Console.ResetColor();
            }
        }
    }
}
