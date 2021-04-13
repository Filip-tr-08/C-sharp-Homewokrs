using System;
using System.Collections.Generic;
using Task4.Classes;
namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("employee1", "first", 25));
            employees.Add(new Employee("employee2", "second", 28));
            employees.Add(new Employee("employee3", "third", 21));
            employees.Add(new Employee("employee4", "forth", 32));
            employees.Add(new Employee("employee5", "fifth", 30));
            employees.Add(new Employee("employee6", "sixth", 27));
            employees.Add(new Employee("employee7", "seventh", 41));
            employees.Add(new Employee("employee8", "eighth", 38));
            employees.Add(new Employee("employee9", "ninth", 19));
            employees.Add(new Employee("employee10", "tenth", 29));
            
            Dictionary<int, List<string>> dictionaryList = new Dictionary<int, List<string>>();


            for (int i = 0; i < employees.Count; i++)
            {

                dictionaryList.Add(key: employees[i].Age, value: new List<string>() { $"{employees[i].FirstName} {employees[i].LastName}" });
            }
            foreach (var item in dictionaryList)
            {
                Console.Write($"{item.Key} - ");
                foreach (var i in item.Value)
                {
                    Console.Write(i);
                    Console.WriteLine();
                }
            }
        }
    }
}
