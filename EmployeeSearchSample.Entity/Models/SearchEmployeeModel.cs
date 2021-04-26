using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeSearchSample.Entity.Models
{
    public class SearchEmployeeModel
    {
        public string SearchingName { get; set; }
        public DateTime StartDateEmployement { get; set; }
        public DateTime EndDateEmployement { get; set; }
    }
}
