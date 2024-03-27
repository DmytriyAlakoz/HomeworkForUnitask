using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.Models;

namespace EmployeeService.App_Data
{
    public class EmployeeStore
    {
        private const string ConnectionString = "Data Source=(local);Initial Catalog=Test;Trusted_Connection=True;";

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employeeTable = await this.ExecuteSqlWithResult($"select * from Employee where (ID = {id} or ManagerID = {id}) and Enable = 1");
            if (employeeTable.Rows.Count > 0)
            {
                var employees = new HashSet<Employee>();
                foreach (DataRow row in employeeTable.Rows)
                {
                    employees.Add(new Employee
                    {
                        ID = row.Field<int>("ID"),
                        Name = row.Field<string>("Name"),
                        ManagerID = row.Field<int?>("ManagerID"),
                        Enable = true,
                    });
                }

                var employee = employees.FirstOrDefault(x => x.ID == id);
                if (employee != null)
                {
                    employees.Remove(employee);
                    employee.Employees = employees;
                    return employee;
                }
            }

            return new EmptyEmployee();
        }
        
        public async Task EnableEmployee(int id)
        {
            await this.ExecuteSqlWithResult($"update Employee set Enable = 1 where ID = {id};");
        }
        
        public async Task DisableEmployee(int id)
        {
            await this.ExecuteSqlWithResult($"update Employee set Enable = 0 where ID = {id};");
        }
        
        private async Task<DataTable> ExecuteSqlWithResult(string query)
        {
            var dt = new DataTable();

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }
    }
}