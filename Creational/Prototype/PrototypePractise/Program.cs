using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace PrototypePractise
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();
            //BinarySerializerTest();
            var person = new Person("")
            {
                Address = new Address()
                {
                    PostalCode = 123,
                    StreetName = "Baker Street"
                },
                Name = "Sherlock"
            };

            var newPerson = person.DeepCopyWithXmlSerializer();
            newPerson.Name = "Watson";
            newPerson.Address.StreetName = "Quaker Street";
            Console.WriteLine(person);
            Console.WriteLine(newPerson);
            Console.ReadKey();
        }

        private static void BinarySerializerTest()
        {
            var person = new Person()
            {
                Address = new Address()
                {
                    PostalCode = 123,
                    StreetName = "Baker Street"
                },
                Name = "Sherlock"
            };

            var newPerson = person.DeepCopyWithBinarySerializer();
            newPerson.Name = "Watson";
            newPerson.Address.StreetName = "Quaker Street";
            Console.WriteLine(person);
            Console.WriteLine(newPerson);
            Console.ReadKey();
        }

        private static void Test1()
        {
            var person = new Person()
            {
                Address = new Address()
                {
                    PostalCode = 123,
                    StreetName = "Baker Street"
                },
                Name = "Sherlock"
            };

            var newPerson = person.DeepCopy();
            newPerson.Name = "Watson";
            newPerson.Address.StreetName = "Quaker Street";
            Console.WriteLine(person);
            Console.WriteLine(newPerson);
            Console.ReadKey();
        }
    }


    public interface IPrototype<T>
        where T : class
    {
        T DeepCopy();
    }

    [Serializable]
    public class Person : IPrototype<Person>
    {
        public Address Address { get; set; }

        public string Name { get; set; }

        public Person()
        {

        }

        public Person DeepCopy()
        {
            return new Person("")
            {
                Address = this.Address.DeepCopy(),
                Name = this.Name
            };
        }

        public Person(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name} stays at {Address.PostalCode},{Address.StreetName}";
        }

        public Person DeepCopyWithBinarySerializer()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(ms) as Person;
            }
        }

        public Person DeepCopyWithXmlSerializer()
        {
            using (var ms = new MemoryStream())
            {

                var xmlSerializer = new XmlSerializer(typeof(Person));
                xmlSerializer.Serialize(ms, this);
                ms.Position = 0;
                return xmlSerializer.Deserialize(ms) as Person;
            }
        }
    }

    [Serializable]
    public class Address : IPrototype<Address>
    {
        public string StreetName { get; set; }

        public int PostalCode { get; set; }

        public Address DeepCopy()
        {
            return new Address()
            {
                StreetName = this.StreetName,
                PostalCode = this.PostalCode
            };
        }
    }
}
