﻿namespace ToDoApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; } 
        public DateTime CreatedAt { get; set; } 
    }


}
