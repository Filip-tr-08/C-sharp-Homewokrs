using CSharpAdvanceHomeworkFive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanceHomeworkFive.Domain.Models
{
    public class ReadingActivity : ActivityTrack
    {
        public int Pages { get; set; }
        public Reading Type { get; set; }
        public ReadingActivity()
        {
            Activity = Activity.Reading;

        }
        public ReadingActivity(int pages,Reading type)
        {
            Activity = Activity.Reading;
            Pages = pages;
            Type = type;
        }
        public override string GetInfo()
        {
            return ($"Reading -- pages:{Pages} type:{Type} time spent:{Time} minutes");
        }
    }
}
