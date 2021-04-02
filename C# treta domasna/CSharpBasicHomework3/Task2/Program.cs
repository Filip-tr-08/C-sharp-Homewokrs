using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a sentence:");
            string sentence = Console.ReadLine();
            string word = "";
            int wordCounter = 0;
            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] == ' ')
                {
                    wordCounter++;
                }
            }
            string[] words = new string[wordCounter + 1];
            int currentWordIndex = 0; 
            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] != ' ')
                {
                    word = word + sentence[i];
                    continue;
                }
                words[currentWordIndex++] = word; 
                word = "";
            }
            words[currentWordIndex++] = word; 
            for(int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[i]);
            }
            Console.ReadLine();
        }
    }
}
