using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Todo.Models
{
    public class CosmosStore : IStore
    {
        private readonly Container _cosmosContainer;
        public CosmosStore(Container cosmosContainer)
        {
            _cosmosContainer = cosmosContainer;
        }

        public async Task DeleteItemAsync(ToDoItem item)
        {
            await _cosmosContainer.DeleteItemAsync<ToDoItem>(item.Id.ToString(), new PartitionKey(item.UserId));
        }

        public async Task<IList<ToDoItem>> GetItemsAsync(string userId)
        {
            var sqlQueryText = $"SELECT * FROM c WHERE c.UserId = '{userId}'";
            QueryDefinition qd = new QueryDefinition(sqlQueryText);
            var iterator = _cosmosContainer.GetItemQueryIterator<ToDoItem>(qd);

            List<ToDoItem> items = new List<ToDoItem>();

            while (iterator.HasMoreResults)
            {
                FeedResponse<ToDoItem> currentResultSet = await iterator.ReadNextAsync();
                foreach (var item in currentResultSet)
                {
                    items.Add(item);
                }
            }

            return items;
        }

        public async Task PutItemAsync(ToDoItem item)
        {
            await _cosmosContainer.CreateItemAsync<ToDoItem>(item, new PartitionKey(item.UserId));
        }

        public async Task UpdateItemAsync(ToDoItem item)
        {
            await _cosmosContainer.UpsertItemAsync<ToDoItem>(item, new PartitionKey(item.UserId));
        }
    }
}
