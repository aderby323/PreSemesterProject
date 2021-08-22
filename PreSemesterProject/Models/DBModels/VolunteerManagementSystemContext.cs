using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PreSemesterProject.Models.DBModels
{
    public partial class VolunteerManagementSystemContext : DbContext
    {
        public VolunteerManagementSystemContext()
        {
        }

        public VolunteerManagementSystemContext(DbContextOptions<VolunteerManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Opportunity> Opportunities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }
        public virtual DbSet<VolunteerAddress> VolunteerAddresses { get; set; }
        public virtual DbSet<VolunteerEmergencyContact> VolunteerEmergencyContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Opportunity>(entity =>
            {
                entity.ToTable("Opportunity");

                entity.Property(e => e.OpportunityId).HasColumnName("OpportunityID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("User");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_User");
            });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.ToTable("Volunteer");

                entity.Property(e => e.VolunteerId).HasColumnName("VolunteerID");

                entity.Property(e => e.ApprovalStatus)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Availability)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.CellPhone)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentLicenses)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.DlonFile).HasColumnName("DLOnFile");

                entity.Property(e => e.EducationBackground)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HomePhone)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PreferredCenter)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SkillsAndInterests)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.SsonFile).HasColumnName("SSOnFile");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WorkPhone)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VolunteerAddress>(entity =>
            {
                entity.ToTable("VolunteerAddress");

                entity.Property(e => e.VolunteerAddressId).HasColumnName("VolunteerAddressID");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Address3)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.VolunteerId).HasColumnName("VolunteerID");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Volunteer)
                    .WithMany(p => p.VolunteerAddresses)
                    .HasForeignKey(d => d.VolunteerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VolunteerAddress_Volunteer");
            });

            modelBuilder.Entity<VolunteerEmergencyContact>(entity =>
            {
                entity.HasKey(e => e.VolunteerEmergencyId);

                entity.ToTable("VolunteerEmergencyContact");

                entity.Property(e => e.VolunteerEmergencyId).HasColumnName("VolunteerEmergencyID");

                entity.Property(e => e.EccellPhone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("ECCellPhone");

                entity.Property(e => e.EcemailAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ECEmailAddress");

                entity.Property(e => e.EchomePhone)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("ECHomePhone");

                entity.Property(e => e.Ecname)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ECName");

                entity.Property(e => e.EcworkPhone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("ECWorkPhone");

                entity.Property(e => e.VolunteerId).HasColumnName("VolunteerID");

                entity.HasOne(d => d.Volunteer)
                    .WithMany(p => p.VolunteerEmergencyContacts)
                    .HasForeignKey(d => d.VolunteerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VolunteerEmergencyContact_Volunteer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
