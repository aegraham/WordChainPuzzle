
using NUnit.Framework;
using WordChainPuzzle.Feature.Words;

namespace WordChainPuzzle.Feature.Tests
{
    [TestFixture]
    public class FileManagerTests
    {
        private FileManager _fileManager;

        public FileManagerTests()
        {
        }

        [SetUp]
        public void SetUp()
        {
            _fileManager = new FileManager();
            _fileManager.LoadWords("files/dictionary.txt");
        }

        [Test]
        public void TestLoadFile()
        { 
        
            Assert.IsNotNull(_fileManager.Words);
        }

        [Test]
        public void TestLoadFile_With_45425Words()
        { 
            Assert.AreEqual(_fileManager.Words.Count, 45425);
        }

        
    }
}
