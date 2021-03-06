﻿using System.IO;

namespace Sartain_Studios_Common.File_System
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

            ReadWriteLocker readWriteLocker = new ReadWriteLocker();

            readWriteLocker.WriteToFileThreadSafe(directory + fileName, content);
        }
    }
}