using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class PersonInfoBuilder<T> 
         : PersonBuilder
         where T : PersonInfoBuilder<T>
    {
        public T CalledAs(string name)
        {
            Person.Name = name;
            return (T)this;
        }
    }
}
