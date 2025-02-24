using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForkyAI.Infrastructure.Interfaces
{
    public interface IObservabilityService
    {
        Task TrackEventAsync(string eventName, Dictionary<string, string> properties);
        Task RecordMetricAsync(string metricName, double value);
        Task LogErrorAsync(Exception exception, string message);
    }

}
