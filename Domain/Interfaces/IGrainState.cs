using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForkyAI.Domain.Interfaces
{
    public interface IGrainState
    {
        Guid Id { get; }
        string Type { get; }
        DateTime LastModified { get; }
    }

}
