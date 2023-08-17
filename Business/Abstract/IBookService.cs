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
        Task<Book> GetById(int id);
        Task< int> Add(BookDto book);
        Task<int> Update(BookDto book);
        Task<int> DeleteById(int id);
    }
}
