using Serilog;

namespace Diary.WebAPI.AppConfiguration.ApplicationExtensions
{
    public static partial class SerilogConfiguratios
    {
        /// <summary>
        /// Use serilog configuration
        /// </summary>
        /// <param name="app"></param>
        public static IApplicationBuilder UseSerilogConfiguration(this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging();

            return app;
        }
    }
}