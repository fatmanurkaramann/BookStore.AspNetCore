using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class CreateAuthorDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<University> Universities { get; set; }
        public int BookId { get; set; }
        public int AddressId { get; set; }
        public BookDto Book { get; set; }
    }
}
