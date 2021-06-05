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
        public void TotalTimePerActivity(List<ActivityTrack> activities, ActivityEnum activityType)
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
        public void TotalTimeGlobal(List<ActivityTrack> activities)
        {
            if (activities.Count != 0)
            {
                double time = activities.Sum(x => x.Time);
                time = Math.Round(time / 60, 2);
                MessageHelper.PrintMessage($"The total time is: {time} hours", ConsoleColor.Green);
            }
            else
            {
                MessageHelper.PrintMessage("There are not any activities", ConsoleColor.Red);
            }
        }
        public void AverageMinutes(List<ActivityTrack> activities, ActivityEnum activityType)
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
        public void FavouriteActivity(List<ActivityTrack> activities)
        {
            if (activities.Count != 0)
            {
                List<ActivityTrack> numOfReadings = activities.Where(x => x.Activity == ActivityEnum.Reading).ToList();
                List<ActivityTrack> numOfExercising = activities.Where(x => x.Activity == ActivityEnum.Exercising).ToList();
                List<ActivityTrack> numOfWorking = activities.Where(x => x.Activity == ActivityEnum.Working).ToList();
                List<ActivityTrack> numOfOther = activities.Where(x => x.Activity == ActivityEnum.Other).ToList();
                List<List<ActivityTrack>> counts = new List<List<ActivityTrack>>
                {
                    numOfReadings,numOfWorking,numOfExercising,numOfOther
                };
                ActivityEnum activity = counts.OrderByDescending(x => x.Count()).FirstOrDefault().Select(x => x.Activity).ToList().FirstOrDefault();
                MessageHelper.PrintMessage($"Your favourite activity is : {activity}", ConsoleColor.Green);
            }
            else
            {
                Console.Write("");
            }
        }
        public void TotalNumberOfPages(List<ActivityTrack> activities)
        {     
            if (activities.Where(x => x.Activity == ActivityEnum.Reading).Count() != 0)
            {
                int totalPages = activities.Where(x => x.Activity == ActivityEnum.Reading).Sum(x => ((ReadingActivity)x).Pages);
                MessageHelper.PrintMessage($"Total read pages is {totalPages}", ConsoleColor.Green);
            }
            else
            {
                Console.Write("");
            }
        }

        public void ListOfAllHobbies(List<ActivityTrack> activities)
        {

            List<string> hobbies = activities.Where(x => x.Activity == ActivityEnum.Other).Select(x => $"{((Other)x).Name}").Distinct().ToList();
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
        public void FavouriteActivityPerActivity(List<ActivityTrack> activities, ActivityEnum type)
        {
            if (type == ActivityEnum.Reading)
            {

                List<ActivityTrack> readingActivity = activities.Where(x => x.Activity == ActivityEnum.Reading).ToList();
                List<ReadingActivity> readings = new List<ReadingActivity>();
                foreach (ActivityTrack activ in readingActivity)
                {
                    object obj = activ;
                    readings.Add((ReadingActivity)activ);
                }
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
            if (type == ActivityEnum.Exercising)
            {

                List<ActivityTrack> exercisingActivity = activities.Where(x => x.Activity == ActivityEnum.Exercising).ToList();
                List<ExercisingActivity> exercisings = new List<ExercisingActivity>();
                foreach (ActivityTrack activ in exercisingActivity)
                {
                    object obj = activ;
                    exercisings.Add((ExercisingActivity)activ);
                }
                if (exercisings.Count != 0)
                {
                    List<ExercisingActivity> generals = exercisings.Where(x => x.Type == Exercise.General).ToList();
                    List<ExercisingActivity> runnings = exercisings.Where(x => x.Type == Exercise.Running).ToList();
                    List<ExercisingActivity> sports = exercisings.Where(x => x.Type == Exercise.Sport).ToList();

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
            if (type == ActivityEnum.Working)
            {
                List<ActivityTrack> workingActivity = activities.Where(x => x.Activity == ActivityEnum.Working).ToList();
                List<WorkingActivity> workings = new List<WorkingActivity>();
                foreach (ActivityTrack activ in workingActivity)
                {
                    object obj = activ;
                    workings.Add((WorkingActivity)activ);
                }
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
}
