using System;

namespace CodingExercise
{
    public class Participant
    {
        public int Value { get; set; }
        private Mediator _mediator;

        public Participant(Mediator mediator)
        {
            _mediator = mediator;
            _mediator.Alert += React;
        }

        public void Say(int n)
        {
            _mediator.Broadcast(this, n);
        }

        public void React(object sender,int value)
        {
            if(sender.Equals(this) == false)
            Value = value;
        }
    }
}
