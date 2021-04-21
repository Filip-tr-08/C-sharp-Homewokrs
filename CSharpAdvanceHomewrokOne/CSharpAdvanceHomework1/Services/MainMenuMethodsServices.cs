using System;
using System.Collections.Generic;
using System.Text;
using Task1.Domain.Classes;

namespace Services
{
    public class MainMenuMethodsServices
    {
        public static void Play(User user, CPU cpu, List<string> list)
        {
            Console.Clear();
            Console.WriteLine("Okey then let's play what is your choice");
            SimpleMethodsServices.ListingLists(list);
            bool success = int.TryParse(Console.ReadLine(), out int userChoice);
            if (success)
            {
                if (userChoice < 1 || userChoice > 3)
                {
                    throw new Exception("Please choose one the following choices");
                }
                else
                {
                    string userGameChoice = list[userChoice - 1];
                    int cpuChoice = SimpleMethodsServices.RandomChoice();
                    string cpuGameChoice = list[cpuChoice];
                    Console.WriteLine($"{user.Name}: {userGameChoice} ---- CPU: {cpuGameChoice}");
                    string result = SimpleMethodsServices.CheckWinner(userGameChoice, cpuGameChoice);
                    if (result == "CPU")
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{result} won");
                        cpu.Wins++;
                        CPU.TotalGames++;
                        Console.ResetColor();
                    }
                    else if (result == "User")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{user.Name} won");
                        user.Wins++;
                        CPU.TotalGames++;
                        Console.ResetColor();
                    }
                    else if (result == "Tie")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"It's a {result.ToLower()}");
                        CPU.TotalGames++;
                        Console.ResetColor();
                    }
                    else
                    {
                        throw new Exception("There is something wrong");
                    }


                }
            }
            else
            {
                throw new Exception("Invalid input");
            }
            Console.WriteLine("Please press Enter if you want to go to Main Menu");
            Console.ReadLine();
        }

        public static void Stats(User user, CPU cpu)
        {
            Console.Clear();
            if (CPU.TotalGames > 0)
            {
                int ties = CPU.TotalGames - (user.Wins + cpu.Wins);
                Console.WriteLine($"{user.Name} won : {user.Wins} times and lost: {cpu.Wins} times from {CPU.TotalGames} games. There have been {ties} ties");
                double Winprecentage = SimpleMethodsServices.Precentage(user.Wins, CPU.TotalGames);
                double LosePrecentage = SimpleMethodsServices.Precentage(cpu.Wins, CPU.TotalGames);
                if (Winprecentage > LosePrecentage)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"The precentage is: {Winprecentage}% won ----- {LosePrecentage}% lost");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"The precentage is: {Winprecentage}% won ----- {LosePrecentage}% lost");
                    Console.ResetColor();
                }
                Console.WriteLine("Please press Enter if you want to go to Main Menu");
            }
            else
            {
                throw new Exception("You have not played yet, go to the Play option firts");
            }
            Console.ReadLine();
        }
        public static void Exit()
        {
            Console.Clear();
            Console.WriteLine($"Okey goodbye then");
            Environment.Exit(-1);
        }
    }
}
