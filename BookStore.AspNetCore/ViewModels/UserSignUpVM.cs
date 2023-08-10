using System.ComponentModel.DataAnnotations;

namespace BookStore.AspNetCore.ViewModels
{
    public class UserSignUpVM
    {
      
        [Required(ErrorMessage ="Lütfen ad soyad giriniz!")]
        public string NameSurname { get; set; }
        [Required]
        public string Password { get; set; }
        [EmailAddress(ErrorMessage ="Lütfen doğru email giriniz!")]
        public string Email { get; set; }
        [Required]

        public string Username { get; set; }
    }
}
