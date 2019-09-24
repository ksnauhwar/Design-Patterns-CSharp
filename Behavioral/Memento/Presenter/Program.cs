using Memento;
using System;
using System.Collections.Generic;

namespace Presenter
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>() { "some","thind"};
            var index = list.IndexOf("s");
            //var ba = new BankAccount(100);
            //ba.Deposit(50);
            //ba.Deposit(25);
            //Console.WriteLine(ba);
            //ba.Undo();
            //Console.WriteLine($"Undo 1 : {ba}");
            //ba.Undo();
            //Console.WriteLine($"Undo 2 : {ba}");
            //ba.Redo();
            //Console.WriteLine($"Redo : {ba}");
        }
    }
}
