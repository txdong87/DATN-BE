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
    [Migration("20240623071756_AddDB")]
    partial class AddDB
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

                    b.Property<string>("CdhaName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("CDHAName");

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("date")
                        .HasColumnName("dateCreate");

                    b.Property<DateTime?>("TimeEstimate")
                        .HasColumnType("date")
                        .HasColumnName("timeEstimate");

                    b.HasKey("Id");

                    b.ToTable("medical_cdha", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MedicalCdhaCaseStudy", b =>
                {
                    b.Property<int?>("MedicalCdhaId")
                        .HasColumnType("int(11)")
                        .HasColumnName("medicalCdhaId");

                    b.Property<int?>("CaseStudyId")
                        .HasColumnType("int(11)")
                        .HasColumnName("caseStudyId");

                    b.Property<string>("Conlusion")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("conclusion")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int(11)")
                        .HasColumnName("doctorId");

                    b.Property<int>("Id")
                        .HasColumnType("int");

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

                    b.Property<int>("ReportId")
                        .HasColumnType("int(11)");

                    b.HasKey("MedicalCdhaId", "CaseStudyId");

                    b.HasIndex("CaseStudyId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("KtvId");

                    b.HasIndex("ReportId")
                        .IsUnique();

                    b.ToTable("medical_cdha_case_study", (string)null);
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

                    b.Property<int>("CaseStudyId")
                        .HasColumnType("int(11)")
                        .HasColumnName("caseStudyId");

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

                    b.Property<string>("Image")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("image")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<int?>("KtvId")
                        .HasColumnType("int(11)");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int(11)")
                        .HasColumnName("patientId");

                    b.Property<int?>("State")
                        .HasColumnType("int(11)")
                        .HasColumnName("state");

                    b.HasKey("ReportId")
                        .HasName("PRIMARY");

                    b.HasIndex("CaseStudyId");

                    b.HasIndex("KtvId");

                    b.HasIndex(new[] { "DoctorId" }, "doctorId");

                    b.HasIndex(new[] { "PatientId" }, "patientId")
                        .HasDatabaseName("patientId1");

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
                        .HasConstraintName("FK_casestudy_doctor");

                    b.HasOne("Domain.Entities.Patient", "PatientIdNavigation")
                        .WithMany("Casestudies")
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_casestudy_patient");

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

            modelBuilder.Entity("Domain.Entities.MedicalCdhaCaseStudy", b =>
                {
                    b.HasOne("Domain.Entities.Casestudy", "CaseStudyIdNavigation")
                        .WithMany("MedicalCdhas")
                        .HasForeignKey("CaseStudyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_medical_cdha_case_study_casestudy");

                    b.HasOne("Domain.Entities.Doctor", "DoctorIdNavigation")
                        .WithMany("MedicalCdhas")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_medical_cdha_case_study_doctor");

                    b.HasOne("Domain.Entities.KTV", "KtvIdNavigation")
                        .WithMany("MedicalCdhas")
                        .HasForeignKey("KtvId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_medical_cdha_case_study_ktv");

                    b.HasOne("Domain.Entities.MedicalCdha", "MedicalCdhaIdNavigation")
                        .WithMany("MedicalCdhaCaseStudies")
                        .HasForeignKey("MedicalCdhaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_medical_cdha_case_study_medicalcdha");

                    b.HasOne("Domain.Entities.Report", "Report")
                        .WithOne()
                        .HasForeignKey("Domain.Entities.MedicalCdhaCaseStudy", "ReportId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_medical_cdha_case_study_report");

                    b.Navigation("CaseStudyIdNavigation");

                    b.Navigation("DoctorIdNavigation");

                    b.Navigation("KtvIdNavigation");

                    b.Navigation("MedicalCdhaIdNavigation");

                    b.Navigation("Report");
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
                    b.HasOne("Domain.Entities.Casestudy", "Casestudy")
                        .WithMany("Report")
                        .HasForeignKey("CaseStudyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Doctor", "DoctorIdNavigation")
                        .WithMany("Reports")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("report_ibfk_2");

                    b.HasOne("Domain.Entities.KTV", "KTVIdNavigation")
                        .WithMany()
                        .HasForeignKey("KtvId");

                    b.HasOne("Domain.Entities.Patient", "PatientIdNavigation")
                        .WithMany("Reports")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("report_ibfk_1");

                    b.Navigation("Casestudy");

                    b.Navigation("DoctorIdNavigation");

                    b.Navigation("KTVIdNavigation");

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

                    b.Navigation("Prescriptions");

                    b.Navigation("Report");
                });

            modelBuilder.Entity("Domain.Entities.Doctor", b =>
                {
                    b.Navigation("Casestudies");

                    b.Navigation("MedicalCdhas");

                    b.Navigation("Patients");

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("Domain.Entities.KTV", b =>
                {
                    b.Navigation("MedicalCdhas");
                });

            modelBuilder.Entity("Domain.Entities.MedicalCdha", b =>
                {
                    b.Navigation("MedicalCdhaCaseStudies");
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