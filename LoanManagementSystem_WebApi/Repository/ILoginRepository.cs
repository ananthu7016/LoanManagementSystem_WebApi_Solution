using LoanManagementSystem_WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem_WebApi.Repository
{
    public interface ILoginRepository
    {
        // This is the interface of the Login Repository here we need to Declare the methods that are to be implemeneted in the 
        // Login Repository 



        #region Validate User using Credentials Entered 

        // The method will Accept Two Parameter they are username and password and based on the Entered username and password
        // we need to Identify the user if the User exist or Else we need to return Error Messages 

        Task<ActionResult<vw_LoginRepsonse>> ValidateUser(string username, string password);
                                                   /*
                                                      Response that will return 
                                                   if(Valid username and Password ){
                                                           if the credentials are valid we will get the username , staff /Customer id and 
                                                           role id for rediretion
                                                    }
                                                   else{
                                                         if the credentials are Wrong then we will get a Stock Usernaame and password followed by a 
                                                         role id corresponding to a number that will be recognisted in the frond end indicating that it was a faulty 
                                                         credentils 
                                                   }
                                                    */
        #endregion
    }
}
