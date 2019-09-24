using System;

namespace CodingExercise
{
    public class Mediator
    {
        public event EventHandler<int> Alert;

        public void Broadcast(Participant participant, int value)
        {
            Alert?.Invoke(participant, value);
        }
    }
}
