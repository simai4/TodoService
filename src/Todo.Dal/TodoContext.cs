using Microsoft.EntityFrameworkCore;

namespace Todo.Dal
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItemModel> TodoItems { get; set; }
    }
}