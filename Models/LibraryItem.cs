namespace LibraryManager.Models
{
    public class LibraryItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int YearPublished { get; set; }
    }
}
