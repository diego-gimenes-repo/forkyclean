using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForkyAI.Infrastructure.Interfaces
{
    public interface ISemanticKernelService
    {
        Task<string> ProcessAsync(string input);
        Task TrainAsync(IEnumerable<string> trainingData);
        Task<string> GetMemoryAsync();
    }   
}
