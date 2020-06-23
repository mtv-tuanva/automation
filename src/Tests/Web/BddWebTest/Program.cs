using Automation.Web.Bdd.Models;
using Automation.Web.Bdd.Processors;
using System;
using System.IO;

namespace BddWebTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World!");
                ITestCaseRunner testCaseRunner = new TestCaseRunner();

                testCaseRunner.Run(TestCaseConfig.ReadTestCasesFromConfig(Path.Combine(Environment.CurrentDirectory, "tc.json")));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
