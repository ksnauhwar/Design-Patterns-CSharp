using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility
{
    public class CreatureModifier
    {
        protected Creature creature { get; set; }

        public CreatureModifier next { get; set; }

        public CreatureModifier(Creature creature)
        {
            this.creature = creature;
        }

        public void Add(CreatureModifier creatureModifier)
        {
            if (next == null)
                next = creatureModifier;

            else
            next.Add(creatureModifier);
        }

        public virtual void Handle()
        {
            next?.Handle();
        }

    }
}
