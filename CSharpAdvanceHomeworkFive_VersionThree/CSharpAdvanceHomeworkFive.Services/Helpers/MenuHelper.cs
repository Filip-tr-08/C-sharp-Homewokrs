using CSharpAdvanceHomeworkFive.Domain.Database;
using CSharpAdvanceHomeworkFive.Domain.Enums;
using CSharpAdvanceHomeworkFive.Domain.Models;
using CSharpAdvanceHomeworkFive.Services.Helpers;
using CSharpAdvanceHomeworkFive.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Services.Implementations
{

    public static class MenusHelper 

    {
        public static IUiService ui = new UiService();
        //public static IStatisticsServices<ReadingActivity> statisticsForReadings = new StatisticsServices<ReadingActivity>();
        //public static IStatisticsServices<ExercisingActivity> statisticsForExercices = new StatisticsServices<ExercisingActivity>();
        //public static IStatisticsServices<WorkingActivity> statisticsForWorkings = new StatisticsServices<WorkingActivity>();
        //public static IStatisticsServices<Other> statisticsForOtherActivities = new StatisticsServices<Other>();
        public static IStatisticsServices statistics = new StatisticsServices();
        public static void ReadingMenu(User currentUser)
        {
            bool readingMenu = true;
            while (readingMenu)
            {
               
                int readingChoice = ui.ActivityMenu();
                if (readingChoice != -1)
                {
                    switch (readingChoice)
                    {
                        case 1:
                            bool readingPredefined = true;
                            while (readingPredefined)
                            {
                                InitializatorHelper._readingService.PrintActivities();
                                bool predefinedReadingSuccess = int.TryParse(Console.ReadLine(), out int predefinedReadingChoice);
                                if (predefinedReadingSuccess)
                                {
                                    ReadingActivity predifinedReading = InitializatorHelper._readingService.FindActivityById(predefinedReadingChoice);
                                    if (predifinedReading != null)
                                    {
                                        predifinedReading = InitializatorHelper._readingService.StopwatchForActivity(predifinedReading);
                                        currentUser.listOfReadingActivities.Add(predifinedReading);
                                        InitializatorHelper._userService.UpdateListOfActivities(predifinedReading, currentUser.Id);
                                        readingPredefined = false;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    MessageHelper.PrintMessage("You must enter a number", ConsoleColor.Red);
                                }
                            }
                            break;
                        case 2:
                            ReadingActivity newReading = new ReadingActivity();
                            newReading = InitializatorHelper._readingService.StopwatchForActivity(newReading);
                            bool readingNewPagesBoolean = true;
                            while (readingNewPagesBoolean)
                            {
                                Console.WriteLine("Enter how many pages have you read");
                                bool validPages = int.TryParse(Console.ReadLine(), out int pages);
                                if (validPages && pages > 0)
                                {
                                    newReading.Pages = pages;
                                    readingNewPagesBoolean = false;
                                }
                                else
                                {
                                    Console.Clear();
                                    MessageHelper.PrintMessage("You must enter valid number", ConsoleColor.Red);
                                    readingNewPagesBoolean = true;
                                }
                            }
                            bool readingNewTypeBoolean = true;
                            while (readingNewTypeBoolean)
                            {
                                int validNewReadingChoice = ui.ReadingTypesMenu();
                                if (validNewReadingChoice != -1)
                                {
                                    switch (validNewReadingChoice)
                                    {
                                        case 1: newReading.Type = Reading.Belles_Lettres; readingNewTypeBoolean = false; break;
                                        case 2: newReading.Type = Reading.Fiction; readingNewTypeBoolean = false; break;
                                        case 3: newReading.Type = Reading.Professional_Literature; readingNewTypeBoolean = false; break;
                                        default:Console.Clear(); MessageHelper.PrintMessage("You must enter number between 1-3", ConsoleColor.Red); break;
                                    }

                                }
                                else
                                {
                                    Console.Clear();
                                    MessageHelper.PrintMessage("Invalid choice", ConsoleColor.Red);
                                    readingNewPagesBoolean = true;
                                }
                            }
                            currentUser.listOfReadingActivities.Add(newReading);
                            InitializatorHelper._userService.UpdateListOfActivities(newReading, currentUser.Id);
                            break;
                        case 3: Console.Clear(); readingMenu = false; break;
                        default: Console.Clear(); MessageHelper.PrintMessage("You must choose between 1-3", ConsoleColor.Red); break;
                    }
                }
                else
                {
                    Console.Clear();
                    MessageHelper.PrintMessage("You must enter a number", ConsoleColor.Red);
                }
            }
        }
        public static void ExerciseMenu(User currentUser)
        {
            bool exerciseMenu = true;
            while (exerciseMenu)
            {
                int exerciseChoice = ui.ActivityMenu();
                if (exerciseChoice != -1)
                {
                    switch (exerciseChoice)
                    {
                        case 1:
                            bool exercisePredefined = true;
                            while (exercisePredefined)
                            {
                                InitializatorHelper._exercisingService.PrintActivities();
                                bool predefinedExerciseSuccess = int.TryParse(Console.ReadLine(), out int predefinedExerciseChoice);
                                if (predefinedExerciseSuccess)
                                {
                                    ExercisingActivity predifinedExercise = InitializatorHelper._exercisingService.FindActivityById(predefinedExerciseChoice);
                                    if (predifinedExercise != null)
                                    {
                                        predifinedExercise = InitializatorHelper._exercisingService.StopwatchForActivity(predifinedExercise);
                                        currentUser.listOfExerciseActivities.Add(predifinedExercise);
                                        InitializatorHelper._userService.UpdateListOfActivities(predifinedExercise, currentUser.Id);
                                        exercisePredefined = false;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    MessageHelper.PrintMessage("You must enter a number", ConsoleColor.Red);
                                }
                            }
                            break;
                        case 2:
                            ExercisingActivity newExercise = new ExercisingActivity();
                            newExercise = InitializatorHelper._exercisingService.StopwatchForActivity(newExercise);
                            bool exerciseNewTypeBoolean = true;
                            while (exerciseNewTypeBoolean)
                            {
                                int validNewExerciseChoice = ui.ExerciseTypesMenu();
                                if (validNewExerciseChoice != -1)
                                {
                                    switch (validNewExerciseChoice)
                                    {
                                        case 1: newExercise.Type = Exercise.General; exerciseNewTypeBoolean = false; break;
                                        case 2: newExercise.Type = Exercise.Running; exerciseNewTypeBoolean = false; break;
                                        case 3: newExercise.Type = Exercise.Sport; exerciseNewTypeBoolean = false; break;
                                        default: Console.Clear(); MessageHelper.PrintMessage("You must enter number between 1-3", ConsoleColor.Red); break;
                                    }
                                }
                            }
                            currentUser.listOfExerciseActivities.Add(newExercise);
                            InitializatorHelper._userService.UpdateListOfActivities(newExercise, currentUser.Id);
                            break;
                        case 3: Console.Clear(); exerciseMenu = false; break;
                        default: Console.Clear(); MessageHelper.PrintMessage("You must choose between 1-3", ConsoleColor.Red); break;
                    }
                }
                else
                {
                    Console.Clear();
                    MessageHelper.PrintMessage("You must enter a number", ConsoleColor.Red);
                }
            }
        }
        public static void WorkingMenu(User currentUser)
        {
            bool workingMenu = true;
            while (workingMenu)
            {
                int workingChoice = ui.ActivityMenu();
                if (workingChoice != -1)
                {
                    switch (workingChoice)
                    {
                        case 1:
                            bool workingPredefined = true;
                            while (workingPredefined)
                            {
                                InitializatorHelper._workingService.PrintActivities();
                                bool predefinedWorkingSuccess = int.TryParse(Console.ReadLine(), out int predefinedWorkingChoice);
                                if (predefinedWorkingSuccess)
                                {
                                    WorkingActivity predifinedWorking = InitializatorHelper._workingService.FindActivityById(predefinedWorkingChoice);
                                    if (predifinedWorking != null)
                                    {
                                        predifinedWorking = InitializatorHelper._workingService.StopwatchForActivity(predifinedWorking);
                                        currentUser.listOfWorkingActivities.Add(predifinedWorking);
                                        InitializatorHelper._userService.UpdateListOfActivities(predifinedWorking, currentUser.Id);
                                        workingPredefined = false;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    MessageHelper.PrintMessage("You must enter a number", ConsoleColor.Red);
                                }
                            }
                            break;
                        case 2:
                            WorkingActivity newWork = new WorkingActivity();
                            newWork = InitializatorHelper._workingService.StopwatchForActivity(newWork);

                            bool workNewTypeBoolean = true;
                            while (workNewTypeBoolean)
                            {
                                int validNewWorkChoice = ui.WorkingTypesMenu();
                                if (validNewWorkChoice != -1)
                                {
                                    switch (validNewWorkChoice)
                                    {
                                        case 1: newWork.Type = Working.Home; workNewTypeBoolean = false; break;
                                        case 2: newWork.Type = Working.Office; workNewTypeBoolean = false; break;
                                        default: Console.Clear(); MessageHelper.PrintMessage("You must enter number between 1 or 2", ConsoleColor.Red); break;
                                    }
                                }
                            }
                            currentUser.listOfWorkingActivities.Add(newWork);
                            InitializatorHelper._userService.UpdateListOfActivities(newWork, currentUser.Id);
                            break;
                        case 3: Console.Clear(); workingMenu = false; break;
                        default: Console.Clear(); MessageHelper.PrintMessage("You must choose between 1-3", ConsoleColor.Red); break;
                    }
                }
                else
                {
                    Console.Clear();
                    MessageHelper.PrintMessage("You must enter a number", ConsoleColor.Red);
                }
            }
        }
        public static void OtherMenu(User currentUser)
        {
            bool otherMenu = true;
            while (otherMenu)
            {
                int otherChoice = ui.ActivityMenu();
                if (otherChoice != -1)
                {
                    switch (otherChoice)
                    {
                        case 1:
                            bool otherPredefined = true;
                            while (otherPredefined)
                            {
                                InitializatorHelper._otherActivityService.PrintActivities();
                                bool predefinedOtherSuccess = int.TryParse(Console.ReadLine(), out int predefinedOtherChoice);
                                if (predefinedOtherSuccess)
                                {
                                    Other predifinedOther = InitializatorHelper._otherActivityService.FindActivityById(predefinedOtherChoice);
                                    if (predifinedOther != null)
                                    {
                                        predifinedOther = InitializatorHelper._otherActivityService.StopwatchForActivity(predifinedOther);
                                        currentUser.listOfOtherActivities.Add(predifinedOther);
                                        InitializatorHelper._userService.UpdateListOfActivities(predifinedOther, currentUser.Id);
                                        otherPredefined = false;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    MessageHelper.PrintMessage("You must enter a number", ConsoleColor.Red);
                                }
                            }
                            break;
                        case 2:
                            Other newOther = new Other();
                            newOther = InitializatorHelper._otherActivityService.StopwatchForActivity(newOther);
                            string newOtherName = String.Empty;
                            bool otherSuccess = true;
                            while (string.IsNullOrEmpty(newOtherName) || otherSuccess)
                            {
                                Console.WriteLine("Enter name of other activity");
                                newOtherName = Console.ReadLine();
                                otherSuccess = int.TryParse(newOtherName, out int num);
                                if (otherSuccess)
                                {
                                    Console.Clear();
                                    MessageHelper.PrintMessage("The name can't be a number", ConsoleColor.Red);
                                }
                                else if (string.IsNullOrEmpty(newOtherName))
                                {
                                    Console.Clear();
                                    MessageHelper.PrintMessage("Invalid name of activity", ConsoleColor.Red);
                                }
                            }
                            newOther.Name = newOtherName;
                            currentUser.listOfOtherActivities.Add(newOther);
                            InitializatorHelper._userService.UpdateListOfActivities(newOther, currentUser.Id);
                            otherPredefined = false;
                    break;
                        case 3: Console.Clear(); otherMenu = false; break;
                        default: Console.Clear(); MessageHelper.PrintMessage("You must choose between 1-3", ConsoleColor.Red); break;
                    }
                }
                else
                {
                    Console.Clear();
                    MessageHelper.PrintMessage("You must enter a number", ConsoleColor.Red);
                }
            }
        }
        public static void TrackMenu(User currentUser)
        {
            bool trackMenu = true;
            while (trackMenu)
            {
                int activityChoice = ui.TrackMenu();
                if (activityChoice != -1)
                {
                    switch (activityChoice)
                    {
                        case 1:
                            Console.Clear();
                            ReadingMenu(currentUser);
                            break;
                        case 2:
                            Console.Clear();
                            ExerciseMenu(currentUser);
                            break;
                        case 3:
                            Console.Clear();
                            WorkingMenu(currentUser);
                            break;
                        case 4:
                            Console.Clear();
                            OtherMenu(currentUser);
                            break;
                        case 5: Console.Clear(); trackMenu = false; break;
                        default: Console.Clear(); Console.WriteLine("You must choose between 1-5"); break;
                    }
                }
                else
                {
                    MessageHelper.PrintMessage("You must enter a number", ConsoleColor.Red);
                }
            }
        }
        public static void AcoountManagmentMenu(User currentUser, ref bool flag)
        {
            bool flagAccountManagment = true;
            while (flagAccountManagment)
            {
                int accountManagmentChoice = ui.AccountManagmentMenu();
                if (accountManagmentChoice != -1)
                {
                    switch (accountManagmentChoice)
                    {
                        case 1:
                            Console.Clear();
                            ui.ChangeInfo("password", currentUser);
                            break;
                        case 2:
                            Console.Clear();
                            ui.ChangeInfo("first name", currentUser);
                            break;
                        case 3:
                            Console.Clear();
                            ui.ChangeInfo("last name", currentUser);
                            break;
                        case 4:
                            Console.Clear();
                            InitializatorHelper._userService.DeactivateAccount(currentUser.Id);
                            MessageHelper.PrintMessage("Account deactivated... Press enter to go back to log in menu", ConsoleColor.Green);
                            Console.ReadLine();
                            flagAccountManagment = false;
                            flag = false;
                            break;
                        case 5: Console.Clear(); flagAccountManagment = false; break;
                        default: Console.Clear(); MessageHelper.PrintMessage("You must choose between 1-5", ConsoleColor.Red); break;
                    }
                }
                else
                {
                    Console.Clear();
                    MessageHelper.PrintMessage("You must enter a number", ConsoleColor.Red);
                }
            }
        }
        public static void UserStatisticsMenu(User currentUser)
        {
            bool userStatisticsMenu = true;
            while (userStatisticsMenu)
            {
                int validStatisticsChoice = ui.UserStatisticsMenu();
                if (validStatisticsChoice != -1)
                {
                    switch (validStatisticsChoice)
                    {
                        case 1:
                            Console.Clear();
                            statistics.TotalTimePerActivity(currentUser.listOfReadingActivities, ActivityEnum.Reading); statistics.AverageMinutes(currentUser.listOfReadingActivities, ActivityEnum.Reading);
                            statistics.TotalNumberOfPages(currentUser.listOfReadingActivities); statistics.FavouriteReadingActivity(currentUser.listOfReadingActivities); break;
                        case 2:
                            Console.Clear(); statistics.TotalTimePerActivity(currentUser.listOfExerciseActivities, ActivityEnum.Exercising); statistics.AverageMinutes(currentUser.listOfExerciseActivities, ActivityEnum.Exercising); statistics.FavouriteExerciseActivity(currentUser.listOfExerciseActivities); break;
                        case 3: Console.Clear(); statistics.TotalTimePerActivity(currentUser.listOfWorkingActivities, ActivityEnum.Working); statistics.AverageMinutes(currentUser.listOfWorkingActivities, ActivityEnum.Working); statistics.FavouriteWorkingActivity(currentUser.listOfWorkingActivities); break;
                        case 4: Console.Clear(); statistics.TotalTimePerActivity(currentUser.listOfOtherActivities, ActivityEnum.Other); statistics.ListOfAllHobbies(currentUser.listOfOtherActivities); break;
                        case 5: Console.Clear(); statistics.TotalTimeGlobal(currentUser.listOfReadingActivities,currentUser.listOfExerciseActivities,currentUser.listOfWorkingActivities,currentUser.listOfOtherActivities); statistics.FavouriteActivity(currentUser.listOfReadingActivities, currentUser.listOfExerciseActivities, currentUser.listOfWorkingActivities, currentUser.listOfOtherActivities); break;
                        case 6: Console.Clear(); userStatisticsMenu = false; break;
                        default: Console.Clear(); MessageHelper.PrintMessage("You must choose between 1-6", ConsoleColor.Red); break;
                    }
                }
                else
                {
                    Console.Clear();
                    MessageHelper.PrintMessage("You must enter a number", ConsoleColor.Red);
                }
            }
        }
    }
}
