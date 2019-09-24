using System;
using System.Collections.Generic;
using System.Text;

namespace NullObject
{
    public class BankAccount
    {
        private readonly ILog _log;
        private int _balance;
        public BankAccount(ILog log)
        {
            _log = log;
        }

        public void Deposit(int amount)
        {
            _balance += amount;
            _log.Save($"Deposited {amount}.Balance is now {_balance}");
        }

    }
}
