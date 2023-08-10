using Microsoft.Build.Framework;

namespace BookStore.AspNetCore.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string Username { get; set; }
    }
}
