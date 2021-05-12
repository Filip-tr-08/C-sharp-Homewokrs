using CSharpAdvanceHomeworkFive.Domain.Database;
using CSharpAdvanceHomeworkFive.Domain.Enums;
using CSharpAdvanceHomeworkFive.Domain.Models;
using CSharpAdvanceHomeworkFive.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Services.Implementations
{
   public class ActivityServices<T> : IActivityServices<T> where T : ActivityTrack
    {
        private GenericDB<T> _activities { get; set; }
        public ActivityServices()
        {
            _activities = new GenericDB<T>();
        }
        public T FindActivityById(int id)
        {
            T activity=_activities.GetById(id);
            return activity;
        }
        public void PrintActivities()
        {

            List<T> activities = _activities.GetAll();
            foreach (T activity in activities)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{activity.Id}) {activity.GetInfo()}");
                Console.ResetColor();
            }
        }
        public void AddActivity(T activity)
        {
            _activities.Insert(activity);
        }
        public T StopwatchForActivity(T activity)
        {
            Stopwatch watch = new Stopwatch();
            Console.WriteLine("Starting activity");
            watch.Start();
            Console.WriteLine("Press enter if you want to stop activity");
            Console.ReadLine();
            watch.Stop();
            Console.WriteLine("Activity stoped");
            activity.Time = Math.Round(watch.Elapsed.TotalMinutes,0);
            return activity;
        }
    }
}
