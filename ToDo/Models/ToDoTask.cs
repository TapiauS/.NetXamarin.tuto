using System;
using SQLite;

namespace ToDo.Models
{
    public class ToDoTask
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Validate { get; set; }
    }
}