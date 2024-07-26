namespace thesis_exercise.common.LoggerManager
{
    public interface ILoggerManager
    {
        void LogDebug(params string[] message);
        void LogError(params string[] message);
        void LogError(Exception ex, params string[] message);
        void LogInfo(params string[] message);
        void LogWarn(params string[] message);
    }
}

