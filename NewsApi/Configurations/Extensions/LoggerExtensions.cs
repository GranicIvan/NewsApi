using Serilog;

namespace NewsApi.Configurations.Extensions
{
    public static class LoggerExtensions
    {

        public static void AddLogger(this WebApplicationBuilder builder)
        {

            var logger = new LoggerConfiguration()
              .ReadFrom.Configuration(builder.Configuration)
              .Enrich.FromLogContext()
              .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            
            builder.Services.AddSingleton<Serilog.ILogger>(logger);
        }
    }
}
