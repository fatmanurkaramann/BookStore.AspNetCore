using Microsoft.AspNetCore.Identity;

namespace BookStore.AspNetCore.Models
{
    public class AppUser:IdentityUser<int>
    {
        public string NameSurname { get; set; }
    }
}
