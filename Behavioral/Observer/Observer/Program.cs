using Coding.Exercise;
using System;
using System.ComponentModel;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();
            //Test2();

            //Test3();
            Test4();

        }

        private static void Test4()
        {
            PropertyChangeNotifier.Market market = new PropertyChangeNotifier.Market();
            PropertyChangeNotifier.MarketVolitalityObserver observer = new PropertyChangeNotifier.MarketVolitalityObserver(market);
            market.Volitality = 5;
            market.MarketIndex = 10000;
        }

        private static void Test3()
        {
            //Useless since Window.Base not available in .net core  so weak event pattern not available
            var button = new Button();
            var window = new Window(button);
            button.Fire();
            window = null;

            FireGC();
            Console.ReadKey();
        }

        private static void FireGC()
        {
            Console.WriteLine("GC start");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Console.WriteLine("GC end");
        }

        private static void Test2()
        {
            var market = new Market();

            market.Prices.ListChanged += Prices_ListChanged;
            market.Prices.Add(1234);
        }

        private static void Prices_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemAdded)
            {
                var price = ((BindingList<float>)sender)[e.NewIndex];
                Console.WriteLine($"Price added is {price}");
            }
        }

        private static void Test1()
        {
            var person = new Person();
            person.FallsIll += CallDoctor;
            person.CatchCold();
        }

        private static void CallDoctor(object sender, FallsIllEventArgs e)
        {
            Console.WriteLine($"Calling the doctor {e.Address}");
        }
    }
}
