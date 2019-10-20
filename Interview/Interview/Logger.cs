using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview;

namespace Interview
{
    public class Logger : ILogger
    {
        public void Log(LogLevel logLevel, string description, Exception exception = null)
        {
            // will log messages in future
        }

        public void LogError(Exception exception)
        {
            // will log messages in future
        }

        public void LogInfo(string description)
        {
            // will log messages in future
        }
    }
}
