using System;
using System.Collections.Generic;

namespace FactoryPatternPractise
{
    public class Program
    {
        static void Main(string[] args)
        {
            var hotDrinkMachine = new HotDrinkMachine();
            var drink = hotDrinkMachine.PrepareDrink(HotDrinkMachine.AvailableDrink.Coffee, 60);
            drink.Drink();
            Console.ReadKey();
        }

        public class HotDrinkMachine
        {
            public enum AvailableDrink
            {
                Coffee,
                Tea
            }

            public Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();

            public HotDrinkMachine()
            {
                foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
                {
                    var factory = (IHotDrinkFactory)Activator.CreateInstance(Type.GetType("FactoryPatternPractise.Program+" + Enum.GetName(typeof(AvailableDrink), drink) + "Factory"));
                    factories[drink] = factory;
                }
            }

            public IHotDrink PrepareDrink(AvailableDrink drink, int amount)
            {
                return factories[drink].Prepare(amount);
            }
        }

        public interface IHotDrink
        {
            void Drink();
        }

        public class Tea : IHotDrink
        {
            public void Drink()
            {
                Console.WriteLine("Nice tea!");
            }
        }

        public class Coffee : IHotDrink
        {
            public void Drink()
            {
                Console.WriteLine("Great coffee");
            }
        }

        public interface IHotDrinkFactory
        {
            IHotDrink Prepare(int amount);
        }

        public class CoffeeFactory : IHotDrinkFactory
        {
            public IHotDrink Prepare(int amount)
            {
                Console.WriteLine($"Preparing delicious {amount}ml coffee");
                return new Coffee();
            }
        }

        public class TeaFactory : IHotDrinkFactory
        {
            public IHotDrink Prepare(int amount)
            {
                Console.WriteLine($"Preparing strong {amount}ml tea");
                return new Tea();
            }
        }
    }
}
