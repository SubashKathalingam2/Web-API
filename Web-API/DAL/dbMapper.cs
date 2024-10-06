using MySql.Data.MySqlClient;
using Web_API.Models;

namespace Web_API.DAL
{
    internal sealed class dbMapper 
    {
        public static void EmployeeModelMap(MySqlDataReader reader, object model)
        {
            var employee = model as EmployeeModel;
            employee.iEmpId = Convert.ToInt32(reader["EmpId"].ToString());
            employee.strEmpName = reader["EmpName"].ToString();
            employee.dSalery = Convert.ToDecimal(reader["Salery"].ToString());
            employee.iStatus = Convert.ToInt32(reader["Status"].ToString());
            employee.strAddress = reader["Address"].ToString();
            employee.strEmail = reader["Email"].ToString();
            employee.strMobile = reader["Mobile"].ToString();
        }
    }
}
