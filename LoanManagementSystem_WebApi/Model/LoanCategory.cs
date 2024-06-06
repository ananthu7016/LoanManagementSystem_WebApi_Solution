using System;
using System.Collections.Generic;

namespace LoanManagementSystem_WebApi.Model;

public partial class LoanCategory
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
