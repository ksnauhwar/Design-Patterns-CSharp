using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class FacetedPersonInfoBuilder:FacetedPersonBuilder
    {
        public FacetedPersonInfoBuilder(Person person)
        {
            this.person = person;
        }

        public FacetedPersonInfoBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }

        public FacetedPersonInfoBuilder In(string city)
        {
            person.City = city;
            return this;
        }

        public FacetedPersonInfoBuilder WithPostalCode(string postalCode)
        {
            person.Zip = postalCode;
            return this;
        }
    }
}
