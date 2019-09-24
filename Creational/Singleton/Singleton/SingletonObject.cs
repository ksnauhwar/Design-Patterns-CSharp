using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public class SingletonObject
    {
        public string Property { get; set; }

        private static int _instanceCount;
        public  int Count { get=>_instanceCount; }
        private SingletonObject()
        {
            _instanceCount++;
        }

        private static Lazy<SingletonObject> _instance = new Lazy<SingletonObject>(() => new SingletonObject());

        public static SingletonObject Instance => _instance.Value;
    }

    //Monostate
    public class CEO
    {
        private static string _name;
        private static int _age;

        public string Name { get => _name; set=> _name = value; }
        public int Age { get => _age; set => _age = value; }
    }
}
