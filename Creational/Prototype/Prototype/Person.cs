using System;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Prototype
{
    [Serializable]
    public class Person : IPrototype<Person>
    {
        public string Name { get; set; }

        public Address Address { get; set; }

        public Person DeepCopy()
        {
            return new Person()
            {
                Name = Name,
                Address = Address.DeepCopy()
            };
        }

        public Person DeepCopyWithBinary()
        {
            var formatter = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                formatter.Serialize(ms, this);
                ms.Position = 0;
               return (Person)formatter.Deserialize(ms);
            }
        }

        public Person DeepCopyWithXmlSerializer()
        {
            var xmlSerializer = new XmlSerializer(typeof(Person));
            using (var ms = new MemoryStream())
            {
                xmlSerializer.Serialize(ms, this);
                ms.Position = 0;
                return (Person)xmlSerializer.Deserialize(ms);
            }
        }

        public override string ToString()
        {
            return $"{Name} lives at {Address.StreetName},{Address.City}";
        }
    }

    [Serializable]
    public class Address : IPrototype<Address>
    {
        public string StreetName, City;
        public Address DeepCopy()
        {
            return new Address()
            {
                StreetName = StreetName,
                City = City
            };
        }
    }
}
