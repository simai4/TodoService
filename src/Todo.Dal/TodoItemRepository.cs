using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Business;
using Todo.Business.Contracts;

namespace Todo.Dal
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly TodoContext _context;

        public TodoItemRepository(TodoContext todoContext)
        {
            _context = todoContext;
        }
        public async Task<TodoItem> CreateTodoItem(TodoItem todoItem)
        {
            var dbItem = new TodoItemModel();
            dbItem.Name = todoItem.Name;
            dbItem.IsComplete = todoItem.IsComplete;
            await _context.AddAsync(dbItem);
            await _context.SaveChangesAsync();
            return ModelToEntity(dbItem);
        }

        public async Task DeleteTodoItem(long id)
        {
            var dbItem = await _context.TodoItems.FindAsync(id);
            _context.Remove(dbItem);
            await _context.SaveChangesAsync();
        }

        public async Task<TodoItem> GetTodoItem(long id)
        {
            var dbItem = await _context.TodoItems.FindAsync(id);
            return ModelToEntity(dbItem);
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItems()
        {
            return (await _context.TodoItems
                .ToListAsync())
                .Select(item => ModelToEntity(item));
        }

        public async Task UpdateTodoItem(TodoItem todoItem)
        {
            var dbItem = await _context.TodoItems.FindAsync(todoItem.Id);
            dbItem.Name = todoItem.Name;
            dbItem.IsComplete = todoItem.IsComplete;
            await _context.SaveChangesAsync();
        }

        private  Func<TodoItemModel, TodoItem> ModelToEntity = (todoItemModel) =>

            todoItemModel == null? null:
            new TodoItem()
            {
                Id = todoItemModel.Id,
                Name = todoItemModel.Name,
                IsComplete = todoItemModel.IsComplete
            };
        
    }
}
