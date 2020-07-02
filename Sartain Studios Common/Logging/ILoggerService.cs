namespace Sartain_Studios_Common.Logging
{
    public interface ILoggerService
    {
        void GetValuesToWriteToLogAndLog(string content, string type, string? codeOrigin, string? subCodeOrigin, string? fileName);
    }
}
