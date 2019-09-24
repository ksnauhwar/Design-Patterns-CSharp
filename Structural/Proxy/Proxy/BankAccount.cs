using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{
    public class BankAccount : IBankAccount
    {
        private int _balance;

        public int Balance()
        {
            return _balance;
        }

        public void Deposit(int amount)
        {
            Console.WriteLine($"Deposit {amount}");

            _balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (amount > _balance)
                Console.WriteLine("Insufficient Balance");

            Console.WriteLine($"Withdraw {amount}");
            _balance -= amount;
        }

        public override string ToString()
        {
            return $"Your balance is {_balance}";
        }
    }
}
