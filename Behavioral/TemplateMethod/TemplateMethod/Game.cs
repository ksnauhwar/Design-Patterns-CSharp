using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethod
{
    public abstract class Game
    {
        protected int numberOfPlayers;
        protected int currentPlayer;
        public Game(int totalPlayers)
        {
            numberOfPlayers = totalPlayers;
        }

        public void Run()
        {
            Start();
            while (HaveWinner == false)
            {
                TakeTurn();
            }

            Console.WriteLine($"Winner is {currentPlayer} player");
        }

        public abstract void Start();
        public abstract bool HaveWinner { get; }
        public abstract void TakeTurn();
    }
}
