using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.src.Domain.Events
{
    public class GrainInitializedEvent : IDomainEvent
    {
        public Guid GrainId { get; }
        public string GrainType { get; }
        public DateTime Timestamp { get; }

        public GrainInitializedEvent(Guid grainId, string grainType)
        {
            GrainId = grainId;
            GrainType = grainType;
            Timestamp = DateTime.UtcNow;
        }
    }
}
