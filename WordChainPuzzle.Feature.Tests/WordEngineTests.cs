using System;
using NUnit.Framework;
using WordChainPuzzle.Feature.Words;

namespace WordChainPuzzle.Feature.Tests
{
    [TestFixture]
    public class WordEngineTests
    {
        private FileManager _FileManager;
        private WordEngine _WordEngine;

        public WordEngineTests()
        {
        }

        [SetUp]
        public void SetUp()
        {
            _FileManager = new FileManager();
            _FileManager.LoadWords("files/dictionary.txt");
            _WordEngine = new WordEngine();
        }

        [TestCaseSource(nameof(WordCases))]
        public void Test_CorrectNumber_WordsInFile(string inputWord, int numberOfWords)
        {
            var result = _WordEngine.GetWords(inputWord, _FileManager.Words);
            Assert.AreEqual(result.Count, numberOfWords);
        }


        static object[] WordCases =
        {
            new object [] {"cat", 536 },
            new object [] {"abba", 2236},
            new object [] {"abbey", 4176},
            new object [] {"abbeys", 6177}
        };
        
    }
    
}
