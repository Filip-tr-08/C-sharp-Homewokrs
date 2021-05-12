using CSharpAdvanceHomeworkFive.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Services.Implementations
{
   public static class RegisterService
    {
        public static string RegisterUsername()
        {
            string userName = String.Empty;
            bool flag = true;
            do
            {
                Console.WriteLine("Enter user name");
                userName = Console.ReadLine();
                if (Database.Database._userService.FirstOrDefaultUser(userName) != null)
                {
                    Console.WriteLine("There is already user with this username try again");
                    flag = true;
                }
                else if (!ValidationHelper.ValidateUserName(userName))
                {
                    Console.WriteLine("The username must have five or more characters");
                    flag = true;
                }
                else
                {
                    flag=false;
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
                bool success = int.TryParse(Console.ReadLine(),out age);
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
