using CSharpAdvanceHomeworkFive.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Services.Interfaces
{
    public interface IUiService
    {
        int ChooseMenuItem(List<string> menuItems);
        int LogInMenu();
        int MainMenu(string fName, string lName);
        int TrackMenu();
        int UserStatisticsMenu();
        int ActivityMenu();
        int ReadingTypesMenu();
        int ExerciseTypesMenu();
        int WorkingTypesMenu();
        int AccountManagmentMenu();
        void ChangeInfo(string info, User currentUser);
    }
}
