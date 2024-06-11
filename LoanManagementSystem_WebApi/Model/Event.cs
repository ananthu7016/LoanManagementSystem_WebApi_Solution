using System;
using System.Collections.Generic;

namespace LoanManagementSystem_WebApi.Model;

public partial class Event
{
    public int EventId { get; set; }

    public string? EventName { get; set; }

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
}
