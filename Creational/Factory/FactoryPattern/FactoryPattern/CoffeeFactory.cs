using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern
{
    public class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Boil milk, add coffee bag, add some cream and pour {amount} ml");
            return new Coffee();
        }
    }
}
