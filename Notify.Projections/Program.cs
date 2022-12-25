using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nofity.Core.Repositories;
using Notify.Projections.Projections;
using Notify.SQL;
using Tacta.EventStore.Projector;
using Tacta.EventStore.Repository;

namespace Notify.Projections
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

                    services.AddTransient<IProjection, ReminderReadModelProjection>();

                    services.AddTransient<IProjectionProcessor, ProjectionProcessor>();
                });
    }
}
