using System.ComponentModel.DataAnnotations;

namespace BookStore.Api_V2.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Add Title Property")]
        public string Titie { get; set; }
        
        [Required]
        public string Description { get; set; }
    }
}
