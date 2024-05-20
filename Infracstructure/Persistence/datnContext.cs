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
        public virtual DbSet<Ktv> Ktvs { get; set; } = null!;
        public virtual DbSet<MedicalCdha> MedicalCdhas { get; set; } = null!;
        public virtual DbSet<MedicalIndication> MedicalIndications { get; set; } = null!;
        public virtual DbSet<MedicalTest> MedicalTests { get; set; } = null!;
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
                entity.HasKey(e => e.CaseStudyld)
                    .HasName("PRIMARY");

                entity.ToTable("casestudy");

                entity.HasIndex(e => e.Patientld, "patientld");

                entity.Property(e => e.CaseStudyld)
                    .HasColumnType("int(11)")
                    .HasColumnName("caseStudyld");

                entity.Property(e => e.ClinicalDiagnosis)
                    .HasMaxLength(255)
                    .HasColumnName("clinicalDiagnosis")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Conclusion)
                    .HasMaxLength(255)
                    .HasColumnName("conclusion")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Diagnostic)
                    .HasMaxLength(255)
                    .HasColumnName("diagnostic")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DiagnosticClinical)
                    .HasMaxLength(255)
                    .HasColumnName("diagnosticClinical")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ListCdha)
                    .HasColumnName("listCDHA")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PatientName)
                    .HasMaxLength(255)
                    .HasColumnName("patientName")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Patientld)
                    .HasColumnType("int(11)")
                    .HasColumnName("patientld")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Report)
                    .HasColumnName("report")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ReportCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("reportCount")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.PatientldNavigation)
                    .WithMany(p => p.Casestudies)
                    .HasForeignKey(d => d.Patientld)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("casestudy_ibfk_1");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.Doctorld)
                    .HasName("PRIMARY");

                entity.ToTable("doctor");

                entity.HasIndex(e => e.Userld, "userld");

                entity.Property(e => e.Doctorld)
                    .HasColumnType("int(11)")
                    .HasColumnName("doctorld");

                entity.Property(e => e.Userld)
                    .HasColumnType("int(11)")
                    .HasColumnName("userld")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.UserldNavigation)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.Userld)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("doctor_ibfk_1");
            });

            modelBuilder.Entity<Ktv>(entity =>
            {
                entity.HasKey(e => e.Ktvld)
                    .HasName("PRIMARY");

                entity.ToTable("ktv");

                entity.Property(e => e.Ktvld)
                    .HasColumnType("int(11)")
                    .HasColumnName("ktvld");

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
                    .HasColumnName("roleIndication")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.User)
                    .HasMaxLength(255)
                    .HasColumnName("user")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<MedicalCdha>(entity =>
            {
                entity.ToTable("medical_cdha");

                entity.HasIndex(e => e.Doctorld, "doctorld");

                entity.HasIndex(e => e.Ktvld, "ktvld");

                entity.HasIndex(e => e.Patientld, "patientld");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("date")
                    .HasColumnName("dateCreate")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(255)
                    .HasColumnName("doctorName")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Doctorld)
                    .HasColumnType("int(11)")
                    .HasColumnName("doctorld")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ImageLink)
                    .HasMaxLength(255)
                    .HasColumnName("imageLink")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ImageName)
                    .HasMaxLength(255)
                    .HasColumnName("imageName")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.KtvName)
                    .HasMaxLength(255)
                    .HasColumnName("ktvName")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Ktvld)
                    .HasColumnType("int(11)")
                    .HasColumnName("ktvld")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NonDicom)
                    .HasColumnName("nonDicom")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ObservationType)
                    .HasColumnName("observationType")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PatientName)
                    .HasMaxLength(255)
                    .HasColumnName("patientName")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Patientld)
                    .HasColumnType("int(11)")
                    .HasColumnName("patientld")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TimeEstimate)
                    .HasColumnType("date")
                    .HasColumnName("timeEstimate")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.DoctorldNavigation)
                    .WithMany(p => p.MedicalCdhas)
                    .HasForeignKey(d => d.Doctorld)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("medical_cdha_ibfk_2");

                entity.HasOne(d => d.KtvldNavigation)
                    .WithMany(p => p.MedicalCdhas)
                    .HasForeignKey(d => d.Ktvld)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("medical_cdha_ibfk_3");

                entity.HasOne(d => d.PatientldNavigation)
                    .WithMany(p => p.MedicalCdhas)
                    .HasForeignKey(d => d.Patientld)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("medical_cdha_ibfk_1");
            });

            modelBuilder.Entity<MedicalIndication>(entity =>
            {
                entity.ToTable("medical_indication");

                entity.HasIndex(e => e.Patientld, "patientld");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Patientld)
                    .HasColumnType("int(11)")
                    .HasColumnName("patientld")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.PatientldNavigation)
                    .WithMany(p => p.MedicalIndications)
                    .HasForeignKey(d => d.Patientld)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("medical_indication_ibfk_1");
            });

            modelBuilder.Entity<MedicalTest>(entity =>
            {
                entity.ToTable("medical_test");

                entity.HasIndex(e => e.Doctorld, "doctorld");

                entity.HasIndex(e => e.Ktvld, "ktvld");

                entity.HasIndex(e => e.Patientld, "patientld");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("date")
                    .HasColumnName("dateCreate")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(255)
                    .HasColumnName("doctorName")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Doctorld)
                    .HasColumnType("int(11)")
                    .HasColumnName("doctorld")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.KtvName)
                    .HasMaxLength(255)
                    .HasColumnName("ktvName")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Ktvld)
                    .HasColumnType("int(11)")
                    .HasColumnName("ktvld")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ObservationType)
                    .HasColumnName("observationType")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PatientName)
                    .HasMaxLength(255)
                    .HasColumnName("patientName")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Patientld)
                    .HasColumnType("int(11)")
                    .HasColumnName("patientld")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TestName)
                    .HasMaxLength(255)
                    .HasColumnName("testName")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TimeEstimate)
                    .HasColumnType("date")
                    .HasColumnName("timeEstimate")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.DoctorldNavigation)
                    .WithMany(p => p.MedicalTests)
                    .HasForeignKey(d => d.Doctorld)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("medical_test_ibfk_2");

                entity.HasOne(d => d.KtvldNavigation)
                    .WithMany(p => p.MedicalTests)
                    .HasForeignKey(d => d.Ktvld)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("medical_test_ibfk_3");

                entity.HasOne(d => d.PatientldNavigation)
                    .WithMany(p => p.MedicalTests)
                    .HasForeignKey(d => d.Patientld)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("medical_test_ibfk_1");
            });

            modelBuilder.Entity<Nurse>(entity =>
            {
                entity.HasKey(e => e.Nurseld)
                    .HasName("PRIMARY");

                entity.ToTable("nurse");

                entity.HasIndex(e => e.Userld, "userld");

                entity.Property(e => e.Nurseld)
                    .HasColumnType("int(11)")
                    .HasColumnName("nurseld");

                entity.Property(e => e.Userld)
                    .HasColumnType("int(11)")
                    .HasColumnName("userld")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.UserldNavigation)
                    .WithMany(p => p.Nurses)
                    .HasForeignKey(d => d.Userld)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("nurse_ibfk_1");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Patientld)
                    .HasName("PRIMARY");

                entity.ToTable("patient");

                entity.HasIndex(e => e.Doctorld, "doctorld");

                entity.Property(e => e.Patientld)
                    .HasColumnType("int(11)")
                    .HasColumnName("patientld");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Doctorld)
                    .HasColumnType("int(11)")
                    .HasColumnName("doctorld")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PatientName)
                    .HasMaxLength(255)
                    .HasColumnName("patientName")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Phone)
                    .HasColumnType("int(11)")
                    .HasColumnName("phone")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Roomld)
                    .HasColumnType("int(11)")
                    .HasColumnName("roomld")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Sex)
                    .HasColumnType("int(11)")
                    .HasColumnName("sex")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.DoctorldNavigation)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.Doctorld)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("patient_ibfk_1");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(e => e.Reportld)
                    .HasName("PRIMARY");

                entity.ToTable("report");

                entity.HasIndex(e => e.Doctorld, "doctorld");

                entity.HasIndex(e => e.Patientld, "patientld");

                entity.Property(e => e.Reportld)
                    .HasColumnType("int(11)")
                    .HasColumnName("reportld");

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

                entity.Property(e => e.Doctorld)
                    .HasColumnType("int(11)")
                    .HasColumnName("doctorld")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("image")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Ktvld)
                    .HasColumnType("int(11)")
                    .HasColumnName("ktvld")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PatientName)
                    .HasMaxLength(255)
                    .HasColumnName("patientName")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Patientld)
                    .HasColumnType("int(11)")
                    .HasColumnName("patientld")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.State)
                    .HasColumnType("int(11)")
                    .HasColumnName("state")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.DoctorldNavigation)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.Doctorld)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("report_ibfk_2");

                entity.HasOne(d => d.PatientldNavigation)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.Patientld)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("report_ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Userld)
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.Property(e => e.Userld)
                    .HasColumnType("int(11)")
                    .HasColumnName("userld");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(255)
                    .HasColumnName("fullname")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password")
                    .HasDefaultValueSql("'NULL'");

            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PRIMARY");

                entity.ToTable("role");

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Roleld");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .HasColumnName("RoleName");

              
            });
                OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
