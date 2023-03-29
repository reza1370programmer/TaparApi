
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using Tapar.Data.ES_Entities;

namespace Tapar.Core.Common.Extensions
{
    public static class ElasticSearchExtensions
    {
        public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["ELKConfiguration:Uri"];
            var defaultIndex = configuration["ELKConfiguration:index"];
            var settings = new ConnectionSettings(new Uri(url)).PrettyJson().DefaultIndex(defaultIndex);
            var client = new ElasticClient(settings);
            services.AddSingleton<IElasticClient>(client);
            CreateIndex(client, defaultIndex);
        }
        public static void CreateIndex(IElasticClient client, string indexName)
        {
            client.Indices.Create(indexName, i => i.Map<PlaceIndex>(x => x.AutoMap()));
        }
    }
}
