using System;
using System.IO;
using System.Text;

namespace Automation.Web.Bdd.Logger
{
    public class BddLogger : ILogger
    {
        private readonly string prefix;
        private readonly StringBuilder stringBuilder = new StringBuilder();

        public BddLogger(string prefix)
        {
            this.prefix = prefix;
        }

        public void Log(string msg)
        {
            stringBuilder.AppendLine(msg);
            Console.WriteLine(msg);
        }

        public void LogDebug(string msg)
        {
            stringBuilder.AppendLine($"Debug--- {prefix} ---- {msg}");
            Console.WriteLine($"Debug--- {prefix} ---- {msg}");
        }

        public void LogError(string msg)
        {
            stringBuilder.AppendLine($"Error--- {prefix} ---- {msg}");
            Console.WriteLine($"Error--- {prefix} ---- {msg}");
        }

        public void LogInfo(string msg)
        {
            stringBuilder.AppendLine($"Info--- {prefix} ---- {msg}");
            Console.WriteLine($"Info--- {prefix} ---- {msg}");
        }

        public void LogTrace(string msg)
        {
            stringBuilder.AppendLine($"Trace--- {prefix} ---- {msg}");
            Console.WriteLine($"Trace--- {prefix} ---- {msg}");
        }

        public void LogWarning(string msg)
        {
            stringBuilder.AppendLine($"Warning--- {prefix} ---- {msg}");
            Console.WriteLine($"Warning--- {prefix} ---- {msg}");
        }

        public void Export(string filePath = null)
        {
            if (string.IsNullOrEmpty(filePath))
                filePath = $"{prefix} steps.txt";
            using (var stream = File.CreateText(filePath))
            {
                stream.Write(stringBuilder.ToString());
            }
        }
    }
}
