using CSharpAdvanceHomeworkFive.Domain.Enums;
using CSharpAdvanceHomeworkFive.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Services.Interfaces
{
   public interface IStatisticsServices 
    {
        void TotalTimePerActivity<T>(List<T> activities, ActivityEnum activityType) where T : ActivityTrack;
        public void TotalTimeGlobal(List<ReadingActivity> readings, List<ExercisingActivity> exercises, List<WorkingActivity> workings, List<Other> hobbies);
        void AverageMinutes<T>(List<T> activities, ActivityEnum activityType) where T: ActivityTrack;
        void FavouriteActivity(List<ReadingActivity> readings, List<ExercisingActivity> exercises, List<WorkingActivity> workings, List<Other> hobbiess);
        void FavouriteReadingActivity(List<ReadingActivity> readings);
        void FavouriteExerciseActivity(List<ExercisingActivity> exercices);
        void FavouriteWorkingActivity(List<WorkingActivity> workings);
        void TotalNumberOfPages(List<ReadingActivity> activities);
        void ListOfAllHobbies(List<Other> activities);
    }
}
