using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern
{
    public class BetterHotDrinkMachine
    {
        private List<Tuple<string,IHotDrinkFactory>> factories = new List<Tuple<string,IHotDrinkFactory>>();

        public BetterHotDrinkMachine()
        {
            foreach (var type in typeof(BetterHotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(type)
                    && type.IsInterface == false)
                {
                    factories.Add(Tuple.Create(
                        type.Name.Replace("Factory", string.Empty).ToLower(),
                        (IHotDrinkFactory)Activator.CreateInstance(type)
                        ));
                }
            }
        }

        //What if I need to make a drink using its name instead of  int drinkType?
        public IHotDrink MakeDrink(int drinkType, int amount)
        {
            return factories[drinkType].Item2.Prepare(amount);
        }
    }
}
