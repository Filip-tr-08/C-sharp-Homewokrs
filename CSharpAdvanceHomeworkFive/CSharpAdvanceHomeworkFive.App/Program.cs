using CSharpAdvanceHomeworkFive.Domain.Enums;
using CSharpAdvanceHomeworkFive.Domain.Models;
using CSharpAdvanceHomeworkFive.Services.Database;
using CSharpAdvanceHomeworkFive.Services.Helpers;
using CSharpAdvanceHomeworkFive.Services.Implementations;
using CSharpAdvanceHomeworkFive.Services.Interfaces;
using System;

namespace CSharpAdvanceHomeworkFive.App
{
    class Program
    {

        static void Main(string[] args)
        {
            bool again = true;
            while (again)
            {
                try
                {
                    Console.WriteLine("1) Log in\n2) Register");
                    bool success1 = int.TryParse(Console.ReadLine(), out int answer);
                    if (!success1)
                    {
                        throw new Exception("Invalid answer");
                    }
                    switch (answer)
                    {
                        case 1:
                            User currentUser = ValidationHelper.ThreeGuesses();
                            if (currentUser != null)
                            {
                                bool flag = true;
                                while (flag)
                                {
                                    Console.WriteLine($"What do you want to do {currentUser.FirstName} {currentUser.LastName}");
                                    Console.WriteLine("1)Track Time\n2)User Statistics\n3)Account Managment\n4)Log Out");
                                    bool mainMenuSuccess = int.TryParse(Console.ReadLine(), out int mainMenuAnswer);
                                    if (!mainMenuSuccess)
                                    {
                                        throw new Exception("Invalid answer");
                                    }
                                    switch (mainMenuAnswer)
                                    {
                                        case 1:
                                            bool trackMenu = true;
                                            while (trackMenu)
                                            {
                                                Console.WriteLine("Choose activity:\n1) Reading\n2) Exercising\n3) Working\n4) Other\n5) Back to main menu");
                                                bool activitySuccess = int.TryParse(Console.ReadLine(), out int activityChoice);
                                                if (activitySuccess)
                                                {
                                                    switch (activityChoice)
                                                    {
                                                        case 1:
                                                            bool readingMenu = true;
                                                            while (readingMenu)
                                                            {
                                                                Console.WriteLine("1) Predefined Activity\n2) New Activity\n3) Back to track menu");
                                                                bool readingSuccess = int.TryParse(Console.ReadLine(), out int readingChoice);
                                                                if (readingSuccess)
                                                                {
                                                                    switch (readingChoice)
                                                                    {
                                                                        case 1:
                                                                            bool readingPredefined = true;
                                                                            while (readingPredefined)
                                                                            {
                                                                                Database._readingService.PrintActivities();
                                                                                bool predefinedReadingSuccess = int.TryParse(Console.ReadLine(), out int predefinedReadingChoice);
                                                                                if (predefinedReadingSuccess)
                                                                                {
                                                                                    ReadingActivity predifinedReading = Database._readingService.FindActivityById(predefinedReadingChoice);
                                                                                    predifinedReading = Database._readingService.StopwatchForActivity(predifinedReading);
                                                                                    currentUser.listOfActivities.Add(predifinedReading);
                                                                                    readingPredefined = false;
                                                                                }
                                                                                else
                                                                                {
                                                                                    Console.WriteLine("You must enter a number");
                                                                                }
                                                                            }
                                                                            break;
                                                                        case 2:
                                                                            ReadingActivity newReading = new ReadingActivity();
                                                                            newReading = Database._readingService.StopwatchForActivity(newReading);
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
                                                                                    Console.WriteLine("You must enter valid number");
                                                                                    readingNewPagesBoolean = true;
                                                                                }
                                                                            }
                                                                            bool readingNewTypeBoolean = true;
                                                                            while (readingNewTypeBoolean)
                                                                            {
                                                                                Console.WriteLine("Choose type:\n 1) Belles Lettres 2) Fiction 3) Profesional Literature ");

                                                                                bool validNewReadingChoice = int.TryParse(Console.ReadLine(), out int newReadingChoice);
                                                                                if (validNewReadingChoice)
                                                                                {
                                                                                    switch (newReadingChoice)
                                                                                    {
                                                                                        case 1: newReading.Type = Reading.Belles_Lettres; readingNewTypeBoolean = false; break;
                                                                                        case 2: newReading.Type = Reading.Fiction; readingNewTypeBoolean = false; break;
                                                                                        case 3: newReading.Type = Reading.Professional_Literature; readingNewTypeBoolean = false; break;
                                                                                        default: Console.WriteLine("You must enter number between 1-3"); break;
                                                                                    }

                                                                                }
                                                                                else
                                                                                {
                                                                                    Console.WriteLine("Invalid choice");
                                                                                    readingNewPagesBoolean = true;
                                                                                }
                                                                            }
                                                                            currentUser.listOfActivities.Add(newReading);
                                                                            break;
                                                                        case 3: readingMenu = false; break;
                                                                        default: Console.WriteLine("You must choose between 1-3"); break;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("You must enter a number");
                                                                }
                                                            }
                                                            break;
                                                        case 2:
                                                            bool exerciseMenu = true;
                                                            while (exerciseMenu)
                                                            {
                                                                Console.WriteLine("1) Predefined Activity\n2) New Activity\n3) Back to track menu");
                                                                bool exerciseSuccess = int.TryParse(Console.ReadLine(), out int exerciseChoice);
                                                                if (exerciseSuccess)
                                                                {
                                                                    switch (exerciseChoice)
                                                                    {
                                                                        case 1:
                                                                            bool exercisePredefined = true;
                                                                            while (exercisePredefined)
                                                                            {
                                                                                Database._exercisingService.PrintActivities();
                                                                                bool predefinedExerciseSuccess = int.TryParse(Console.ReadLine(), out int predefinedExerciseChoice);
                                                                                if (predefinedExerciseSuccess)
                                                                                {
                                                                                    ExercisingActivity predifinedExercise = Database._exercisingService.FindActivityById(predefinedExerciseChoice);
                                                                                    predifinedExercise = Database._exercisingService.StopwatchForActivity(predifinedExercise);
                                                                                    currentUser.listOfActivities.Add(predifinedExercise);
                                                                                    exercisePredefined = false;
                                                                                }
                                                                                else
                                                                                {
                                                                                    Console.WriteLine("You must enter a number");
                                                                                }
                                                                            }
                                                                            break;
                                                                        case 2:
                                                                            ExercisingActivity newExercise = new ExercisingActivity();
                                                                            newExercise = Database._exercisingService.StopwatchForActivity(newExercise);

                                                                            bool exerciseNewTypeBoolean = true;
                                                                            while (exerciseNewTypeBoolean)
                                                                            {
                                                                                Console.WriteLine("Choose type:\n 1) General 2) Running 3) Sport ");

                                                                                bool validNewExerciseChoice = int.TryParse(Console.ReadLine(), out int newExerciseChoice);
                                                                                if (validNewExerciseChoice)
                                                                                {
                                                                                    switch (newExerciseChoice)
                                                                                    {
                                                                                        case 1: newExercise.Type = Exercise.General; exerciseNewTypeBoolean = false; break;
                                                                                        case 2: newExercise.Type = Exercise.Running; exerciseNewTypeBoolean = false; break;
                                                                                        case 3: newExercise.Type = Exercise.Sport; exerciseNewTypeBoolean = false; break;
                                                                                        default: Console.WriteLine("You must enter number between 1-3"); break;
                                                                                    }

                                                                                }

                                                                            }
                                                                            currentUser.listOfActivities.Add(newExercise);
                                                                            break;
                                                                        case 3: exerciseMenu = false; break;
                                                                        default: Console.WriteLine("You must choose between 1-3"); break;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("You must enter a number");
                                                                }
                                                            }
                                                            break;
                                                        case 3:
                                                            bool workingMenu = true;
                                                            while (workingMenu)
                                                            {
                                                                Console.WriteLine("1) Predefined Activity\n2) New Activity\n3) Back to track menu");
                                                                bool workingSuccess = int.TryParse(Console.ReadLine(), out int workingChoice);
                                                                if (workingSuccess)
                                                                {
                                                                    switch (workingChoice)
                                                                    {
                                                                        case 1:
                                                                            bool workingPredefined = true;
                                                                            while (workingPredefined)
                                                                            {
                                                                                Database._workingService.PrintActivities();
                                                                                bool predefinedWorkingSuccess = int.TryParse(Console.ReadLine(), out int predefinedWorkingChoice);
                                                                                if (predefinedWorkingSuccess)
                                                                                {
                                                                                    WorkingActivity predifinedWorking = Database._workingService.FindActivityById(predefinedWorkingChoice);
                                                                                    predifinedWorking = Database._workingService.StopwatchForActivity(predifinedWorking);
                                                                                    currentUser.listOfActivities.Add(predifinedWorking);
                                                                                    workingPredefined = false;
                                                                                }
                                                                                else
                                                                                {
                                                                                    Console.WriteLine("You must enter a number");
                                                                                }
                                                                            }
                                                                            break;
                                                                        case 2:
                                                                            WorkingActivity newWork = new WorkingActivity();
                                                                            newWork = Database._workingService.StopwatchForActivity(newWork);

                                                                            bool workNewTypeBoolean = true;
                                                                            while (workNewTypeBoolean)
                                                                            {
                                                                                Console.WriteLine("Choose type:\n 1) Home 2) Office ");

                                                                                bool validNewWorkChoice = int.TryParse(Console.ReadLine(), out int newWorkChoice);
                                                                                if (validNewWorkChoice)
                                                                                {
                                                                                    switch (newWorkChoice)
                                                                                    {
                                                                                        case 1: newWork.Type = Working.Home; workNewTypeBoolean = false; break;
                                                                                        case 2: newWork.Type = Working.Office; workNewTypeBoolean = false; break;

                                                                                        default: Console.WriteLine("You must enter number between 1 or 2"); break;
                                                                                    }

                                                                                }

                                                                            }
                                                                            currentUser.listOfActivities.Add(newWork);
                                                                            break;
                                                                        case 3: workingMenu = false; break;
                                                                        default: Console.WriteLine("You must choose between 1-3"); break;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("You must enter a number");
                                                                }
                                                            }
                                                            break;
                                                        case 4:
                                                            bool otherMenu = true;
                                                            while (otherMenu)
                                                            {
                                                                Console.WriteLine("1) Predefined Activity\n2) New Activity\n3) Back to track menu");
                                                                bool otherSuccess = int.TryParse(Console.ReadLine(), out int otherChoice);
                                                                if (otherSuccess)
                                                                {
                                                                    switch (otherChoice)
                                                                    {
                                                                        case 1:
                                                                            bool otherPredefined = true;
                                                                            while (otherPredefined)
                                                                            {
                                                                                Database._otherActivityService.PrintActivities();
                                                                                bool predefinedOtherSuccess = int.TryParse(Console.ReadLine(), out int predefinedOtherChoice);
                                                                                if (predefinedOtherSuccess)
                                                                                {
                                                                                    Other predifinedOther = Database._otherActivityService.FindActivityById(predefinedOtherChoice);
                                                                                    predifinedOther = Database._otherActivityService.StopwatchForActivity(predifinedOther);
                                                                                    currentUser.listOfActivities.Add(predifinedOther);
                                                                                    otherPredefined = false;
                                                                                }
                                                                                else
                                                                                {
                                                                                    Console.WriteLine("You must enter a number");
                                                                                }
                                                                            }
                                                                            break;
                                                                        case 2:
                                                                            Other newOther = new Other();
                                                                            newOther = Database._otherActivityService.StopwatchForActivity(newOther);
                                                                            string newOtherName = String.Empty;
                                                                            bool otherSucces = true;
                                                                            while(string.IsNullOrEmpty(newOtherName) || otherSucces )
                                                                            {
                                                                                Console.WriteLine("Enter name of other activity");
                                                                                newOtherName = Console.ReadLine();
                                                                                otherSucces = int.TryParse(newOtherName, out int num);
                                                                                if (otherSucces)
                                                                                {
                                                                                    Console.WriteLine("The name can't be a number");
                                                                                }
                                                                                else if (string.IsNullOrEmpty(newOtherName))
                                                                                {
                                                                                    Console.WriteLine("Invalid name of activity");
                                                                                }
                                                                            }
                                                                            newOther.Name = newOtherName;
                                                                            currentUser.listOfActivities.Add(newOther);
                                                                            break;
                                                                        case 3: otherMenu = false; break;
                                                                        default: Console.WriteLine("You must choose between 1-3"); break;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("You must enter a number");
                                                                }
                                                            }
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
                                            break;
                                        case 2:
                                            if (currentUser.listOfActivities.Count == 0)
                                            {
                                                Console.WriteLine("There are not any activities");
                                            }
                                            else
                                            {
                                                Console.WriteLine($"{currentUser.GetInfo()}:");
                                                currentUser.PrintUserActivities();
                                            }
                                            break;
                                        case 3:
                                            bool flagAccountManagment = true;
                                            while (flagAccountManagment)
                                            {
                                                Console.WriteLine("1) Change Password\n2) Change first name\n3) Change last name\n4) Deactivate account\n5) Back to main menu");
                                                bool successAccountManagment = int.TryParse(Console.ReadLine(), out int accountManagmentChoice);
                                                if (successAccountManagment)
                                                {
                                                    switch (accountManagmentChoice)
                                                    {
                                                        case 1:
                                                            bool changePass = true;
                                                            while (changePass)
                                                            {
                                                                Console.WriteLine("Enter your old password");
                                                                string oldPass = Console.ReadLine();
                                                                Console.WriteLine("Enter your new password");
                                                                string newPass = Console.ReadLine();
                                                                changePass = Database._userService.ChangePassword(currentUser.Id, oldPass, newPass);
                                                            }
                                                            break;
                                                        case 2:
                                                            bool changeFirstName = true;
                                                            while (changeFirstName)
                                                            {
                                                                Console.WriteLine("Enter your old first name");
                                                                string oldFirstName = Console.ReadLine();
                                                                Console.WriteLine("Enter your new first name");
                                                                string newFirstName = Console.ReadLine();
                                                                changeFirstName = Database._userService.ChangeFirstName(currentUser.Id, oldFirstName, newFirstName);
                                                            }
                                                            break;
                                                        case 3:
                                                            bool changeLastName = true;
                                                            while (changeLastName)
                                                            {
                                                                Console.WriteLine("Enter your old last name");
                                                                string oldLastName = Console.ReadLine();
                                                                Console.WriteLine("Enter your new last name");
                                                                string newLastName = Console.ReadLine();
                                                                changeLastName = Database._userService.ChangeLastName(currentUser.Id, oldLastName, newLastName);
                                                            }
                                                            break;
                                                        case 4:
                                                            Database._userService.DeactivateAccount(currentUser.Id);
                                                            Console.WriteLine("Account deactivated... Press enter to go back to log in menu");
                                                            Console.ReadLine();
                                                            flagAccountManagment = false;
                                                            flag = false;
                                                            break;
                                                        case 5: flagAccountManagment = false; break;
                                                        default: Console.WriteLine("You must choose between 1-5"); break;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("You must enter a number");
                                                }
                                            }
                                            break;
                                        case 4: flag = false; break;
                                        default: Console.WriteLine("You must choose between 1 to 4"); break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Goodbye you have guessed wrong three times!!!");
                                again = false;
                            }
                            break;
                        case 2:
                            string userName = RegisterService.RegisterUsername();
                            string password = RegisterService.RegisterPassword();
                            string firstName = RegisterService.RegisterFirstNameOrLastName("firstName");
                            string lastName = RegisterService.RegisterFirstNameOrLastName("lastName");
                            int age = RegisterService.RegisterAge();
                            User user = new User(firstName, lastName, age, userName, password);
                            Database._userService.AddUser(user);
                            Console.WriteLine("You have succesfully register!!! To go back to main menu please press enter");
                            Console.ReadLine();
                            break;
                        default: throw new Exception("You must enter 1 or 2");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}