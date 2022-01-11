using System;
using System.Collections.Generic;

namespace WordChainPuzzle.Feature.Words
{
    public class WordEngine
    {
        private FileManager _fileManager;

        public WordEngine(string filePath)
        {
            _fileManager = new FileManager();
            _fileManager.LoadWords(filePath);
        }

        public List<string> GetWordChain(string firstWord,string lastWord)
        {
            if(!WordsMatch(firstWord, lastWord))
            {
                throw new ArgumentException("Words must be the same length.", nameof(WordEngine));
            }

            var listOfWords = GetCorrectSizeWords(firstWord, _fileManager.Words);

            if(!WordExists(firstWord,listOfWords))
            {
                throw new ArgumentException("Word does not exist", nameof(WordEngine));
            }

            if(!WordExists(lastWord, listOfWords))
            {
                throw new ArgumentException("Word does not exist", nameof(WordEngine));
            }

            var wordChain = new List<string>();
            wordChain.Add(firstWord);
            var foundWord = false;
            var newWord = firstWord;
            var letterCount = 0;

            while (!foundWord)
            {
                if (newWord == lastWord)
                {
                    foundWord = true;
                    break;
                }

                if(letterCount == lastWord.Length)
                {
                    letterCount = 0;
                }

                SwapLetter(ref newWord, lastWord, letterCount);

                while (!listOfWords.Contains(newWord))
                {
                    if(letterCount == lastWord.Length)
                    {
                        throw new ArgumentException("Not found word ran out of letters", nameof(WordEngine));
                    }
                    newWord = firstWord;
                    letterCount++;
                    SwapLetter(ref newWord, lastWord, letterCount);
                    
                }

                wordChain.Add(newWord);
                letterCount++;

                
            }
           

            return wordChain;
        }

        public void SwapLetter(ref string newWord, in string lastWord,in int letterCount)
        {
            newWord = newWord.Replace(newWord[letterCount], lastWord[letterCount]);
            
        }

        public List<string> GetCorrectSizeWords(string inputWord, List<string> words)
        {
            if (words is null)
            {
                throw new ArgumentNullException(nameof(words));
            }

            return words.FindAll(x => x.Length == inputWord.Length);
        }

        public bool WordExists(string word, in List<string> listOfWords)
        {
            if(listOfWords.Contains(word.ToLower()))
            {
                return true;
            }

            return false;
        }

        public bool WordsMatch(string firstWord, string lastWord)
        {
            if(firstWord.Length == lastWord.Length && firstWord != lastWord)
            {
                return true;
            }

            return false;
        }
    }
}
