using System;

namespace Proxy
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
            var bankAccount = Log<BankAccount>.As<IBankAccount>();
            bankAccount.Deposit(100);
            bankAccount.Withdraw(50);
            bankAccount.Deposit(50);
            bankAccount.Withdraw(50);

            Console.WriteLine(bankAccount);

        }

        private static void Test1()
        {
            var creature = new Creature();
            creature.Agility = 10;
            creature.Agility = 10;
        }
    }
}
