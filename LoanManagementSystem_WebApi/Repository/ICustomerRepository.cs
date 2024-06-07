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



        #region Get Details Of All Loans 

        Task<ActionResult<IEnumerable<vw_LoanDetailsOfCustomer>>> GetAllLoansOfCustomer(int custId);

        #endregion

    }
}
