using CSharpAdvanceHomeworkFive.Domain.Models;
using CSharpAdvanceHomeworkFive.Services.Helpers;
using CSharpAdvanceHomeworkFive.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Services.Implementations
{
   public class RegisterService:IRegisterService
    {
        
        public bool RegisterUser()
        {
            string userName = RegisterHelper.RegisterUsername();
            if (InitializatorHelper._userService.FirstOrDefaultUser(userName) != null)
            {
                return false;
            }
            else
            {
                string password = RegisterHelper.RegisterPassword();
                string firstName = RegisterHelper.RegisterFirstNameOrLastName("firstName");
                string lastName = RegisterHelper.RegisterFirstNameOrLastName("lastName");
                int age = RegisterHelper.RegisterAge();
                User user = new User(firstName, lastName, age, userName, password);
                InitializatorHelper._userService.AddUser(user);
                return true;
            }
        }
    }
}
