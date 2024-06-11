using System;
using System.Collections.Generic;

namespace LoanManagementSystem_WebApi.Model;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public int? RoleId { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public virtual Role? Role { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
