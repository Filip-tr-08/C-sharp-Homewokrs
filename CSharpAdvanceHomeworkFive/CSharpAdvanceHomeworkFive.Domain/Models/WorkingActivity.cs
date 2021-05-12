using CSharpAdvanceHomeworkFive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Domain.Models
{
    public class WorkingActivity : ActivityTrack
    {
        
        public Working Type { get; set; }
        public WorkingActivity()
        {
            Activity = Activity.Working;

        }
        public WorkingActivity(Working type)
        {
            Activity = Activity.Working;
            Type = type;
        }
        public override string GetInfo()
        {
            return $"Working from {Type} time spent:{Time} minutes";
        }
    }
}
