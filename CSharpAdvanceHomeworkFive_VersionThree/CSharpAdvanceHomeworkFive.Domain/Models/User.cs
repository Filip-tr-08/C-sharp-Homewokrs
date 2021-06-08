using CSharpAdvanceHomeworkFive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Domain.Models
{
    public class User : BaseEntity
    {
        public List<ReadingActivity> listOfReadingActivities { get; set; }
        public List<ExercisingActivity> listOfExerciseActivities { get; set; }
        public List<WorkingActivity> listOfWorkingActivities { get; set; }
        public List<Other> listOfOtherActivities { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserStatus userStatus { get; set; }
        public User(string firstName, string lastName, int age, string userName, string password)
        {
            userStatus = UserStatus.Active;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            UserName = userName;
            Password = password;
            listOfReadingActivities = new List<ReadingActivity>();
            listOfExerciseActivities = new List<ExercisingActivity>();
            listOfWorkingActivities = new List<WorkingActivity>();
            listOfOtherActivities = new List<Other>();
        }

        public override string GetInfo()
        {
            string result = ($"First name: {FirstName} Last name: {LastName} Age: {Age} Username: {UserName} Password: {Password}");
            return result;
        }
    }
}
