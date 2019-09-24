using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.BrokerChain
{
    public abstract class CreatureModifier : IDisposable
    {
        protected Creature creature;
        protected Game game;

        public CreatureModifier(Creature creature,Game game)
        {
            this.creature = creature;
            this.game = game;
            this.game.Queries += Handle;
        }

        public void Dispose()
        {
            game.Queries -= Handle;
        }

        protected abstract void Handle(object sender,Query query);
    }
}
