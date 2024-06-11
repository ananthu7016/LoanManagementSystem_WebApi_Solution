namespace LoanManagementSystem_WebApi.ViewModel
{
    public class vw_Staff
    {
        // this is a ViewModel to store the details of Staff 

        public string? StaffFirstName { get; set; }
        // this is a getter and setter for First name

        public string? StaffLastName { get; set; }

        public string? StaffAddress { get; set; }

        public string? StaffGender { get; set; }

        public string? StaffPhone { get; set; }

        public string? StaffEmail { get; set; }

        public decimal? StaffSalary { get; set; }

        public int? RoleId { get; set; }

        public bool? StaffStatus { get; set; }
    }
}
