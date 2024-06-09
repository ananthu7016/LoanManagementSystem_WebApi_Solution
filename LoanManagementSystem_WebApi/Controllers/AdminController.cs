using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanManagementSystem_WebApi.Model;
using LoanManagementSystem_WebApi.Repository;
using LoanManagementSystem_WebApi.ViewModel;

namespace LoanManagementSystem_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        //first we need to get the instance of the IAdmin Repository through DI 

        //-------------------------------
        private readonly IAdminRepository _repository;

        public AdminController(IAdminRepository repository)
        {
            _repository = repository;
        }

        //-------------------------------


        #region Get Details of Loans Applied By Every Customer

        [HttpGet("requests")]
        public async Task<ActionResult<IEnumerable<vw_LoanRequest>>> GetAllRequestedLoans()
        {
            if (_repository != null)
            {
                return await _repository.GetAllRequestedLoans();
            }
            return null;
        }


        #endregion



        #region Get Details of All Loan Officers

        [HttpGet("officers")]
        public async Task<ActionResult<IEnumerable<vw_Dropdown>>> GetDetailsOfOfficers()
        {
            if (_repository != null)
                return await _repository.GetDetailsOfOfficers();
            else
                return null;
        }

        #endregion



        #region Assign a Officer for Verification

        [HttpPost("Assign")]
        public async Task<ActionResult<int>> AssignVerificationOfficer(LoanVerification detail)
        {
            if(_repository != null)
            {
                return await _repository.AssignVerificationOfficer(detail);
            }

            return 0;
        }

        #endregion


        #region Get all Details of Verified Loans for Approval

        [HttpGet("ToApprove")]
        public async Task<ActionResult<IEnumerable<vw_ApprovalDetails>>> GetDetailsOfLoanToApprove()
        {
            if(_repository != null)
                return await _repository.GetDetailsOfLoanToApprove();
            else
                return new List<vw_ApprovalDetails>();
        }

        #endregion



        #region Approve a Loan 
        [HttpPost("Approve")]
        public async Task<ActionResult<int>> ApproveALoan(vw_ApprovalDetails loan)
        {
            if(_repository != null)
               return await _repository.ApproveALoan(loan);   
            else
                return 0;
        }

        #endregion 



    }
}
