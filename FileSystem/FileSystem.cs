using System;
using System.IO;

namespace FileSystem
{
    public class FileSystem : IFileSystem
    {
        public string GetAllTextFromFile(string path)
        {
            return File.ReadAllText(path);
        }

        public string[] GetAllLinesFromFile(string path)
        {
            return File.ReadAllLines(path);
        }

        public void AppendAllTextToFile(string directory, string fileName, string content)
        {
            Directory.CreateDirectory(directory);

            using (var sw = File.AppendText(directory + fileName))
            {
                sw.WriteLine(content);
            }
        }
    }
}