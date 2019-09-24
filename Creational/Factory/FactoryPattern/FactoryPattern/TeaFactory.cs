using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern
{
    public class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Boil water, put tea bag  and pour {amount} ml");
            return new Tea();
        }
    }
}
