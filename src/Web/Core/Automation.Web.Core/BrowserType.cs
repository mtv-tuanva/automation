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
        Auto,
        X32,
        X64,
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
