using System;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();
            Test2();
        }

        private static void Test2()
        {
            var hotDrinkMachine = new HotDrinkMachine();
            var coffee = hotDrinkMachine.MakeDrink(HotDrinkMachine.AvailableDrink.Coffee, 100);
            coffee.Consume();
            var tea = hotDrinkMachine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 200);
            tea.Consume();

            //better machine
            var betterHotDrinkMachine = new BetterHotDrinkMachine();
            var coffeeDrink = betterHotDrinkMachine.MakeDrink(0, 100);
            coffeeDrink.Consume();
            var teaDrink = betterHotDrinkMachine.MakeDrink(1, 100);
            teaDrink.Consume();
         }

        private static void Test1()
        {
            var point = Point.Factory.NewCartesianPoint(10, 10);
            var point2 = Point.Factory.NewPolarPoint(10, 45);
            
            Console.WriteLine(point);
            Console.WriteLine(point2);

        }
    }
}
