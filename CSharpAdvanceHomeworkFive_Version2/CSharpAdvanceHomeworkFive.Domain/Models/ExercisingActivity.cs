using CSharpAdvanceHomeworkFive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Domain.Models
{
    public class ExercisingActivity : ActivityTrack
    {
        public Exercise Type { get; set; }
        public ExercisingActivity()
        {
            Activity = ActivityEnum.Exercising;

        }
        public ExercisingActivity(Exercise type) 
        {
            Activity = ActivityEnum.Exercising;
            Type = type;
        }
        public override string GetInfo()
        {
            return  $"Exercising type:{Type} time spent:{Time} minutes";
        }
    }
}
