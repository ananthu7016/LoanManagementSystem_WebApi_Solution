using System;
using System.Collections.Generic;

namespace LoanManagementSystem_WebApi.Model;

public partial class Log
{
    public int LogId { get; set; }

    public int? EventId { get; set; }

    public DateTime? TimeStamp { get; set; }

    public string? LogDescription { get; set; }

    public virtual Event? Event { get; set; }
}
