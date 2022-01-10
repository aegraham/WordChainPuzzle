
using NUnit.Framework;
using WordChainPuzzle.Feature.Words;

namespace WordChainPuzzle.Feature.Tests
{
    [TestFixture]
    public class FileManagerTests
    {
        public FileManagerTests()
        {
        }

        [Test]
        public void TestLoadFile()
        {
            var fileManager = new FileManager();
            fileManager.LoadWords("files/dictionary.txt");
            Assert.IsNotNull(fileManager.Words);
        }

        [Test]
        public void TestLoadFile_With_45425Words()
        {
            var fileManager = new FileManager();
            fileManager.LoadWords("files/dictionary.txt");
            Assert.AreEqual(fileManager.Words.Count, 45425);
        }
    }
}
