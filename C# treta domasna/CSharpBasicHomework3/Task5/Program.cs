using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write your birthday:");
            
            string bDay = "";
            string[] strings = new string []{"month","day","year"};
           for(int i = 0; i < strings.Length; i++)
            {
                startAgain:
                Console.WriteLine($"Enter the {strings[i]}");
                string date = Console.ReadLine();
                bool success = int.TryParse(date, out int parsedDate);
                if (success)
                {
                    if (i != strings.Length - 1)
                    {
                        bDay += date + "-";
                    }
                    else
                    {
                        bDay += date;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    goto startAgain;
                }
            }

            Console.WriteLine(bDay);
            string myBirthday = "01-08-1996";
            AgeCalculator(bDay);
            AgeCalculator(myBirthday);
            Console.ReadLine();
        }
        static void AgeCalculator(string birthDay)
        {
            DateTime convertedDate = DateTime.Parse(birthDay);
            DateTime currentDate = DateTime.Now;
            int resultYears = currentDate.Year - convertedDate.Year;
            int resultMonths = currentDate.Month - convertedDate.Month;
            int resultDays = currentDate.Day - convertedDate.Day;
            if (resultDays < 0)
            {
                resultDays += DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
                resultMonths--;
            }

            if (resultMonths < 0)
            {
                resultMonths += 12;
                resultYears--;
            }
            Console.WriteLine($"{resultYears} - {resultMonths} - {resultDays} {currentDate}");


        }
    }
}
