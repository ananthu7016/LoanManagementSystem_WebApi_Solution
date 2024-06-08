using LoanManagementSystem_WebApi.Model;
using LoanManagementSystem_WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem_WebApi.Repository
{
    public class OfficerRepository : IOfficerRepository
    {


        // this is the implementation of the IOfficerInterface 
       
        //-------------------------
        // then through dependency injection we need intatiate the instance of Database context

        private readonly LmsDbContext _context;

        public OfficerRepository(LmsDbContext context)
        {
            _context = context;
        }

        //-------------------------


        #region Get Details of All Assigned Varification 

        public async Task<ActionResult<IEnumerable<vw_VerificationDetails>>> GetDetailsToVerify(int staff_id)
        {
            if(_context != null && staff_id !=0)
            {
                try
                {
             return await (from v in _context.LoanVerifications
                           from c in _context.Customers
                           from l in _context.Loans
                           from r in _context.LoanRequests
                           where v.RequestId == r.RequestId && r.CustId == c.CustId && r.LoanId == l.LoanId && v.StaffId == staff_id && v.VerificationStatus == true
                           select new vw_VerificationDetails
                           {
                              VerificationId = v.VerificationId,
                              RequestId = r.RequestId,
                              LoanName = l.LoanName,
                              CustomerName = c.CustFirstName+" "+c.CustLastName,
                              CustomerAddress= c.CustAddress,
                              CustomerAnnualIncome = c.CustAnnualIncome,
                              CustomerContact = c.CustPhone,
                              CustomerGender = c.CustGender,
                              CustomerNationality = c.CustNationality,
                              CustomerOccupation = c.CustOccupation,
                              LoanAmount = r.RequestedAmount,
                              LoanPurpose = r.LoanPurpose

                           }).ToListAsync();
                }
                catch { }
            }

            return null;
        }

        #endregion


    }
}
