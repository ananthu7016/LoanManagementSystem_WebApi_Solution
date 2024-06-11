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

        // first we need to get the instance of IAdminRepository through DI
        private readonly IAdminRepository _repository;

        public AdminController(IAdminRepository repository)
        {
            _repository = repository;
        }
        //--------------------------------------------------



        #region Add a New Staff 

        [HttpPost("NewStaff")]
        public async Task<ActionResult<int>> RegisterNewStaff(vw_Staff staff)
        {
            if (_repository != null && staff != null)
                return await _repository.RegisterNewStaff(staff);
            else
                return 0;
        }

        #endregion




        #region Get all Log Details 

        [HttpGet("Logs")]
        public async Task<ActionResult<IEnumerable<vw_LogDetails>>> GetAllLogDetails()
        {
            if (_repository != null)
                return await _repository.GetAllLogDetails();
            else
                return new List<vw_LogDetails>();
        }

        #endregion
    }
}
