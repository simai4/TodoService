using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todo.Business.Contracts
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetTodoItems();

        Task<TodoItem> GetTodoItem(long id);

        Task UpdateTodoItem(long id, TodoItem todoItem);

        Task<TodoItem> CreateTodoItem(TodoItem todoItemDTO);

        Task DeleteTodoItem(long id);
    }
}
