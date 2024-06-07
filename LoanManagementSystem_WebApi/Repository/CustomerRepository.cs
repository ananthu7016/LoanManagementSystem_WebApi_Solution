using LoanManagementSystem_WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem_WebApi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {


        // this is the implementation of the ICustomer Repository all the Functionalities for the customer will be defined in here


        //first through DI we need to create a instance of the Database context for the Entity Framework

        //----------------------------------------------------------
        private readonly LmsDbContext _context;

        public CustomerRepository(LmsDbContext context)
        {
            _context = context;
        }
        //-----------------------------------------------------------



        #region Register a New Customer 
        public async Task<ActionResult<int>> RegisterNewCustomer(Customer customer)
        {
            
            if(_context != null)
            {//making sure that the DI is Proper 


                // at first we need to create an instance of the User Table and insert into the user table 
                User newUser = new User
                {
                    UserName = customer.CustFirstName,
                    RoleId = 2,
                    Password = customer.CustPhone,
                };

                try
                {
                    //first we need to add the user to the userTable
                    await _context.Users.AddAsync(newUser);
                    
                    await _context.SaveChangesAsync();  

                    //then we need to get the UserId of the Added User
                    customer.UserId = newUser.UserId;

                    customer.CustStatus = true;
                    // then we need to insert the details of the customer 
                    await _context.Customers.AddAsync(customer);

                    // then we need to save the changes to Db 

                    await _context.SaveChangesAsync();

                    //if everything is Successfull we will return 1 
                    return 1;


                }
                catch(Exception e)
                {
                    return 0;
                }

            }

            return 0;

        }
        #endregion

    }
}
