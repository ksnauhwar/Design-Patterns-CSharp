using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern
{
    public class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Nice tea");
        }
    }
}
