using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Models;

[assembly: FunctionsStartup(typeof(Todo.Startup))]
namespace Todo
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton(c =>
            {
                var cosmosClient = new CosmosClient(Environment.GetEnvironmentVariable("CosmosConnectionString"));
                var database = cosmosClient.GetDatabase(Environment.GetEnvironmentVariable("CosmosDatabase"));
                var container = database.GetContainer(Environment.GetEnvironmentVariable("CosmosContainer"));
                return container;
            });
            builder.Services.AddSingleton<IStore, CosmosStore>();
        }
    }
}
