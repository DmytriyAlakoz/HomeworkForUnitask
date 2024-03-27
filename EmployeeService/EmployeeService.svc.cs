using System.Threading.Tasks;
using EmployeeService.App_Data;
using EmployeeService.Interfaces;
using EmployeeService.Models;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IEmployeeService
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