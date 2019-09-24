using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public abstract class PersonBuilder
    {
       protected Person Person = new Person();

        public Person Build()
        {
            return Person;
        }
    }
}
