using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeSearchSample.Entity.Models
{
    public class EmployeeModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public byte Age { get; set; }
        public DateTime StartDateEmployement { get; set; }
        public DateTime EndDateEmployement { get; set; }
    }
}
