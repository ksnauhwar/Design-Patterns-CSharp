using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.BrokerChain
{
    public class Game
    {
        public EventHandler<Query> Queries;

        public void PerformQuery(object sender, Query query)
        {
            Queries?.Invoke(sender, query);
        }
    }
}
