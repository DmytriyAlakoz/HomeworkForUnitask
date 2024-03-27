using System.Threading.Tasks;
using EmployeeService.App_Data;

namespace EmployeeService
{
    public class UpdateEmployeeEnableStatusUseCase
    {
        public async Task Execute(int id, int enableStatus)
        {
            var employeeStore = new EmployeeStore();
            if (enableStatus > 0)
            {
                await employeeStore.EnableEmployee(id);
            }
            else
            {
                await employeeStore.DisableEmployee(id);
            }
        }
    }
}