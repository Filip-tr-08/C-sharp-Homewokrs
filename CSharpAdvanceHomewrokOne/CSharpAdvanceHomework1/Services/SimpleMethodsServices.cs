using System;
using System.Collections.Generic;
using System.Text;


namespace Services
{
   public class SimpleMethodsServices
    {
        public static double Precentage(int player1Results, int games)
        {
            double precentage = Math.Round(((double)player1Results / (double)games) * 100, 1);
            return precentage;
        }
        public static int RandomChoice()
        {
            Random rand = new Random();
            int x = rand.Next(0, 3);
            return x;
        }
        public static void ListingLists(List<string> list)
        {
            int counter = 1;
            foreach(string item in list)
            {
                Console.WriteLine($"{counter}) {item}");
                counter++;
            }
        }
        public static string CheckWinner(string userChoice, string cpuChoice)
        {
            string result = string.Empty;
            if(userChoice=="Rock" && cpuChoice=="Scissors" || userChoice=="Scissors" && cpuChoice=="Paper" || userChoice=="Paper" && cpuChoice == "Rock")
            {
                return result = "User";
            } 
            else if(userChoice=="Rock" && cpuChoice=="Paper" || userChoice=="Scissors" && cpuChoice=="Rock" || userChoice=="Paper" && cpuChoice=="Scissors")
            {
                return result = "CPU";
            }
            else if (userChoice==cpuChoice)
            {
                return result = "Tie";
            }
            else
            {
                return result;
            }
        }
    }
}
