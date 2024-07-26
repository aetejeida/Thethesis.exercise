using NLog;

namespace thesis_exercise.common.LoggerManager
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();
        private string separator = "-----";

        public LoggerManager()
        {
        }

        public static LoggerManager GetInstance()
        {
            return new LoggerManager();
        }

        public void LogDebug(params string[] messages)
        {
            _logger.Debug(GetMessagesMerged(messages));
            Console.WriteLine($"{separator} DEBUG {separator} {GetMessagesMerged(messages)}");
        }

        public void LogError(params string[] messages)
        {
            _logger.Error(GetMessagesMerged(messages));
            Console.WriteLine($"{separator} ERROR {separator} {GetMessagesMerged(messages)}");
        }

        public void LogError(Exception ex, params string[] messages)
        {
            _logger.Error($"{GetMessagesMerged(messages)}, {GetInnerExceptionsMessages(ex)}, {ex.StackTrace}");
            Console.WriteLine($"{separator} ERROR {separator} {GetMessagesMerged(messages)}, {GetInnerExceptionsMessages(ex)}, {ex.StackTrace}");
        }

        public void LogInfo(params string[] messages)
        {
            _logger.Info(GetMessagesMerged(messages));
            Console.WriteLine($"{separator} INFO {separator} {GetMessagesMerged(messages)}");
        }

        public void LogWarn(params string[] messages)
        {
            _logger.Warn(GetMessagesMerged(messages));
            Console.WriteLine($"{separator} WARN {separator} {GetMessagesMerged(messages)}");
        }

        private string GetMessagesMerged(string[] messages)
        {
            return messages != null && messages.Length > 0 ? string.Join(' ', messages) : string.Empty;
        }

        private string GetInnerExceptionsMessages(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return $"Exception Message: {ex?.Message}, Inner Exception: {GetInnerExceptionsMessages(ex.InnerException)}";
            }
            return ex?.Message;
        }
    }
}
