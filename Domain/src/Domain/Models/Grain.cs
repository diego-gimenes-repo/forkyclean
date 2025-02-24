using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans;

namespace Domain.src.Domain.Models
{
    public abstract class Grain : IGrainWithIntegerKey
    {
        protected ImmutableDictionary<string, object> State { get; private set; }

        public Grain(ImmutableDictionary<string, object> state)
        {
            State = state;
        }

        public virtual Task InitializeAsync(string grainType)
        {
            State = State.SetItem(nameof(grainType), grainType);
            return Task.CompletedTask;
        }
    }
}
