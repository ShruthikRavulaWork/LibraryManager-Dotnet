using System.ComponentModel.DataAnnotations;

namespace LibraryApiConsumer.Models
{
    public class LibraryItemDto
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Author { get; set; } = null!;

        [Range(1450, 2100)]
        public int YearPublished { get; set; }
    }
}
