using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ForkyAI.Application.Commands
{
    public class UpdateGrainCommand : ICommand
    {
        public Guid Id { get; }
        public string GrainType { get; }

        public UpdateGrainCommand(Guid id, string grainType)
        {
            Id = id;
            GrainType = grainType;
        }
    }
}
