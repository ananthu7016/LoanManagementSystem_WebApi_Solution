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
    public class AdminController : ControllerBase
    {

        //first we need to get the instance of the IAdmin Repository through DI 

        //-------------------------------
        private readonly IAdminRepository _repository;

        public AdminController(IAdminRepository repository)
        {
            _repository = repository;
        }

        //-------------------------------


        #region Get Details of Loans Applied By Every Customer

        [HttpGet("requests")]
        public async Task<ActionResult<IEnumerable<vw_LoanRequest>>> GetAllRequestedLoans()
        {
            if (_repository != null)
            {
                return await _repository.GetAllRequestedLoans();
            }
            return null;
        }


        #endregion

    }
}
