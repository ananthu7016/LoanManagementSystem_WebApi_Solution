using System;
using System.Collections.Generic;

namespace LoanManagementSystem_WebApi.Model;

public partial class Loan
{
    public int LoanId { get; set; }

    public string? LoanName { get; set; }

    public int? CategoryId { get; set; }

    public decimal? LoanMinimumAmount { get; set; }

    public decimal? LoanMaximumAmount { get; set; }

    public decimal? LoanIntrestRate { get; set; }

    public decimal? LatePaymentPenalty { get; set; }

    public int? LoanTerm { get; set; }

    public bool? LoanStatus { get; set; }

    public virtual LoanCategory? Category { get; set; }

    public virtual ICollection<LoanDeatil> LoanDeatils { get; set; } = new List<LoanDeatil>();

    public virtual ICollection<LoanRequest> LoanRequests { get; set; } = new List<LoanRequest>();
}
