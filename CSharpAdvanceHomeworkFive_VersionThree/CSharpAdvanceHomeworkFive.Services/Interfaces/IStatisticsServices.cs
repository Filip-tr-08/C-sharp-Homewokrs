using CSharpAdvanceHomeworkFive.Domain.Enums;
using CSharpAdvanceHomeworkFive.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Services.Interfaces
{
   public interface IStatisticsServices
    {
        void TotalTimePerActivity(List<ActivityTrack> activities, ActivityEnum activityType);
        void TotalTimeGlobal(List<ActivityTrack> activities);
        void AverageMinutes(List<ActivityTrack> activities, ActivityEnum activityType);
        void FavouriteActivity(List<ActivityTrack> activities);
        void FavouriteActivityPerActivity(List<ActivityTrack> activities, ActivityEnum type);
        void TotalNumberOfPages(List<ActivityTrack> activities);
        void ListOfAllHobbies(List<ActivityTrack> activities);
    }
}
