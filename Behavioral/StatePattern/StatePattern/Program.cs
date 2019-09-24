using System;
using System.Collections.Generic;
using System.Linq;
namespace StatePattern
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
            var switchState = new SwitchBasedState();
            int count = 0;
            while (count <= 1)
            {
                switchState.BeginStateTransition();
                if (switchState.Current == LockState.UnLocked)
                {
                    count++;
                }
            }
        }

        private static void Test1()
        {
            var phone = new Phone();
            while (true)
            {
                Console.WriteLine($"{phone.CurrentState}");
                Console.WriteLine($"Choose a trigger from the following");

                var scenario = phone.State[phone.CurrentState];
                Console.WriteLine(string.Join(',', scenario.Select(x => Enum.GetName(typeof(Trigger), x.Item2)))); //not working
                int trigger = int.Parse(Console.ReadLine());
                phone.CurrentState = phone.State[phone.CurrentState].FirstOrDefault(kvp => kvp.Item2 == (Trigger)trigger).Item1;
            }
        }
    }
}
