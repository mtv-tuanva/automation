namespace Automation.Web.Bdd.Models
{
    public enum TestStatus
    {
        /// <summary>
        /// The test was inconclusive
        /// </summary>
        Inconclusive = 0,
        /// <summary>
        /// The test has skipped
        /// </summary>
        Skipped = 1,
        /// <summary>
        /// The test succeeded
        /// </summary>
        Passed = 2,
        /// <summary>
        /// There was a warning
        /// </summary>
        Warning = 3,
        /// <summary>
        /// The test failed
        /// </summary>
        Failed = 4
    }
}
