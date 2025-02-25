using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForkyAI.Application.Commands;
using MediatR;

namespace ForkyAI.Application.Handlers
{
    public class UpdateGrainHandler : ICommandHandler<UpdateGrainCommand>
    {
        private readonly IClusterClient _clusterClient;

        public UpdateGrainHandler(IClusterClient clusterClient)
        {
            _clusterClient = clusterClient;
        }

        public async Task<Unit> Handle(UpdateGrainCommand request, CancellationToken cancellationToken)
        {
            var grain = _clusterClient.GetGrain<IGrain>(request.Id);
            await grain.UpdateAsync(request.GrainType);

            return Unit.Value;
        }
    }
}
