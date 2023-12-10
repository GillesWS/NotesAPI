using Notes.ApiClient.Models;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Text;

namespace Notes.ApiClient.IoC
{
    public static class ServiceCollectionExtension
    {
        public static void AddNoteApiClientService(this IServiceCollection services,
            Action<ApiClientOptions> options)
        {
            services.Configure(options);
            services.AddSingleton(provider =>
            {
                var options = provider.GetRequiredService<IOptions<ApiClientOptions>>().Value;
                return new NotesApiClientService(options);
            });
        }
    }
}
