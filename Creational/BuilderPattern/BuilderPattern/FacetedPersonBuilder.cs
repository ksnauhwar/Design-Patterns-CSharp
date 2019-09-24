using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
   public class FacetedPersonBuilder
    {
        protected Person person = new Person();

        public FacetedPersonJobBuilder Works => new FacetedPersonJobBuilder(person);
        public FacetedPersonInfoBuilder Lives => new FacetedPersonInfoBuilder(person);

        public static implicit operator Person(FacetedPersonBuilder personBuilder)
        {
            return personBuilder.person;
        }
    }
}
