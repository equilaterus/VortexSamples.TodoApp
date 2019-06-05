using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Models;

namespace TodoApp.Domain.Infrastructure.Repositories
{
    public interface ITodoRepository
    {
        Task<List<Todo>> FindAllAsync();

        Task<List<Todo>> FindAsync(Expression<Func<Todo, bool>> filter);

        Task<Todo> FirstAsync(Expression<Func<Todo, bool>> filter);

        Task<Todo> UpdateAsync(Todo entity);

        Task<Todo> CreateAsync(Todo entity);

        Task<bool> DeleteAsync(Todo entity);
    }
}
