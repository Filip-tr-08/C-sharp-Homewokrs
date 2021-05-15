using CSharpAdvanceHomeworkFive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Services.Helpers
{
   public static class RegisterHelper
    {
        public static string RegisterUsername()
        {
            string userName = String.Empty;
            bool flag = true;
            do
            {
                Console.WriteLine("Enter user name");
                userName = Console.ReadLine();
                if (Database.Database._userService.FirstOrDefaultUser(userName) != null && Database.Database._userService.FirstOrDefaultUser(userName).userStatus == UserStatus.Active)
                {
                    MessageHelper.PrintMessage("There is already user with this username try again", ConsoleColor.Red);
                    flag = true;
                }
                else if((Database.Database._userService.FirstOrDefaultUser(userName) != null && Database.Database._userService.FirstOrDefaultUser(userName).userStatus == UserStatus.Deactivated)){
                    flag=ValidationHelper.ActivateDeactivatedAccount(userName);
                }
                else if (!ValidationHelper.ValidateUserName(userName))
                {
                    MessageHelper.PrintMessage("The username must have five or more characters", ConsoleColor.Red);
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            } while (flag);
            return userName;
        }
        public static string RegisterPassword()
        {
            string password = String.Empty;
            bool flag = true;
            do
            {
                Console.WriteLine("Enter password");
                password = Console.ReadLine();

                if (!ValidationHelper.ValidatePassword(password))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            } while (flag);
            return password;
        }
        public static string RegisterFirstNameOrLastName(string typeName)
        {
            string name = String.Empty;
            bool flag = true;
            do
            {
                if (typeName == "firstName")
                {
                    Console.WriteLine("Enter first name");
                    name = Console.ReadLine();

                    if (!ValidationHelper.ValidateFirstOrLastName(name))
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                else if (typeName == "lastName")
                {
                    Console.WriteLine("Enter last name");
                    name = Console.ReadLine();

                    if (!ValidationHelper.ValidateFirstOrLastName(name))
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }


            } while (flag);
            return name;
        }
        public static int RegisterAge()
        {
            int age = 0;
            bool flag = true;
            do
            {
                Console.WriteLine("Enter Age");
                bool success = int.TryParse(Console.ReadLine(), out age);
                if (!success)
                {
                    Console.WriteLine("You must enter a number");
                    flag = true;
                }
                else if (!ValidationHelper.ValidateAge(age))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            } while (flag);
            return age;
        }
    }
}
