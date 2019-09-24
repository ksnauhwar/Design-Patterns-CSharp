using System;
using System.Collections.Generic;
using System.Text;

namespace FlyWeight
{
    public class User
    {
        public string FullName { get; set; }

        public User(string fullName)
        {
            FullName = fullName;
        }
    }
}
