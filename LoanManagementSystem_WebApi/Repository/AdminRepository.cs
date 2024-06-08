using LoanManagementSystem_WebApi.Model;
using LoanManagementSystem_WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem_WebApi.Repository
{
    // This is the Admin Repository
    public class AdminRepository : IAdminRepository
    {

        //first through DI we need to create a instance of the Database context for the Entity Framework

        //----------------------------------------------------------
        private readonly LmsDbContext _context;

        public AdminRepository(LmsDbContext context)
        {
            _context = context;
        }



        //-----------------------------------------------------------

        #region Get Details of Loans Applied By Every Customer

        public async Task<ActionResult<IEnumerable<vw_LoanRequest>>> GetAllRequestedLoans()
        {
            if(_context != null)
            {
               return await (from r in _context.LoanRequests
                       from c in _context.Customers
                       from l in _context.Loans
                       where r.LoanId == l.LoanId && r.CustId == c.CustId
                       select new vw_LoanRequest
                       {
                           CustId = c.CustId,
                           RequestId = r.RequestId,
                           LoanId = l.LoanId,
                           LoanName = l.LoanName,
                           CustomerName = c.CustFirstName + " " + c.CustLastName,
                           LoanPurpose = r.LoanPurpose,
                           LoanRequestDate = r.LoanRequestDate,
                           RequestedAmount = r.RequestedAmount
                       }).ToListAsync();
            }

            return null;
            
        }


        #endregion

    }
}
