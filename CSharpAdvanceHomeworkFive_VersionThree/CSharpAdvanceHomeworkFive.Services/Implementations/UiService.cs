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
   public class UiService:IUiService
    {
        public int ChooseMenuItem(List<string> menuItems)
        {
            while (true)
            {

                for (int i = 0; i < menuItems.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {menuItems[i]}");
                }
                string input = Console.ReadLine();
                int choice = ValidationHelper.ValidateNumber(input, menuItems.Count);
                if (choice == -1)
                {
                    MessageHelper.PrintMessage("You must enter a valid option", ConsoleColor.Red);

                    continue;
                }
                return choice;
            }
        }
        public int LogInMenu()
        {
            List<string> menuItems = new List<string> { "LogIn", "Register" };
            Console.WriteLine("Choose option");
            return ChooseMenuItem(menuItems);
        }

        public int MainMenu(string fName, string lName)
        {
            List<string> menuItems = Enum.GetNames(typeof(MainMenu)).ToList();
            Console.WriteLine($"Choose what you want to do {fName} {lName}");
            return ChooseMenuItem(menuItems);
        }
        public int TrackMenu()
        {
            List<string> menuItems = Enum.GetNames(typeof(ActivityEnum)).ToList();
            menuItems.Add("Back to main menu");
            Console.WriteLine("Choose track:");
            return ChooseMenuItem(menuItems);
        }
        public int UserStatisticsMenu()
        {
            List<string> menuItems = Enum.GetNames(typeof(ActivityEnum)).ToList();
            menuItems.Add("Global");
            menuItems.Add("Back to main menu");
            Console.WriteLine("Choose option:");
            return ChooseMenuItem(menuItems);
        }
        public int ActivityMenu()
        {
            List<string> menuItems = Enum.GetNames(typeof(OneActivityChoices)).ToList();
            menuItems.Add("Back to main menu");
            Console.WriteLine("Choose option:");
            return ChooseMenuItem(menuItems);
        }
        public int ReadingTypesMenu()
        {
            List<string> menuItems = Enum.GetNames(typeof(Reading)).ToList();
            Console.WriteLine("Choose option:");
            return ChooseMenuItem(menuItems);
        }
        public int ExerciseTypesMenu()
        {
            List<string> menuItems = Enum.GetNames(typeof(Exercise)).ToList();
            Console.WriteLine("Choose option:");
            return ChooseMenuItem(menuItems);
        }
        public int WorkingTypesMenu()
        {
            List<string> menuItems = Enum.GetNames(typeof(Working)).ToList();
            Console.WriteLine("Choose option:");
            return ChooseMenuItem(menuItems);
        }
        public int AccountManagmentMenu()
        {
            List<string> menuItems = Enum.GetNames(typeof(AccountManagmentOptions)).ToList();
            menuItems.Add("Back to main menu");
            Console.WriteLine("Choose option:");
            return ChooseMenuItem(menuItems);
        }

        public void ChangeInfo(string info,User currentUser)
        {
            bool changeInfo = true;
            while (changeInfo)
            {
                Console.WriteLine($"Enter your old {info}");
                string oldInfo = Console.ReadLine();
                Console.WriteLine($"Enter your new {info}");
                string newInfo = Console.ReadLine();
                switch (info)
                {
                    case "first name": 
                changeInfo = InitializatorHelper._userService.ChangeFirstName(currentUser.Id, oldInfo, newInfo);
                        break;
                    case "last name":
                changeInfo = InitializatorHelper._userService.ChangeLastName(currentUser.Id, oldInfo, newInfo);
                        break;
                    case "password":
                changeInfo = InitializatorHelper._userService.ChangePassword(currentUser.Id, oldInfo, newInfo);
                        break;
                }
            }
            MessageHelper.PrintMessage($"Changed {info}", ConsoleColor.Green);

        }
    }
}
