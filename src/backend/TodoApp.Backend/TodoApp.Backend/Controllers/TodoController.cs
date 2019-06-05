using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Equilaterus.Vortex;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Domain.Behaviors;
using TodoApp.Domain.Infrastructure.Repositories;
using TodoApp.Domain.Models;

namespace TodoApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        protected readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Todo>>> GetAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Todo>> GetByIdAsync(int id)
        {
            var maybe = new Maybe<int>(id);            

            return await
                from result in maybe.AwaitSideEffect(_id => _repository.FirstAsync(t => t.Id == _id))
                select result.Match<ActionResult>(Ok, NotFound());
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateTodoAsync(Todo todo)
        {
            var maybe = new Maybe<Todo>(todo);
 
            return await 
                from result in maybe.AwaitSideEffect(_repository.CreateAsync)
                select result.Match<ActionResult>(
                    _todo => CreatedAtAction(nameof(GetByIdAsync), new { _todo.Id }, _todo), 
                    BadRequest());
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateTodoAsync(int id, Todo todo)
        {
            return await
                from maybeTodo in
                    from persitedTodo in _repository.FirstAsync(t => t.Id == id)
                    select TodoBehavior.TryUpdate(persitedTodo, todo)
                from result in maybeTodo.AwaitSideEffect(_repository.UpdateAsync)
                select result.Match<IActionResult>(_ => NoContent(), NotFound());
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteTodoAsync(int id)
        {
            return await
                from maybeTodo in
                    from persitedTodo in _repository.FirstAsync(t => t.Id == id)
                    select TodoBehavior.TryDelete(persitedTodo)
                from result in maybeTodo.AwaitSideEffect(_repository.DeleteAsync)
                select result.MatchBool<IActionResult>(_ => NoContent(), NotFound());
        }
    }
}