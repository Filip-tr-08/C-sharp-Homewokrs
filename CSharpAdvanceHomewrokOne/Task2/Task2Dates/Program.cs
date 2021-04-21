using System;
using System.Linq;

namespace Task2Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Geting the dates
            DateTime firstDate = new DateTime(1999, 1, 1);
            DateTime now = DateTime.Now;
            var allDates = Enumerable
     .Range(0, int.MaxValue)
     .Select(i => new DateTime?(firstDate.AddDays(i)))
     .TakeWhile(d => d <= now)
     .ToList();
            var weekends = allDates.Where(d => d.Value.DayOfWeek.ToString() == "Saturday" || d.Value.DayOfWeek.ToString() == "Sunday").ToList();
            var holydays = allDates.Where(d => d.Value.Day == 1 && d.Value.Month == 1 || d.Value.Day==7 && d.Value.Month==1 || d.Value.Day == 1 && d.Value.Month == 5 || d.Value.Day == 25 && d.Value.Month == 5 || d.Value.Day == 3 && d.Value.Month == 8 || d.Value.Day == 8 && d.Value.Month == 9 ||  d.Value.Day == 12 && d.Value.Month == 10 || d.Value.Day == 23 && d.Value.Month == 10 || d.Value.Day == 8 && d.Value.Month == 12).ToList();
            #endregion
            string result = String.Empty;
            bool again = true;
            while (again)
            {
                try { 
                Console.WriteLine("Choose a date");
                string userDate = String.Empty;
                string[] strings = new string[] { "month", "day", "year" };
                for (int i = 0; i < strings.Length; i++)
                {
             
                    Console.WriteLine($"Enter the {strings[i]}");
                    string date = Console.ReadLine();
                    bool success = int.TryParse(date, out int parsedDate);
                    if (success && parsedDate > 0)
                    {
                        if (i != strings.Length - 1)
                        {
                            userDate += date + "-";
                        }
                        else
                        {
                            userDate += date;
                        }
                    }
                    else
                    {
                            Console.Clear();

                            throw new Exception($"Invalid {strings[i]}");
                    }
                }
                DateTime convertedDate = DateTime.Parse(userDate);
                if (weekends.Contains(convertedDate) || holydays.Contains(convertedDate))
                {
                        result = String.Format("{0:dd MMMM yyyy - dddd} is not a working day", convertedDate);  
                    
                        if(weekends.Contains(convertedDate) && holydays.Contains(convertedDate))
                        {
                            result+=(" because it is a weekend and a holyday");
                        }
                        else if (weekends.Contains(convertedDate) && !holydays.Contains(convertedDate))
                        {
                           result+=(" because it is weekend");
                        }
                        else if(holydays.Contains(convertedDate) && !weekends.Contains(convertedDate))
                        {
                            result+=(" because it is a holyday");
                        }
                        Console.WriteLine(result);
                    }
                    else
                    {
                        result = String.Format("{0:dd MMMM yyyy - dddd} is a working day", convertedDate);
                        Console.WriteLine(result);
                    }
            }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Do you want to try another date (y/n):");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Okey have a nice day");
                    break;
                }
;            }
            Console.ReadLine();
        }
    }
}
