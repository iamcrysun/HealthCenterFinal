using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL
{
    public partial class HealthyContext : IdentityDbContext<DAL.Entity.User>
    {
        public HealthyContext()
        {
        }

        public HealthyContext(DbContextOptions<HealthyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<DoProc> DoProcs { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<DoctorSee> DoctorSees { get; set; }
        public virtual DbSet<MakingProcedure> MakingProcedures { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<Nurce> Nurces { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Procedure> Procedures { get; set; }
        public virtual DbSet<RecordInPatientFile> RecordInPatientFiles { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<ScheduleProcedure> ScheduleProcedures { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<TypeofProc> TypeofProcs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-F6L7479J\\SQLEXPRESS;Database=Healthy;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Category1)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Category");
            });

            modelBuilder.Entity<Day>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DayOfWeek)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DoProc>(entity =>
            {
                entity.ToTable("DoProc");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.ProcId).HasColumnName("ProcID");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.DoProcs)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoProc_Patient");

                entity.HasOne(d => d.Proc)
                    .WithMany(p => p.DoProcs)
                    .HasForeignKey(d => d.ProcId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoProc_TypeofProc");

                entity.HasOne(d => d.Record)
                    .WithMany(p => p.DoProcs)
                    .HasForeignKey(d => d.RecordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoProc_RecordInPatientFile");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctor");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.SpecializationId).HasColumnName("SpecializationID");

                entity.Property(e => e.ZamEnd).HasColumnType("date");

                entity.Property(e => e.ZamStart).HasColumnType("date");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doctor_Categories");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.SpecializationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doctor_Specialization");
            });

            modelBuilder.Entity<DoctorSee>(entity =>
            {
                entity.ToTable("DoctorSee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.ZamId).HasColumnName("ZamID");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.DoctorSees)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorSee_Doctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.DoctorSees)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorSee_Patient");
            });

            modelBuilder.Entity<MakingProcedure>(entity =>
            {
                entity.ToTable("MakingProcedure");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NurceId).HasColumnName("NurceID");

                entity.Property(e => e.ProcedureId).HasColumnName("ProcedureID");

                entity.HasOne(d => d.Nurce)
                    .WithMany(p => p.MakingProcedures)
                    .HasForeignKey(d => d.NurceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MakingProcedure_Nurce");

                entity.HasOne(d => d.Procedure)
                    .WithMany(p => p.MakingProcedures)
                    .HasForeignKey(d => d.ProcedureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MakingProcedure_TypeofProc");
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Medicine)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.HasOne(d => d.Record)
                    .WithMany(p => p.Medicaments)
                    .HasForeignKey(d => d.RecordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medicaments_RecordInPatientFile");
            });

            modelBuilder.Entity<Nurce>(entity =>
            {
                entity.ToTable("Nurce");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Document)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Male)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlaceOfWork)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetId).HasColumnName("StreetID");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.StreetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient_Patient");
            });

            modelBuilder.Entity<Procedure>(entity =>
            {
                entity.ToTable("Procedure");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DoProcId).HasColumnName("DoProcID");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.HasOne(d => d.DoProc)
                    .WithMany(p => p.Procedures)
                    .HasForeignKey(d => d.DoProcId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Procedure_DoProc");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Procedures)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Procedure_ScheduleProcedure");
            });

            modelBuilder.Entity<RecordInPatientFile>(entity =>
            {
                entity.ToTable("RecordInPatientFile");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Diagnosis)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.NurseId).HasColumnName("NurseID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.Result)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.RecordInPatientFiles)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_RecordInPatientFile_Doctor");

                entity.HasOne(d => d.Nurse)
                    .WithMany(p => p.RecordInPatientFiles)
                    .HasForeignKey(d => d.NurseId)
                    .HasConstraintName("FK_RecordInPatientFile_Nurce");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.RecordInPatientFiles)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecordInPatientFile_Patient");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DayofWeek).HasColumnName("dayofWeek");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.ZamId).HasColumnName("ZamID");

                entity.HasOne(d => d.DayofWeekNavigation)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.DayofWeek)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Days");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Doctor");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Shifts");
            });

            modelBuilder.Entity<ScheduleProcedure>(entity =>
            {
                entity.ToTable("ScheduleProcedure");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DayId).HasColumnName("DayID");

                entity.Property(e => e.ProcedureId).HasColumnName("ProcedureID");

                entity.HasOne(d => d.Day)
                    .WithMany(p => p.ScheduleProcedures)
                    .HasForeignKey(d => d.DayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduleProcedure_Days");

                entity.HasOne(d => d.Procedure)
                    .WithMany(p => p.ScheduleProcedures)
                    .HasForeignKey(d => d.ProcedureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduleProcedure_TypeofProc");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Number).HasColumnName("number");
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.ToTable("Specialization");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SpecializationName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Street1)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Street");
            });

            modelBuilder.Entity<TypeofProc>(entity =>
            {
                entity.ToTable("TypeofProc");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Users_Doctor");

                entity.HasOne(d => d.UserTypeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_UserTypes");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.UserType1)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("UserType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
