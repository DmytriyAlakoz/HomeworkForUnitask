using System.Threading.Tasks;
using EmployeeService.Models;

namespace EmployeeService.Interfaces
{
    /// <summary>
    /// Repository for operations with employees.
    /// </summary>
    public interface IEmployeeStore
    {
        /// <summary>
        /// Retrieves an employee by their ID, including their subordinates if any.
        /// </summary>
        Task<Employee> GetEmployeeById(int id);

        /// <summary>
        /// Enables an employee by setting their Enable flag to true.
        /// </summary>
        Task EnableEmployee(int id);

        /// <summary>
        /// Disables an employee by setting their Enable flag to false.
        /// </summary>
        Task DisableEmployee(int id);
    }
}