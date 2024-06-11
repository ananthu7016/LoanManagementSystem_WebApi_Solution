using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

    [JsonIgnore]
    public virtual ICollection<LoanDeatil> LoanDeatils { get; set; } = new List<LoanDeatil>();

    [JsonIgnore]
    public virtual ICollection<LoanVerification> LoanVerifications { get; set; } = new List<LoanVerification>();

    [JsonIgnore]
    public virtual User? User { get; set; }
}
