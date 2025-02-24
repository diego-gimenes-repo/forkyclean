using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Application.Commands
{
    public class CreateGrainCommand : ICommand
    {
        public Guid Id { get; }
        public string GrainType { get; }

        public CreateGrainCommand(Guid id, string grainType)
        {
            Id = id;
            GrainType = grainType;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
