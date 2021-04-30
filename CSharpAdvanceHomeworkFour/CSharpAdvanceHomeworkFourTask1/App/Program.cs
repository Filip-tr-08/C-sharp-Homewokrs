using System;
using Task1.Domain.Classes;
using Task1.Domain.Generics;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Reactangle reactangle1 = new Reactangle(1, 3, 5);
            Reactangle reactangle2 = new Reactangle(2, 2.6, 8.5);
            Reactangle reactangle3 = new Reactangle(3, 5.6, 5.6);

            Circle circle1 = new Circle(4, 5);
            Circle circle2 = new Circle(5, 4.4);
            Circle circle3 = new Circle(6, 6.3);

            GenericDb<Shape>.Shapes.Add(reactangle1);
            GenericDb<Shape>.Shapes.Add(reactangle2);
            GenericDb<Shape>.Shapes.Add(reactangle3);
            GenericDb<Shape>.Shapes.Add(circle1);
            GenericDb<Shape>.Shapes.Add(circle2);
            GenericDb<Shape>.Shapes.Add(circle3);

            GenericDb<Shape>.PrintPerimeters();
            GenericDb<Shape>.PrintAreas();

            foreach(Shape shape in GenericDb<Shape>.Shapes)
            {
                shape.ShapeInfo<Shape>();
            }
          }
    }
}
