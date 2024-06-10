using LoanManagementSystem_WebApi.Model;
using LoanManagementSystem_WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem_WebApi.Repository
{
    public class LoginRepository : ILoginRepository
    {

        // this is the Repository layer that deals with the logics behind the login and it Implements the 
        // inteface ILoginRepository 



        //-----------------------------------------------
                  // here we need to get access to the Database context so that we could use the Entity frameword to manipulate the Database

                  private  readonly LmsDbContext _context;

                  public LoginRepository(LmsDbContext context)
                  {
                      _context = context;
                  }

        // declaring a private readonly variable to store the instance of Database context once its injected using DI



        //-----------------------------------------------



        #region Validate User using Credentials Entered 

        public async Task<vw_LoginRepsonse> ValidateUser(string username, string password)
        {
           
            if(_context != null)
            {
                // making sure that Instance of Database is Created 

                //defining an instance to store the details of The User if User Exist 
                User userLoggedIn = null;

                try
                {
                   userLoggedIn = await _context.Users.Where(u => u.UserName == username && u.Password == password).FirstAsync();
                }
                catch (Exception ex) { 
                                     // this block will catch the exception that maybe raised
                                     }


                //Then we need to check if the User with that Id is Present in the Database 

                if(userLoggedIn != null && userLoggedIn.RoleId ==2)
                    {
                        // if the control enter this block it means we have a valid user and the user is a Customer  
                        try
                        {
                        return await (from c in _context.Customers
                                      where c.UserId == userLoggedIn.UserId
                                      select new vw_LoginRepsonse
                                      {
                                          Id = c.CustId,
                                          UserName = userLoggedIn.UserName,
                                          RoleId = userLoggedIn.RoleId

                                      }).FirstAsync();

                        }
                        catch (Exception e) { 
                                            // this block will catch any exception
                                            }
     
                    }
                else if(userLoggedIn != null)
                {

                    try
                    {
                        return await (from s in _context.Staffs
                                      where s.UserId == userLoggedIn.UserId
                                      select new vw_LoginRepsonse
                                      {
                                          Id = s.StaffId,
                                          UserName = userLoggedIn.UserName,
                                          RoleId = userLoggedIn.RoleId

                                      }).FirstAsync();

                    }
                    catch (Exception e)
                    {
                        // this block will catch any exception
                    }

                }
                else
                {
                    // if the control enter this block it means that the user is not a valid user so we need to return a Details of user with Controlled Dummy Data
                    // so that we can show appropriate validation message in Frond end 

                    return new vw_LoginRepsonse
                    {
                        Id = 0,
                        RoleId = 501,              
                        UserName = "Not_exist"
                    };

                                                                  //Note Role Id 501 Indicate UserDoesnot Exist
                }


             }


            return null;
        }

        #endregion




        #region Change User Credentials 
        async Task<ActionResult<int>> ILoginRepository.UpdateUserCredentials(vw_LoginRepsonse credentials)
        {
           if(_context != null)
            {
                int? user_id = 0;
                if(credentials.RoleId == 2)
                {
                    // then the user is customer 
                    Customer customer = new Customer();
                    try
                    {
                        customer = await _context.Customers.Where(c=>c.CustId == credentials.Id).FirstAsync();
                        // then we need to get his/ her user_id 
                        user_id = customer.UserId;
                    }
                    catch (Exception e) { }

                }
                else
                {
                    try
                    {
                        Staff staff = await _context.Staffs.Where(s => s.StaffId == credentials.Id).FirstAsync();
                        // then we need to get the user_id of the staff 
                        user_id = staff.UserId;
                    }
                    catch (Exception e) { }

                  

                }


               
                if(user_id != 0)
                {
                    // so now we got the user_id 
                    User user = new User();
                    try
                    {
                        user = await _context.Users.Where(u => u.UserId == user_id).FirstAsync();

                        // we need to assign the new credentials recieved to this user 
                        user.UserName = credentials.UserName;
                        user.Password = credentials.Password;

                        // then we need to save changes 

                        await _context.SaveChangesAsync();

                        // then we return one to show the success response 
                        return 1;
                    }
                    catch (Exception e) { }
                   
                }
            }

            return 0;
        }

        #endregion

    }
}
