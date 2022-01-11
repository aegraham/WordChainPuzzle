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

        [TestCaseSource(nameof(WordsExistCases))]
        public void WordExisits_AllWordsExists_ReturnsTrue(string word)
        {
            var match =_wordengine.WordExists(word, _fileManager.Words);
            Assert.IsTrue(match);
        }

        [TestCaseSource(nameof(WordsDoNotExistCases))]
        public void WordExisits_AllWordsDoNotExists_ReturnsTrue(string word)
        {
            var match =  _wordengine.WordExists(word, _fileManager.Words);
            Assert.IsFalse(match);
        }

        [TestCase("dog","cog")]
        public void GetWordChain(string firstWord, string lastword)
        {
            var words = _wordengine.GetWordChain(firstWord, lastword);
            Assert.IsNotNull(words);
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

        static object[] WordsExistCases =
       {
            new object [] {"cat"},
            new object [] {"abba"},
            new object [] {"abbey" },
            new object [] {"abbeys"}
        };

        static object[] WordsDoNotExistCases =
       {
            new object [] {"kkk"},
            new object [] {"gaol"},
            new object [] {"popes" },
            new object [] {"hellos"}
        };

    }
    
}
