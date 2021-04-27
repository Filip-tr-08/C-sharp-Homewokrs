using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkThree.Domain.Static_Classes
{
    public static class Vallidator
    {
        public static bool Validate(Vehicle vehicle)
        {
            if (vehicle.Id == 0 || vehicle.Type == String.Empty || vehicle.YearOfProduction == 0)
            {
                return false;
            }
           
            else
            {
                return true;
            }
        }
    }
}
