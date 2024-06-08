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
    public class CustomerController : ControllerBase
    {

        //This is the Controller for the Customer Functionalities 

        //first we need to get the instance of the ICustomer Repository through DI 

        //-------------------------------
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        //-------------------------------


        #region Register a New Customer 

        [HttpPost]
        public async Task<ActionResult<int>> RegisterNewCustomer(Customer customer)
        {
            if(_repository !=null)
            {
                return await _repository.RegisterNewCustomer(customer);
            }

            return 0;
        }

        #endregion


        #region Get Details Of All Loans Taken By a Customer

        [HttpGet("{custId}")]
        public async Task<ActionResult<IEnumerable<vw_LoanDetailsOfCustomer>>> GetAllLoansOfCustomer(int custId)
        {
            if(_repository !=null)
            {
                return await _repository.GetAllLoansOfCustomer(custId);
            }
            else
            {
                return null;
            }
        }

        #endregion


        #region Get Details of All Available Loans
        [HttpGet("Loans")]
        public async Task<ActionResult<IEnumerable<Loan>>> GetDetailsOfAllLoans()
        {
            if (_repository != null)
                return await _repository.GetDetailsOfAllLoans();
            else
                return null;
        }

        #endregion



        #region Apply for a Loan 
        [HttpPost("Apply")]
        public async Task<ActionResult<int>> ApplyForLoan(LoanRequest loan)
        {
            if (_repository != null)
            {
               return await _repository.ApplyForLoan(loan);
            }

            return 0;
        }

        #endregion
    }
}
