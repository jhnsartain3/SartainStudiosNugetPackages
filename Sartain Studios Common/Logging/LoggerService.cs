using Sartain_Studios_Common.File_System;
using Sartain_Studios_Common.Time_Functions;

namespace Sartain_Studios_Common.Logging
{
    public class LoggerService : ILoggerService
    {
        private readonly string _baseLogDirectory;
        readonly FileSystem _fileSystem;
        readonly TimeFunctions _timeFunctions;

        public LoggerService(string baseLogDirectory)
        {
            _baseLogDirectory = baseLogDirectory;
            _fileSystem = new FileSystem();
            _timeFunctions = new TimeFunctions();
        }

        public void GetValuesToWriteToLogAndLog(string content, string type, string? codeOrigin, string? subCodeOrigin, string? fileName)
        {
            var contentToWrite = DetermineContentToWrite(content, type, codeOrigin, subCodeOrigin);

            var (directory, fileNameAndExtension) = DetermineWritePath(type, fileName);

            WriteToLog(directory, fileNameAndExtension, contentToWrite);
            WriteToLog(_baseLogDirectory, "Everything.log", contentToWrite);
        }

        public string DetermineContentToWrite(string content, string type, string? codeOrigin, string? subCodeOrigin)
        {
            var dateTime = _timeFunctions.GetCurrentDateTimeLocal();

            var stringToWrite = dateTime.ToString() + " " + type + " " + codeOrigin + " " + subCodeOrigin + " " + content;

            return stringToWrite;
        }

        public (string directory, string fileNameAndExtension) DetermineWritePath(string type, string fileName)
        {
            var directory = _baseLogDirectory + @"\" + type + @"\";
            var fileNameAndExtension = (string.IsNullOrEmpty(fileName) ? "log" : fileName + " " + type) + ".log";

            return (directory, fileNameAndExtension);
        }

        private void WriteToLog(string directory, string fileNameAndExtension, string contentToWrite)
        {
            _fileSystem.AppendAllTextToFile(directory, fileNameAndExtension, contentToWrite);
        }
    }
}