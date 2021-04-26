using EmployeeSearchSample.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSearchSample.Data.DBContext
{
    public class EmployeeSearchSampleApiDBContext : DbContext
    {
        public DbSet<EmployeeModel> Employees { get; set; }

        public EmployeeSearchSampleApiDBContext(DbContextOptions<EmployeeSearchSampleApiDBContext> options)
           : base(options)
        {
            AddTestData();
        }
        public async Task<List<EmployeeModel>> GetEmployees()
        {
            return Employees.Local.AsQueryable().AsTracking().ToList<EmployeeModel>();
        }
        public async Task<IEnumerable<EmployeeModel>> SearchEmployees(SearchEmployeeModel searchEmployeeModel)
        {
            IEnumerable<EmployeeModel> returnList = null;
            try
            {
                DateTime start = searchEmployeeModel.StartDateEmployement;
                DateTime end = searchEmployeeModel.EndDateEmployement;

                returnList = Employees.Local.AsQueryable().AsTracking().Where(f =>
                (f.FirstName.ToLower().Contains(searchEmployeeModel.SearchingName.ToLower())
                | f.LastName.ToLower().Contains(searchEmployeeModel.SearchingName.ToLower())) & (f.StartDateEmployement >= searchEmployeeModel.StartDateEmployement
                                                                                                && f.EndDateEmployement <= searchEmployeeModel.EndDateEmployement));
            }
            catch (Exception)
            {
                throw;
            }
            return returnList;
        }
        private void AddTestData()
        {
            if (!this.Employees.Any())
            {
                List<EmployeeModel> employeeModels = new List<EmployeeModel>();
                employeeModels.Add(new EmployeeModel()
                {
                    Id = 1,
                    FirstName = "Varun",
                    LastName = "Agarwal",
                    JobTitle = "Developer",
                    Age = 20,
                    StartDateEmployement = DateTime.Now,
                    EndDateEmployement = Convert.ToDateTime("01/01/2022"),
                    CreatedBy = Guid.NewGuid()
                });
                employeeModels.Add(new EmployeeModel()
                {
                    Id = 2,
                    FirstName = "Mahesh",
                    LastName = "Sharma",
                    JobTitle = "Accountant",
                    Age = 29,
                    StartDateEmployement= DateTime.Now,
                    EndDateEmployement = Convert.ToDateTime("01/01/2024"),
                    CreatedBy = Guid.NewGuid()
                });
                employeeModels.Add(new EmployeeModel()
                {
                    Id = 3,
                    FirstName = "Raj",
                    LastName = "Agarwal",
                    JobTitle = "Manager",
                    Age = 35,
                    StartDateEmployement = DateTime.Now,
                    EndDateEmployement = Convert.ToDateTime("01/01/2030"),
                    CreatedBy = Guid.NewGuid()
                });
                employeeModels.Add(new EmployeeModel()
                {
                    Id = 4,
                    FirstName = "Amit",
                    LastName = "Sharma",
                    JobTitle = "Developer",
                    Age = 28,
                    StartDateEmployement = DateTime.Now,
                    EndDateEmployement = Convert.ToDateTime("01/01/2023"),
                    CreatedBy = Guid.NewGuid()
                });
                Employees.AddRange(employeeModels);
            }
        }
    }
}
