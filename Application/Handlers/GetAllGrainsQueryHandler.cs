using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForkyAI.Application.Queries;

namespace ForkyAI.Application.Handlers
{
    public class GetAllGrainsQueryHandler : IQueryHandler<GetAllGrainsQuery, IEnumerable<GrainResponse>>
    {
        private readonly IClusterClient _clusterClient;

        public GetAllGrainsQueryHandler(IClusterClient clusterClient)
        {
            _clusterClient = clusterClient;
        }

        public async Task<IEnumerable<GrainResponse>> Handle(GetAllGrainsQuery request, CancellationToken cancellationToken)
        {
            var grains = await _clusterClient.GetGrain<IManagementGrain>(0)
                .GetAllGrainsAsync(cancellationToken);

            return grains.Select(g => new GrainResponse
            {
                Id = g.Key,
                Type = g.Value.Type,
                Status = g.Value.Status
            });
        }
    }
}
