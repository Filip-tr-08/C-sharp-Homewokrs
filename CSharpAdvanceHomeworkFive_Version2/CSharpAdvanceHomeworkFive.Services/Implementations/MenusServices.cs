using CSharpAdvanceHomeworkFive.Domain.Enums;
using CSharpAdvanceHomeworkFive.Domain.Models;
using CSharpAdvanceHomeworkFive.Services.Helpers;
using CSharpAdvanceHomeworkFive.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Services.Implementations
{

    public class MenusServices : IMenusServices

    {
        public static IUiService ui = new UiService();
        public static IStatisticsServices statistics = new StatisticsServices();
        public void ReadingMenu(User currentUser)
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
                                Database.Database._readingService.PrintActivities();
                                bool predefinedReadingSuccess = int.TryParse(Console.ReadLine(), out int predefinedReadingChoice);
                                if (predefinedReadingSuccess)
                                {
                                    ReadingActivity predifinedReading = Database.Database._readingService.FindActivityById(predefinedReadingChoice);
                                    if (predifinedReading != null)
                                    {
                                        predifinedReading = Database.Database._readingService.StopwatchForActivity(predifinedReading);
                                        currentUser.listOfActivities.Add(predifinedReading);
                                        readingPredefined = false;
                                    }
                                }
                                else
                                {
                                    MessageHelper.PrintMessage("You must enter a number", ConsoleColor.Red);
                                }
                            }
                            break;
                        case 2:
                            ReadingActivity newReading = new ReadingActivity();
                            newReading = Database.Database._readingService.StopwatchForActivity(newReading);
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
                                        default: MessageHelper.PrintMessage("You must enter number between 1-3", ConsoleColor.Red); break;
                                    }

                                }
                                else
                                {
                                    MessageHelper.PrintMessage("Invalid choice", ConsoleColor.Red);
                                    readingNewPagesBoolean = true;
                                }
                            }
                            currentUser.listOfActivities.Add(newReading);
                            break;
                        case 3: readingMenu = false; break;
                        default: MessageHelper.PrintMessage("You must choose between 1-3", ConsoleColor.Red); break;
                    }
                }
                else
                {
                    MessageHelper.PrintMessage("You must enter a number", ConsoleColor.Red);
                }
            }
        }
        public void ExerciseMenu(User currentUser)
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
                                Database.Database._exercisingService.PrintActivities();
                                bool predefinedExerciseSuccess = int.TryParse(Console.ReadLine(), out int predefinedExerciseChoice);
                                if (predefinedExerciseSuccess)
                                {
                                    ExercisingActivity predifinedExercise = Database.Database._exercisingService.FindActivityById(predefinedExerciseChoice);
                                    if (predifinedExercise != null)
                                    {
                                        predifinedExercise = Database.Database._exercisingService.StopwatchForActivity(predifinedExercise);
                                        currentUser.listOfActivities.Add(predifinedExercise);
                                        exercisePredefined = false;
                                    }
                                }
                                else
                                {
                                    MessageHelper.PrintMessage("You must enter a number", ConsoleColor.Red);
                                }
                            }
                            break;
                        case 2:
                            ExercisingActivity newExercise = new ExercisingActivity();
                            newExercise = Database.Database._exercisingService.StopwatchForActivity(newExercise);
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
                                        default: MessageHelper.PrintMessage("You must enter number between 1-3", ConsoleColor.Red); break;
                                    }
                                }
                            }
                            currentUser.listOfActivities.Add(newExercise);
                            break;
                        case 3: exerciseMenu = false; break;
                        default: MessageHelper.PrintMessage("You must choose between 1-3", ConsoleColor.Red); break;
                    }
                }
                else
                {
                    MessageHelper.PrintMessage("You must enter a number", ConsoleColor.Red);
                }
            }
        }
        public void WorkingMenu(User currentUser)
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
                                Database.Database._workingService.PrintActivities();
                                bool predefinedWorkingSuccess = int.TryParse(Console.ReadLine(), out int predefinedWorkingChoice);
                                if (predefinedWorkingSuccess)
                                {
                                    WorkingActivity predifinedWorking = Database.Database._workingService.FindActivityById(predefinedWorkingChoice);
                                    if (predifinedWorking != null)
                                    {
                                        predifinedWorking = Database.Database._workingService.StopwatchForActivity(predifinedWorking);
                                        currentUser.listOfActivities.Add(predifinedWorking);
                                        workingPredefined = false;
                                    }
                                }
                                else
                                {
                                    MessageHelper.PrintMessage("You must enter a number", ConsoleColor.Red);
                                }
                            }
                            break;
                        case 2:
                            WorkingActivity newWork = new WorkingActivity();
                            newWork = Database.Database._workingService.StopwatchForActivity(newWork);

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
                                        default: MessageHelper.PrintMessage("You must enter number between 1 or 2", ConsoleColor.Red); break;
                                    }
                                }
                            }
                            currentUser.listOfActivities.Add(newWork);
                            break;
                        case 3: workingMenu = false; break;
                        default: MessageHelper.PrintMessage("You must choose between 1-3", ConsoleColor.Red); break;
                    }
                }
                else
                {
                    MessageHelper.PrintMessage("You must enter a number", ConsoleColor.Red);
                }
            }
        }

        public void OtherMenu(User currentUser)
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
                                Database.Database._otherActivityService.PrintActivities();
                                bool predefinedOtherSuccess = int.TryParse(Console.ReadLine(), out int predefinedOtherChoice);
                                if (predefinedOtherSuccess)
                                {
                                    Other predifinedOther = Database.Database._otherActivityService.FindActivityById(predefinedOtherChoice);
                                    if (predifinedOther != null)
                                    {
                                        predifinedOther = Database.Database._otherActivityService.StopwatchForActivity(predifinedOther);
                                        currentUser.listOfActivities.Add(predifinedOther);
                                        otherPredefined = false;
                                    }
                                }
                                else
                                {
                                    MessageHelper.PrintMessage("You must enter a number", ConsoleColor.Red);
                                }
                            }
                            break;
                        case 2:
                            Other newOther = new Other();
                            newOther = Database.Database._otherActivityService.StopwatchForActivity(newOther);
                            string newOtherName = String.Empty;
                            bool otherSuccess = true;
                            while (string.IsNullOrEmpty(newOtherName) || otherSuccess)
                            {
                                Console.WriteLine("Enter name of other activity");
                                newOtherName = Console.ReadLine();
                                otherSuccess = int.TryParse(newOtherName, out int num);
                                if (otherSuccess)
                                {
                                    MessageHelper.PrintMessage("The name can't be a number",ConsoleColor.Red);
                                }
                                else if (string.IsNullOrEmpty(newOtherName))
                                {
                                   MessageHelper.PrintMessage("Invalid name of activity",ConsoleColor.Red);
                                }
                            }
                            newOther.Name = newOtherName;
                            currentUser.listOfActivities.Add(newOther);
                            break;
                        case 3: otherMenu = false; break;
                        default: MessageHelper.PrintMessage("You must choose between 1-3" ,ConsoleColor.Red); break;
                    }
                }
                else
                {
                    MessageHelper.PrintMessage("You must enter a number",ConsoleColor.Red);
                }
            }
        }
        public void TrackMenu(User currentUser)
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
                            ReadingMenu(currentUser);
                            break;
                        case 2:
                            ExerciseMenu(currentUser);
                            break;
                        case 3:
                            WorkingMenu(currentUser);
                            break;
                        case 4:
                            OtherMenu(currentUser);
                            break;
                        case 5: trackMenu = false; break;
                        default: Console.WriteLine("You must choose between 1-5"); break;
                    }
                }
                else
                {
                    Console.WriteLine("You must enter a number");
                }
            }
        }
        public void AcoountManagmentMenu(User currentUser,bool flag)
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
                            ui.ChangeInfo("password", currentUser);
                            break;
                        case 2:
                            ui.ChangeInfo("first name", currentUser);
                            break;
                        case 3:
                            ui.ChangeInfo("last name", currentUser);
                            break;
                        case 4:
                            Database.Database._userService.DeactivateAccount(currentUser.Id);
                            MessageHelper.PrintMessage("Account deactivated... Press enter to go back to log in menu", ConsoleColor.Green);
                            Console.ReadLine();
                            flagAccountManagment = false;
                            flag = false;
                            break;
                        case 5: flagAccountManagment = false; break;
                        default: MessageHelper.PrintMessage("You must choose between 1-5", ConsoleColor.Red); break;
                    }
                }
                else
                {
                    MessageHelper.PrintMessage("You must enter a number", ConsoleColor.Red);
                }
            }
        }
        public void UserStatisticsMenu(User currentUser)
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
                            statistics.TotalTimePerActivity(currentUser.listOfActivities, ActivityEnum.Reading); statistics.AverageMinutes(currentUser.listOfActivities, ActivityEnum.Reading);
                            statistics.TotalNumberOfPages(currentUser.listOfActivities); statistics.FavouriteActivityPerActivity(currentUser.listOfActivities, ActivityEnum.Reading); break;
                        case 2: statistics.TotalTimePerActivity(currentUser.listOfActivities, ActivityEnum.Exercising); statistics.AverageMinutes(currentUser.listOfActivities, ActivityEnum.Exercising); statistics.FavouriteActivityPerActivity(currentUser.listOfActivities, ActivityEnum.Exercising); break;
                        case 3: statistics.TotalTimePerActivity(currentUser.listOfActivities, ActivityEnum.Working); statistics.AverageMinutes(currentUser.listOfActivities, ActivityEnum.Working); statistics.FavouriteActivityPerActivity(currentUser.listOfActivities, ActivityEnum.Working); break;
                        case 4: statistics.TotalTimePerActivity(currentUser.listOfActivities, ActivityEnum.Other); statistics.ListOfAllHobbies(currentUser.listOfActivities); break;
                        case 5: statistics.TotalTimeGlobal(currentUser.listOfActivities); statistics.FavouriteActivity(currentUser.listOfActivities); break;
                        case 6: userStatisticsMenu = false; break;
                        default: MessageHelper.PrintMessage("You must choose between 1-6", ConsoleColor.Red); break;
                    }
                }
                else
                {
                    MessageHelper.PrintMessage("You must enter a number", ConsoleColor.Red);
                }
            }
        }
    }
}
