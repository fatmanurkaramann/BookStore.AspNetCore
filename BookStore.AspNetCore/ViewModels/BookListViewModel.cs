using BookStore.AspNetCore.Models;

namespace BookStore.AspNetCore.ViewModels
{
    public class BookListViewModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
    }
}
