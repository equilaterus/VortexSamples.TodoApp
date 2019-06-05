using Equilaterus.Vortex;
using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Domain.Models;

namespace TodoApp.Domain.Behaviors
{
    public static class TodoBehavior
    {
        public static Maybe<Todo> TryUpdate(Todo persitedTodo, Todo newTodo)
        {
            return persitedTodo != null ?
                new Maybe<Todo>(new Todo(newTodo)) :
                new Maybe<Todo>();
        }

        public static Maybe<Todo> TryDelete(Todo persitedTodo)
        {
            return persitedTodo != null ?
                new Maybe<Todo>(new Todo(persitedTodo)) :
                new Maybe<Todo>();
        }
    }
}
