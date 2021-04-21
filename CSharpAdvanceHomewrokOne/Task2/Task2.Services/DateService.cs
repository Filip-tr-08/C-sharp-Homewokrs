using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2.Services
{
    public class DateService
    {
        public static IEnumerable<List<DateTime?>> DateLists()
        {
            DateTime firstDate = new DateTime(1999, 1, 1);
            DateTime now = DateTime.Now;
            var allDates = Enumerable
     .Range(0, int.MaxValue)
     .Select(index => new DateTime?(firstDate.AddDays(index)))
     .TakeWhile(date => date <= now)
     .ToList();
            var weekends = allDates.Where(d => d.Value.DayOfWeek.ToString() == "Saturday" || d.Value.DayOfWeek.ToString() == "Sunday").ToList();
            var holydays = allDates.Where(d => d.Value.Day == 1 && d.Value.Month == 1 || d.Value.Day == 7 && d.Value.Month == 1 || d.Value.Day == 1 && d.Value.Month == 5 || d.Value.Day == 25 && d.Value.Month == 5 || d.Value.Day == 3 && d.Value.Month == 8 || d.Value.Day == 8 && d.Value.Month == 9 || d.Value.Day == 12 && d.Value.Month == 10 || d.Value.Day == 23 && d.Value.Month == 10 || d.Value.Day == 8 && d.Value.Month == 12).ToList();
            yield return weekends;
            yield return holydays;
        }
    }
}
