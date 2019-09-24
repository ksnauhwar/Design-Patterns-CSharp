using System;
using System.Collections.Generic;
using System.Text;

namespace NullObject
{
    public class Log : ILog
    {
        public void Save(string msg)
        {
            Console.WriteLine(msg);
        }

        public void Warn(string msg)
        {
            Console.WriteLine("Warning: {0}", msg);
        }
    }
}
