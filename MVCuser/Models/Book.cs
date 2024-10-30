using System.ComponentModel.DataAnnotations;

namespace MVCuser.Models
{
    public class Book
    {
        [Required]
        [Key]
        public int id { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
