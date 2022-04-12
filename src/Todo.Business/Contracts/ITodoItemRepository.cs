using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Business.Contracts
{
    public interface ITodoItemRepository
    {
        Task<IEnumerable<TodoItem>> GetTodoItems();

        Task<TodoItem> GetTodoItem(long id);

        Task UpdateTodoItem(TodoItem todoItem);

        Task<TodoItem> CreateTodoItem(TodoItem todoItemDTO);

        Task DeleteTodoItem(long id);
    }
}
