using CSharpAdvanceHomeworkFive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Domain.Models
{
   public abstract class ActivityTrack:BaseEntity
    {
        public ActivityEnum Activity { get; set; }
        public double Time { get; set; }
    }
}
