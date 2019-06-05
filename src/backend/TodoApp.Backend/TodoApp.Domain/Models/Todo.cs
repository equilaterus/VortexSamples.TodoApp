namespace TodoApp.Domain.Models
{
    public class Todo
    {
        public int Id { get; set; }

        public string Title  { get; set; }

        public string Text { get; set; }

        public Todo() { }

        public Todo(Todo todo)
        {
            Id = todo.Id;
            Title = todo.Title;
            Text = todo.Text;
        }
    }
}
