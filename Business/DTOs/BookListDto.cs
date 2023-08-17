using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class BookListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int PageCount { get; set; }
        public string ImagePath { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public AuthorDto Author { get; set; }
        public CategoryDto Category { get; set; }
    }
}
