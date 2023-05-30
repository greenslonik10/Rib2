using Serilog;

namespace Diary.WebAPI.AppConfiguration.ServicesExtensions
{
    public static partial class SerilogConfigurations
    {
        /// <summary>
        /// Add serilog configuration
        /// </summary>
        /// <param name="app"></param>
        public static void AddSerilogConfiguration(this WebApplicationBuilder app)
        {
            app.Host.UseSerilog((context, loggerConfiguration) =>
            {
                loggerConfiguration
                .Enrich.WithCorrelationId()
                .ReadFrom.Configuration(context.Configuration);
            });

            app.Services.AddHttpContextAccessor();
        }
    }
}