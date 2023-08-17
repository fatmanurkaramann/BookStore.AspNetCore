using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Category:IEntity
    {
        public string CategoryName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
