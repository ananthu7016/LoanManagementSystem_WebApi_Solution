using System;
using System.Collections.Generic;

namespace LoanManagementSystem_WebApi.Model;

public partial class UploadedDocument
{
    public int UploadId { get; set; }

    public int? CustId { get; set; }

    public int? DocTypeId { get; set; }

    public string? DocPath { get; set; }

    public virtual Customer? Cust { get; set; }

    public virtual DocumentType? DocType { get; set; }
}
