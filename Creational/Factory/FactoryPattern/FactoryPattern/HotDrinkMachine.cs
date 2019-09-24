using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern
{
    public class HotDrinkMachine
    {
        public enum AvailableDrink
        {
            Tea,Coffee
        }

        Dictionary<AvailableDrink, IHotDrinkFactory> factories =
            new Dictionary<AvailableDrink, IHotDrinkFactory>();

        public HotDrinkMachine()
        {
            foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                IHotDrinkFactory factory = (IHotDrinkFactory)Activator.CreateInstance(Type.GetType("FactoryPattern." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory"));
                factories.Add(drink, factory);
            }
        }

        public IHotDrink MakeDrink(AvailableDrink drink,int amount)
        {
            var hotDrink = factories[drink].Prepare(amount);
            return hotDrink;
        }
    }
}
