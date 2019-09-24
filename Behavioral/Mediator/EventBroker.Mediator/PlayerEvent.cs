namespace EventBroker.Mediator
{
    public class PlayerEvent
    {
        public string Name { get; set; }
    }

    public class PlayerSentOffEvent : PlayerEvent
    {
        public string Reason { get; set; }
    }

    public class PlayerScoresEvent : PlayerEvent
    {
        public int GoalsScored { get; set; }
    }
}