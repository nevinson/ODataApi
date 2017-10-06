using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Something.OData.Api.Models
{
    public class TodoList
    {
        public int TodoListId { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual List<TodoItem> Todos { get; set; }
    }
}