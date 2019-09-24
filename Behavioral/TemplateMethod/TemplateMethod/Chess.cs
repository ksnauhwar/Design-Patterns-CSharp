using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethod
{
    public class Chess : Game
    {
        private int _totalNoOfTurns = 10;
        public Chess(int totalPlayers) : base(totalPlayers)
        {
        }

        public override bool HaveWinner => _totalNoOfTurns == 0;

        public override void Start()
        {
            Console.WriteLine("Game has started");
        }

        public override void TakeTurn()
        {
            currentPlayer = (currentPlayer + 1) % numberOfPlayers;
            Console.WriteLine($"{currentPlayer}'s turn");
            --_totalNoOfTurns;
        }
    }
}
