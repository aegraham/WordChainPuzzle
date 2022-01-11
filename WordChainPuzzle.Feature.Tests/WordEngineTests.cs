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

        [TestCaseSource(nameof(WordMatchByLengthCases))]
        public void WordsMatch_AllWordsLengthMatch_ReturnsTrue(string firstWord, string lastWord)
        {
            var match = _wordengine.WordsMatch(firstWord, lastWord);
            Assert.IsTrue(match);
        }

        [TestCaseSource(nameof(WordDoNotMatchByLengthCases))]
        public void WordsMatch_AllWordsLengthDoNotMatch_ReturnsTrue(string firstWord, string lastWord)
        {
            var match = _wordengine.WordsMatch(firstWord, lastWord);
            Assert.IsFalse(match);
        }

        [TestCase("dog","dog")]
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
        public void GetWordChain_DogToCog_ReturnsTrue(string firstWord, string lastword)
        {
            var words = _wordengine.GetWordChain(firstWord, lastword);
            Assert.IsNotNull(words);
        }

        [TestCase("dog", "cog")]
        public void GetWordChain_DogToCogTwoWordChain_ReturnsTrue(string firstWord, string lastword)
        {
            var words = _wordengine.GetWordChain(firstWord, lastword);
            Assert.AreEqual(2,words.Count);
        }

        [TestCase("dog", "dog")]
        public void GetWordChain_DogToDogTwoWordChain_ReturnsTrue(string firstWord, string lastword)
        {
            var words = _wordengine.GetWordChain(firstWord, lastword);
            Assert.AreEqual(1, words.Count);
        }

        [TestCase("cat", "dog")]
        public void GetWordChain_CatToDogTwoWordChain_ReturnsTrue(string firstWord, string lastword)
        {
            var words = _wordengine.GetWordChain(firstWord, lastword);
            Assert.AreEqual(4, words.Count);
        }

        [TestCase("dog", "cat")]
        public void GetWordChain_DogToCatTwoWordChain_ReturnsTrue(string firstWord, string lastword)
        {
            var words = _wordengine.GetWordChain(firstWord, lastword);
            Console.WriteLine(String.Join(",", words));
            Assert.AreEqual(5, words.Count);
        }

        static object[] WordSizeCases =
        {
            new object [] {"cat", 536 },
            new object [] {"abba", 2236},
            new object [] {"abbey", 4176},
            new object [] {"abbeys", 6177}
        };

        static object[] WordMatchByLengthCases =
        {
            new object [] {"cat", "Dog" },
            new object [] {"abba", "road"},
            new object [] {"abbey", "pizza"},
            new object [] {"abbeys", "mezzea"}
        };

        static object[] WordDoNotMatchByLengthCases =
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
