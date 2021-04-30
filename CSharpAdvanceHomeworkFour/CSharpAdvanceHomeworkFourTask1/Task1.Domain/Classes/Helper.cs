using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.Domain.Classes
{
    public static class Helper
    {
        public static void ShapeInfo<T>(this T shape) where T : Shape
        {
            object obj = shape;
            if (shape.GetType() == typeof(Reactangle))
            {
                Console.WriteLine($"Id:{shape.Id} (Reactangle) side a= {((Reactangle)obj).SideA} side b = {((Reactangle)obj).SideB}");
            }
            else if (shape.GetType() == typeof(Circle))
            {
                Console.WriteLine($"Id:{shape.Id} (Circle) radius= {((Circle)obj).Radius}");
            }
        }
    }
}
