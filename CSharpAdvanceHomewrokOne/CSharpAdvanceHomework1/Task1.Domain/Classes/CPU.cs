using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.Domain.Classes
{
   public class CPU : User
    {
        public static int TotalGames { get; set; }
        public CPU()
        {
            base.Name = "CPU";
        }
    }
}
