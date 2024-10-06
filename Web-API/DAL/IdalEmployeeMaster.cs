using Web_API.Models;

namespace Web_API.DAL
{
    public interface IdalEmployeeMaster
    {
      Task<bool> InsUpd_Employes(EmployeeModel employee);
      Task<List<EmployeeModel>> Load_Employes(int iEmpId);
    }
}
