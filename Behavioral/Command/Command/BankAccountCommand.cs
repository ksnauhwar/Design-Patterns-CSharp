using System;
using System.Collections.Generic;
using System.Text;

namespace Command
{
    public class BankAccountCommand
    {
        private BankAccount _bankAccount;
        private int _amount;
        private bool _isCommandSuccessful;

        public enum Activity
        {
            Deposit,
            Widthdraw
        }

        public Activity BankActivity;

        public BankAccountCommand(BankAccount ba,Activity activity,int amount)
        {
            _bankAccount = ba;
            _amount = amount;
            BankActivity = activity;
        }

        public void Call()
        {
            switch (BankActivity)
            {
                case Activity.Deposit:
                    _isCommandSuccessful = _bankAccount.Deposit(_amount);
                    break;
                case Activity.Widthdraw:
                    _isCommandSuccessful = _bankAccount.Withdraw(_amount);
                    break;
                default:
                    break;
            }
        }

        public void Undo()
        {
            switch (BankActivity)
            {
                case Activity.Deposit:
                    if(_isCommandSuccessful)
                    _bankAccount.Withdraw(_amount);
                    break;
                case Activity.Widthdraw:
                    if(_isCommandSuccessful)
                    _bankAccount.Deposit(_amount);
                    break;
                default:
                    break;
            }
        }
    }
}
