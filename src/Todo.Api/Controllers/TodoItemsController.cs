using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Api.Dto;
using Todo.Api.Infrastructure;
using Todo.Business;
using Todo.Business.Contracts;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [NotFoundExceptionFilter]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;

        public TodoItemsController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
        {
            return (await _todoItemService.GetTodoItems()).Select(item => ItemToDTO(item)).ToArray();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
        {
            var todoItem = await _todoItemService.GetTodoItem(id);

            return ItemToDTO(todoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(long id, TodoItemDTO todoItemDTO)
        {
            if (id != todoItemDTO.Id)
            {
                return BadRequest();
            }

            var entity = DTOToItem(todoItemDTO);

            await _todoItemService.UpdateTodoItem(id, entity);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> CreateTodoItem(TodoItemDTO todoItemDTO)
        {
            var todoItem = DTOToItem(todoItemDTO);
            var result = await _todoItemService.CreateTodoItem(todoItem);

            return CreatedAtAction(
                nameof(GetTodoItem),
                new { id = result.Id },
                ItemToDTO(result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            await _todoItemService.DeleteTodoItem(id);

            return NoContent();
        }

        private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
            new TodoItemDTO
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };

        private static TodoItem DTOToItem(TodoItemDTO todoItem) =>
            new TodoItem()
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
    }
}
