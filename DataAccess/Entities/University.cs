using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class University:IEntity
    {
        public string UniversityName { get; set; }
        public ICollection<Author> Authors { get; set; }

    }
}
