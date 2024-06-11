﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanManagementSystem_WebApi.Model;
using LoanManagementSystem_WebApi.Repository;
using LoanManagementSystem_WebApi.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace LoanManagementSystem_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = "Bearer")]
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


        #region Submit a Verification Report 

        // this method is responsible to Submit the verification form 
        [HttpPost("report")]
        public async Task<ActionResult<int>>SubmitVerificationReport(vw_Dropdown report)
        {
            if(_repository!=null)
            {
                return await _repository.SubmitVerificationReport(report);
            }
            return 0;
        }

        #endregion



        #region Get Details of all Documents Uploaded by a Customer 
        [HttpGet("Documents/{customer_id}")]
        public async Task<ActionResult<IEnumerable<vw_Documents>>> GetDocumentOfCustomer(int customer_id)
        {
            if (_repository != null)
                return await _repository.GetDocumentOfCustomer(customer_id);
            else
                return new List<vw_Documents>();
        }

        #endregion
    }
}
