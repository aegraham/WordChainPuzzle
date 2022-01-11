using System;
using NUnit.Framework;
using WordChainPuzzle.Feature.Words;

namespace WordChainPuzzle.Feature.Tests
{
    [TestFixture]
    public class WordEngineTests
    {
        private WordEngine _wordengine;
        private FileManager _fileManager;

        public WordEngineTests()
        {
        }

        [SetUp]
        public void SetUp()
        {
            _fileManager = new FileManager();
            _fileManager.LoadWords("files/dictionary.txt");
            _wordengine = new WordEngine("files/dictionary.txt");
        }

        [TestCaseSource(nameof(WordSizeCases))]
        public void GetCorrectSizeWords_DifferentSizeWords_ReturnsCorrectValues(string inputWord, int numberOfWords)
        {
            var result = _wordengine.GetCorrectSizeWords(inputWord, _fileManager.Words);
            Assert.AreEqual(result.Count, numberOfWords);
        }

        [TestCaseSource(nameof(WordMatchCases))]
        public void WordsMatch_AllWordsMatch_ReturnsTrue(string firstWord, string lastWord)
        {
            var match = _wordengine.WordsMatch(firstWord, lastWord);
            Assert.IsTrue(match);
        }

        [TestCaseSource(nameof(WordDoNotMatchCases))]
        public void WordsMatch_AllWordsDoNotMatch_ReturnsTrue(string firstWord, string lastWord)
        {
            var match = _wordengine.WordsMatch(firstWord, lastWord);
            Assert.IsFalse(match);
        }

        static object[] WordSizeCases =
        {
            new object [] {"cat", 536 },
            new object [] {"abba", 2236},
            new object [] {"abbey", 4176},
            new object [] {"abbeys", 6177}
        };

        static object[] WordMatchCases =
        {
            new object [] {"cat", "Dog" },
            new object [] {"abba", "road"},
            new object [] {"abbey", "pizza"},
            new object [] {"abbeys", "mezzea"}
        };

        static object[] WordDoNotMatchCases =
        {
            new object [] {"cat", "Dogs" },
            new object [] {"abba", "roada"},
            new object [] {"abbey", "pizzaa"},
            new object [] {"abbeys", "mezzeas"}
        };

    }
    
}
