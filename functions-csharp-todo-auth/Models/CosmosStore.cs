using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Models
{
    class CosmosStore : IStore
    {
        private readonly Container _cosmosContainer;
        public CosmosStore(Container cosmosContainer)
        {
            _cosmosContainer = cosmosContainer;
        }
        public Task<IList<ToDoItem>> GetItemsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task PutItemAsync(ToDoItem item, string userId)
        {
            await _cosmosContainer.CreateItemAsync(item, new PartitionKey(userId));
        }
    }
}
