using CSharpAdvanceHomeworkFive.Domain.Enums;
using CSharpAdvanceHomeworkFive.Domain.Models;
using CSharpAdvanceHomeworkFive.Services.Helpers;
using CSharpAdvanceHomeworkFive.Services.Implementations;
using CSharpAdvanceHomeworkFive.Services.Interfaces;
using System;

namespace CSharpAdvanceHomeworkFive.App
{
    class Program
    {
        public static IRegisterService register = new RegisterService();
        public static IUiService ui = new UiService();
        public static IMenusServices menus = new MenusServices();
        public static IStatisticsServices statistics = new StatisticsServices();
        static void Main(string[] args)
        {
            bool again = true;
            while (again)
            {
                try
                {
                    int answer = ui.LogInMenu();
                    if (answer == -1)
                    {
                        throw new Exception("Invalid answer");
                    }
                    switch (answer)
                    {
                        case 1:
                            User currentUser = ValidationHelper.ThreeGuesses();
                            bool flag = true;
                            if (currentUser != null && currentUser.userStatus != UserStatus.Deactivated)
                            {
                                while (flag)
                                {
                                    int mainMenu = ui.MainMenu(currentUser.FirstName, currentUser.LastName);

                                    if (mainMenu == -1)
                                    {
                                        throw new Exception("Invalid answer");
                                    }
                                    switch (mainMenu)
                                    {
                                        case 1: menus.TrackMenu(currentUser); break;
                                        case 2:menus.UserStatisticsMenu(currentUser);break;
                                        case 3: menus.AcoountManagmentMenu(currentUser,ref flag); break;
                                        case 4: flag = false; break;
                                        default: MessageHelper.PrintMessage("You must choose between 1 to 4", ConsoleColor.Red); break;
                                    }
                                }
                            }
                            else if (currentUser == null)
                            {
                                MessageHelper.PrintMessage("Goodbye you have guessed wrong three times!!!", ConsoleColor.Red);
                                again = false;
                            }
                            else if (currentUser.userStatus == UserStatus.Deactivated)
                            {
                                MessageHelper.PrintMessage("The account has been deactivated", ConsoleColor.Red);
                                flag = ValidationHelper.ActivateDeactivatedAccount(currentUser.UserName);
                            }
                            break;
                        case 2:
                            bool registered = register.RegisterUser();
                            if (registered)
                            {
                                MessageHelper.PrintMessage("You have succesfully register!!! To go back to main menu please press enter", ConsoleColor.Green);
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Press enter");
                                Console.ReadLine();
                            }
                            break;
                        default:
                            MessageHelper.PrintMessage("You must enter 1 or 2", ConsoleColor.Red); break;
                    }
                }
                catch (Exception e)
                {
                    MessageHelper.PrintMessage(e.Message, ConsoleColor.Red);
                }
            }
        }
    }
}