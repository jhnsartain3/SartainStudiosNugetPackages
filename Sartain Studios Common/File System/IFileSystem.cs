namespace Sartain_Studios_Common.File_System
{
    public interface IFileSystem
    {
        /// <summary>
        /// Retrieve all characters from a file as a string.
        /// </summary>
        /// <param name="path">String path to file to read.</param>
        /// <returns>String containing the text from a file.</returns>
        string GetAllTextFromFile(string path);

        /// <summary>
        /// Retrieve all lines from a file as a string.
        /// </summary>
        /// <param name="path">String path to file to read.</param>
        /// <returns>String array contains the characters by line from the file.</returns>
        string[] GetAllLinesFromFile(string path);

        /// <summary>
        /// Write additional line of text to a given file.
        /// </summary>
        /// <param name="directory">String path to file to read.</param>
        /// <param name="fileName">String name of the file to read.</param>
        /// <param name="content">String content to write to file.</param>
        void AppendAllTextToFile(string directory, string fileName, string content);
    }
}