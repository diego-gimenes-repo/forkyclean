using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ForkyAI.Application.Queries
{
    public class GetGrainQuery : IQuery<GrainResponse>
    {
        public Guid Id { get; }

        public GetGrainQuery(Guid id)
        {
            Id = id;
        }
    }
}
