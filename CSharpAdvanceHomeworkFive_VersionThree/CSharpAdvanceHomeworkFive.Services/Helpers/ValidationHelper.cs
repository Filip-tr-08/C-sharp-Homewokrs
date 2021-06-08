using CSharpAdvanceHomeworkFive.Domain.Models;
using CSharpAdvanceHomeworkFive.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CSharpAdvanceHomeworkFive.Domain.Enums;

namespace CSharpAdvanceHomeworkFive.Services.Helpers
{
    public static class ValidationHelper
    {
        public static bool ValidateUserName(string userName)
        {
            bool validUserName = userName.Length >= 5 ? true : false;
            return validUserName;
        }
        public static bool ValidatePassword(string password)
        {
            if (ValidatePasswordCharacters(password) && ValidatePasswordCapitalLetter(password) && ValidatePasswordNum(password))
            {
                Console.Clear();
                return true;
            }
            return false;
        }
        public static bool ValidatePasswordCharacters(string password)
        {

            bool validPasswordChar = password.Length >= 6 ? true : false;
            if (!validPasswordChar)
            {
                Console.Clear();
                MessageHelper.PrintMessage("The password must have at least 6 characters", ConsoleColor.Red);
            }
            return validPasswordChar;
        }
        public static bool ValidatePasswordCapitalLetter(string password)
        {
            bool flag = false;
            foreach (char letter in password)
            {
                if (letter.ToString() == letter.ToString().ToUpper())
                {
                    flag = true;
                    break;
                }
            }
            bool validPasswordCapitalLet = flag ? true : false;
            if (!validPasswordCapitalLet)
            {
                Console.Clear();
                MessageHelper.PrintMessage("The password must have at least one capital letter", ConsoleColor.Red);
            }
            return validPasswordCapitalLet;
        }
        public static bool ValidatePasswordNum(string password)
        {
            bool flag = false;
            foreach (char letter in password)
            {
                bool success = int.TryParse(letter.ToString(), out int num);
                if (success)
                {
                    flag = true;
                    break;
                }
            }
            bool validPasswordNumber = flag ? true : false;
            if (!validPasswordNumber)
            {
                Console.Clear();
                MessageHelper.PrintMessage("The password must have at least one number", ConsoleColor.Red);
            }
            return validPasswordNumber;
        }
        public static bool ValidateFirstOrLastName(string firstOrLastName)
        {
            if (ValidateFirstOrLastNameNum(firstOrLastName) && ValidateFirstOrLastNameCharacters(firstOrLastName))
            {
                Console.Clear();
                return true;
            }
            return false;
        }
        public static bool ValidateFirstOrLastNameNum(string firstOrLastName)
        {
            bool flag = true;
            foreach (char letter in firstOrLastName)
            {
                bool success = int.TryParse(letter.ToString(), out int num);
                if (success)
                {
                    flag = false;
                    break;
                }
            }
            bool validFirstOrLastNameNumber = flag ? true : false;
            if (!validFirstOrLastNameNumber)
            {
                Console.Clear();
                MessageHelper.PrintMessage("The name can't contain any numbers", ConsoleColor.Red);
            }
            return validFirstOrLastNameNumber;
        }
        public static bool ValidateFirstOrLastNameCharacters(string firstOrLastName)
        {
            bool validFirstOrLastNameChar = firstOrLastName.Length >= 2 ? true : false;
            if (!validFirstOrLastNameChar)
            {
                Console.Clear();
                MessageHelper.PrintMessage("The name must have at least two characters", ConsoleColor.Red);
            }
            return validFirstOrLastNameChar;
        }
        public static bool ValidateAge(int age)
        {
            bool validAge = age >= 18 && age <= 120 ? true : false;
            if (!validAge)
            {
                Console.Clear();
                MessageHelper.PrintMessage("You must have between 18 and 120 years to register", ConsoleColor.Red);
            }
            return validAge;
        }
        public static User ThreeGuesses()
        {
            string userName = String.Empty;
            string password = String.Empty;
            int guessCount = 0;
            int guessLimit = 3;
            bool outOfGuesses = false;

            User userByUsername = null;
            while ((InitializatorHelper._userService.FirstOrDefaultUser(userName) == null || InitializatorHelper._userService.FirstOrDefaultPassword(password) == null) && !outOfGuesses)
            {
                if (guessCount < guessLimit)
                {
                    Console.WriteLine("Enter username: ");
                    userName = Console.ReadLine();
                    Console.WriteLine("Enter password");
                    password = Console.ReadLine();
                    guessCount++;
                    if (InitializatorHelper._userService.FirstOrDefaultUser(userName) != null && InitializatorHelper._userService.FirstOrDefaultPassword(password) != null)
                    {
                        userByUsername = InitializatorHelper._userService.FirstOrDefaultUser(userName);
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        MessageHelper.PrintMessage("Invalid password or username try again", ConsoleColor.Red);

                    }
                }
                else
                {
                    outOfGuesses = true;
                }
            }
            if (outOfGuesses)
            {
                return null;
            }
            else
            {
                return userByUsername;
            }
        }
        public static int ValidateNumber(string inputNum, int range)
        {
            bool isNum = int.TryParse(inputNum, out int number);
            if (!isNum)
            {
                MessageHelper.PrintMessage("You must choose a number", ConsoleColor.Red);
                return -1;
            }
            if (number < 1 || number > range)
            {
                MessageHelper.PrintMessage($"The choice must be between 1 - {range}", ConsoleColor.Red);
                return -1;
            }
            return number;
        }
        public static bool ActivateDeactivatedAccount(string userName)
        {
            bool activateOrNot = false;
            do
            {
                Console.Clear();
                Console.WriteLine("The account with this username has been deactivated do you want to activate it y/n?");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "y":
                        bool correctPassword = false;
                        while (!correctPassword)
                        {
                            Console.WriteLine("Please enter your password to activate the account");
                            string password = Console.ReadLine();
                            Console.Clear();
                            if (password == InitializatorHelper._userService.FirstOrDefaultUser(userName).Password)
                            {
                                User user = InitializatorHelper._userService.FirstOrDefaultUser(userName);
                                user.userStatus = UserStatus.Active;
                                InitializatorHelper._userService.ActivateAccount(user.Id);                           
                                MessageHelper.PrintMessage("Your account is now active again", ConsoleColor.Green);
                                correctPassword = true;
                                activateOrNot = true;
                               
                            }
                        }
                        return false;
                    case "n": Console.WriteLine("Your account is stil deactivated"); activateOrNot = true; return false ; 
                    default: MessageHelper.PrintMessage("Invalid answer", ConsoleColor.Red); return true ; 
                }
            } while (!activateOrNot);
        }
    }
}
