using AutoMapper;
using Business.Abstract;
using Business.DTOs;
using DataAccess.Abstract.Author;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorDal _authorDal;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorDal authorDal, IMapper mapper)
        {
            _authorDal = authorDal;
            _mapper = mapper;
        }

        public List<AuthorDto> GetAllAuthor()
        {
            var author = _authorDal.GetAll().ToList();
            List<AuthorDto> bookEntity = _mapper.Map<List<AuthorDto>>(author);
            return bookEntity;
        }

        public async Task<Author> GetById(int id)
        {
           return await _authorDal.GetByIdAsync(id);
        }
    }
}
