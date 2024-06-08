using LoanManagementSystem_WebApi.Model;
using LoanManagementSystem_WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem_WebApi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {


        // this is the implementation of the ICustomer Repository all the Functionalities for the customer will be defined in here


        //first through DI we need to create a instance of the Database context for the Entity Framework

        //----------------------------------------------------------
        private readonly LmsDbContext _context;

        public CustomerRepository(LmsDbContext context)
        {
            _context = context;
        }



        //-----------------------------------------------------------



        #region Register a New Customer 
        public async Task<ActionResult<int>> RegisterNewCustomer(Customer customer)
        {
            
            if(_context != null)
            {//making sure that the DI is Proper 


                // at first we need to create an instance of the User Table and insert into the user table 
                User newUser = new User
                {
                    UserName = customer.CustFirstName,
                    RoleId = 2,
                    Password = customer.CustPhone,
                };

                try
                {
                    //first we need to add the user to the userTable
                    await _context.Users.AddAsync(newUser);
                    
                    await _context.SaveChangesAsync();  

                    //then we need to get the UserId of the Added User
                    customer.UserId = newUser.UserId;

                    customer.CustStatus = true;
                    // then we need to insert the details of the customer 
                    await _context.Customers.AddAsync(customer);

                    // then we need to save the changes to Db 

                    await _context.SaveChangesAsync();

                    //if everything is Successfull we will return 1 
                    return 1;


                }
                catch(Exception e)
                {
                    return 0;
                }

            }

            return 0;

        }
        #endregion


        #region Get Details Of All Loans Taken By a Customer

        public async Task<ActionResult<IEnumerable<vw_LoanDetailsOfCustomer>>> GetAllLoansOfCustomer(int custId)
        {
            if(_context !=null)
            {
                try
                {
                    return await (from c in _context.Customers
                                  from ld in _context.LoanDeatils
                                  from l in _context.Loans
                                  from lc in _context.LoanCategories
                                  where c.CustId == custId && ld.CustId == custId && ld.LoanId == l.LoanId && l.CategoryId == lc.CategoryId
                                  select new vw_LoanDetailsOfCustomer
                                  {
                                      CustomerId = c.CustId,
                                      CustomerName = c.CustFirstName,
                                      LoanName = l.LoanName,
                                      LoanCategory = lc.CategoryName,
                                      AmountPayed = ld.TotalAmountRepaid,
                                      AmountToPay = ld.OutstandingBalance,
                                      LoanAmountTaken = ld.LoanAmount,
                                      LoanStatus = ld.LoanStatus
                                  }).ToListAsync();

                }
                catch(Exception e) { }
             
            }
           
            
                return null;
            
        }



        #endregion


        #region Get Details of All Available Loans

        public async Task<ActionResult<IEnumerable<Loan>>> GetDetailsOfAllLoans()
        {
            if( _context !=null)
            {
                //then we need to use Entity Framework to get all Details of Loans 
                try
                {
                    return await (from l in _context.Loans
                                  where l.LoanStatus ==true
                                  select new Loan
                                  {
                                      LoanId = l.LoanId,
                                      CategoryId = l.CategoryId,
                                      LoanName = l.LoanName,
                                      LoanIntrestRate = l.LoanIntrestRate,
                                      LoanMinimumAmount = l.LoanMinimumAmount,
                                      LoanMaximumAmount = l.LoanMaximumAmount,
                                      LatePaymentPenalty = l.LatePaymentPenalty,
                                      LoanTerm = l.LoanTerm,
                                      LoanStatus =l.LoanStatus
                                  }).ToListAsync();

                    // this will create an List of Instance of Each loans and return it.
                }
                catch (Exception e) { }

            }

            return null; // this will return null if any exception is raised or the DI is not Proper 
        }

        #endregion


        #region Get Details of Logged in Customer 


        public async Task<ActionResult<Customer>> GetCustomerDetails(int custId)
        {
            if(_context != null && custId !=0)
            {
                try
                {
                   return await (from c in _context.Customers
                           where c.CustId == custId
                           select new Customer
                           {
                               CustId = c.CustId,
                               CustFirstName = c.CustFirstName,
                               CustLastName = c.CustLastName,
                               CustAadhar = c.CustAadhar,
                               CustAddress = c.CustAddress,
                               CustAnnualIncome = c.CustAnnualIncome,
                               CustPhone = c.CustPhone
                           }).FirstAsync();

                }
                catch (Exception){ }
            }

            return null;
        }


        #endregion


        #region Apply for a Loan 

        public async Task<ActionResult<int>> ApplyForLoan(LoanRequest loan)
        {
            if(_context!=null && loan != null)
            {
                try
                {
                    loan.LoanRequestDate = DateTime.Now.Date;
                    loan.RequestStatus = true;
                    await _context.LoanRequests.AddAsync(loan);

                    // then we need to save changes

                    await _context.SaveChangesAsync();

                    // if success we need to return 1

                    return 1;

                }
                catch(Exception e) { }
            }

            return 0;
        }


        #endregion

    }
}
