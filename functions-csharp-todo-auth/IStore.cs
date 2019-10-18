using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Models
{
    public interface IStore
    {
        Task<IList<ToDoItem>> GetItemsAsync(string userId);
        System.Threading.Tasks.Task PutItemAsync(ToDoItem item);
    }
}
