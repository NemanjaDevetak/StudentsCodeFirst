using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Dtos
{
    public class GetStudentDto
    {
        public int Id { get; set; }
        public string StudentIndex { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
