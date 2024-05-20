﻿//// <auto-generated />
//using System;
//using Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

//#nullable disable

//namespace DATN.Migrations
//{
//    [DbContext(typeof(datnContext))]
//    partial class datnContextModelSnapshot : ModelSnapshot
//    {
//        protected override void BuildModel(ModelBuilder modelBuilder)
//        {
//#pragma warning disable 612, 618
//            modelBuilder
//                .HasAnnotation("ProductVersion", "6.0.29")
//                .HasAnnotation("Relational:MaxIdentifierLength", 64);

//            modelBuilder.Entity("DATN.Entities.Casestudy", b =>
//                {
//                    b.Property<int>("CaseStudyld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("caseStudyld");

//                    b.Property<string>("ClinicalDiagnosis")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("clinicalDiagnosis")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("Conclusion")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("conclusion")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("Diagnostic")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("diagnostic")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("DiagnosticClinical")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("diagnosticClinical")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("ListCdha")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("longtext")
//                        .HasColumnName("listCDHA")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("PatientName")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("patientName")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<int?>("Patientld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("patientld")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("Report")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("longtext")
//                        .HasColumnName("report")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<int?>("ReportCount")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("reportCount")
//                        .HasDefaultValueSql("'NULL'");

//                    b.HasKey("CaseStudyld")
//                        .HasName("PRIMARY");

//                    b.HasIndex(new[] { "Patientld" }, "patientld");

//                    b.ToTable("casestudy", (string)null);
//                });

//            modelBuilder.Entity("DATN.Entities.Doctor", b =>
//                {
//                    b.Property<int>("Doctorld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("doctorld");

//                    b.Property<int?>("Userld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("userld")
//                        .HasDefaultValueSql("'NULL'");

//                    b.HasKey("Doctorld")
//                        .HasName("PRIMARY");

//                    b.HasIndex(new[] { "Userld" }, "userld");

//                    b.ToTable("doctor", (string)null);
//                });

//            modelBuilder.Entity("DATN.Entities.Ktv", b =>
//                {
//                    b.Property<int>("Ktvld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("ktvld");

//                    b.Property<string>("KtvName")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("ktvName")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("Password")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("password")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<int?>("RoleIndication")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("roleIndication")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("User")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("user")
//                        .HasDefaultValueSql("'NULL'");

//                    b.HasKey("Ktvld")
//                        .HasName("PRIMARY");

//                    b.ToTable("ktv", (string)null);
//                });

//            modelBuilder.Entity("DATN.Entities.MedicalCdha", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("id");

//                    b.Property<DateTime?>("DateCreate")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("date")
//                        .HasColumnName("dateCreate")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("DoctorName")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("doctorName")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<int?>("Doctorld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("doctorld")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("ImageLink")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("imageLink")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("ImageName")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("imageName")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("KtvName")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("ktvName")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<int?>("Ktvld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("ktvld")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<bool?>("NonDicom")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("tinyint(1)")
//                        .HasColumnName("nonDicom")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("ObservationType")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("longtext")
//                        .HasColumnName("observationType")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("PatientName")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("patientName")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<int?>("Patientld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("patientld")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<DateTime?>("TimeEstimate")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("date")
//                        .HasColumnName("timeEstimate")
//                        .HasDefaultValueSql("'NULL'");

//                    b.HasKey("Id");

//                    b.HasIndex(new[] { "Doctorld" }, "doctorld");

//                    b.HasIndex(new[] { "Ktvld" }, "ktvld");

//                    b.HasIndex(new[] { "Patientld" }, "patientld")
//                        .HasDatabaseName("patientld1");

//                    b.ToTable("medical_cdha", (string)null);
//                });

//            modelBuilder.Entity("DATN.Entities.MedicalIndication", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("id");

//                    b.Property<int?>("Patientld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("patientld")
//                        .HasDefaultValueSql("'NULL'");

//                    b.HasKey("Id");

//                    b.HasIndex(new[] { "Patientld" }, "patientld")
//                        .HasDatabaseName("patientld2");

//                    b.ToTable("medical_indication", (string)null);
//                });

//            modelBuilder.Entity("DATN.Entities.MedicalTest", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("id");

//                    b.Property<DateTime?>("DateCreate")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("date")
//                        .HasColumnName("dateCreate")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("DoctorName")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("doctorName")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<int?>("Doctorld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("doctorld")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("KtvName")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("ktvName")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<int?>("Ktvld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("ktvld")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("ObservationType")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("longtext")
//                        .HasColumnName("observationType")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("PatientName")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("patientName")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<int?>("Patientld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("patientld")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("TestName")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("testName")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<DateTime?>("TimeEstimate")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("date")
//                        .HasColumnName("timeEstimate")
//                        .HasDefaultValueSql("'NULL'");

//                    b.HasKey("Id");

//                    b.HasIndex(new[] { "Doctorld" }, "doctorld")
//                        .HasDatabaseName("doctorld1");

//                    b.HasIndex(new[] { "Ktvld" }, "ktvld")
//                        .HasDatabaseName("ktvld1");

//                    b.HasIndex(new[] { "Patientld" }, "patientld")
//                        .HasDatabaseName("patientld3");

//                    b.ToTable("medical_test", (string)null);
//                });

//            modelBuilder.Entity("DATN.Entities.Nurse", b =>
//                {
//                    b.Property<int>("Nurseld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("nurseld");

//                    b.Property<int?>("Userld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("userld")
//                        .HasDefaultValueSql("'NULL'");

//                    b.HasKey("Nurseld")
//                        .HasName("PRIMARY");

//                    b.HasIndex(new[] { "Userld" }, "userld")
//                        .HasDatabaseName("userld1");

//                    b.ToTable("nurse", (string)null);
//                });

//            modelBuilder.Entity("DATN.Entities.Patient", b =>
//                {
//                    b.Property<int>("Patientld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("patientld");

//                    b.Property<string>("Address")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("address")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<DateTime?>("Dob")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("date")
//                        .HasColumnName("dob")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<int?>("Doctorld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("doctorld")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("PatientName")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("patientName")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<int?>("Phone")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("phone")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<int?>("Roomld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("roomld")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<int?>("Sex")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("sex")
//                        .HasDefaultValueSql("'NULL'");

//                    b.HasKey("Patientld")
//                        .HasName("PRIMARY");

//                    b.HasIndex(new[] { "Doctorld" }, "doctorld")
//                        .HasDatabaseName("doctorld2");

//                    b.ToTable("patient", (string)null);
//                });

//            modelBuilder.Entity("DATN.Entities.Report", b =>
//                {
//                    b.Property<int>("Reportld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("reportld");

//                    b.Property<string>("Conclusion")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("conclusion")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("Diagnostic")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("diagnostic")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("DoctorName")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("doctorName")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<int?>("Doctorld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("doctorld")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("Image")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("image")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<int?>("Ktvld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("ktvld")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("PatientName")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("patientName")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<int?>("Patientld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("patientld")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<int?>("State")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("state")
//                        .HasDefaultValueSql("'NULL'");

//                    b.HasKey("Reportld")
//                        .HasName("PRIMARY");

//                    b.HasIndex(new[] { "Doctorld" }, "doctorld")
//                        .HasDatabaseName("doctorld3");

//                    b.HasIndex(new[] { "Patientld" }, "patientld")
//                        .HasDatabaseName("patientld4");

//                    b.ToTable("report", (string)null);
//                });

//            modelBuilder.Entity("DATN.Entities.User", b =>
//                {
//                    b.Property<int>("Userld")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int(11)")
//                        .HasColumnName("userld");

//                    b.Property<string>("Fullname")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("fullname")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("Password")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("password")
//                        .HasDefaultValueSql("'NULL'");

//                    b.Property<string>("User1")
//                        .ValueGeneratedOnAdd()
//                        .HasMaxLength(255)
//                        .HasColumnType("varchar(255)")
//                        .HasColumnName("user")
//                        .HasDefaultValueSql("'NULL'");

//                    b.HasKey("Userld")
//                        .HasName("PRIMARY");

//                    b.ToTable("user", (string)null);
//                });

//            modelBuilder.Entity("DATN.Entities.Casestudy", b =>
//                {
//                    b.HasOne("DATN.Entities.Patient", "PatientldNavigation")
//                        .WithMany("Casestudies")
//                        .HasForeignKey("Patientld")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("casestudy_ibfk_1");

//                    b.Navigation("PatientldNavigation");
//                });

//            modelBuilder.Entity("DATN.Entities.Doctor", b =>
//                {
//                    b.HasOne("DATN.Entities.User", "UserldNavigation")
//                        .WithMany("Doctors")
//                        .HasForeignKey("Userld")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("doctor_ibfk_1");

//                    b.Navigation("UserldNavigation");
//                });

//            modelBuilder.Entity("DATN.Entities.MedicalCdha", b =>
//                {
//                    b.HasOne("DATN.Entities.Doctor", "DoctorldNavigation")
//                        .WithMany("MedicalCdhas")
//                        .HasForeignKey("Doctorld")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("medical_cdha_ibfk_2");

//                    b.HasOne("DATN.Entities.Ktv", "KtvldNavigation")
//                        .WithMany("MedicalCdhas")
//                        .HasForeignKey("Ktvld")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("medical_cdha_ibfk_3");

//                    b.HasOne("DATN.Entities.Patient", "PatientldNavigation")
//                        .WithMany("MedicalCdhas")
//                        .HasForeignKey("Patientld")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("medical_cdha_ibfk_1");

//                    b.Navigation("DoctorldNavigation");

//                    b.Navigation("KtvldNavigation");

//                    b.Navigation("PatientldNavigation");
//                });

//            modelBuilder.Entity("DATN.Entities.MedicalIndication", b =>
//                {
//                    b.HasOne("DATN.Entities.Patient", "PatientldNavigation")
//                        .WithMany("MedicalIndications")
//                        .HasForeignKey("Patientld")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("medical_indication_ibfk_1");

//                    b.Navigation("PatientldNavigation");
//                });

//            modelBuilder.Entity("DATN.Entities.MedicalTest", b =>
//                {
//                    b.HasOne("DATN.Entities.Doctor", "DoctorldNavigation")
//                        .WithMany("MedicalTests")
//                        .HasForeignKey("Doctorld")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("medical_test_ibfk_2");

//                    b.HasOne("DATN.Entities.Ktv", "KtvldNavigation")
//                        .WithMany("MedicalTests")
//                        .HasForeignKey("Ktvld")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("medical_test_ibfk_3");

//                    b.HasOne("DATN.Entities.Patient", "PatientldNavigation")
//                        .WithMany("MedicalTests")
//                        .HasForeignKey("Patientld")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("medical_test_ibfk_1");

//                    b.Navigation("DoctorldNavigation");

//                    b.Navigation("KtvldNavigation");

//                    b.Navigation("PatientldNavigation");
//                });

//            modelBuilder.Entity("DATN.Entities.Nurse", b =>
//                {
//                    b.HasOne("DATN.Entities.User", "UserldNavigation")
//                        .WithMany("Nurses")
//                        .HasForeignKey("Userld")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("nurse_ibfk_1");

//                    b.Navigation("UserldNavigation");
//                });

//            modelBuilder.Entity("DATN.Entities.Patient", b =>
//                {
//                    b.HasOne("DATN.Entities.Doctor", "DoctorldNavigation")
//                        .WithMany("Patients")
//                        .HasForeignKey("Doctorld")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("patient_ibfk_1");

//                    b.Navigation("DoctorldNavigation");
//                });

//            modelBuilder.Entity("DATN.Entities.Report", b =>
//                {
//                    b.HasOne("DATN.Entities.Doctor", "DoctorldNavigation")
//                        .WithMany("Reports")
//                        .HasForeignKey("Doctorld")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("report_ibfk_2");

//                    b.HasOne("DATN.Entities.Patient", "PatientldNavigation")
//                        .WithMany("Reports")
//                        .HasForeignKey("Patientld")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .HasConstraintName("report_ibfk_1");

//                    b.Navigation("DoctorldNavigation");

//                    b.Navigation("PatientldNavigation");
//                });

//            modelBuilder.Entity("DATN.Entities.Doctor", b =>
//                {
//                    b.Navigation("MedicalCdhas");

//                    b.Navigation("MedicalTests");

//                    b.Navigation("Patients");

//                    b.Navigation("Reports");
//                });

//            modelBuilder.Entity("DATN.Entities.Ktv", b =>
//                {
//                    b.Navigation("MedicalCdhas");

//                    b.Navigation("MedicalTests");
//                });

//            modelBuilder.Entity("DATN.Entities.Patient", b =>
//                {
//                    b.Navigation("Casestudies");

//                    b.Navigation("MedicalCdhas");

//                    b.Navigation("MedicalIndications");

//                    b.Navigation("MedicalTests");

//                    b.Navigation("Reports");
//                });

//            modelBuilder.Entity("DATN.Entities.User", b =>
//                {
//                    b.Navigation("Doctors");

//                    b.Navigation("Nurses");
//                });
//#pragma warning restore 612, 618
//        }
//    }
//}