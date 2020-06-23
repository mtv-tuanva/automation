namespace Automation.Web.Bdd.Logger
{
    public interface ILogger
    {
        void Log(string msg);

        void LogError(string msg);

        void LogWarning(string msg);

        void LogInfo(string msg);

        void LogDebug(string msg);

        void LogTrace(string msg);

        void Export(string filePath = null);
    }
}
