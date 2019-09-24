
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern
{
    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }
}
