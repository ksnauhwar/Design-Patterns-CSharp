using System;
using System.Collections.Generic;
using System.Linq;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            var bankAccount = new BankAccount();
            var bankAccountCommands = new List<BankAccountCommand>()
            {
                new BankAccountCommand(bankAccount,BankAccountCommand.Activity.Deposit,100),
                new BankAccountCommand(bankAccount,BankAccountCommand.Activity.Widthdraw,500)
            };

            bankAccountCommands.ForEach(command => command.Call());

            foreach (var command in Enumerable.Reverse(bankAccountCommands))
            {
                command.Undo();
            }
        }
    }
}
