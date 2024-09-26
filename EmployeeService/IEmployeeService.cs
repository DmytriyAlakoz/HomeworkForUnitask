using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using EmployeeService.Models;


namespace EmployeeService
{
    [ServiceContract]
    public interface IEmployeeService
    {
        /// <summary>
        /// Get employee and all his first level subordinates.
        /// </summary>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetEmployeeById?id={id}",
            ResponseFormat = WebMessageFormat.Json,  BodyStyle = WebMessageBodyStyle.Bare)]
        Task<Employee> GetEmployeeById(int id);

        /// <summary>
        /// Enable/Disable employee.
        /// </summary>
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "EnableEmployee?id={id}", 
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Task EnableEmployee(int id, int enable);
    }

	
}
