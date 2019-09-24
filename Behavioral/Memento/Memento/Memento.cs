using System;

namespace Memento
{
    public class Memento
    {
        public int Balance { get; private set; }

        public Memento(int balance)
        {
            Balance = balance;
        }

        
    }

}
