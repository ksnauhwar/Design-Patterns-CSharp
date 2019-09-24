using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
   public class FacetedPersonJobBuilder : FacetedPersonBuilder
    {
        public FacetedPersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public FacetedPersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public FacetedPersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public FacetedPersonJobBuilder WithPostalCode(string postalCode)
        {
            person.Zip = postalCode;
            return this;
        }
    }
}
