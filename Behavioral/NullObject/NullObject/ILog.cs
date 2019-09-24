using System;
using System.Collections.Generic;
using System.Text;

namespace NullObject
{
    public interface ILog
    {
        void Save(string msg);
        void Warn(string warn);
    }
}
