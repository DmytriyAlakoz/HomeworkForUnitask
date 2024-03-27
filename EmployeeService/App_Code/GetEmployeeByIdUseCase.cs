using System.Threading.Tasks;
using EmployeeService.App_Data;
using EmployeeService.Models;

namespace EmployeeService
{
    public class GetEmployeeByIdUseCase
    {
        public async Task<Employee> Execute(int id)
        {
            var employeeStore = new EmployeeStore();
            return await employeeStore.GetEmployeeById(id);
        }
    }
}