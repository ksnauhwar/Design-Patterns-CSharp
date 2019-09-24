using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{
    public class Property<T> where T:new()
    {
        private T _value;

        public T Value
        {
            get { return _value; }

            set
            {
                if (Equals(_value, value)) return;
                Console.WriteLine($"Assigning value {value}");
                _value = value;
            }
        }

        public Property():this(default(T))
        {

        }

        public Property(T value)
        {
            Value = value;
        }

        public static implicit operator Property<T>(T value)
        {
            return new Property<T>(value);
        }

        public static implicit operator T(Property<T> property)
        {
            return property.Value;
        }
    }
}
