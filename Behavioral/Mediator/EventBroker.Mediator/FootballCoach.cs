using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;

namespace EventBroker.Mediator
{
   public class FootballCoach : Actor
    {
        public FootballCoach(EventBroker broker) : base(broker)
        {
            broker.OfType<PlayerScoresEvent>().Subscribe(pe => Console.WriteLine($"Coach:Well done {pe.Name}"));
            broker.OfType<PlayerSentOffEvent>().Subscribe(pe =>
            {
                if (string.Equals(pe.Reason, "violence", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Coach:Fuck you {pe.Name}");
                }
                else
                {
                    Console.WriteLine($"Coach: Hard luch {pe.Name}");
                }
            });
        }


    }
}
