using LoanManagementSystem_WebApi.Model;
using LoanManagementSystem_WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem_WebApi.Repository
{
    public class AdminRepository:IAdminRepository
    {
        // this is the Admin Repository Which Implements the IAdminRepository

        // first through DI we need to get the instance of Database context

        private readonly LmsV2DbContext _context;

        public AdminRepository(LmsV2DbContext context)
        {
            _context = context;
        }
        //-----------------------------------------------------------------



        #region Add a New Staff 

        public async Task<ActionResult<int>> RegisterNewStaff(vw_Staff staff)
        {
           if(_context != null && staff != null)
            {
              
                bool isUser = false; // to set if user is created or not
                // first we need to insert this person into UserTable for that we need to create an instance of User 

                User user = new User{
                    UserName = staff.StaffFirstName,
                    Password = staff.StaffPhone,
                    RoleId = staff.RoleId,
                    CreatedDateTime = DateTime.Now,
                };

                // then we need to create an instance of Staff 
                Staff newStaff = new Staff
                {
                    StaffAddress = staff.StaffAddress,
                    StaffEmail = staff.StaffEmail,
                    StaffFirstName = staff.StaffFirstName,
                    StaffGender = staff.StaffGender,
                    StaffPhone = staff.StaffPhone,
                    StaffLastName = staff.StaffLastName,
                    StaffSalary = staff.StaffSalary,
                    StaffStatus = true
                };

                try
                {
                    // then we need to insert the Staff into UserTable First to get the User ID
                    await _context.Users.AddAsync(user);
                    // then we need to save it to database 
                    await _context.SaveChangesAsync();

                    // setting isUser to true to show that user is created successfully 
                    isUser = true;
                }
                catch(Exception e) { }


                if (isUser)
                {
                    newStaff.UserId = user.UserId;
                    // setting the userId to the id of newly created user
                    try
                    {

                        await _context.Staffs.AddAsync(newStaff);
                        // then we need to save it to database 

                        // then we need to save changes to database 
                        await _context.SaveChangesAsync();

                        // then as a response of success we need to return 1 
                        return 1;
                    }
                    catch (Exception ex) { }
                }


             
            

            }
            // then we need to return zero if something went wrong 
            return 0;
        }

   

        #endregion
    }
}
