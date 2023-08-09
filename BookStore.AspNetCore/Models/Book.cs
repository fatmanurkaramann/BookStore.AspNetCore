namespace BookStore.AspNetCore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int PageCount { get; set; }
        public string ImagePath { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
