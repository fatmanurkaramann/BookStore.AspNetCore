using Business.Abstract;
using DataAccess.Abstract.Category;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
           return _categoryDal.GetAll(false).ToList();
        }

        public async Task<Category> GetById(int id)
        {
            return await _categoryDal.GetByIdAsync(id,false);
        }
    }
}
