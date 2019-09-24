using System;

namespace PractiseBuilderPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            var person = Person.New.Called("Kuldeep").WorksAsA("Software Engineer").LivesAt("Sudarshan Nagar").Build();
            Console.WriteLine(person);

            var builder = new FacetedPersonBuilder();
            person = builder.Called.As("Kuldeep")
                   .Lives.At("Sudarshan Nagar")
                   .Works.AsA("Sofware Engineer")
                   .Build();

            Console.WriteLine(person);

            Console.ReadKey();
        }
    }


    public class Person
    {
        public string Name { get; set; }

        public string Position { get; set; }

        public string Address { get; set; }

        public class Builder : PersonAddressBuilder<Builder>
        {

        }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{Name} works as a {Position} and lives at  {Address}";
        }
    }

    public class FacetedPersonBuilder
    {
        protected Person person ;

        public FacetedPersonBuilder()
        {
            person = new Person();
        }

        public FacetedPersonInfoBuilder Called => new FacetedPersonInfoBuilder(person);

        public FacetedPersonJobBuilder Works => new FacetedPersonJobBuilder(person);

        public FacetedPersonAdressBuilder Lives => new FacetedPersonAdressBuilder(person);

        public Person Build()
        {
            return person;
        }
    }

    public class FacetedPersonInfoBuilder : FacetedPersonBuilder
    {

        public FacetedPersonInfoBuilder(Person person)
        {
            this.person = person;
        }
        public FacetedPersonInfoBuilder As(string name)
        {
            person.Name = name;
            return this;
        }
    }

    public class FacetedPersonJobBuilder : FacetedPersonBuilder
    {
        public FacetedPersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public FacetedPersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }
    }


    public class FacetedPersonAdressBuilder : FacetedPersonBuilder
    {
        public FacetedPersonAdressBuilder(Person person)
        {
            this.person = person;
        }
        public FacetedPersonAdressBuilder At(string address)
        {
            person.Address = address;
            return this;
        }
    }


    public abstract class PersonBuilder
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

    public class PersonInfoBuilder<T> : PersonBuilder
        where T : PersonInfoBuilder<T>
    {
        public T Called(string name)
        {
            person.Name = name;
            return this as T;
        }
    }

    public class PersonJobBuilder<T> : PersonInfoBuilder<PersonJobBuilder<T>>
        where T : PersonJobBuilder<T>
    {
        public T WorksAsA(string position)
        {
            person.Position = position;
            return this as T;
        }
    }

    public class PersonAddressBuilder<T> : PersonJobBuilder<PersonAddressBuilder<T>>
        where T : PersonAddressBuilder<T>
    {
        public T LivesAt(string address)
        {
            person.Address = address;
            return this as T;
        }
    }
}
