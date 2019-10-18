using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Todo.Models
{
    public class ToDoItem
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; } = false;
    }
}
