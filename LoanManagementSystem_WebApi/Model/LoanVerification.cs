using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LoanManagementSystem_WebApi.Model;

public partial class LoanVerification
{
 
    public int VerificationId { get; set; }

    public int? RequestId { get; set; }

    public int? StaffId { get; set; }

    [JsonIgnore]
    public string? VerificationReview { get; set; }

    public bool? VerificationStatus { get; set; }

    [JsonIgnore]
    public virtual LoanRequest? Request { get; set; }

    [JsonIgnore]
    public virtual Staff? Staff { get; set; }
}
