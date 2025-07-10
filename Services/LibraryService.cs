using LibraryManager.DTOs;
using LibraryManager.Models;
using Microsoft.Extensions.Options;

namespace LibraryManager.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly List<LibraryItem> _items = new();
        private readonly LibraryConfig _config;
        private int _nextId = 1;

        public LibraryService(IOptions<LibraryConfig> config)
        {
            _config = config.Value;
        }

        public IEnumerable<LibraryItem> GetAll() => _items;

        public LibraryItem? GetById(int id) =>
            _items.FirstOrDefault(x => x.Id == id);

        public LibraryItem? Create(LibraryItemDto dto)
        {
            if (_items.Count >= _config.MaxItems) return null;

            var item = new LibraryItem
            {
                Id = _nextId++,
                Title = dto.Title,
                Author = dto.Author,
                YearPublished = dto.YearPublished
            };
            _items.Add(item);
            return item;
        }

        public bool Update(int id, LibraryItemDto dto)
        {
            var item = GetById(id);
            if (item == null) return false;

            item.Title = dto.Title;
            item.Author = dto.Author;
            item.YearPublished = dto.YearPublished;
            return true;
        }

        public bool Delete(int id)
        {
            var item = GetById(id);
            if (item == null) return false;
            _items.Remove(item);
            return true;
        }
    }
}
