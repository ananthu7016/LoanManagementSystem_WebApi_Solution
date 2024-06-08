using LoanManagementSystem_WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem_WebApi.Repository
{

    // This is the interface of admin repository 
    public interface IAdminRepository
    {

        #region Get Details of Loans Applied By Every Customer

        Task<ActionResult<IEnumerable<vw_LoanRequest>>> GetAllRequestedLoans();


        #endregion

    }
}
