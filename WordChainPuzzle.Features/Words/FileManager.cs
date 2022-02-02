using System;
using System.Collections.Generic;
using System.IO;

namespace WordChainPuzzle.Feature.Words
{
    public class FileManager
    {
        public List<string> Words { get; set; }

        public FileManager()
        {
        }

        public void LoadWords(string filePath)
        {
            //TODO May be a better way to find the directory path than this.
            var directory = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"../../../../"));
            var file = File.ReadAllLines(directory + "/" + filePath);
            Words = new List<string>(file);
        }
    }
}
