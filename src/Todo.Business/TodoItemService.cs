using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Business.Contracts;

namespace Todo.Business
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoItemService(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public Task<IEnumerable<TodoItem>> GetTodoItems()
        {
            return _todoItemRepository.GetTodoItems();
        }

        public async Task<TodoItem> GetTodoItem(long id)
        {
            var result = await _todoItemRepository.GetTodoItem(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public async Task UpdateTodoItem(long id, TodoItem todoItem)
        {
             var todoItemDb = await _todoItemRepository.GetTodoItem(id);
            if (todoItem == null)
            {
                throw new NotFoundException();
            }

            todoItemDb.Update(todoItem);

            await _todoItemRepository.UpdateTodoItem(todoItemDb);
        }

        public Task<TodoItem> CreateTodoItem(TodoItem todoItem)
        {
            return _todoItemRepository.CreateTodoItem(todoItem);
        }

        public async Task DeleteTodoItem(long id)
        {
            var todoItem = await _todoItemRepository.GetTodoItem(id);

            if (todoItem == null)
            {
                throw new NotFoundException();
            }

            await _todoItemRepository.DeleteTodoItem(id); ;
        }
    }
}
