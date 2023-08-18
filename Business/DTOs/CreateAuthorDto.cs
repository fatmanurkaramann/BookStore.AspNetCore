using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class CreateAuthorDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public AddressDto Addresses { get; set; }
        public UniversityDto Universities { get; set; }
    }
}
