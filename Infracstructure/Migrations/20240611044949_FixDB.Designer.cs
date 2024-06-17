﻿// <auto-generated />
using System;
using Infracstructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(datnContext))]
    [Migration("20240611044949_FixDB")]
    partial class FixDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Casestudy", b =>
                {
                    b.Property<int>("CaseStudyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("CaseStudyId");

                    b.Property<string>("Conclusion")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("conclusion")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("date")
                        .HasColumnName("CreateDate");

                    b.Property<string>("Diagnostic")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("diagnostic")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int(11)");

                    b.Property<string>("Reason")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Reason")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<string>("Report")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("longtext")
                        .HasColumnName("report")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<int?>("ReportCount")
                        .HasColumnType("int(11)")
                        .HasColumnName("reportCount");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Status")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<int>("patientId")
                        .HasColumnType("int(11)")
                        .HasColumnName("patientId");

                    b.HasKey("CaseStudyId")
                        .HasName("PRIMARY");

                    b.HasIndex("DoctorId");

                    b.HasIndex(new[] { "patientId" }, "patientId");

                    b.ToTable("casestudy", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("doctorId");

                    b.Property<string>("DoctorRole")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("doctorRole");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("userId");

                    b.HasKey("DoctorId")
                        .HasName("PRIMARY");

                    b.HasIndex("UserId");

                    b.ToTable("doctor", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.KTV", b =>
                {
                    b.Property<int>("KtvId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ktvId");

                    b.Property<string>("KtvName")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ktvName")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<string>("Password")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<int?>("RoleIndication")
                        .HasColumnType("int(11)")
                        .HasColumnName("roleIndication");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("userId");

                    b.HasKey("KtvId")
                        .HasName("PRIMARY");

                    b.HasIndex("UserId");

                    b.ToTable("ktv", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MedicalCdha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int?>("CaseStudyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("date")
                        .HasColumnName("dateCreate");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int(11)")
                        .HasColumnName("doctorId");

                    b.Property<string>("ImageLink")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("imageLink")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<string>("ImageName")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("imageName")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<int?>("KtvId")
                        .HasColumnType("int(11)")
                        .HasColumnName("ktvId");

                    b.Property<bool?>("NonDicom")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("nonDicom");

                    b.Property<string>("ObservationType")
                        .HasColumnType("longtext")
                        .HasColumnName("observationType");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int(11)")
                        .HasColumnName("patientId");

                    b.Property<int?>("PatientIdNavigationPatientId")
                        .HasColumnType("int(11)");

                    b.Property<DateTime?>("TimeEstimate")
                        .HasColumnType("date")
                        .HasColumnName("timeEstimate");

                    b.HasKey("Id");

                    b.HasIndex("PatientIdNavigationPatientId");

                    b.HasIndex(new[] { "DoctorId" }, "doctorId");

                    b.HasIndex(new[] { "KtvId" }, "ktvId");

                    b.HasIndex(new[] { "PatientId" }, "patientId")
                        .HasDatabaseName("patientId1");

                    b.ToTable("medical_cdha", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MedicalIndication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int?>("CaseStudyId")
                        .HasColumnType("int(11)")
                        .HasColumnName("CaseStudyId");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CaseStudyId" }, "CaseStudyId");

                    b.ToTable("medical_indication", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MedicalTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int?>("CaseStudyId")
                        .HasColumnType("int(11)")
                        .HasColumnName("CaseStudyId");

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("date")
                        .HasColumnName("dateCreate");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int(11)")
                        .HasColumnName("doctorId");

                    b.Property<int?>("KtvId")
                        .HasColumnType("int(11)")
                        .HasColumnName("ktvId");

                    b.Property<string>("ObservationType")
                        .HasColumnType("longtext")
                        .HasColumnName("observationType");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int(11)")
                        .HasColumnName("patientId");

                    b.Property<string>("TestName")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("testName")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<DateTime?>("TimeEstimate")
                        .HasColumnType("date")
                        .HasColumnName("timeEstimate");

                    b.HasKey("Id");

                    b.HasIndex("CaseStudyId");

                    b.HasIndex(new[] { "DoctorId" }, "doctorId")
                        .HasDatabaseName("doctorId1");

                    b.HasIndex(new[] { "KtvId" }, "ktvId")
                        .HasDatabaseName("ktvId1");

                    b.HasIndex(new[] { "PatientId" }, "patientId")
                        .HasDatabaseName("patientId2");

                    b.ToTable("medical_test", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Medication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsFunctionalFoods")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Route")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Usage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Medication", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Nurse", b =>
                {
                    b.Property<int>("NurseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("nurseId");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("userId");

                    b.HasKey("NurseId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "UserId" }, "userId");

                    b.ToTable("nurse", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("patientId");

                    b.Property<string>("Address")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("address")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("date")
                        .HasColumnName("dob");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int(11)");

                    b.Property<string>("PatientName")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("patientName")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<int?>("Phone")
                        .HasColumnType("int(11)")
                        .HasColumnName("phone");

                    b.Property<int?>("Sex")
                        .HasColumnType("int(11)")
                        .HasColumnName("sex");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("date")
                        .HasColumnName("createdAt");

                    b.Property<string>("patientCode")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("patientCode")
                        .HasDefaultValueSql("'NULL'");

                    b.HasKey("PatientId")
                        .HasName("PRIMARY");

                    b.HasIndex("DoctorId");

                    b.ToTable("patient", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CasestudyId")
                        .IsRequired()
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("CasestudyId");

                    b.HasIndex("PatientId");

                    b.ToTable("Prescription", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.PrescriptionMedication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Dosages")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("MedicationId")
                        .HasColumnType("int");

                    b.Property<int>("PrescriptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicationId");

                    b.HasIndex("PrescriptionId");

                    b.ToTable("PrescriptionMedication", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Report", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("reportId");

                    b.Property<string>("Conclusion")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("conclusion")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<string>("Diagnostic")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("diagnostic")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int(11)")
                        .HasColumnName("doctorId");

                    b.Property<string>("DoctorName")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("doctorName")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<string>("Image")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("image")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<int?>("KtvId")
                        .HasColumnType("int(11)")
                        .HasColumnName("ktvId");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int(11)")
                        .HasColumnName("patientId");

                    b.Property<string>("PatientName")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("patientName")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<int?>("State")
                        .HasColumnType("int(11)")
                        .HasColumnName("state");

                    b.HasKey("ReportId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "DoctorId" }, "doctorId")
                        .HasDatabaseName("doctorId2");

                    b.HasIndex(new[] { "PatientId" }, "patientId")
                        .HasDatabaseName("patientId3");

                    b.ToTable("report", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("RoleId");

                    b.Property<string>("RoleName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("RoleName");

                    b.HasKey("RoleId")
                        .HasName("PRIMARY");

                    b.ToTable("role", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("userId");

                    b.Property<string>("Fullname")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("fullname")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<string>("Password")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int(11)")
                        .HasColumnName("RoleId");

                    b.Property<string>("user")
                        .HasColumnType("longtext");

                    b.HasKey("UserId")
                        .HasName("PRIMARY");

                    b.HasIndex("RoleId");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Casestudy", b =>
                {
                    b.HasOne("Domain.Entities.Doctor", "DoctorIdNavigation")
                        .WithMany("Casestudies")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_casestudy_doctor_DoctorId");

                    b.HasOne("Domain.Entities.Patient", "PatientIdNavigation")
                        .WithMany("Casestudies")
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("casestudy_ibfk_1");

                    b.Navigation("DoctorIdNavigation");

                    b.Navigation("PatientIdNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Doctor", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany("Doctors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.KTV", b =>
                {
                    b.HasOne("Domain.Entities.User", "UserldNavigation")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserldNavigation");
                });

            modelBuilder.Entity("Domain.Entities.MedicalCdha", b =>
                {
                    b.HasOne("Domain.Entities.Doctor", "DoctorIdNavigation")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("Domain.Entities.KTV", "KtvIdNavigation")
                        .WithMany("MedicalCdhas")
                        .HasForeignKey("KtvId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("medical_cdha_ibfk_3");

                    b.HasOne("Domain.Entities.Casestudy", "CaseStudyIdNavigation")
                        .WithMany("MedicalCdhas")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("medical_cdha_ibfk_1");

                    b.HasOne("Domain.Entities.Patient", "PatientIdNavigation")
                        .WithMany()
                        .HasForeignKey("PatientIdNavigationPatientId");

                    b.Navigation("CaseStudyIdNavigation");

                    b.Navigation("DoctorIdNavigation");

                    b.Navigation("KtvIdNavigation");

                    b.Navigation("PatientIdNavigation");
                });

            modelBuilder.Entity("Domain.Entities.MedicalIndication", b =>
                {
                    b.HasOne("Domain.Entities.Casestudy", "CaseStudyIdNavigation")
                        .WithMany("MedicalIndications")
                        .HasForeignKey("CaseStudyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("medical_indication_ibfk_1");

                    b.Navigation("CaseStudyIdNavigation");
                });

            modelBuilder.Entity("Domain.Entities.MedicalTest", b =>
                {
                    b.HasOne("Domain.Entities.Casestudy", "CaseStudyIdNavigation")
                        .WithMany("MedicalTests")
                        .HasForeignKey("CaseStudyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("medical_test_ibfk_1");

                    b.HasOne("Domain.Entities.Doctor", "DoctorIdNavigation")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("Domain.Entities.KTV", "KtvIdNavigation")
                        .WithMany("MedicalTests")
                        .HasForeignKey("KtvId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("medical_test_ibfk_3");

                    b.HasOne("Domain.Entities.Patient", "PatientIdNavigation")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.Navigation("CaseStudyIdNavigation");

                    b.Navigation("DoctorIdNavigation");

                    b.Navigation("KtvIdNavigation");

                    b.Navigation("PatientIdNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Nurse", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany("Nurses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Patient", b =>
                {
                    b.HasOne("Domain.Entities.Doctor", null)
                        .WithMany("Patients")
                        .HasForeignKey("DoctorId");
                });

            modelBuilder.Entity("Domain.Entities.Prescription", b =>
                {
                    b.HasOne("Domain.Entities.Casestudy", "Casestudy")
                        .WithMany("Prescriptions")
                        .HasForeignKey("CasestudyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.Navigation("Casestudy");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Entities.PrescriptionMedication", b =>
                {
                    b.HasOne("Domain.Entities.Medication", "Medication")
                        .WithMany("PrescriptionMedications")
                        .HasForeignKey("MedicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Prescription", "Prescription")
                        .WithMany("PrescriptionMedications")
                        .HasForeignKey("PrescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medication");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("Domain.Entities.Report", b =>
                {
                    b.HasOne("Domain.Entities.Doctor", "DoctorIdNavigation")
                        .WithMany("Reports")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("report_ibfk_2");

                    b.HasOne("Domain.Entities.Patient", "PatientIdNavigation")
                        .WithMany("Reports")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("report_ibfk_1");

                    b.Navigation("DoctorIdNavigation");

                    b.Navigation("PatientIdNavigation");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.Entities.Casestudy", b =>
                {
                    b.Navigation("MedicalCdhas");

                    b.Navigation("MedicalIndications");

                    b.Navigation("MedicalTests");

                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("Domain.Entities.Doctor", b =>
                {
                    b.Navigation("Casestudies");

                    b.Navigation("Patients");

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("Domain.Entities.KTV", b =>
                {
                    b.Navigation("MedicalCdhas");

                    b.Navigation("MedicalTests");
                });

            modelBuilder.Entity("Domain.Entities.Medication", b =>
                {
                    b.Navigation("PrescriptionMedications");
                });

            modelBuilder.Entity("Domain.Entities.Patient", b =>
                {
                    b.Navigation("Casestudies");

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("Domain.Entities.Prescription", b =>
                {
                    b.Navigation("PrescriptionMedications");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Doctors");

                    b.Navigation("Nurses");
                });
#pragma warning restore 612, 618
        }
    }
}
