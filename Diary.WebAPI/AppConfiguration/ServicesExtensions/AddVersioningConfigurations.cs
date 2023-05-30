
using Microsoft.AspNetCore.Mvc;

namespace Diary.WebAPI.AppConfiguration.ServicesExtensions
{
    /// <summary>
    /// Services extensions
    /// </summary>
    public static partial class VersioningConfigurations
    {
        /// <summary>
        /// Configure versioning
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddVersioningConfiguration(this IServiceCollection services)
        {
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            return services;
        }
    }

}