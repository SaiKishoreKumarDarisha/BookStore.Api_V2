using System.ComponentModel.DataAnnotations;

namespace BookStore.Api_V2.Models
{
    public class SignInModel
    {
        [Required]
        [EmailAddress]
        public string  Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
