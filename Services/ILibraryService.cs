using LibraryManager.Models;
using LibraryManager.DTOs;

namespace LibraryManager.Services
{
    public interface ILibraryService
    {
        IEnumerable<LibraryItem> GetAll();
        LibraryItem? GetById(int id);
        LibraryItem? Create(LibraryItemDto dto);
        bool Update(int id, LibraryItemDto dto);
        bool Delete(int id);
    }
}
