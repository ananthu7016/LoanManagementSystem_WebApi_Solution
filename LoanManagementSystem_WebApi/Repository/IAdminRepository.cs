using LoanManagementSystem_WebApi.Model;
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


        #region Get Details of All Loan Officers

        Task<ActionResult<IEnumerable<vw_Dropdown>>> GetDetailsOfOfficers();

        #endregion


        #region Assign a Officer for Verification

        Task<ActionResult<int>> AssignVerificationOfficer(LoanVerification detail);

        #endregion


        #region Get all Details of Verified Loans for Approval

        Task<ActionResult<IEnumerable<vw_ApprovalDetails>>> GetDetailsOfLoanToApprove();

        #endregion


        #region Approve a Loan 
        Task<ActionResult<int>> ApproveALoan(vw_ApprovalDetails loan);

        #endregion 

    }
}
