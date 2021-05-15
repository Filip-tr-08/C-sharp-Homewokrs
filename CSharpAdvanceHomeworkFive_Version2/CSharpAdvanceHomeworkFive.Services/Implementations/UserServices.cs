
using CSharpAdvanceHomeworkFive.Domain.Models;
using CSharpAdvanceHomeworkFive.Domain.Database;
using System;
using System.Collections.Generic;
using System.Text;
using CSharpAdvanceHomeworkFive.Services.Interfaces;
using System.Linq;
using CSharpAdvanceHomeworkFive.Services.Helpers;
using CSharpAdvanceHomeworkFive.Domain.Enums;

namespace CSharpAdvanceHomeworkFive.Services.Implementations
{
    
    public class UserServices<T>:IUserServices<T> where T : User
    {
        private  GenericDB<T> _users { get; set; }
        public UserServices()
        {
            _users = new GenericDB<T>();
        }
        public void PrintUsers()
        {
           
            List<T> users=_users.GetAll();
            foreach(T user in users)
            {
                Console.WriteLine(user.FirstName);
            }
        }
       public void AddUser(T user)
        {
            _users.Insert(user);
        }

        public User FirstOrDefaultUser(string username)
        {
            User user=_users.GetAll().FirstOrDefault(x => x.UserName == username);
            return user;
        }
        public User FirstOrDefaultPassword(string password)
        {
            User user = _users.GetAll().FirstOrDefault(x => x.Password == password);
            return user;
        }
        public bool ChangePassword(int userId,string oldPassword,string newPassword)
        {
            T userDb = _users.GetById(userId);
            if (userDb.Password != oldPassword)
            {
               MessageHelper.PrintMessage("Old passwords do not match",ConsoleColor.Red);
                return true;
            }
            if (!ValidationHelper.ValidatePassword(newPassword))
            {
                return true;
            }
            userDb.Password = newPassword;
            _users.Update(userDb);
            return false;
        }
        public bool ChangeFirstName(int userId,string oldFirstName,string newFirstName)
        {
            T userDb = _users.GetById(userId);
            if (userDb.FirstName != oldFirstName)
            {
                MessageHelper.PrintMessage("Old first names do not match",ConsoleColor.Red);
                return true;
            }
            if (!ValidationHelper.ValidateFirstOrLastName(newFirstName)) 
            {
                return true;
            }
            userDb.FirstName = newFirstName;
            _users.Update(userDb);
            return false;
        }
        public bool ChangeLastName(int userId, string oldLastName, string newLastName)
        {
            T userDb = _users.GetById(userId);
            if (userDb.LastName != oldLastName)
            {
                MessageHelper.PrintMessage("Old last names do not match",ConsoleColor.Red);
                return true;
            }
            if (!ValidationHelper.ValidateFirstOrLastName(newLastName))
            {
                return true;
            }
            userDb.LastName = newLastName;
            _users.Update(userDb);
            return false;
        }
        public void DeactivateAccount(int userId)
        {
            User user=_users.GetById(userId);
            user.userStatus = UserStatus.Deactivated;
        }

    }
}
