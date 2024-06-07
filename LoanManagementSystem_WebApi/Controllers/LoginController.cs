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
    public class LoginController : ControllerBase
    {

        // this is the controller for the Login Functionality 

        //--------------------------------------
        // first we need to create instance for the Repository layer through constructor injection 

        private readonly ILoginRepository _repository;
                      // this private readonly variable will be instanciated through dependency injection 

        public LoginController(ILoginRepository repository)
        {
            _repository = repository;
        }


        //--------------------------------------



        #region Validate User using Credentials Entered 

        [HttpPost("{username}/{password}")]
        public async Task<ActionResult<vw_LoginRepsonse>> ValidateUser(string username, string password)
        {
            if(_repository != null)
            {
               return await _repository.ValidateUser(username, password);
            }
            else
            {
                return null;
            }

        }


        #endregion



    }
}
