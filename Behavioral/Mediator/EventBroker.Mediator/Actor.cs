using System;
using System.Collections.Generic;
using System.Text;

namespace EventBroker.Mediator
{
    public class Actor
    {
        protected EventBroker _broker;

        public Actor(EventBroker broker)
        {
            _broker = broker;
        }
    }
}
