using System;
using System.Collections.Generic;
using System.Text;

namespace NullObject
{
    public class NullLog : ILog
    {
        public void Save(string msg)
        {
        }

        public void Warn(string warn)
        {
        }
    }
}
