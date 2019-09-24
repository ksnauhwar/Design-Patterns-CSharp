using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;

namespace EventBroker.Mediator
{
    public class FootballPlayer : Actor
    {
        public string Name { get; set; }
        public int GoalsScored { get; set; }

        public FootballPlayer(EventBroker broker,string name) : base(broker)
        {
            Name = name;
            broker.OfType<PlayerScoresEvent>()
                .Where(pe => string.Equals(Name, pe.Name, StringComparison.OrdinalIgnoreCase) == false)
                .Subscribe(pe =>
            {
                if (string.Equals(Name, pe.Name, StringComparison.OrdinalIgnoreCase) == false && pe.GoalsScored < 3)
                {
                    Console.WriteLine($"{Name} : Woohoo! Nicely done {pe.Name}");
                }
                else
                {
                    Console.WriteLine($"{Name} : Boss Tha {pe.Name}");
                }
               
            });
            broker.OfType<PlayerSentOffEvent>().Subscribe(pe =>
            {
                if (string.Equals(Name, pe.Name, StringComparison.OrdinalIgnoreCase) == false)
                {
                    Console.WriteLine($"{Name} : You have cocked it now {pe.Name}, you moron!");
                }
            });
        }

        public void Score()
        {
            GoalsScored++;
            _broker.Publish(new PlayerScoresEvent { Name = this.Name,GoalsScored = this.GoalsScored});
        }

        public void KickRef()
        {
            _broker.Publish(new PlayerSentOffEvent() { Name = Name ,Reason="violence"});
        }
    }
}
