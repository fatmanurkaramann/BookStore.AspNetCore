using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Book : IEntity
    {
        public string Name { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int PageCount { get; set; }
        public string ImagePath { get; set; }
        public DateTime PublishDate { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
    }
}
