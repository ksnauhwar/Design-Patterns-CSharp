using System;
using System.Linq;

namespace CodingExercise
{
    public class Goblin : Creature
    {
        private int _baseAttack;
        private int _baseDefence;

        public Goblin(Game game):base(game)
        {
            _baseAttack = 1;
            _baseDefence = 1;
        }

        public override int Attack
        {
            get
            {
                var query = new StatQuery(_baseAttack, Trait.Attack);
                return Query(this, query);
            }
        }

        public override int Defense
        {
            get
            {
                var query = new StatQuery(_baseDefence, Trait.Defense);
                return Query(this, query);
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
                    query.Result = query.Result + _game.Creatures.OfType<GoblinKing>().Count();
                    break;
            }

            return query.Result;
        }
    }
}
