using System;
using System.Collections.Generic;
using Task1.Domain.Classes;
using Services;
namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> menuOptions = new List<string>()
            {
                {"Play" },
                {"Stats" },
                { "Exit"}
            };
            List<string> gameoptions = new List<string>()
            {
                {"Rock" },
                {"Scissors" },
                {"Paper" }
            };
            bool again = true;

            while (again)
            {
                try
                {
                    Console.WriteLine("Enter your name");
                    string userName = Console.ReadLine();
                    if (String.IsNullOrEmpty(userName))
                    {
                        throw new Exception("You must enter your name");
                    }
                    User user = new User();
                    user.Name = userName;
                    CPU cpu = new CPU();
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Choose an option");
                        SimpleMethodsServices.ListingLists(menuOptions);
                        string choice = Console.ReadLine();
                        bool success = int.TryParse(choice, out int choiceParsed);
                        if (success)
                        {
                            if (choiceParsed < 1 || choiceParsed > 3)
                            {
                                throw new Exception("You must choose between theese choices");
                            }
                            else
                            {
                                switch (choiceParsed)
                                {
                                    case 1: MainMenuMethodsServices.Play(user, cpu, gameoptions); break;
                                    case 2: MainMenuMethodsServices.Stats(user, cpu); break;
                                    case 3: MainMenuMethodsServices.Exit(); break;
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("You must enter a number");
                        }

                    }
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Incorrect input");
                    Console.ResetColor();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
                Console.WriteLine("How about another round? y/n");
                string answer = Console.ReadLine();
                if (answer.ToLower() == "y")
                {
                    again = true;
                    Console.Clear();
                }
                else
                {
                    again = false;
                    Console.WriteLine($"Okey then goodbye");
                }
            }

            Console.ReadLine();
        }

    }
}
