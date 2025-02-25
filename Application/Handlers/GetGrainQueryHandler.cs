using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Queries;

namespace ForkyAI.Application.Handlers
{
    public class GetGrainQueryHandler : IQueryHandler<GetGrainQuery, GrainResponse>
    {
        private readonly IClusterClient _clusterClient;

        public GetGrainQueryHandler(IClusterClient clusterClient)
        {
            _clusterClient = clusterClient;
        }

        public async Task<GrainResponse> Handle(GetGrainQuery request, CancellationToken cancellationToken)
        {
            var grain = _clusterClient.GetGrain<IGrain>(request.Id);
            var state = await grain.GetStateAsync();

            return new GrainResponse
            {
                Id = request.Id,
                Type = state.Type,
                Status = state.Status
            };
        }
    }
}
