using System;
using System.Collections.Generic;

namespace LoanManagementSystem_WebApi.Model;

public partial class DocumentType
{
    public int DocTypeId { get; set; }

    public string? DocTypeName { get; set; }

    public virtual ICollection<UploadedDocument> UploadedDocuments { get; set; } = new List<UploadedDocument>();
}
