using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Models
{
    class ToDoItem
    {
        public string Title { get; set; }
        public bool Completed { get; set; } = false;
    }
}
