﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.RoleId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user = table.Column<string>(type: "longtext", nullable: true),
                    fullname = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    RoleId = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.userId);
                    table.ForeignKey(
                        name: "FK_user_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "role",
                        principalColumn: "RoleId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "doctor",
                columns: table => new
                {
                    doctorId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<int>(type: "int(11)", nullable: false),
                    doctorRole = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.doctorId);
                    table.ForeignKey(
                        name: "fk_user",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ktv",
                columns: table => new
                {
                    ktvId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<int>(type: "int(11)", nullable: false),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    ktvName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    roleIndication = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ktvId);
                    table.ForeignKey(
                        name: "FK_ktv_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "nurse",
                columns: table => new
                {
                    nurseId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.nurseId);
                    table.ForeignKey(
                        name: "nurse_ibfk_1",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    patientId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    patientName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    sex = table.Column<int>(type: "int(11)", nullable: true),
                    dob = table.Column<DateTime>(type: "date", nullable: true),
                    phone = table.Column<int>(type: "int(11)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "date", nullable: true),
                    patientCode = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    DoctorId = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.patientId);
                    table.ForeignKey(
                        name: "FK_patient_doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctor",
                        principalColumn: "doctorId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "casestudy",
                columns: table => new
                {
                    CaseStudyId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    patientId = table.Column<int>(type: "int(11)", nullable: true),
                    report = table.Column<string>(type: "longtext", nullable: true, defaultValueSql: "'NULL'"),
                    reportCount = table.Column<int>(type: "int(11)", nullable: true),
                    Reason = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    Status = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: true),
                    conclusion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    diagnostic = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    DoctorId = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.CaseStudyId);
                    table.ForeignKey(
                        name: "casestudy_ibfk_1",
                        column: x => x.patientId,
                        principalTable: "patient",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_casestudy_doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctor",
                        principalColumn: "doctorId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "report",
                columns: table => new
                {
                    reportId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    patientId = table.Column<int>(type: "int(11)", nullable: true),
                    patientName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    doctorId = table.Column<int>(type: "int(11)", nullable: true),
                    doctorName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    image = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    state = table.Column<int>(type: "int(11)", nullable: true),
                    conclusion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    ktvId = table.Column<int>(type: "int(11)", nullable: true),
                    diagnostic = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.reportId);
                    table.ForeignKey(
                        name: "report_ibfk_1",
                        column: x => x.patientId,
                        principalTable: "patient",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "report_ibfk_2",
                        column: x => x.doctorId,
                        principalTable: "doctor",
                        principalColumn: "doctorId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medical_cdha",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    patientId = table.Column<int>(type: "int(11)", nullable: true),
                    doctorId = table.Column<int>(type: "int(11)", nullable: true),
                    ktvId = table.Column<int>(type: "int(11)", nullable: true),
                    CaseStudyId = table.Column<int>(type: "int", nullable: true),
                    observationType = table.Column<string>(type: "longtext", nullable: true),
                    dateCreate = table.Column<DateTime>(type: "date", nullable: true),
                    timeEstimate = table.Column<DateTime>(type: "date", nullable: true),
                    imageName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    imageLink = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    nonDicom = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PatientIdNavigationPatientId = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medical_cdha", x => x.id);
                    table.ForeignKey(
                        name: "FK_medical_cdha_doctor_doctorId",
                        column: x => x.doctorId,
                        principalTable: "doctor",
                        principalColumn: "doctorId");
                    table.ForeignKey(
                        name: "FK_medical_cdha_patient_PatientIdNavigationPatientId",
                        column: x => x.PatientIdNavigationPatientId,
                        principalTable: "patient",
                        principalColumn: "patientId");
                    table.ForeignKey(
                        name: "medical_cdha_ibfk_1",
                        column: x => x.patientId,
                        principalTable: "casestudy",
                        principalColumn: "CaseStudyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "medical_cdha_ibfk_3",
                        column: x => x.ktvId,
                        principalTable: "ktv",
                        principalColumn: "ktvId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medical_indication",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CaseStudyId = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medical_indication", x => x.id);
                    table.ForeignKey(
                        name: "medical_indication_ibfk_1",
                        column: x => x.CaseStudyId,
                        principalTable: "casestudy",
                        principalColumn: "CaseStudyId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medical_test",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    patientId = table.Column<int>(type: "int(11)", nullable: true),
                    doctorId = table.Column<int>(type: "int(11)", nullable: true),
                    CaseStudyId = table.Column<int>(type: "int(11)", nullable: true),
                    ktvId = table.Column<int>(type: "int(11)", nullable: true),
                    observationType = table.Column<string>(type: "longtext", nullable: true),
                    dateCreate = table.Column<DateTime>(type: "date", nullable: true),
                    timeEstimate = table.Column<DateTime>(type: "date", nullable: true),
                    testName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medical_test", x => x.id);
                    table.ForeignKey(
                        name: "FK_medical_test_doctor_doctorId",
                        column: x => x.doctorId,
                        principalTable: "doctor",
                        principalColumn: "doctorId");
                    table.ForeignKey(
                        name: "FK_medical_test_patient_patientId",
                        column: x => x.patientId,
                        principalTable: "patient",
                        principalColumn: "patientId");
                    table.ForeignKey(
                        name: "medical_test_ibfk_1",
                        column: x => x.CaseStudyId,
                        principalTable: "casestudy",
                        principalColumn: "CaseStudyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "medical_test_ibfk_3",
                        column: x => x.ktvId,
                        principalTable: "ktv",
                        principalColumn: "ktvId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_casestudy_DoctorId",
                table: "casestudy",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "patientId",
                table: "casestudy",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_doctor_userId",
                table: "doctor",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_ktv_userId",
                table: "ktv",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "doctorId",
                table: "medical_cdha",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_medical_cdha_PatientIdNavigationPatientId",
                table: "medical_cdha",
                column: "PatientIdNavigationPatientId");

            migrationBuilder.CreateIndex(
                name: "ktvId",
                table: "medical_cdha",
                column: "ktvId");

            migrationBuilder.CreateIndex(
                name: "patientId1",
                table: "medical_cdha",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "CaseStudyId",
                table: "medical_indication",
                column: "CaseStudyId");

            migrationBuilder.CreateIndex(
                name: "doctorId1",
                table: "medical_test",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_medical_test_CaseStudyId",
                table: "medical_test",
                column: "CaseStudyId");

            migrationBuilder.CreateIndex(
                name: "ktvId1",
                table: "medical_test",
                column: "ktvId");

            migrationBuilder.CreateIndex(
                name: "patientId2",
                table: "medical_test",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "userId",
                table: "nurse",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_patient_DoctorId",
                table: "patient",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "doctorId2",
                table: "report",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "patientId3",
                table: "report",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_user_RoleId",
                table: "user",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medical_cdha");

            migrationBuilder.DropTable(
                name: "medical_indication");

            migrationBuilder.DropTable(
                name: "medical_test");

            migrationBuilder.DropTable(
                name: "nurse");

            migrationBuilder.DropTable(
                name: "report");

            migrationBuilder.DropTable(
                name: "casestudy");

            migrationBuilder.DropTable(
                name: "ktv");

            migrationBuilder.DropTable(
                name: "patient");

            migrationBuilder.DropTable(
                name: "doctor");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}