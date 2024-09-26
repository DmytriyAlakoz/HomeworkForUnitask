using System.Threading.Tasks;
using EmployeeService.App_Data;
using EmployeeService.Interfaces;
using EmployeeService.Models;

namespace EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeStore _store = new EmployeeStore();

        /// <inheritdoc />
        public async Task<Employee> GetEmployeeById(int id)
        {
            var useCase = new GetEmployeeByIdUseCase(this._store);
            return await useCase.Execute(id);
        }

        /// <inheritdoc />
        public async Task EnableEmployee(int id, int enable)
        {
            var useCase = new UpdateEmployeeEnableStatusUseCase(this._store);
            await useCase.Execute(id, enable);
        }
    }
}