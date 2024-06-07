using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LoanManagementSystem_WebApi.Model;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public int? RoleId { get; set; }
    [JsonIgnore]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
    [JsonIgnore]
    public virtual Role? Role { get; set; }
    [JsonIgnore]
    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
