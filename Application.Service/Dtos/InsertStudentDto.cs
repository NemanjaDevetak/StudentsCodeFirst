using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Dtos
{
    public class InsertStudentDto
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentIndex { get; set; }
        public AddressDto Address { get; set; }
    }
}
