namespace Sartain_Studios_Common.Logging
{
    public interface ILoggerWrapper
    {
        void LogError(string content, string? codeOrigin, string? subCodeOrigin, string? fileName);
        void LogWarning(string content, string? codeOrigin, string? subCodeOrigin, string? fileName);
        void LogInformation(string content, string? codeOrigin, string? subCodeOrigin, string? fileName);
        void LogDebug(string content, string? codeOrigin, string? subCodeOrigin, string? fileName);
        void LogVerbose(string content, string? codeOrigin, string? subCodeOrigin, string? fileName);
    }
}