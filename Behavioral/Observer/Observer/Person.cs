using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public class Person
    {
        public event EventHandler<FallsIllEventArgs> FallsIll;

        public void CatchCold()
        {
            FallsIll?.Invoke(this,new FallsIllEventArgs() { Address = "123 Baker Street"});
        }
    }
}
