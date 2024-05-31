using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Logging
{
    public class LogToDB : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("LogToDB");

        }
    }
}