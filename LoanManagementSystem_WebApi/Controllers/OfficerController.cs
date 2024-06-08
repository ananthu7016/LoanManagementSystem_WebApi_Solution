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
    public class OfficerController : ControllerBase
    {
        // this is the controller for Officer Module
        //-------------------------------------------

        // so we need to get the instance of IOfficer Repository Through constructor injection 
        private readonly IOfficerRepository _repository;

        public OfficerController(IOfficerRepository repository)
        {
            _repository = repository;
        }


        //-------------------------------------------



        #region Get Details of All Assigned Varification 

        [HttpGet("details/{staff_id}")]
        public async Task<ActionResult<IEnumerable<vw_VerificationDetails>>> GetDetailsToVerify(int staff_id)
        {

            if(_repository !=null)
            {
                return await _repository.GetDetailsToVerify(staff_id);
            }

            return null;
        }

        #endregion
    }
}
