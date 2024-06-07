using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanManagementSystem_WebApi.Model;
using LoanManagementSystem_WebApi.Repository;

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
    }
}
