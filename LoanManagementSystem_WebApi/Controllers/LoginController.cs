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
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Policy;
using NuGet.Common;

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
        private IConfiguration _configuration;
        // this private readonly variable will be instanciated through dependency injection 

        public LoginController(ILoginRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }


        //--------------------------------------



        #region Validate User using Credentials Entered 

        [HttpPost("{username}/{password}")]
        public async Task<ActionResult<vw_LoginRepsonse>> ValidateUser(string username, string password)
        {
            ActionResult response = Unauthorized();
            if(_repository != null)
            {
               vw_LoginRepsonse user = await _repository.ValidateUser(username, password);
                // here we will get the details of Users Who has logged in 

                // then we need to get the token for the user 
                string Token = GenerateJWTToken();

                if (user.RoleId == 501)
                    Token = "";

                return Ok(new
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    RoleId =user.RoleId,
                    Token = Token
                });
            }
            else
            {
                return response;
            }

        }


        #endregion




        #region Generate Token Jwt 

        private string GenerateJWTToken()
        {
            // Security key - - we can get the security key from App settings 


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            // Credentials or Algorithm 
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // JWT Token 
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(20), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion


    }
}
