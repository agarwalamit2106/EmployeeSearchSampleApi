using EmployeeSearchSample.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSearchSample.Entity.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeModel>> GetAllAsync();
        Task<EmployeeModel> GetAsync(int id);
        //Task<bool> CreateAsync(EmployeeModel product);
        //Task<bool> UpdateAsync(EmployeeModel product);
        //Task<bool> ExistsAsync(int id);
        //Task<bool> DeleteAsync(int id);
    }
}
