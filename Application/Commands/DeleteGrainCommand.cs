

namespace ForkyAI.Application.Commands
{
    public class DeleteGrainCommand : ICommand
    {
        public Guid Id { get; }

        public DeleteGrainCommand(Guid id)
        {
            Id = id;
        }
    }
}
