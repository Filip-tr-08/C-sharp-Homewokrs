using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.Domain.Classes
{
   public class Circle:Shape
    {
        public double Radius { get; set; }
        public override double GetArea()
        {
            return Math.Round(Math.PI*Math.Pow(Radius,2),2);
        }
        public override double GetPerimeter()
        {
            return Math.Round(2*Math.PI*Radius,2);
        }
        public Circle(int id,double radius):base(id)
        {
            Radius = radius;
        }
    }
}
