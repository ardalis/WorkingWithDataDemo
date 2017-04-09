using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModifyingDataDemo.Data;
using ModifyingDataDemo.Interfaces;
using ModifyingDataDemo.Models;
using System.Threading.Tasks;
using System.Linq;

namespace ModifyingDataDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/ToDoItems")]
    public class ToDoItemsController : Controller
    {
        private readonly IToDoItemRepository _todoRepository;
        public ToDoItemsController(IToDoItemRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            return Ok((await _todoRepository
                .ListAsync())
                .Select(t => new ToDoItemDTO { Id = t.Id, Name = t.Name, IsComplete = t.IsComplete }));
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody]ToDoItemAddDTO itemDto)
        {
            var item = new ToDoItem() { Name = itemDto.Name };
            await _todoRepository.AddAsync(item);
            return Ok(item);
        }
    }

    public class ToDoItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }

    public class ToDoItemAddDTO
    {
        public string Name { get; set; }
    }
}