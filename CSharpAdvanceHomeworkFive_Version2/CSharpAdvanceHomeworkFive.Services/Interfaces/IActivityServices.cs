using CSharpAdvanceHomeworkFive.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Services.Interfaces
{
    public interface IActivityServices<T>where T:ActivityTrack
    {
        public T FindActivityById(int id);
        void PrintActivities();
        public void AddActivity(T activity);
        public T StopwatchForActivity(T activity);
    }
}
