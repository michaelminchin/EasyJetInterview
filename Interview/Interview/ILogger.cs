using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public interface ILogger
    {
        void LogFatal(Exception exception);

        void LogError(Exception exception);

        void LogWarn(string description);

        void LogInfo(string description);

        void LogDebug(string description);

        void LogTrace(string description);
    }
}
