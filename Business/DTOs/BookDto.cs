using System;

namespace Business.DTOs
{
    public class BookDto
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
        public int CategoryId { get; set; }

    }
}
