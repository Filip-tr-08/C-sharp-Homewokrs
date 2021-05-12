using CSharpAdvanceHomeworkFive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Domain.Models
{
    public class User : BaseEntity
    {
        public List<ActivityTrack> listOfActivities { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public User(string firstName, string lastName, int age, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            UserName = userName;
            Password = password;
            listOfActivities = new List<ActivityTrack>();
        }

        public override string GetInfo()
        {
            string result = ($"First name: {FirstName} Last name: {LastName} Age: {Age} Username: {UserName} Password: {Password}");
            return result;
        }
        public void PrintUserActivities()
        {
            listOfActivities.OrderByDescending(x => x.Time);
            foreach(ActivityTrack activity in listOfActivities)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(activity.GetInfo());
                Console.ResetColor();
            }
        }
    }
}
