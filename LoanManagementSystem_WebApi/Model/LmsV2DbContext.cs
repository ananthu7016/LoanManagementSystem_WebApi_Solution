using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem_WebApi.Model;

public partial class LmsV2DbContext : DbContext
{
    public LmsV2DbContext()
    {
    }

    public LmsV2DbContext(DbContextOptions<LmsV2DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<LoanCategory> LoanCategories { get; set; }

    public virtual DbSet<LoanDeatil> LoanDeatils { get; set; }

    public virtual DbSet<LoanRequest> LoanRequests { get; set; }

    public virtual DbSet<LoanVerification> LoanVerifications { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Staff> Staffs { get; set; }

    public virtual DbSet<UploadedDocument> UploadedDocuments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source =HP_Ananthu\\SQLEXPRESS; Initial Catalog =LMS_V2_db; Integrated Security = True;\nTrusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustId).HasName("PK__Customer__A1B71F90C93E3A22");

            entity.Property(e => e.CustId).HasColumnName("cust_id");
            entity.Property(e => e.CustAadhar)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("cust_aadhar");
            entity.Property(e => e.CustAddress)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("cust_address");
            entity.Property(e => e.CustAnnualIncome)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("cust_annual_income");
            entity.Property(e => e.CustDob)
                .HasColumnType("date")
                .HasColumnName("cust_dob");
            entity.Property(e => e.CustEmploymentStatus).HasColumnName("cust_employment_status");
            entity.Property(e => e.CustFirstName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("cust_first_name");
            entity.Property(e => e.CustGender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cust_gender");
            entity.Property(e => e.CustLastName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cust_last_name");
            entity.Property(e => e.CustMaritalStatus).HasColumnName("cust_marital_status");
            entity.Property(e => e.CustNationality)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cust_nationality");
            entity.Property(e => e.CustOccupation)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("cust_occupation");
            entity.Property(e => e.CustPhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cust_phone");
            entity.Property(e => e.CustStatus).HasColumnName("cust_status");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RegistredDateTime)
                .HasColumnType("datetime")
                .HasColumnName("registred_date_time");
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.DocTypeId).HasName("PK__Document__85153F05CEC04E33");

            entity.HasIndex(e => e.DocTypeName, "UQ__Document__D1FDC4699F8A75F1").IsUnique();

            entity.Property(e => e.DocTypeId).HasColumnName("doc_type_id");
            entity.Property(e => e.DocTypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("doc_type_name");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__2370F727BDCE51A3");

            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.EventName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("event_name");
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.LoanId).HasName("PK__Loans__A1F79554F8F58397");

            entity.Property(e => e.LoanId).HasColumnName("loan_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CollateralRequired).HasColumnName("collateral_required");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("created_date_time");
            entity.Property(e => e.EmployementStatusRequired).HasColumnName("employement_status_required");
            entity.Property(e => e.GracePeriod).HasColumnName("grace_period");
            entity.Property(e => e.LatePaymentPenalty)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("late_payment_penalty");
            entity.Property(e => e.LoanDescription)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("loan_description");
            entity.Property(e => e.LoanIntrestRate)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("loan_intrest_rate");
            entity.Property(e => e.LoanMaximumAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("loan_maximum_amount");
            entity.Property(e => e.LoanMinimumAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("loan_minimum_amount");
            entity.Property(e => e.LoanName)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("loan_name");
            entity.Property(e => e.LoanStatus).HasColumnName("loan_status");
            entity.Property(e => e.LoanTerm).HasColumnName("loan_term");
            entity.Property(e => e.ProcessingFee)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("processing_fee");
            entity.Property(e => e.RepaymentFrequency).HasColumnName("repayment_frequency");
            entity.Property(e => e.TaxPercentage)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("tax_percentage");

            entity.HasOne(d => d.Category).WithMany(p => p.Loans)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Loans__category___160F4887");
        });

        modelBuilder.Entity<LoanCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__LoanCate__D54EE9B4E8E91B3C");

            entity.ToTable("LoanCategory");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<LoanDeatil>(entity =>
        {
            entity.HasKey(e => e.DetailId).HasName("PK__LoanDeat__38E9A224B660895F");

            entity.Property(e => e.DetailId).HasColumnName("detail_id");
            entity.Property(e => e.CustId).HasColumnName("cust_id");
            entity.Property(e => e.DocumentUploadedStatus).HasColumnName("document_uploaded_status");
            entity.Property(e => e.LatePaymentPenalty)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("late_payment_penalty");
            entity.Property(e => e.LoanAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("loan_amount");
            entity.Property(e => e.LoanId).HasColumnName("loan_id");
            entity.Property(e => e.LoanPurpose)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("loan_purpose");
            entity.Property(e => e.LoanRequestDateTime)
                .HasColumnType("datetime")
                .HasColumnName("loan_request_date_time");
            entity.Property(e => e.LoanSanctionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("loan_sanction_date_time");
            entity.Property(e => e.LoanStatus).HasColumnName("loan_status");
            entity.Property(e => e.OutstandingBalance)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("outstanding_balance");
            entity.Property(e => e.RepaymentFrequency).HasColumnName("repayment_frequency");
            entity.Property(e => e.TotalAmountRepaid)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total_amount_repaid");
            entity.Property(e => e.VerifiedBy).HasColumnName("verified_by");

            entity.HasOne(d => d.Cust).WithMany(p => p.LoanDeatils)
                .HasForeignKey(d => d.CustId)
                .HasConstraintName("FK__LoanDeati__cust___19DFD96B");

            entity.HasOne(d => d.Loan).WithMany(p => p.LoanDeatils)
                .HasForeignKey(d => d.LoanId)
                .HasConstraintName("FK__LoanDeati__loan___18EBB532");

            entity.HasOne(d => d.VerifiedByNavigation).WithMany(p => p.LoanDeatils)
                .HasForeignKey(d => d.VerifiedBy)
                .HasConstraintName("FK__LoanDeati__verif__1AD3FDA4");
        });

        modelBuilder.Entity<LoanRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__LoanRequ__18D3B90F4AC3E785");

            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.CustId).HasColumnName("cust_id");
            entity.Property(e => e.DocumentUploadedStatus).HasColumnName("document_uploaded_status");
            entity.Property(e => e.LoanId).HasColumnName("loan_id");
            entity.Property(e => e.LoanPurpose)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("loan_purpose");
            entity.Property(e => e.LoanRequestDateTime)
                .HasColumnType("datetime")
                .HasColumnName("loan_request_date_time");
            entity.Property(e => e.RepaymentFrequency).HasColumnName("repayment_frequency");
            entity.Property(e => e.RequestDetails)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("request_details");
            entity.Property(e => e.RequestStatus).HasColumnName("request_status");
            entity.Property(e => e.RequestedAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("requested_amount");

            entity.HasOne(d => d.Cust).WithMany(p => p.LoanRequests)
                .HasForeignKey(d => d.CustId)
                .HasConstraintName("FK__LoanReque__cust___1EA48E88");

            entity.HasOne(d => d.Loan).WithMany(p => p.LoanRequests)
                .HasForeignKey(d => d.LoanId)
                .HasConstraintName("FK__LoanReque__loan___1DB06A4F");
        });

        modelBuilder.Entity<LoanVerification>(entity =>
        {
            entity.HasKey(e => e.VerificationId).HasName("PK__LoanVeri__24F17969AC55A34F");

            entity.Property(e => e.VerificationId).HasColumnName("verification_id");
            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.StaffId).HasColumnName("staff_id");
            entity.Property(e => e.VerificationReview)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("verification_review");
            entity.Property(e => e.VerificationStatus).HasColumnName("verification_status");

            entity.HasOne(d => d.Request).WithMany(p => p.LoanVerifications)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK__LoanVerif__reque__498EEC8D");

            entity.HasOne(d => d.Staff).WithMany(p => p.LoanVerifications)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__LoanVerif__staff__4A8310C6");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Logs__9E2397E0BFAB1865");

            entity.Property(e => e.LogId).HasColumnName("log_id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.LogDescription)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("log_description");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");

            entity.HasOne(d => d.Event).WithMany(p => p.Logs)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Logs__event_id__6A30C649");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__760965CC202A7338");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staffs__1963DD9C0D0DE1B7");

            entity.Property(e => e.StaffId).HasColumnName("staff_id");
            entity.Property(e => e.StaffAddress)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("staff_address");
            entity.Property(e => e.StaffEmail)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("staff_email");
            entity.Property(e => e.StaffFirstName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("staff_first_name");
            entity.Property(e => e.StaffGender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("staff_gender");
            entity.Property(e => e.StaffLastName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("staff_last_name");
            entity.Property(e => e.StaffPhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("staff_phone");
            entity.Property(e => e.StaffSalary)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("staff_salary");
            entity.Property(e => e.StaffStatus).HasColumnName("staff_status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Staff)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Staffs__user_id__4E88ABD4");
        });

        modelBuilder.Entity<UploadedDocument>(entity =>
        {
            entity.HasKey(e => e.UploadId).HasName("PK__Uploaded__A13DEF58F78CAD0B");

            entity.HasIndex(e => e.DocPath, "UQ__Uploaded__048063CF01384EFB").IsUnique();

            entity.Property(e => e.UploadId).HasColumnName("upload_id");
            entity.Property(e => e.CustId).HasColumnName("cust_id");
            entity.Property(e => e.DocPath)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("doc_path");
            entity.Property(e => e.DocTypeId).HasColumnName("doc_type_id");

            entity.HasOne(d => d.Cust).WithMany(p => p.UploadedDocuments)
                .HasForeignKey(d => d.CustId)
                .HasConstraintName("FK__UploadedD__cust___45BE5BA9");

            entity.HasOne(d => d.DocType).WithMany(p => p.UploadedDocuments)
                .HasForeignKey(d => d.DocTypeId)
                .HasConstraintName("FK__UploadedD__doc_t__46B27FE2");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F9A1CD071");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("created_date_time");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("user_name");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__role_id__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
