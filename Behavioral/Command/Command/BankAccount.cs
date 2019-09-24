using System;
using System.Collections.Generic;
using System.Text;

namespace Command
{
    public class BankAccount
    {
        private int _balance;

        public bool Deposit(int amount)
        {
            _balance += amount;
            Console.WriteLine($"Amount of {amount} deposited,balance in the account is {_balance}");
            return true;
        }

        public bool Withdraw(int amount)
        {
            if (_balance < amount)
            {
                Console.WriteLine("Insufficient balance");
                return false ;
            }

            _balance -= amount;
            Console.WriteLine($"Amount of {amount} withdrawn,balance in the account is {_balance}");
            return true;
        }
    }
}
