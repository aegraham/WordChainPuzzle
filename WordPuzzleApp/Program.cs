using System;
using WordChainPuzzle.Feature.Words;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to word chain.");
            Console.WriteLine("Please enter your first word");
            var firstWord = Console.ReadLine();
            Console.WriteLine("Please enter your second word");
            var lastWord = Console.ReadLine();

            if (firstWord.Length != lastWord.Length)
            {
                Console.WriteLine("Words do not match.");
            }
            
            var wordEngine = new WordEngine("../files/dictionary.txt");
            var startTime = DateTime.Now;
            var words = wordEngine.GetWordChain(firstWord, lastWord);
            var stopTime = DateTime.Now;
            Console.WriteLine(words + " time taken = " + (stopTime.TimeOfDay - startTime.TimeOfDay));
        }
        
      
    }
}