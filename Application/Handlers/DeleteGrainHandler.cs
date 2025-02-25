
using ForkyAI.Application.Commands;
using MediatR;

namespace Application.Handlers
{
    public class DeleteGrainHandler : ICommandHandler<DeleteGrainCommand>
    {
        private readonly IClusterClient _clusterClient;

        public DeleteGrainHandler(IClusterClient clusterClient)
        {
            _clusterClient = clusterClient;
        }

        public async Task<Unit> Handle(DeleteGrainCommand request, CancellationToken cancellationToken)
        {
            var grain = _clusterClient.GetGrain<IGrain>(request.Id);
            await grain.DeactivateAsync();

            return Unit.Value;
        }
    }
}
