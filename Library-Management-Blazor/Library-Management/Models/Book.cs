using System.ComponentModel.DataAnnotations;

namespace Library_Management.Models
{
    public class Book
    {
        [Required]
        public string Title { get; set; } = "";

        [Required]
        public string Author { get; set; } = "";

        [Required]
        public string ISBN { get; set; } = "";

        [Required]
        public int PublishYear { get; set; }
    }
}
