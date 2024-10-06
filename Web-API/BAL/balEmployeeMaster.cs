using System;
using Web_API.DAL;
using Web_API.Models;

namespace Web_API.BAL
{
    public class balEmployeeMaster : IbalEmployeeMaster
    {
        private IdalEmployeeMaster dalEmployee;
        public balEmployeeMaster()
        {
            dalEmployee = new dalEmployeeMaster();
        }
        public async Task<bool> InsUpd_Employes(EmployeeModel employee)
        {
            return await dalEmployee.InsUpd_Employes(employee);
        }
        public async Task<List<EmployeeModel>> Load_Employes(int iEmpId)
        {
            return await dalEmployee.Load_Employes(iEmpId);
        }
    }
}
