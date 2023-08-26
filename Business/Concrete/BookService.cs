using AutoMapper;
using Business.Abstract;
using Business.DTOs;
using DataAccess.Abstract.Book;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookDal _bookDal;

        public BookService(IBookDal bookDal, IMapper mapper)
        {
            _bookDal = bookDal;
            _mapper = mapper;
        }

        public async Task<int> Add(BookDto book)
        {
           var bookEntity =  _mapper.Map<Book>(book);
          return await _bookDal.AddAsync(bookEntity);
        }

        public async Task<int> DeleteById(int id)
        {
           return await _bookDal.Delete(id);
        }

        public List<Book> GetAll()
        {
            //Eager Loading (Yükleme):
            var book = _bookDal.GetAll(false).Include(b => b.Author)
                        .Include(b => b.Category).ToList();
            return book;
        }
       

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _bookDal.GetByIdAsync(id,false);
        }
        public async Task<Book> NoTrackingGetByIdAsync(int id)
        {
            return await _bookDal.NoTrackingGetById(id, false,true);
        }
        public async Task<int> Update(BookUpdateDto book)
        {
            var bookEntity = _mapper.Map<Book>(book);
            return await _bookDal.Update(bookEntity);
        }
    }
}
