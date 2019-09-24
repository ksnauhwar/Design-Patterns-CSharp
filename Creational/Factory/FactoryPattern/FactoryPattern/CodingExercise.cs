using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern
{
    public class CodingExercise
    {
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }

            private static int _personInstanceCount =-1;

            public static int PersonInstantceCount
            {
                get
                {

                    _personInstanceCount += 1;
                    return _personInstanceCount;
                }
            }
        }

        public interface IPersonFactory
        {
            Person CreatePerson(string name);
        }

        public class PersonFactory : IPersonFactory
        {
            public Person CreatePerson(string name)
            {
                return new Person()
                {
                    Id = Person.PersonInstantceCount,
                    Name = name
                };
            }
        }
    }
}
