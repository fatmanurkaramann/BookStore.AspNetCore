using Business.DTOs;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookService
    {
        List<Book> GetAll();
        Task<Book> GetByIdAsync(int id);
        Task<Book> NoTrackingGetByIdAsync(int id);
        Task< int> Add(BookDto book);
        Task<int> Update(BookUpdateDto book);
        Task<int> DeleteById(int id);
    }
}
