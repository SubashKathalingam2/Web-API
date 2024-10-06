using Web_API.Models;

namespace Web_API.BAL
{
    public interface IbalEmployeeMaster
    {
        Task<bool> InsUpd_Employes(EmployeeModel employee);
        Task<List<EmployeeModel>> Load_Employes(int iEmpId);
    }
}
