using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise
{
    public class GoblinKing : Goblin
    {
        private int _baseAttack;
        private int _baseDefence;

        public GoblinKing(Game game):base(game)
        {
            _baseAttack = 3;
            _baseDefence = 3;
        }

        public override int Attack
        {
            get
            {
                var query = new StatQuery(_baseAttack, Trait.Attack);
                return query.Result;
            }
        }

        public override int Defense
        {
            get
            {
                var query = new StatQuery(_baseDefence, Trait.Defense);
                return query.Result;
            }
        }

        public override int Query(object sender, StatQuery query)
        {
            switch (query.Trait)
            {
                case Trait.Defense:
                    query.Result = query.Result + _game.Creatures.Count - 1;
                    break;
                case Trait.Attack:
                    query.Result = _baseAttack;
                    break;
            }
            return query.Result;
        }
    }

}
