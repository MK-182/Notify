using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nofity.Core.Repositories;
using Notify.SQL;
using Tacta.EventStore.Repository;

namespace Notify.Sender
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();

                    services.AddSingleton<ISqlConnectionFactory>(new SqlConnectionFactory());
                    services.AddTransient<IEventStoreRepository, EventStoreRepository>();

                    services.AddTransient<IReminderReadModelRepository, ReminderReadModelRepository>();
                });
    }
}
