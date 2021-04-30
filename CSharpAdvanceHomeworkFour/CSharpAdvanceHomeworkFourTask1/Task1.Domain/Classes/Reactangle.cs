using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.Domain.Classes
{
    public class Reactangle : Shape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public override double GetArea()
        {
            return Math.Round(SideA * SideB,2);
        }

        public override double GetPerimeter()
        {
            return Math.Round(2 * (SideA + SideB), 2);

        }
        public Reactangle(int id,double sideA, double sideB) : base(id)
        {
            SideA = sideA;
            SideB = sideB;
        }

    }
}
