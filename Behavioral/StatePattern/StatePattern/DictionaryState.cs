using System;
using System.Collections.Generic;
using System.Text;

namespace StatePattern
{
    public enum State
    {
        PhonePickedUp,
        PhoneKept
    }

    public enum Trigger
    {
        PhoneRinging,
        CallSomeOne,
        ConversationOver
    }

    public class Phone
    {
        public State CurrentState { get; set; }

        public Dictionary<State,List<(State,Trigger)>> State { get; set; }

        public Phone()
        {
            CurrentState = StatePattern.State.PhoneKept;
            State = new Dictionary<State, List<(State, Trigger)>>() {
                {
                    StatePattern.State.PhoneKept,
                      new List<(State, Trigger)>()
                      {
                          (StatePattern.State.PhonePickedUp, Trigger.CallSomeOne),
                          (StatePattern.State.PhonePickedUp, Trigger.PhoneRinging)
                      }
                },
                {
                    StatePattern.State.PhonePickedUp,
                    new List<(State, Trigger)>()
                    {
                        (StatePattern.State.PhoneKept,Trigger.ConversationOver)
                    }
                }
            };
        }
    }
}
