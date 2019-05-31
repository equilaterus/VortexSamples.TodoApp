using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Models;

namespace TodoApp.Domain.Infrastructure.Data
{
    public class Context : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public Context(DbContextOptions<DbContext> options) : base(options)
        {

        }
    }
}
