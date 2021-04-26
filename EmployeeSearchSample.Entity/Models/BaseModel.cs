using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeSearchSample.Entity.Models
{
    public class BaseModel
    {
        private DateTime createdOn = DateTime.Now;
       
       // [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid CreatedBy { get; set; }

        public DateTime CreatedOn { get => createdOn; set => createdOn = value; }

        public Guid ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
