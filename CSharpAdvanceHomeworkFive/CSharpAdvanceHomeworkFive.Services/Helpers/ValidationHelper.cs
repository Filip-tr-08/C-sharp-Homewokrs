using CSharpAdvanceHomeworkFive.Domain.Models;
using CSharpAdvanceHomeworkFive.Services.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
                return true;
            }
            return false;
        }
        public static bool ValidatePasswordCharacters(string password)
        {

            bool validPasswordChar = password.Length >= 6 ? true : false;
            if (!validPasswordChar)
            {
                Console.WriteLine("The password must have at least 6 characters");
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
                Console.WriteLine("The password must have at least one capital letter");
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
                Console.WriteLine("The password must have at least one number");
            }
            return validPasswordNumber;
        }
        public static bool ValidateFirstOrLastName(string firstOrLastName)
        {
            if (ValidateFirstOrLastNameNum(firstOrLastName) && ValidateFirstOrLastNameCharacters(firstOrLastName))
            {
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
                Console.WriteLine("The name can't contain any numbers");
            }
            return validFirstOrLastNameNumber;
        }
        public static bool ValidateFirstOrLastNameCharacters(string firstOrLastName)
        {
            bool validFirstOrLastNameChar = firstOrLastName.Length >= 2 ? true : false;
            if (!validFirstOrLastNameChar)
            {
                Console.WriteLine("The name must have at least two characters");
            }
            return validFirstOrLastNameChar;
        }
        public static bool ValidateAge(int age)
        {
            bool validAge = age >= 18 && age <= 120 ? true : false;
            if (!validAge)
            {
                Console.WriteLine("You must have between 18 and 120 years to register");
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
            while((Database.Database._userService.FirstOrDefaultUser(userName)== null || Database.Database._userService.FirstOrDefaultPassword(password)== null) && !outOfGuesses)
            {
                if (guessCount < guessLimit)
                {
                    Console.WriteLine("Enter username: ");
                    userName = Console.ReadLine();
                    Console.WriteLine("Enter password");
                    password = Console.ReadLine();
                    guessCount++;
                    if(Database.Database._userService.FirstOrDefaultUser(userName) != null && Database.Database._userService.FirstOrDefaultPassword(password) != null)
                    {
                        userByUsername = Database.Database._userService.FirstOrDefaultUser(userName);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid password or username try again");

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
    }
}
