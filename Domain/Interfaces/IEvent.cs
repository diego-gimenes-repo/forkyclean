using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForkyAI.Domain.Interfaces
{
    public interface IEvent
    {
        Guid Id { get; }
        DateTime Timestamp { get; }
    }
}
