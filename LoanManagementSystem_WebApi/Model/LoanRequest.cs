﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LoanManagementSystem_WebApi.Model;

public partial class LoanRequest
{
    public int RequestId { get; set; }

    public int? LoanId { get; set; }

    public int? CustId { get; set; }

    public DateTime? LoanRequestDate { get; set; }

    public string? LoanPurpose { get; set; }

    public decimal? RequestedAmount { get; set; }

    public int? RepaymentFrequency { get; set; }

    public bool? RequestStatus { get; set; }
    [JsonIgnore]
    public virtual Customer? Cust { get; set; }
    [JsonIgnore]
    public virtual Loan? Loan { get; set; }
    [JsonIgnore]
    public virtual ICollection<LoanVerification> LoanVerifications { get; set; } = new List<LoanVerification>();
}
