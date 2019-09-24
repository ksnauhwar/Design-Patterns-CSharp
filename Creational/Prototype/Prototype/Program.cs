using System;

namespace Prototype
{
    public struct SomeStruct
    {
        int value;
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Test2();
            Test3();
        }

        private static void Test3()
        {
            var person = new Person()
            {
                Address = new Address()
                {
                    StreetName = "Mane Vasti",
                    City = "Pune"
                },
                Name = "Kuldeep Singh"
            };

            var newPerson = person.DeepCopyWithBinary();
            newPerson.Address.StreetName = "Khese Park";
            var newerPerson = person.DeepCopyWithXmlSerializer();
            newerPerson.Name = "Ravnit";
            newerPerson.Address.StreetName = "Khese Park";
            Console.WriteLine(person);
            Console.WriteLine(newPerson);
            Console.WriteLine(newerPerson);
        }

        private static void Test2()
        {
            var person = new Person()
            {
                Address = new Address()
                {
                    StreetName = "Mane Vasti",
                    City = "Pune"
                },
                Name = "Kuldeep Singh"
            };

            var newPerson = person.DeepCopy();
            newPerson.Name = "Ravneet Kaur";
            newPerson.Address.StreetName = "Lane No 3,Mane Vasti";
            Console.WriteLine(person);
            Console.WriteLine(newPerson);
        }

        public static void Test1()
        {
            var line = new Line()
            {
                Start = new Point()
                {
                    X = 0,
                    Y = 0
                },
                End = new Point()
                {
                    X = 1,
                    Y = 1
                }
            };

            var line2 = line.DeepCopy();
            line2.End.X = line2.End.Y = 5;
            Console.WriteLine(line);
            Console.WriteLine(line2);
        }
    }
}
