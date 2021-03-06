using CSharpAdvanceHomeworkFive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Domain.Models
{
   public class Other : ActivityTrack
    {
        public string Name { get; set; }
        public Other()
        {
            Activity = ActivityEnum.Other;           
        }
        public Other(string name)
        {
            Activity = ActivityEnum.Other;
            Name = name;
        }

        public override string GetInfo()
        {
            return $"Name of other activity: {Name} time spent: {Time} minutes";
        }
    }
}
