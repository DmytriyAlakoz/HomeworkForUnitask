using System.Threading.Tasks;
using EmployeeService.Interfaces;

namespace EmployeeService
{
    public class UpdateEmployeeEnableStatusUseCase
    {
        private readonly IEmployeeStore _store;

        public UpdateEmployeeEnableStatusUseCase(IEmployeeStore store)
        {
            this._store = store;
        }

        public async Task Execute(int id, int enableStatus)
        {
            if (enableStatus > 0)
            {
                await this._store.EnableEmployee(id);
            }
            else
            {
                await this._store.DisableEmployee(id);
            }
        }
    }
}