using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentPortal.Repository.Models;

public partial class RecruitmentPortalContext : DbContext
{
    public RecruitmentPortalContext()
    {
    }

    public RecruitmentPortalContext(DbContextOptions<RecruitmentPortalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyHistory> CompanyHistories { get; set; }

    public virtual DbSet<CompanyLocation> CompanyLocations { get; set; }

    public virtual DbSet<CompanyLocationsHistory> CompanyLocationsHistories { get; set; }

    public virtual DbSet<CompanySocialMedium> CompanySocialMedia { get; set; }

    public virtual DbSet<CompanyStatus> CompanyStatuses { get; set; }

    public virtual DbSet<CompanyStatusHistory> CompanyStatusHistories { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Degree> Degrees { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<EducationUserMapping> EducationUserMappings { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<ExperienceUserMapping> ExperienceUserMappings { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobCategory> JobCategories { get; set; }

    public virtual DbSet<JobRole> JobRoles { get; set; }

    public virtual DbSet<JobType> JobTypes { get; set; }

    public virtual DbSet<JobsHistory> JobsHistories { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<ProfileHistory> ProfileHistories { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SkillsExperienceMapping> SkillsExperienceMappings { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersHistory> UsersHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PCA117\\SQLEXPRESS;Database=RecruitmentPortal;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__City__F2D21B766DB84751");

            entity.ToTable("City");

            entity.Property(e => e.CityName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.State).WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__City__StateId__5070F446");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__company__2D971CACA6D2D6EC");

            entity.ToTable("company", tb =>
                {
                    tb.HasTrigger("trg_company_history_ins_del");
                    tb.HasTrigger("trg_company_history_mod");
                });

            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CompanyType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CompanyWebsite)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CountryCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("00");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedById).HasDefaultValue(0);
            entity.Property(e => e.DeletedById).HasDefaultValue(0);
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ImageURl");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedById).HasDefaultValue(0);

            entity.HasOne(d => d.User).WithMany(p => p.Companies)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__company__UserId__5CD6CB2B");
        });

        modelBuilder.Entity<CompanyHistory>(entity =>
        {
            entity.HasKey(e => e.CompanyHistoryId).HasName("PK__company___33794629CE93EA0C");

            entity.ToTable("company_History");

            entity.Property(e => e.CompanyHistoryId).HasColumnName("Company_HistoryId");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CompanyType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CompanyWebsite)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CountryCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedById).HasDefaultValue(0);
            entity.Property(e => e.DeletedById).HasDefaultValue(0);
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ImageURl");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedById).HasDefaultValue(0);
            entity.Property(e => e.Operation)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("operation");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyHistories)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__company_H__Compa__25518C17");

            entity.HasOne(d => d.User).WithMany(p => p.CompanyHistories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__company_H__UserI__2645B050");
        });

        modelBuilder.Entity<CompanyLocation>(entity =>
        {
            entity.HasKey(e => e.CompanyLocationId).HasName("PK__CompanyL__7496FF4DA24A63ED");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("trg_companyLocation_history_ins_del");
                    tb.HasTrigger("trg_companyLocation_history_mod");
                });

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedById).HasDefaultValue(0);
            entity.Property(e => e.DeletedById).HasDefaultValue(0);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedById).HasDefaultValue(0);

            entity.HasOne(d => d.City).WithMany(p => p.CompanyLocations)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompanyLocations_City");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyLocations)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CompanyLo__Compa__76969D2E");

            entity.HasOne(d => d.Country).WithMany(p => p.CompanyLocations)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CompanyLo__Count__778AC167");

            entity.HasOne(d => d.State).WithMany(p => p.CompanyLocations)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CompanyLo__State__787EE5A0");
        });

        modelBuilder.Entity<CompanyLocationsHistory>(entity =>
        {
            entity.HasKey(e => e.CompanyLocationHistoryId).HasName("PK__CompanyL__DDB13B6FDC6AED69");

            entity.ToTable("CompanyLocations_History");

            entity.Property(e => e.CompanyLocationHistoryId).HasColumnName("CompanyLocation_HistoryId");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedById).HasDefaultValue(0);
            entity.Property(e => e.DeletedById).HasDefaultValue(0);
            entity.Property(e => e.ModifiedById).HasDefaultValue(0);
            entity.Property(e => e.Operation)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("operation");

            entity.HasOne(d => d.City).WithMany(p => p.CompanyLocationsHistories)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__CompanyLo__CityI__625A9A57");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyLocationsHistories)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CompanyLo__Compa__2FCF1A8A");

            entity.HasOne(d => d.CompanyLocation).WithMany(p => p.CompanyLocationsHistories)
                .HasForeignKey(d => d.CompanyLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CompanyLo__Compa__2EDAF651");

            entity.HasOne(d => d.Country).WithMany(p => p.CompanyLocationsHistories)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CompanyLo__Count__30C33EC3");

            entity.HasOne(d => d.State).WithMany(p => p.CompanyLocationsHistories)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CompanyLo__State__31B762FC");
        });

        modelBuilder.Entity<CompanySocialMedium>(entity =>
        {
            entity.HasKey(e => e.CompanySocialMedia).HasName("PK__CompanyS__A3F33ABE3546CC5A");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedById).HasDefaultValue(0);
            entity.Property(e => e.DeletedById).HasDefaultValue(0);
            entity.Property(e => e.FaceBook)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.LinkedIn)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Medium)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedById).HasDefaultValue(0);
            entity.Property(e => e.Twitter)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Company).WithMany(p => p.CompanySocialMedia)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CompanySo__Compa__00200768");
        });

        modelBuilder.Entity<CompanyStatus>(entity =>
        {
            entity.HasKey(e => e.CompanyStatusId).HasName("PK__CompanyS__2104C34EE4076872");

            entity.ToTable("CompanyStatus", tb =>
                {
                    tb.HasTrigger("trg_companyStatus_history_ins_del");
                    tb.HasTrigger("trg_companyStatus_history_ins_mod");
                });

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedById).HasDefaultValue(0);
            entity.Property(e => e.DeletedById).HasDefaultValue(0);
            entity.Property(e => e.IndustryType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedById).HasDefaultValue(0);
            entity.Property(e => e.TotalRevenue).HasColumnType("numeric(18, 0)");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyStatuses)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CompanySt__Compa__07C12930");
        });

        modelBuilder.Entity<CompanyStatusHistory>(entity =>
        {
            entity.HasKey(e => e.CompanyStatusHistoryId).HasName("PK__CompanyS__220EC10FC0DB489C");

            entity.ToTable("CompanyStatus_History");

            entity.Property(e => e.CompanyStatusHistoryId).HasColumnName("CompanyStatus_HistoryId");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedById).HasDefaultValue(0);
            entity.Property(e => e.DeletedById).HasDefaultValue(0);
            entity.Property(e => e.IndustryType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedById).HasDefaultValue(0);
            entity.Property(e => e.Operation)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("operation");
            entity.Property(e => e.TotalRevenue).HasColumnType("numeric(18, 0)");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyStatusHistories)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CompanySt__Compa__3B40CD36");

            entity.HasOne(d => d.CompanyStatus).WithMany(p => p.CompanyStatusHistories)
                .HasForeignKey(d => d.CompanyStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CompanySt__Compa__3A4CA8FD");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Country__10D1609FDC06E984");

            entity.ToTable("Country");

            entity.Property(e => e.CountryName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Degree>(entity =>
        {
            entity.HasKey(e => e.DegreeId).HasName("PK__Degrees__4D94AD2ED58E25C9");

            entity.Property(e => e.Degree1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Degree");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.EducationId).HasName("PK__Educatio__4BBE3805D5ADD915");

            entity.ToTable("Education");

            entity.Property(e => e.Activities)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedById).HasDefaultValue(0);
            entity.Property(e => e.Degree)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DeletedById).HasDefaultValue(0);
            entity.Property(e => e.FeildOfStudy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Grade).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedById).HasDefaultValue(0);
            entity.Property(e => e.School)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EducationUserMapping>(entity =>
        {
            entity.HasKey(e => e.EducationUserMappingId).HasName("PK__Educatio__13EE2D2C700CF7E4");

            entity.ToTable("EducationUserMapping");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedById).HasDefaultValue(0);
            entity.Property(e => e.DeletedById).HasDefaultValue(0);
            entity.Property(e => e.ModifiedById).HasDefaultValue(0);

            entity.HasOne(d => d.Education).WithMany(p => p.EducationUserMappings)
                .HasForeignKey(d => d.EducationId)
                .HasConstraintName("FK__Education__Educa__412EB0B6");

            entity.HasOne(d => d.User).WithMany(p => p.EducationUserMappings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Education__UserI__403A8C7D");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.ExperienceId).HasName("PK__Experien__2F4E3449318691D3");

            entity.ToTable("Experience");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedById).HasDefaultValue(0);
            entity.Property(e => e.DeletedById).HasDefaultValue(0);
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.LocationAddress)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedById).HasDefaultValue(0);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ExperienceUserMapping>(entity =>
        {
            entity.HasKey(e => e.ExperienceUserMappingId).HasName("PK__Experien__F1D72DF2B6B78738");

            entity.ToTable("ExperienceUserMapping");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedById).HasDefaultValue(0);
            entity.Property(e => e.DeletedById).HasDefaultValue(0);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedById).HasDefaultValue(0);

            entity.HasOne(d => d.Experience).WithMany(p => p.ExperienceUserMappings)
                .HasForeignKey(d => d.ExperienceId)
                .HasConstraintName("FK__Experienc__Exper__398D8EEE");

            entity.HasOne(d => d.User).WithMany(p => p.ExperienceUserMappings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Experienc__UserI__38996AB5");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK__Jobs__056690C297282C99");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedById).HasDefaultValue(0);
            entity.Property(e => e.DeletedById).HasDefaultValue(0);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.JobTitle)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MaxSalary).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.MinSalary).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.ModifiedById).HasDefaultValue(0);

            entity.HasOne(d => d.Company).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Jobs__CompanyId__7C1A6C5A");

            entity.HasOne(d => d.CompanyLocation).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.CompanyLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Jobs__CompanyLoc__7D0E9093");

            entity.HasOne(d => d.Degree).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.DegreeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Jobs__DegreeId__2610A626");

            entity.HasOne(d => d.JobCategory).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.JobCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Jobs__JobCategor__7E02B4CC");

            entity.HasOne(d => d.JobRole).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.JobRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Jobs__JobRoleId__1B9317B3");

            entity.HasOne(d => d.JobType).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.JobTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Jobs__JobTypeId__214BF109");
        });

        modelBuilder.Entity<JobCategory>(entity =>
        {
            entity.HasKey(e => e.JobCategoryId).HasName("PK__JobCateg__302BAD2DF837C8E1");

            entity.ToTable("JobCategory");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<JobRole>(entity =>
        {
            entity.HasKey(e => e.JobRoleId).HasName("PK__JobRoles__6D8BAC2F8195BBBE");

            entity.Property(e => e.JobRole1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("JobRole");
        });

        modelBuilder.Entity<JobType>(entity =>
        {
            entity.HasKey(e => e.JobTypeId).HasName("PK__JobTypes__E1F462AD90A54F89");

            entity.Property(e => e.JobType1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("JobType");
        });

        modelBuilder.Entity<JobsHistory>(entity =>
        {
            entity.HasKey(e => e.JobHistoryId).HasName("PK__Jobs_His__4D0D6260D1D0242A");

            entity.ToTable("Jobs_History");

            entity.Property(e => e.JobHistoryId).HasColumnName("Job_HistoryId");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedById).HasDefaultValue(0);
            entity.Property(e => e.DeletedById).HasDefaultValue(0);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.JobTitle)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MaxSalary).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.MinSalary).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.ModifiedById).HasDefaultValue(0);

            entity.HasOne(d => d.Company).WithMany(p => p.JobsHistories)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Jobs_Hist__Compa__0697FACD");

            entity.HasOne(d => d.CompanyLocation).WithMany(p => p.JobsHistories)
                .HasForeignKey(d => d.CompanyLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Jobs_Hist__Compa__078C1F06");

            entity.HasOne(d => d.Degree).WithMany(p => p.JobsHistories)
                .HasForeignKey(d => d.DegreeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Jobs_Hist__Degre__251C81ED");

            entity.HasOne(d => d.JobCategory).WithMany(p => p.JobsHistories)
                .HasForeignKey(d => d.JobCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Jobs_Hist__JobCa__0880433F");

            entity.HasOne(d => d.Job).WithMany(p => p.JobsHistories)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Jobs_Hist__JobId__05A3D694");

            entity.HasOne(d => d.JobRole).WithMany(p => p.JobsHistories)
                .HasForeignKey(d => d.JobRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Jobs_Hist__JobRo__1C873BEC");

            entity.HasOne(d => d.JobType).WithMany(p => p.JobsHistories)
                .HasForeignKey(d => d.JobTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Jobs_Hist__JobTy__2057CCD0");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PK__Profile__290C88E45A9045AD");

            entity.ToTable("Profile", tb =>
                {
                    tb.HasTrigger("trg_profile_history_ins_del");
                    tb.HasTrigger("trg_profile_history_mod");
                });

            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CountryCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("00");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedById).HasDefaultValue(0);
            entity.Property(e => e.DateOfBirth).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DeletedById).HasDefaultValue(0);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ImageURl");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedById).HasDefaultValue(0);
            entity.Property(e => e.Pincode).HasColumnName("pincode");

            entity.HasOne(d => d.City).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Profile__CityId__534D60F1");

            entity.HasOne(d => d.Country).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Profile__Country__5165187F");

            entity.HasOne(d => d.State).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__Profile__StateId__52593CB8");

            entity.HasOne(d => d.User).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Profile_Users");
        });

        modelBuilder.Entity<ProfileHistory>(entity =>
        {
            entity.HasKey(e => e.ProfileHistoryId).HasName("PK__Profile___666B8B39A7E7E6F8");

            entity.ToTable("Profile_History");

            entity.Property(e => e.ProfileHistoryId).HasColumnName("Profile_HistoryId");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CountryCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedById).HasDefaultValue(0);
            entity.Property(e => e.DeletedById).HasDefaultValue(0);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ImageURl");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedById).HasDefaultValue(0);
            entity.Property(e => e.Operation)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("operation");
            entity.Property(e => e.Pincode).HasColumnName("pincode");

            entity.HasOne(d => d.City).WithMany(p => p.ProfileHistories)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Profile_H__CityI__1CBC4616");

            entity.HasOne(d => d.Country).WithMany(p => p.ProfileHistories)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Profile_H__Count__1AD3FDA4");

            entity.HasOne(d => d.Profile).WithMany(p => p.ProfileHistories)
                .HasForeignKey(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Profile_H__Profi__19DFD96B");

            entity.HasOne(d => d.State).WithMany(p => p.ProfileHistories)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__Profile_H__State__1BC821DD");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PK__Skills__DFA0918799D3EBA4");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedById).HasDefaultValue(0);
            entity.Property(e => e.DeletedById).HasDefaultValue(0);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedById).HasDefaultValue(0);
            entity.Property(e => e.SkillName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SkillsExperienceMapping>(entity =>
        {
            entity.HasKey(e => e.SkillsExperienceMappingId).HasName("PK__SkillsEx__3AD4B6888BC236CF");

            entity.ToTable("SkillsExperienceMapping");

            entity.Property(e => e.SkillsExperienceMappingId).HasColumnName("SkillsExperienceMappingID");

            entity.HasOne(d => d.Experience).WithMany(p => p.SkillsExperienceMappings)
                .HasForeignKey(d => d.ExperienceId)
                .HasConstraintName("FK__SkillsExp__Exper__47DBAE45");

            entity.HasOne(d => d.Skill).WithMany(p => p.SkillsExperienceMappings)
                .HasForeignKey(d => d.SkillId)
                .HasConstraintName("FK__SkillsExp__Skill__48CFD27E");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK__State__C3BA3B3A1B24A0CD");

            entity.ToTable("State");

            entity.Property(e => e.StateName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.States)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__State__CountryId__4D94879B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C6CBE4D87");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("trg_user_history_ins_del");
                    tb.HasTrigger("trg_user_history_mod");
                });

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534D05FAD47").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__Users__C9F284562985F4BD").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DeletedById).HasDefaultValue(0);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedById).HasDefaultValue(0);
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsersHistory>(entity =>
        {
            entity.HasKey(e => e.UserHistoryId).HasName("PK__Users_Hi__454942E713835121");

            entity.ToTable("Users_History");

            entity.Property(e => e.UserHistoryId).HasColumnName("User_HistoryId");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedById).HasDefaultValue(0);
            entity.Property(e => e.DeletedById).HasDefaultValue(0);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedById).HasDefaultValue(0);
            entity.Property(e => e.Operation)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("operation");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.UsersHistories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users_His__UserI__114A936A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
