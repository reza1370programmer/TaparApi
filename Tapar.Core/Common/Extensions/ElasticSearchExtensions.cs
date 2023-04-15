
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;


//namespace Tapar.Core.Common.Extensions
//{
//    public static class ElasticSearchExtensions
//    {

//        public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
//        {
//            List<string> list = new();
//            var url = configuration["ELKConfiguration:Uri"];
//            var defaultIndex = configuration["ELKConfiguration:index"];
//            var settings = new ConnectionSettings(new Uri(url)).PrettyJson().DefaultIndex(defaultIndex).DisableDirectStreaming();
//            var client = new ElasticClient(settings);
//            services.AddSingleton<IElasticClient>(client);
//            if (!client.Indices.Exists(defaultIndex).Exists)
//                CreateIndex(client, defaultIndex);
//        }
//        public static void CreateIndex(IElasticClient client, string indexName)
//        {
//            client.Indices.Create(indexName, i => i.Map<PlaceIndex>(x => x.AutoMap()));
//        }
//    }
//}
