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
            //throw new NotImplementedException();
            // will log messages in future
        }
    }
}
