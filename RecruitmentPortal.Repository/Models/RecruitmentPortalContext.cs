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

    public virtual DbSet<CompanyLocation> CompanyLocations { get; set; }

    public virtual DbSet<CompanySocialMedium> CompanySocialMedia { get; set; }

    public virtual DbSet<CompanyStatus> CompanyStatuses { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<EducationUserMapping> EducationUserMappings { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<ExperienceUserMapping> ExperienceUserMappings { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SkillsExperienceMapping> SkillsExperienceMappings { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<User> Users { get; set; }

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

            entity.ToTable("company");

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

        modelBuilder.Entity<CompanyLocation>(entity =>
        {
            entity.HasKey(e => e.CompanyLocationId).HasName("PK__CompanyL__7496FF4DA24A63ED");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedById).HasDefaultValue(0);
            entity.Property(e => e.DeletedById).HasDefaultValue(0);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifiedById).HasDefaultValue(0);

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

            entity.ToTable("CompanyStatus");

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

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Country__10D1609FDC06E984");

            entity.ToTable("Country");

            entity.Property(e => e.CountryName)
                .HasMaxLength(255)
                .IsUnicode(false);
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

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PK__Profile__290C88E45A9045AD");

            entity.ToTable("Profile");

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
