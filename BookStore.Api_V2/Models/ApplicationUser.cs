using Microsoft.AspNetCore.Identity;

namespace BookStore.Api_V2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string  FirstName { get; set; }
        public string LastName { get; set; }

    }
}
