using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class Person
    {
        public string Name;
        public string Position,CompanyName;
        public string StreetAddress, City, Zip;
        public class Builder: PersonJobBuilder<Builder>
        { }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"Person is called {Name} and works at {CompanyName} as a {Position} and lives at {StreetAddress} in {City} with postal code {Zip}";
        }
    }
}
