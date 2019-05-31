using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Models;

namespace TodoApp.Domain.Infrastructure.Repositories
{
    public interface ITodoRepository
    {
        Task<List<Todo>> FindAllAsync();

        Task<List<Todo>> FindAsync(Predicate<Todo> filter);

        Task UpdateAsync(Todo entity);

        Task CreateAsync(Todo entity);

        Task DeleteAsync(Todo entity);
    }
}
