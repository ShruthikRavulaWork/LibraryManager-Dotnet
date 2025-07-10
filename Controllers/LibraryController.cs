using Microsoft.AspNetCore.Mvc;
using LibraryManager.Models;
using LibraryManager.DTOs;

namespace LibraryManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private static readonly List<LibraryItem> _libraryItems = new();
        private static int _nextId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<LibraryItem>> GetAll()
        {
            return Ok(_libraryItems);
        }

        [HttpGet("{id}")]
        public ActionResult<LibraryItem> GetById(int id)
        {
            var item = _libraryItems.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public ActionResult<LibraryItem> Create(LibraryItemDto dto)
        {
            var newItem = new LibraryItem
            {
                Id = _nextId++,
                Title = dto.Title,
                Author = dto.Author,
                YearPublished = dto.YearPublished
            };

            _libraryItems.Add(newItem);
            return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, LibraryItemDto dto)
        {
            var item = _libraryItems.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return NotFound();

            item.Title = dto.Title;
            item.Author = dto.Author;
            item.YearPublished = dto.YearPublished;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var item = _libraryItems.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return NotFound();

            _libraryItems.Remove(item);
            return NoContent();
        }
    }
}
