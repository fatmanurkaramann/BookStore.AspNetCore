//using BookStore.AspNetCore.AppDbContext;
//using BookStore.AspNetCore.Models;
//using Microsoft.EntityFrameworkCore;

//namespace BookStore.AspNetCore.Repositories
//{
//    public class BookRepository : IBookRepository
//    {
//        private readonly BookStoreDbContext _dbContext;

//        public BookRepository(BookStoreDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }
//        public DbSet<Book> Table => _dbContext.Set<Book>();

//        public void Add(Book book)
//        {
//            Table.Add(book);
//            _dbContext.SaveChanges();
//        }

//        public Book Get(int id,bool tracking=true)
//        {
//            //(tracking değeri false), sorgu sonuçlarındaki değişiklikler veritabanına yansıtılmadan alınabilir. 
//            var query = Table.AsQueryable();
//            if (!tracking)
//            {
//                query = Table.AsNoTracking();
//            }
//            return query.FirstOrDefault(c => c.Id == id); ;
//        }

//        public List<Book> GetAll()
//        {
//           return Table.ToList();
//        }

//        public void Remove(int id)
//        {
//            Book book = Table.Find(id);
//            Table.Remove(book);
//            _dbContext.SaveChanges();
//        }

//        public void Update(Book book)
//        {
//            Table.Update(book);
//            _dbContext.SaveChanges();
//        }
//    }
//}
