using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public enum LogLevel { Fatal, Error, Warning, Information, Debug, Trace }

    public interface ILogger
    {
        void Log(LogLevel logLevel, string description, Exception exception = null);
    }
}
