using System;
using System.ComponentModel.DataAnnotations;

namespace Business.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required(ErrorMessage ="Fiyat giriniz.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Sayfa sayısı giriniz.")]
        public int PageCount { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int CategoryId { get; set; }

    }
}
