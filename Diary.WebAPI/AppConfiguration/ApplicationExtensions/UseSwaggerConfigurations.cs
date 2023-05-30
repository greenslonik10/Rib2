using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Duende.IdentityServer.Models;

namespace Diary.WebAPI.AppConfiguration.ApplicationExtensions
{
   
    public static partial class ApplicationExtensions
    {
         /// <summary>
        /// Use swagger configuration
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options=>
            {
                var provider= app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"{description.GroupName}/swagger.json",description.GroupName);
                };
                options.OAuthAppName("API - Swagger");

                options.OAuthClientId("swagger");
                options.OAuthClientSecret("swagger");
            });
        }
    }
}