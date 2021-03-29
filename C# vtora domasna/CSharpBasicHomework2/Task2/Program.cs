using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            string[] studentsG1 = {"Zdravko","Petko","Stanko", "Branko","Trajko"};
            string[] studentsG2 = { "Student1", "Student2", "Student3" , "Student4" , "Student5", "Student6" };
            Console.WriteLine("Enter student group: (there are 1 and 2)");
            int.TryParse(Console.ReadLine(), out num);
            if (num !=0 ) {
                if (num == 1)
                {
                    foreach(string student in studentsG1)
                    {
                        Console.WriteLine(student);
                    }
                }
                else if (num == 2)
                {
                    foreach (string student in studentsG2)
                    {
                        Console.WriteLine(student);
                    }
                }
                else
                {
                    Console.WriteLine("There is not a group with that number");
                }
            }
            else
            {
                Console.WriteLine("ERROR");
            }

        }
    }
}
