using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForkyAI.Application.Events
{
    public class GrainUpdatedEvent : IDomainEvent
    {
        public Guid GrainId { get; }
        public string GrainType { get; }
        public DateTime Timestamp { get; }

        public GrainUpdatedEvent(Guid grainId, string grainType)
        {
            GrainId = grainId;
            GrainType = grainType;
            Timestamp = DateTime.UtcNow;
        }
    }
}
