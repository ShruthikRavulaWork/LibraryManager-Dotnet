using LibraryManager.DTOs;
using LibraryManager.Models;
using LibraryManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _service;

        public LibraryController(ILibraryService service) => _service = service;

        [HttpGet]
        public ActionResult<IEnumerable<LibraryItem>> GetAll() =>
            Ok(_service.GetAll());

        [HttpGet("{id}")]
        public ActionResult<LibraryItem> GetById(int id)
        {
            var item = _service.GetById(id);
            if (item is null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public ActionResult<LibraryItem> Create(LibraryItemDto dto)
        {
            var item = _service.Create(dto);
            if (item is null)
                return BadRequest("Library is full");
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, LibraryItemDto dto) =>
            _service.Update(id, dto) ? NoContent() : NotFound();

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) =>
            _service.Delete(id) ? NoContent() : NotFound();
    }
}
