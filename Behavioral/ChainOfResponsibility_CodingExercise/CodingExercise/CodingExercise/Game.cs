using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise
{
    public class Game
    {
        public IList<Creature> Creatures;

        public Game()
        {
            Creatures = new List<Creature>();
        }
    }
}
