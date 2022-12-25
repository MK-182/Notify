using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Tacta.EventStore.Projector;
using Tacta.EventStore.Repository;

namespace Notify.Projections
{
    public class Worker : BackgroundService
    {
        private readonly IProjectionProcessor _projectionProcessor;

        public Worker(IProjectionProcessor projectionProcessor)
        {
            _projectionProcessor = projectionProcessor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        { 
            while (!stoppingToken.IsCancellationRequested)
            {
                await _projectionProcessor.Process();

                await Task.Delay(100, stoppingToken);
            }
        }
    }
}
