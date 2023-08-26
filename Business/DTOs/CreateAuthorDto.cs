using DataAccess.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class CreateAuthorDto
    {
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public ICollection<AddressDto> Addresses { get; set; }
        public ICollection<UniversityDto> Universities { get; set; }
        public int BookId { get; set; }
        public int AddressId { get; set; }
    }
}
