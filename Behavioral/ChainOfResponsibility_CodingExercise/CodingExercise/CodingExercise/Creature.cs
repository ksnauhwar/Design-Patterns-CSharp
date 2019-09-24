using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise
{
    public abstract class Creature
    {
        protected Game _game;
        public virtual int Attack { get; set; }
        public virtual int Defense { get; set; }

        public Creature(Game game)
        {
            _game = game;
        }

        public abstract int Query(object sender, StatQuery query);
    }
}
