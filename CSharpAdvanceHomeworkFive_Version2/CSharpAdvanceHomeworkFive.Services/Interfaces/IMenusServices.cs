using CSharpAdvanceHomeworkFive.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Services.Interfaces
{
   public interface IMenusServices
    {
        void ReadingMenu(User currentUser);
        void ExerciseMenu(User currentUser);
        void WorkingMenu(User currentUser);
        void OtherMenu(User currentUser);
        void TrackMenu(User currentUser);
        void AcoountManagmentMenu(User currentUser, ref bool flag);
        void UserStatisticsMenu(User currentUser);
    }
}
