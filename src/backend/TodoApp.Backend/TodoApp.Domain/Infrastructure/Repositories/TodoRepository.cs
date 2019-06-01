using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Models;

namespace TodoApp.Domain.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        public Task<Todo> CreateAsync(Todo entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Todo entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Todo>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Todo>> FindAsync(Predicate<Todo> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Todo> FirstAsync(Predicate<Todo> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Todo> UpdateAsync(Todo entity)
        {
            throw new NotImplementedException();
        }
    }
}
