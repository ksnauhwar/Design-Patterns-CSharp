using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern
{
    public class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Nice coffee");
        }
    }
}
