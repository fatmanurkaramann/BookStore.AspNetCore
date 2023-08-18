using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class BookUpdateDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int PageCount { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public AuthorDto Author { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
