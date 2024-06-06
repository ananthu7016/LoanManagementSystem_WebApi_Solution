using System;
using System.Collections.Generic;

namespace LoanManagementSystem_WebApi.Model;

public partial class LoanVerification
{
    public int VerificationId { get; set; }

    public int? RequestId { get; set; }

    public int? StaffId { get; set; }

    public string? VerificationReview { get; set; }

    public bool? VerificationStatus { get; set; }

    public virtual LoanRequest? Request { get; set; }

    public virtual Staff? Staff { get; set; }
}
