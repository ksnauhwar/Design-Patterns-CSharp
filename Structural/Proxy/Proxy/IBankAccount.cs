using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{
    public interface IBankAccount
    {
        void Deposit(int amount);
        void Withdraw(int amount);
        int Balance();
    }
}
