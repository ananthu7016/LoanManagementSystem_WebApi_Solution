﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LoanManagementSystem_WebApi.Model;

public partial class Customer
{
    public int CustId { get; set; }

    public string? CustFirstName { get; set; }

    public string? CustLastName { get; set; }

    public string? CustOccupation { get; set; }

    public string? CustAddress { get; set; }

    public string? CustPhone { get; set; }

    public string? CustAadhar { get; set; }

    public string? CustGender { get; set; }

    public DateTime? CustDob { get; set; }

    public string? CustNationality { get; set; }

    public decimal? CustAnnualIncome { get; set; }

    public bool? CustEmploymentStatus { get; set; }

    public bool? CustMaritalStatus { get; set; }

    public int? UserId { get; set; }

    public bool? CustStatus { get; set; }

    [JsonIgnore]
    public virtual ICollection<LoanDeatil> LoanDeatils { get; set; } = new List<LoanDeatil>();
    [JsonIgnore]
    public virtual ICollection<LoanRequest> LoanRequests { get; set; } = new List<LoanRequest>();
    [JsonIgnore]
    public virtual User? User { get; set; }
}
