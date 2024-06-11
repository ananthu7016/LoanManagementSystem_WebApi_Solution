using System;
using System.Collections.Generic;

namespace LoanManagementSystem_WebApi.Model;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? StaffFirstName { get; set; }

    public string? StaffLastName { get; set; }

    public string? StaffAddress { get; set; }

    public string? StaffGender { get; set; }

    public string? StaffPhone { get; set; }

    public string? StaffEmail { get; set; }

    public decimal? StaffSalary { get; set; }

    public int? UserId { get; set; }

    public bool? StaffStatus { get; set; }

    public virtual ICollection<LoanDeatil> LoanDeatils { get; set; } = new List<LoanDeatil>();

    public virtual ICollection<LoanVerification> LoanVerifications { get; set; } = new List<LoanVerification>();

    public virtual User? User { get; set; }
}
