
using System.ComponentModel.DataAnnotations;

namespace BookStore.AspNetCore.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "İsim alanı boş olamaz")]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int PageCount { get; set; }
        [Required]
        public string ImagePath { get; set; }
        public DateTime PublishDate { get; set; }
        [Required]
        public string Author { get; set; }
        public string Description { get; set; }
    }
}
