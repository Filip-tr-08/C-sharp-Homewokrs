using CSharpAdvanceHomeworkFive.Domain.Enums;
using CSharpAdvanceHomeworkFive.Domain.Models;
using CSharpAdvanceHomeworkFive.Services.Helpers;
using CSharpAdvanceHomeworkFive.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Services.Implementations
{
    public class StatisticsServices : IStatisticsServices 
    {
        public void TotalTimePerActivity<T> (List<T> activities, ActivityEnum activityType) where T:ActivityTrack
        {
            if (activities.Where(x => x.Activity == activityType).ToList().Count != 0)
            {
                double time = activities.Where(x => x.Activity == activityType).ToList().Sum(x => x.Time);
                time = Math.Round(time / 60, 0);
                MessageHelper.PrintMessage($"Total time spent for {activityType}: {time} hours", ConsoleColor.Green);
            }
            else
            {
                MessageHelper.PrintMessage($"There are not any {activityType} activities", ConsoleColor.Red);
            }
        }
        public void TotalTimeGlobal(List<ReadingActivity> readings, List<ExercisingActivity> exercises, List<WorkingActivity> workings,List<Other> hobbies)
        {
            if (readings.Count != 0 || exercises.Count!=0 || workings.Count!=0||hobbies.Count!=0)
            {
                double readingTime = readings.Sum(x => x.Time);
                double exerciseTime = exercises.Sum(x => x.Time);
                double workingTime = workings.Sum(x => x.Time);
                double hobbiesTime = hobbies.Sum(x => x.Time);
                double time = readingTime + exerciseTime + workingTime + hobbiesTime;
                time = Math.Round(time / 60, 2);
                MessageHelper.PrintMessage($"The total time is: {time} hours", ConsoleColor.Green);
            }
            else
            {
                MessageHelper.PrintMessage("There are not any activities", ConsoleColor.Red);
            }
        }
        public void AverageMinutes<T>(List<T> activities, ActivityEnum activityType) where T : ActivityTrack
        {
            if (activities.Where(x => x.Activity == activityType).ToList().Count != 0)
            {
                double totalTime = activities.Where(x => x.Activity == activityType).ToList().Sum(x => x.Time);
                int numOfActivites = activities.Where(x => x.Activity == activityType).ToList().Count();
                double averageTime = Math.Round(totalTime / numOfActivites, 0);
                MessageHelper.PrintMessage($"Average time spent for {activityType}: {averageTime} minutes", ConsoleColor.Green);
            }
            else
            {
                Console.Write("");
            }
        }
        public void FavouriteActivity(List<ReadingActivity> readings, List<ExercisingActivity> exercises, List<WorkingActivity> workings, List<Other> hobbies)
        {
            if (readings.Count != 0 || exercises.Count != 0 || workings.Count != 0 || hobbies.Count != 0)
            { 
                List<int> counts = new List<int>
                {
                    readings.Count,workings.Count,exercises.Count,hobbies.Count
                };
                int greatestCount = counts.OrderByDescending(x => x).FirstOrDefault();
                ActivityEnum ?activity = null;
                if (greatestCount == readings.Count)
                {
                    activity = ActivityEnum.Reading;
                }
                else if (greatestCount == exercises.Count)
                {
                    activity = ActivityEnum.Exercising;
                }
                else if (greatestCount == workings.Count)
                {
                    activity = ActivityEnum.Working;
                }
                else
                {
                    activity = ActivityEnum.Other;
                }
                MessageHelper.PrintMessage($"Your favourite activity is : {activity}", ConsoleColor.Green);
            }
            else
            {
                Console.Write("");
            }
        }
        public void TotalNumberOfPages(List<ReadingActivity> activities)
        {     
            if (activities.Where(x => x.Activity == ActivityEnum.Reading).Count() != 0)
            {
                int totalPages = activities.Where(x => x.Activity == ActivityEnum.Reading).Sum(x => (x.Pages));
                MessageHelper.PrintMessage($"Total read pages is {totalPages}", ConsoleColor.Green);
            }
            else
            {
                Console.Write("");
            }
        }

        public void ListOfAllHobbies(List<Other> activities)
        {

            List<string> hobbies = activities.Where(x => x.Activity == ActivityEnum.Other).Select(x => $"{x.Name}").Distinct().ToList();
            if (hobbies.Count != 0) { 
                MessageHelper.PrintMessage("Your hobbies:", ConsoleColor.Green);
                foreach (string hobby in hobbies)
                {
                    MessageHelper.PrintMessage($"{hobby}", ConsoleColor.Green);
                }
            }
            else
            {
                Console.Write("");
            }
        }

        public void FavouriteReadingActivity(List<ReadingActivity> readings)
        {
            if (readings.Count != 0)
              {
                List<ReadingActivity> bellesLetres = readings.Where(x => x.Type == Reading.Belles_Lettres).ToList();
                List<ReadingActivity> fictions = readings.Where(x => x.Type == Reading.Fiction).ToList();
                List<ReadingActivity> proLiterature = readings.Where(x => x.Type == Reading.Professional_Literature).ToList();

                List<List<ReadingActivity>> readingCounts = new List<List<ReadingActivity>>
                        {
                            bellesLetres,fictions,proLiterature
                        };
                Reading reading = readingCounts.OrderByDescending(x => x.Count()).FirstOrDefault().Select(x => x.Type).ToList().FirstOrDefault();
                MessageHelper.PrintMessage($"Your favourite activity is : {reading}", ConsoleColor.Green);
            }
            else
            {
                Console.Write("");
            }
        }
     public void FavouriteExerciseActivity(List<ExercisingActivity> exercises)
        {
            if (exercises.Count != 0)
            {
                List<ExercisingActivity> generals = exercises.Where(x => x.Type == Exercise.General).ToList();
                List<ExercisingActivity> runnings = exercises.Where(x => x.Type == Exercise.Running).ToList();
                List<ExercisingActivity> sports = exercises.Where(x => x.Type == Exercise.Sport).ToList();

                List<List<ExercisingActivity>> exercisingCounts = new List<List<ExercisingActivity>>
                        {
                            generals,runnings,sports
                        };
                Exercise exercising = exercisingCounts.OrderByDescending(x => x.Count()).FirstOrDefault().Select(x => x.Type).ToList().FirstOrDefault();
                MessageHelper.PrintMessage($"Your favourite activity is : {exercising}", ConsoleColor.Green);
            }
            else
            {
                Console.Write("");
            }
          }
        public void FavouriteWorkingActivity(List<WorkingActivity> workings)
        {
            if (workings.Count != 0)
            {
                List<WorkingActivity> home = workings.Where(x => x.Type == Working.Home).ToList();
                List<WorkingActivity> office = workings.Where(x => x.Type == Working.Office).ToList();
                List<List<WorkingActivity>> workingCounts = new List<List<WorkingActivity>>
                {
                    home,office
                };
                Working working = workingCounts.OrderByDescending(x => x.Count()).FirstOrDefault().Select(x => x.Type).ToList().FirstOrDefault();
                MessageHelper.PrintMessage($"You want more to work from {working}", ConsoleColor.Green);
            }
            else
            {
                Console.Write("");
            }
        }
    }
}
