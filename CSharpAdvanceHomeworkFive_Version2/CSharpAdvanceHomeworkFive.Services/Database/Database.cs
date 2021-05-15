using CSharpAdvanceHomeworkFive.Domain.Enums;
using CSharpAdvanceHomeworkFive.Domain.Models;
using CSharpAdvanceHomeworkFive.Services.Implementations;
using CSharpAdvanceHomeworkFive.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Services.Database
{
    public static class Database
    {
        public static IActivityServices<ReadingActivity> _readingService = new ActivityServices<ReadingActivity>();
        public static IActivityServices<WorkingActivity> _workingService = new ActivityServices<WorkingActivity>();
        public static IActivityServices<Other> _otherActivityService = new ActivityServices<Other>();
        public static IActivityServices<ExercisingActivity> _exercisingService = new ActivityServices<ExercisingActivity>();

        public static IUserServices<User> _userService = new UserServices<User>();

        static Database()
        {
            _userService.AddUser(new User("Filip", "Trajanovski", 25, "ftrajanovski", "Fil1996"));
            _userService.AddUser(new User("Ivana", "Angelovska", 23, "iangelovska", "Ivana1997"));
            _userService.AddUser(new User("user3", "three", 30, "userthree", "User2000"));

            _readingService.AddActivity(new ReadingActivity(140, Reading.Professional_Literature));
            _readingService.AddActivity(new ReadingActivity(230, Reading.Fiction));
            _readingService.AddActivity(new ReadingActivity(200, Reading.Belles_Lettres));

            _workingService.AddActivity(new WorkingActivity(Working.Home));
            _workingService.AddActivity(new WorkingActivity(Working.Office));

            _otherActivityService.AddActivity(new Other("Swimming"));
            _otherActivityService.AddActivity(new Other("Playing video games"));
            _otherActivityService.AddActivity(new Other("Eating"));

            _exercisingService.AddActivity(new ExercisingActivity(Exercise.General));
            _exercisingService.AddActivity(new ExercisingActivity(Exercise.Running));
            _exercisingService.AddActivity(new ExercisingActivity(Exercise.Sport));

        }  
        }
}
