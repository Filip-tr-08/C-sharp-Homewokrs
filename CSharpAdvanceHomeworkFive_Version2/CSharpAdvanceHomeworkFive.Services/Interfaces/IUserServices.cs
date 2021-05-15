using CSharpAdvanceHomeworkFive.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Services.Interfaces
{
    public interface IUserServices<T> where T : User
    {
        void PrintUsers();
        void AddUser(T user);
        User FirstOrDefaultUser(string username);
        User FirstOrDefaultPassword(string password);
        bool ChangePassword(int userId, string oldPassword, string newPassword);
        bool ChangeFirstName(int userId, string oldFirstName, string newFirstName);
        bool ChangeLastName(int userId, string oldLastName, string newLastName);
        void DeactivateAccount(int userId);
    }
}
