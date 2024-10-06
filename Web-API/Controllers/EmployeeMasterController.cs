using Microsoft.AspNetCore.Mvc;
using Web_API.BAL;
using Web_API.Models;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeMasterController : ControllerBase
    {
        IbalEmployeeMaster balEmployee = new balEmployeeMaster();

        [HttpGet("Load_Employes/{iEmpId}")]
        public async Task<IActionResult> Load_Employes(int iEmpId)
        {
            try
            {
                return Ok(await balEmployee.Load_Employes(iEmpId));
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost("Insert_Employee")]
        public async Task<IActionResult> Insert_Employee(EmployeeModel employee)
        {
            try
            {
                bool Inserted = await balEmployee.InsUpd_Employes(employee);
                if (Inserted)
                    return Ok("Data SuccessFully Inserted ");
                else
                    return Ok("Data Inserted Un SuccessFully");
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
       
    }
}