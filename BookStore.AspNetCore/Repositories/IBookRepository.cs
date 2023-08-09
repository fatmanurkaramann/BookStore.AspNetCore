using BookStore.AspNetCore.Models;

namespace BookStore.AspNetCore.Repositories
{
    public interface IBookRepository
    {
        void Add(Book book);
        void Update(Book book);
        void Remove(int id);
        List<Book> GetAll();
        Book Get(int id);
    }
}
