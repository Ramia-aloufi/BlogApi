using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Logging
{
    public interface ILogger
    {
        void Log(string message);
        
    }
}