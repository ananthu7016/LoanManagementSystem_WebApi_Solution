using System;
using System.Collections.Generic;

namespace LoanManagementSystem_WebApi.Model;

public partial class LoanDeatil
{
    public int DetailId { get; set; }

    public int? LoanId { get; set; }

    public int? CustId { get; set; }

    public decimal? LoanAmount { get; set; }

    public DateTime? LoanRequestDateTime { get; set; }

    public DateTime? LoanSanctionDateTime { get; set; }

    public int? RepaymentFrequency { get; set; }

    public string? LoanPurpose { get; set; }

    public decimal? TotalAmountRepaid { get; set; }

    public decimal? OutstandingBalance { get; set; }

    public decimal? LatePaymentPenalty { get; set; }

    public bool? DocumentUploadedStatus { get; set; }

    public int? VerifiedBy { get; set; }

    public bool? LoanStatus { get; set; }

    public virtual Customer? Cust { get; set; }

    public virtual Loan? Loan { get; set; }

    public virtual Staff? VerifiedByNavigation { get; set; }
}
