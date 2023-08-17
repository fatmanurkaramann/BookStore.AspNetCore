using Core.DataAccess;
using DataAccess.Abstract.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Category
{
    public class CategoryDal : Repository<Entities.Category, BookAppDbContext>, ICategoryDal
    {
        public CategoryDal(BookAppDbContext context) : base(context)
        {
        }
    }
}
