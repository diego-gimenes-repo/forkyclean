﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ForkyAI.Application.Queries
{
    public class GetAllGrainsQuery : IQuery<IEnumerable<GrainResponse>>
    {
    }
}
