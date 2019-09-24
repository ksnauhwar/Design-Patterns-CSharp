using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.BrokerChain
{
   public class Creature
    {
        private Game _game;
        private int _attack;
        private int _defence;
        public string Name;

        public Creature(Game game ,int attack,int defence,string creatureName)
        {
            _game = game;
            _attack = attack;
            _defence = defence;
            Name = creatureName;
        }

        public int Attack
        {
            get
            {
                var query = new Query(Name, Query.QueryType.Attack, _attack);
                _game.PerformQuery(this, query);
                return query.Result;
            }
        }

        public int Defence
        {
            get
            {
                var query = new Query(Name,Query.QueryType.Defence,_defence);
                _game.PerformQuery(this,query);
                return query.Result;
            }

        }


        public override string ToString() // no game
        {
            return $"{nameof(Name)}: {Name}, {nameof(_attack)}: {Attack}, {nameof(_defence)}: {Defence}";
        }
        }
    }
