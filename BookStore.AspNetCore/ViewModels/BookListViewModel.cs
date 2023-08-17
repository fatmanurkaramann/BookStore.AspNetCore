
namespace BookStore.AspNetCore.ViewModels
{
    public class BookListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
