using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.BrokerChain
{
    public class AttackModifier : CreatureModifier
    {
        public AttackModifier(Creature creature, Game game) : base(creature, game)
        {
        }

        protected override void Handle(object sender, Query query)
        {
            if (string.Equals(creature.Name, query.CreatureName, StringComparison.InvariantCultureIgnoreCase)
                && query.WhatToQuery == Query.QueryType.Attack)
            {
                query.Result *= 2;
            }
        }
    }
}
