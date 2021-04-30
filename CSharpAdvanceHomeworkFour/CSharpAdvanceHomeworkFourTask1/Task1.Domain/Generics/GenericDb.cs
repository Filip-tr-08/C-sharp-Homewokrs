using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task1.Domain.Classes;

namespace Task1.Domain.Generics
{
    public static class GenericDb<T> where T : Shape
    {
        public static List<T> Shapes;
        static GenericDb()
        {
            Shapes = new List<T>();
        }
        public static void PrintAreas()
        {
            foreach (T shape in Shapes)
            {
                if (shape.GetType() == typeof(Reactangle))
                {
                    Console.WriteLine($"The area of the reactangle with id.{shape.Id} is:{shape.GetArea()}");
                }
                else if (shape.GetType() == typeof(Circle))
                {
                    Console.WriteLine($"The area of the circle with id.{shape.Id} is:{shape.GetArea()}");
                }
            }
        }
        public static void PrintPerimeters()
        {
            foreach (T shape in Shapes)
            {
                if (shape.GetType() == typeof(Reactangle))
                {
                    Console.WriteLine($"The perimeter of the reactangle with id.{shape.Id} is:{shape.GetPerimeter()}");
                }
                else if (shape.GetType() == typeof(Circle))
                {
                    Console.WriteLine($"The perimeter of the circle with id.{shape.Id} is:{shape.GetPerimeter()}");
                }
            }
        }

    }
}
