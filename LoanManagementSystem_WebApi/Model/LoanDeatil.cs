using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LoanManagementSystem_WebApi.Model;

public partial class LoanDeatil
{
    public int DetailId { get; set; }

    public int? LoanId { get; set; }

    public int? CustId { get; set; }

    public decimal? LoanAmount { get; set; }

    public DateTime? LoanRequestDate { get; set; }

    public DateTime? LoanSanctionDate { get; set; }

    public int? RepaymentFrequency { get; set; }

    public decimal? TotalAmountRepaid { get; set; }

    public decimal? OutstandingBalance { get; set; }

    public decimal? LatePaymentPenalty { get; set; }

    public bool? LoanStatus { get; set; }

    [JsonIgnore]
    public virtual Customer? Cust { get; set; }
    [JsonIgnore]
    public virtual Loan? Loan { get; set; }
}
