using System;
using System.Collections.Generic;
using System.Text;

namespace Memento
{
    public class BankAccount
    {
        private int _balance;
        private List<Memento> _changeLog;
        private int _current;

        public BankAccount(int balance)
        {
            _balance = balance;
            _changeLog = new List<Memento>() { new Memento(_balance) };
        }

        public Memento Deposit(int amount)
        {
            _balance += amount;
            var memento = new Memento(_balance);
            _changeLog.Add(memento);
            _current++;
            return memento;
        }

        public bool Restore(Memento memento)
        {
            if (memento!=null)
            {
                _balance = memento.Balance;
                _changeLog.Add(memento);
                return true;
            }

            return false;
        }

        public bool Undo()
        {
            if (_current > 0)
            {
                _balance = _changeLog[--_current].Balance;
                return true;
            }
            return false;
        }

        public bool Redo()
        {
            if (_current < _changeLog.Count)
            {
                _balance = _changeLog[++_current].Balance;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Account balance is {_balance}";
        }
    }
}
