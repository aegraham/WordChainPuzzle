using System;
using System.Collections.Generic;

namespace WordChainPuzzle.Feature.Words
{
    public class WordEngine
    {


        public WordEngine()
        {
        }

        public List<string> GetWords(string inputWord, in List<string> words)
        {
            if (words is null)
            {
                throw new ArgumentNullException(nameof(words));
            }

            return words.FindAll(x => x.Length == inputWord.Length);
        }
    }
}
