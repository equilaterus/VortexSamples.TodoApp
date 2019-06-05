using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Infrastructure.Data;
using TodoApp.Domain.Models;

namespace TodoApp.Domain.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private Context _context;

        public TodoRepository(Context context)
        {
            _context = context;
        }

        public async Task<Todo> CreateAsync(Todo entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            _context.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public async Task<bool> DeleteAsync(Todo entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Todo>> FindAllAsync()
        {
            IQueryable <Todo> query = _context.Todos.AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<List<Todo>> FindAsync(Expression<Func<Todo, bool>> filter)
        {
            IQueryable<Todo> query = _context.Todos.AsNoTracking();
            query.Where(filter);

            return await query.ToListAsync();
        }

        public async Task<Todo> FirstAsync(Expression<Func<Todo, bool>> filter)
        {
            IQueryable<Todo> query = _context.Todos.AsNoTracking();
            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<Todo> UpdateAsync(Todo entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }
    }
}
