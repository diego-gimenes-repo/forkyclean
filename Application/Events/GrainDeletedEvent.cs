

namespace ForkyAI.Application.Events
{
    public class GrainDeletedEvent : IDomainEvent
    {
        public Guid GrainId { get; }
        public DateTime Timestamp { get; }

        public GrainDeletedEvent(Guid grainId)
        {
            GrainId = grainId;
            Timestamp = DateTime.UtcNow;
        }
    }
}
