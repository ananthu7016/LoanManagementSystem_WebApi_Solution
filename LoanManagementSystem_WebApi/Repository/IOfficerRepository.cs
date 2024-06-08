using LoanManagementSystem_WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem_WebApi.Repository
{
    public interface IOfficerRepository
    {

        // this is the interface for Officer Repository 


        #region Get Details of All Assigned Varification 

        Task<ActionResult<IEnumerable<vw_VerificationDetails>>> GetDetailsToVerify(int staff_id);

        #endregion
    }
}
