using System;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();
            //Test2();
            Test3();
        }

        private static void Test3()
        {
            var nullLog = Null<ILog>.Instance;
            BankAccount ba = new BankAccount(nullLog);
            ba.Deposit(50);
        }

        private static void Test1()
        {
            var consoleLogger = new Log();
            var ba = new BankAccount(consoleLogger);
            ba.Deposit(50);
        }

        private static void Test2()
        {
            var consoleLogger = new NullLog();
            var ba = new BankAccount(consoleLogger);
            ba.Deposit(50);
        }
    }
}
