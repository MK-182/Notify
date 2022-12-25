using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nofity.Core.Repositories;

namespace Notify.Sender
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly IReminderReadModelRepository _reminderReadModelRepository;

        public Worker(ILogger<Worker> logger, IReminderReadModelRepository reminderReadModelRepository)
        {
            _reminderReadModelRepository = reminderReadModelRepository;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var notificationsToSend = await _reminderReadModelRepository.GetAllToSendAsync().ConfigureAwait(false);
                
                _logger.LogInformation("Notifications to send: {count}", notificationsToSend.Count());

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
