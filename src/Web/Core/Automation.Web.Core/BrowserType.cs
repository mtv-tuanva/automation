namespace Automation.Web.Core
{
    public enum BrowserType
    {
        Chrome,
        Firefox,
        InternetExplorer,
        Edge,
        Opera,
        Safari
    }

    public enum PlatformType
    {
        Any,
        Win32,
        Win64,
        Mac,
        Android,
        IOS
    }

    public static class BrowserTypeName
    {
        public const string Chrome = "chrome";
        public const string Firefox = "firefox";
        public const string InternetExplorer = "internetexplorer";
        public const string Edge = "edge";
        public const string Opera = "opera";
        public const string Safari = "safari";
    }
}
