using LoanManagementSystem_WebApi.Model;
using LoanManagementSystem_WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem_WebApi.Repository
{
    public interface ICustomerRepository
    {

        // This is the Interface of Customer Repository here we neeed to declare the methods that are to be implemented in the 
        //child class 


        #region Register a New Customer 

        Task<ActionResult<int>> RegisterNewCustomer(Customer customer);
        // the declaration of this method is responsible to add details of a new customer.

        #endregion



        #region Get Details Of All Loans Taken By a Customer

        Task<ActionResult<IEnumerable<vw_LoanDetailsOfCustomer>>> GetAllLoansOfCustomer(int custId);

        #endregion


        #region Get Details of All Available Loans

        Task<ActionResult<IEnumerable<Loan>>> GetDetailsOfAllLoans();

        #endregion


        #region Get Details of Logged in Customer 
        
        Task<ActionResult<Customer>> GetCustomerDetails(int custId);

        #endregion


        #region Apply for a Loan 

        Task<ActionResult<int>> ApplyForLoan(LoanRequest loan);

        #endregion

    }
}
