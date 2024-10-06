using MySql.Data.MySqlClient;
using System.Data;
using Web_API.Models;

namespace Web_API.DAL
{
    public class dalEmployeeMaster : IdalEmployeeMaster
    {
        dbhelper dh = new dbhelper();
        public async Task<bool> InsUpd_Employes(EmployeeModel employee)
        {
            DataAccessparameters dtacparam = new DataAccessparameters();
            dtacparam.CommandType = CommandType.StoredProcedure;
            dtacparam.CommandName = "InsUpd_Employee";

            var parem1 = new MySqlParameter("_EmpId", MySqlDbType.Int32);
            parem1.Value = employee.iEmpId;
            dtacparam.MySQLParams.Add(parem1);

            var parem2 = new MySqlParameter("_EmpName", MySqlDbType.VarChar);
            parem2.Value = employee.strEmpName;
            dtacparam.MySQLParams.Add(parem2);

            var parem3 = new MySqlParameter("_Address", MySqlDbType.VarChar);
            parem3.Value = employee.strAddress;
            dtacparam.MySQLParams.Add(parem3);
            
            var parem4 = new MySqlParameter("_Mobile", MySqlDbType.VarChar);
            parem4.Value = employee.strMobile;
            dtacparam.MySQLParams.Add(parem4);
            
            var parem5 = new MySqlParameter("_Email", MySqlDbType.VarChar);
            parem5.Value = employee.strEmail;
            dtacparam.MySQLParams.Add(parem5); 
            
            var parem6 = new MySqlParameter("_Salery", MySqlDbType.Decimal);
            parem6.Value = employee.dSalery;
            dtacparam.MySQLParams.Add(parem6);

            var parem7 = new MySqlParameter("_Status", MySqlDbType.VarChar);
            parem7.Value = employee.iStatus;
            dtacparam.MySQLParams.Add(parem7);

           return await dh.ExecuteNonQuery(dtacparam);
        }
        public async Task<List<EmployeeModel>> Load_Employes(int iEmpId)
        {
            DataAccessparameters dtacparam = new DataAccessparameters();
            dtacparam.CommandType = CommandType.StoredProcedure;
            dtacparam.CommandName = "Load_Employee";

            var parem1 = new MySqlParameter("_EmpId", MySqlDbType.Int32);
            parem1.Value = iEmpId;
            dtacparam.MySQLParams.Add(parem1);

            dtacparam.ActionMapper = dbMapper.EmployeeModelMap;
            return await dh.ExecuteQuery<EmployeeModel>(dtacparam);
        }
    }
}
