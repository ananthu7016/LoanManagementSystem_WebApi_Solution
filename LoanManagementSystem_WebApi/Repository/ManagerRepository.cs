using LoanManagementSystem_WebApi.Model;
using LoanManagementSystem_WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem_WebApi.Repository
{
    // This is the Admin Repository
    public class ManagerRepository : IManagerRepository
    {

        //first through DI we need to create a instance of the Database context for the Entity Framework

        //----------------------------------------------------------
        private readonly LmsV2DbContext _context;

        public ManagerRepository(LmsV2DbContext context)
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
                           LoanRequestDate = r.LoanRequestDateTime,
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



        #region Get all Details of Verified Loans for Approval


        public async Task<ActionResult<IEnumerable<vw_ApprovalDetails>>> GetDetailsOfLoanToApprove()
        {
            if( _context != null )
            {
                try
                {
             return await (from v in _context.LoanVerifications
                           from c in _context.Customers
                           from r in _context.LoanRequests
                           from l in _context.Loans
                           where v.RequestId == r.RequestId && r.CustId == c.CustId && r.LoanId == l.LoanId && v.VerificationStatus == false
                           select new vw_ApprovalDetails
                           {
                               VerificationId = v.VerificationId,
                               CustomerId = c.CustId,
                               CustomerName = c.CustFirstName+" "+c.CustLastName,
                               CustomerPhone = c.CustPhone,
                               LoanId = l.LoanId,
                               LoanName = l.LoanName,
                               LoanAmount = r.RequestedAmount,
                               LoanRequestDate = r.LoanRequestDateTime,
                               RepaymentFrequency = r.RepaymentFrequency,
                               Review = v.VerificationReview
                          
                              
                           }).ToListAsync();
                }
                catch { }
            }

            return null;
        }




        #endregion


        #region Approve a Loan 
        public async Task<ActionResult<int>> ApproveALoan(vw_ApprovalDetails loan)
        {
           if(_context != null)
            {
                //first we need to create an instance for LoanDetails 
                LoanDeatil loanDeatil = new LoanDeatil
                {
                    LoanId = loan.LoanId,
                    CustId = loan.CustomerId,
                    LoanAmount = loan.LoanAmount,
                    LoanRequestDateTime = loan.LoanRequestDate,
                    LoanSanctionDateTime = DateTime.Now.Date,
                    LatePaymentPenalty = 0,
                    OutstandingBalance = loan.LoanAmount,
                    TotalAmountRepaid = 0,
                    LoanStatus = true,
                    RepaymentFrequency = loan.RepaymentFrequency
                };



                // Then we need to get the details of Requested loan From LoanVerification Table to remove it if Loan is Sanctioned.
                LoanVerification verificationDetails = new LoanVerification();
                int? flag = 0;

                try
                {
                    verificationDetails = await _context.LoanVerifications.Where(l => l.VerificationId == loan.VerificationId).FirstAsync();
                    flag = 1;
                    // to show that there is details with that ID
                }
                catch (Exception e) { }


                try
                {
                    if (flag == 1)
                    {

                        await _context.LoanDeatils.AddAsync(loanDeatil);

                        // then we need to Remove The Details From Loan Verification Details 
                        _context.LoanVerifications.Remove(verificationDetails);

                        // if this add and removal is suceess only the details will be saved 

                        // then we need to save changes
                        await _context.SaveChangesAsync();

                        // then we will return 1 to show success 
                        return 1;
                    }


                }
                catch(Exception ex) { }


                

            }
            return 0;
        }

        #endregion



        #region Reject a Loan 
        public async Task<ActionResult<int>> RejectALoan(vw_ApprovalDetails loan)
        {
            if(_context != null)
            {
                // Then we need to get the details of Requested loan From LoanVerification Table to remove it if Loan is Sanctioned.
                LoanVerification verificationDetails = new LoanVerification();
                int? flag = 0;

                try
                {
                    verificationDetails = await _context.LoanVerifications.Where(l => l.VerificationId == loan.VerificationId).FirstAsync();
                    flag = 1;
                    // to show that there is details with that ID
                }
                catch (Exception e) { }


                try
                {
                    // then we need to Remove The Details From Loan Verification Details 
                    _context.LoanVerifications.Remove(verificationDetails);

                    // if this add and removal is suceess only the details will be saved 

                    // then we need to save changes
                    await _context.SaveChangesAsync();

                    // then we will return 1 to show success 
                    return 1;
                }
                catch (Exception e) { }
            }

            return 0;
        }


        #endregion





        #region Add Details of a new  Loan 

        public async Task<ActionResult<int>> AddNewLoanDetails(Loan loan)
        {
            if(_context != null && loan != null)
            {

                //so to the recieved instance we need to add some extra details like The time stamp when it was created 
                loan.CreatedDateTime = DateTime.Now;

                try
                {
                    await _context.Loans.AddAsync(loan);

                    // then we need to save it to database
                    await _context.SaveChangesAsync();

                    // then as a sucess response we need to send 1 
                    return 1;
                }
                catch (Exception ex) { 
                    // to catch any exception that maybe raised.
                 }    

            }

            return 0;
            // return zero to show that there was some problem while inserting the new Loan.
        }

        #endregion



        #region Disable or Enable a Loan 

        public async Task<ActionResult<int>> ToggleLoanStatus(int loan_id)
        {
            // so we need to set the status of the Loan with the given Id to false / true 
            if(_context != null)
            {
                Loan loanDetails = new Loan();
                loanDetails.LoanId = 0;
                // defining and instance to store the details of loan with this id

                try
                {
                    loanDetails = await _context.Loans.Where(l=>l.LoanId == loan_id).FirstAsync();
                    // this will get the detail of loan with this id 

                }catch(Exception e)
                {
                    // to catch any exception that maybe raised.
                }

                if(loanDetails.LoanId != 0)
                {
                    // then we have a Loan with the matching ID
                    loanDetails.LoanStatus = !loanDetails.LoanStatus;
                    // this will toogle the loan status 

                    // then we need to save the change to database
                    await _context.SaveChangesAsync();
                    // then we need to return success status;
                    return 1;
                }
            }

            return 0;
            // if something went wrong we need to return zero 
        }

        #endregion

    }
}
