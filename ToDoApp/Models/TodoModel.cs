using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    public class TodoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The Due Date field is required.")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "The Is Completed field is required.")]
        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; } 
    }
}
