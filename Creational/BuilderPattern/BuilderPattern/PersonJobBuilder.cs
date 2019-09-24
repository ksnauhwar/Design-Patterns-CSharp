using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class PersonJobBuilder<T> 
        : PersonInfoBuilder<PersonJobBuilder<T>>
          where T : PersonJobBuilder<T>
    {
        public T WorksAs(string position)
        {
            Person.Position = position;
            return (T)this;
        }
    }
}
