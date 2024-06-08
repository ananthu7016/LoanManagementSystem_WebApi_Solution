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
                       where r.LoanId == l.LoanId && r.CustId == c.CustId && r.RequestStatus==true
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



        #region Get Details of All Loan Officers

        public async Task<ActionResult<IEnumerable<vw_Dropdown>>> GetDetailsOfOfficers()
        {
           if( _context != null)
            {

                try
                {

                    return await (from s in _context.Staffs
                                  from u in _context.Users
                                  where s.UserId == u.UserId && u.RoleId == 3
                                  select new vw_Dropdown
                                  {
                                      Id = s.StaffId,
                                      Name = s.StaffFirstName + " " + s.StaffLastName
                                  }).ToListAsync();

                }
                catch(Exception ex) { }
         
            }

            return null;// is something went wrong exception will be returned.
        }

        #endregion


        #region Assign a Officer for Verification

        public async Task<ActionResult<int>> AssignVerificationOfficer(LoanVerification detail)
        {
            if(_context != null)
            {
                try
                {
                    detail.VerificationReview = "";
                    detail.VerificationStatus = true;
                      
                    // then we need to add the instce to DbContext
                    await _context.LoanVerifications.AddAsync(detail);
                    LoanRequest request = new LoanRequest();
                    try
                    {
                        // then after we assign we need to set the status of request to false 
                        request = await _context.LoanRequests.Where(r => r.RequestId == detail.RequestId).FirstAsync();

                    }
                    catch(Exception) { }
                    
                    if(request != null)
                    {
                        request.RequestStatus= false;
                    }

                    // then we need to save changes to the Database.
                    await _context.SaveChangesAsync();

                    // then we need to return one to show that its a success 
                    return 1;
                    
                    
                }
                catch (Exception ex) { }

                
            }
            return 0;
        }

        #endregion


    }
}
