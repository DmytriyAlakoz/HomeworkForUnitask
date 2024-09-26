using System.Threading.Tasks;
using EmployeeService.Interfaces;
using EmployeeService.Models;

namespace EmployeeService
{
    /// <summary>
    /// Provide functionality to get employee.
    /// </summary>
    public class GetEmployeeByIdUseCase
    {
        private readonly IEmployeeStore _store;

        public GetEmployeeByIdUseCase(IEmployeeStore store)
        {
            this._store = store;
        }
        
        public async Task<Employee> Execute(int id)
        {
            return await this._store.GetEmployeeById(id);
        }
    }
}