namespace Sartain_Studios_Common.Logging
{
    public class LoggerWrapper : ILoggerWrapper
    {
        private LoggerService _loggerService;

        public LoggerWrapper(string baseLogDirectory)
        {
            _loggerService = new LoggerService(baseLogDirectory);
        }

        public void LogError(string content, string? codeOrigin, string? subCodeOrigin, string? fileName)
        {
            _loggerService.GetValuesToWriteToLogAndLog(content, "Error", codeOrigin, subCodeOrigin, fileName);
        }

        public void LogWarning(string content, string? codeOrigin, string? subCodeOrigin, string? fileName)
        {
            _loggerService.GetValuesToWriteToLogAndLog(content, "Warning", codeOrigin, subCodeOrigin, fileName);
        }

        public void LogInformation(string content, string? codeOrigin, string? subCodeOrigin, string? fileName)
        {
            _loggerService.GetValuesToWriteToLogAndLog(content, "Information", codeOrigin, subCodeOrigin, fileName);
        }

        public void LogDebug(string content, string? codeOrigin, string? subCodeOrigin, string? fileName)
        {
            _loggerService.GetValuesToWriteToLogAndLog(content, "Debug", codeOrigin, subCodeOrigin, fileName);
        }

        public void LogVerbose(string content, string? codeOrigin, string? subCodeOrigin, string? fileName)
        {
            _loggerService.GetValuesToWriteToLogAndLog(content, "Verbose", codeOrigin, subCodeOrigin, fileName);
        }
    }
}
