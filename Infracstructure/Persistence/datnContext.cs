using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Entities;

namespace Infracstructure.Persistance
{
    public partial class datnContext : DbContext
    {
        public datnContext()
        {
        }

        public datnContext(DbContextOptions<datnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Casestudy> Casestudies { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<KTV> Ktvs { get; set; } = null!;
        public virtual DbSet<MedicalCdha> MedicalCdhas { get; set; } = null!;
        public virtual DbSet<Medication> Medication { get; set; } = null!;
        public virtual DbSet<Prescription> Prescription { get; set; } = null!;
        public virtual DbSet<PrescriptionMedication> PrescriptionMedication { get; set; } = null!;
        public virtual DbSet<Nurse> Nurses { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Casestudy>(entity =>
            {
                entity.HasKey(e => e.CaseStudyId)
                    .HasName("PRIMARY");

                entity.ToTable("casestudy");

                entity.HasIndex(e => e.patientId, "patientId");

                entity.Property(e => e.CaseStudyId)
                    .HasColumnType("int(11)")
                    .HasColumnName("CaseStudyId");

                //entity.Property(e => e.ClinicalDiagnosis)
                //    .HasMaxLength(255)
                //    .HasColumnName("clinicalDiagnosis")
                //    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Conclusion)
                    .HasMaxLength(255)
                    .HasColumnName("conclusion")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Diagnostic)
                    .HasMaxLength(255)
                    .HasColumnName("diagnostic")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Reason)
                    .HasMaxLength(255)
                    .HasColumnName("Reason")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("Status")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("CreateDate") ;

                //entity.Property(e => e.ListCdha)
                //    .HasColumnName("listCDHA")
                //    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.patientId)
                    .HasColumnType("int(11)")
                    .HasColumnName("patientId");

                entity.Property(e => e.Report)
                    .HasColumnName("report")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ReportCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("reportCount");
                entity.HasOne(d => d.PatientIdNavigation)
                  .WithMany(p => p.Casestudies)
                  .HasForeignKey(d => d.patientId)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("FK_casestudy_patient");

                // Configure relationship with Doctor (optional initially)
                entity.HasOne(d => d.DoctorIdNavigation)
                    .WithMany(p => p.Casestudies)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_casestudy_doctor");

                // Configure relationship with Prescription
                entity.HasMany(e => e.Prescriptions)
                    .WithOne(e => e.Casestudy)
                    .HasForeignKey(e => e.CasestudyId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Configure relationship with MedicalCdha
                entity.HasMany(e => e.MedicalCdhas)
                    .WithOne(e => e.CaseStudyIdNavigation)
                    .HasForeignKey(e => e.CaseStudyId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.DoctorId)
                      .HasName("PRIMARY");

                entity.ToTable("doctor");

                entity.Property(e => e.DoctorId)
                      .HasColumnType("int(11)")
                      .HasColumnName("doctorId");

                entity.Property(e => e.UserId)
                      .HasColumnType("int(11)")
                      .HasColumnName("userId");
                entity.Property(e => e.DoctorRole)
                   .HasMaxLength(255)
                   .HasColumnName("doctorRole");
            });

            modelBuilder.Entity<KTV>(entity =>
            {
                entity.HasKey(e => e.KtvId)
                    .HasName("PRIMARY");

                entity.ToTable("ktv");

                entity.Property(e => e.KtvId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ktvId");

                entity.Property(e => e.KtvName)
                    .HasMaxLength(255)
                    .HasColumnName("ktvName")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RoleIndication)
                    .HasColumnType("int(11)")
                    .HasColumnName("roleIndication");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("userId");

            });

            modelBuilder.Entity<MedicalCdha>(entity =>
            {
                entity.ToTable("medical_cdha");

                entity.HasIndex(e => e.DoctorId, "doctorId");

                entity.HasIndex(e => e.KtvId, "ktvId");

                entity.HasIndex(e => e.PatientId, "patientId");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("date")
                    .HasColumnName("dateCreate");

                entity.Property(e => e.DoctorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("doctorId");

                entity.Property(e => e.ImageLink)
                    .HasMaxLength(255)
                    .HasColumnName("imageLink")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ImageName)
                    .HasMaxLength(255)
                    .HasColumnName("imageName")
                    .HasDefaultValueSql("'NULL'");


                entity.Property(e => e.KtvId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ktvId");

                entity.Property(e => e.NonDicom)
                    .HasColumnName("nonDicom");

                entity.Property(e => e.ObservationType)
                    .HasColumnName("observationType");


                entity.Property(e => e.PatientId)
                    .HasColumnType("int(11)")
                    .HasColumnName("patientId");

                entity.Property(e => e.TimeEstimate)
                    .HasColumnType("date")
                    .HasColumnName("timeEstimate");

                entity.HasOne(d => d.KtvIdNavigation)
                    .WithMany(p => p.MedicalCdhas)
                    .HasForeignKey(d => d.KtvId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("medical_cdha_ibfk_3");

                entity.HasOne(d => d.CaseStudyIdNavigation)
                    .WithMany(p => p.MedicalCdhas)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("medical_cdha_ibfk_1");
            });

           
            modelBuilder.Entity<Nurse>(entity =>
            {
                entity.HasKey(e => e.NurseId)
                    .HasName("PRIMARY");

                entity.ToTable("nurse");

                entity.HasIndex(e => e.UserId, "userId");

                entity.Property(e => e.NurseId)
                    .HasColumnType("int(11)")
                    .HasColumnName("nurseId");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("userId");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PRIMARY");

                entity.ToTable("patient");

                entity.Property(e => e.PatientId)
                    .HasColumnType("int(11)")
                    .HasColumnName("patientId");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.patientCode)
                     .HasMaxLength(255)
                    .HasColumnName("patientCode")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PatientName)
                    .HasMaxLength(255)
                    .HasColumnName("patientName")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Phone)
                    .HasColumnType("int(11)")
                    .HasColumnName("phone");

                entity.Property(e => e.Sex)
                    .HasColumnType("int(11)")
                    .HasColumnName("sex");
                entity.Property(e => e.createdAt)
                   .HasColumnType("date")
                   .HasColumnName("createdAt");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PRIMARY");

                entity.ToTable("report");

                entity.HasIndex(e => e.DoctorId, "doctorId");

                entity.HasIndex(e => e.PatientId, "patientId");

                entity.Property(e => e.ReportId)
                    .HasColumnType("int(11)")
                    .HasColumnName("reportId");

                entity.Property(e => e.Conclusion)
                    .HasMaxLength(255)
                    .HasColumnName("conclusion")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Diagnostic)
                    .HasMaxLength(255)
                    .HasColumnName("diagnostic")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(255)
                    .HasColumnName("doctorName")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DoctorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("doctorId");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("image")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.KtvId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ktvId");

                entity.Property(e => e.PatientName)
                    .HasMaxLength(255)
                    .HasColumnName("patientName")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PatientId)
                    .HasColumnType("int(11)")
                    .HasColumnName("patientId");

                entity.Property(e => e.State)
                    .HasColumnType("int(11)")
                    .HasColumnName("state");

                entity.HasOne(d => d.DoctorIdNavigation)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("report_ibfk_2");

                entity.HasOne(d => d.PatientIdNavigation)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("report_ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId)
                      .HasName("PRIMARY");

                entity.ToTable("user");

                entity.Property(e => e.UserId)
                      .HasColumnType("int(11)")
                      .HasColumnName("userId")
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Fullname)
                      .HasMaxLength(255)
                      .HasColumnName("fullname")
                      .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.Password)
                      .HasMaxLength(255)
                      .HasColumnName("password")
                      .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RoleId)
                      .HasColumnType("int(11)")
                      .HasColumnName("RoleId");
            });


            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PRIMARY");

                entity.ToTable("role");

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(11)")
                    .HasColumnName("RoleId");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .HasColumnName("RoleName");

              
            });
            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.ToTable("Prescription");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Date).IsRequired();

                entity.HasOne(e => e.Casestudy)
                      .WithMany(c => c.Prescriptions)
                      .HasForeignKey(e => e.CasestudyId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Medication>(entity =>
            {
                entity.ToTable("Medication");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Unit).HasMaxLength(50);
                entity.Property(e => e.Route).HasMaxLength(100);
                entity.Property(e => e.Usage).HasMaxLength(100);
                entity.Property(e => e.IsFunctionalFoods).HasDefaultValue(false);
            });

            modelBuilder.Entity<PrescriptionMedication>(entity =>
            {
                entity.ToTable("PrescriptionMedication");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Dosages).HasMaxLength(200);

                entity.HasOne(e => e.Prescription)
                      .WithMany(p => p.PrescriptionMedications)
                      .HasForeignKey(e => e.PrescriptionId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Medication)
                      .WithMany(m => m.PrescriptionMedications)
                      .HasForeignKey(e => e.MedicationId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
