using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Models;

namespace TodoApp.Domain.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        public Task CreateAsync(Todo entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Todo entity)
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

        public Task UpdateAsync(Todo entity)
        {
            throw new NotImplementedException();
        }
    }
}
