using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoApp { get; set; }
    }
}
