using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medical_cdha",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CDHAName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    dateCreate = table.Column<DateTime>(type: "date", nullable: true),
                    timeEstimate = table.Column<int>(type: "int(11)", nullable: true),
                    price = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medical_cdha", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Medication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Unit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Route = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Usage = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    IsFunctionalFoods = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.Id);
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
                    patientCode = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.patientId);
                })
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
                        name: "FK_doctor_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ktv",
                columns: table => new
                {
                    ktvId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<int>(type: "int(11)", nullable: false),
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
                        name: "FK_nurse_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "casestudy",
                columns: table => new
                {
                    CaseStudyId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    patientId = table.Column<int>(type: "int(11)", nullable: false),
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
                        name: "FK_casestudy_doctor",
                        column: x => x.DoctorId,
                        principalTable: "doctor",
                        principalColumn: "doctorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_casestudy_patient",
                        column: x => x.patientId,
                        principalTable: "patient",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(type: "int(11)", nullable: true),
                    CasestudyId = table.Column<int>(type: "int(11)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescription_casestudy_CasestudyId",
                        column: x => x.CasestudyId,
                        principalTable: "casestudy",
                        principalColumn: "CaseStudyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patient",
                        principalColumn: "patientId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "report",
                columns: table => new
                {
                    reportId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    patientId = table.Column<int>(type: "int(11)", nullable: true),
                    caseStudyId = table.Column<int>(type: "int(11)", nullable: false),
                    doctorId = table.Column<int>(type: "int(11)", nullable: true),
                    image = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    state = table.Column<int>(type: "int(11)", nullable: true),
                    conclusion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    KtvId = table.Column<int>(type: "int(11)", nullable: true),
                    diagnostic = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.reportId);
                    table.ForeignKey(
                        name: "FK_report_casestudy_caseStudyId",
                        column: x => x.caseStudyId,
                        principalTable: "casestudy",
                        principalColumn: "CaseStudyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_report_doctor_doctorId",
                        column: x => x.doctorId,
                        principalTable: "doctor",
                        principalColumn: "doctorId");
                    table.ForeignKey(
                        name: "FK_report_ktv_KtvId",
                        column: x => x.KtvId,
                        principalTable: "ktv",
                        principalColumn: "ktvId");
                    table.ForeignKey(
                        name: "report_ibfk_1",
                        column: x => x.patientId,
                        principalTable: "patient",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PrescriptionMedication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PrescriptionId = table.Column<int>(type: "int", nullable: false),
                    MedicationId = table.Column<int>(type: "int", nullable: false),
                    Dosages = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionMedication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescriptionMedication_Medication_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionMedication_Prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medical_cdha_case_study",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    caseStudyId = table.Column<int>(type: "int(11)", nullable: false),
                    medicalCdhaId = table.Column<int>(type: "int(11)", nullable: false),
                    ktvId = table.Column<int>(type: "int(11)", nullable: true),
                    reportId = table.Column<int>(type: "int(11)", nullable: true),
                    conclusion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    imageName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    imageLink = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medical_cdha_case_study", x => new { x.medicalCdhaId, x.caseStudyId, x.id });
                    table.ForeignKey(
                        name: "FK_medical_cdha_case_study_casestudy",
                        column: x => x.caseStudyId,
                        principalTable: "casestudy",
                        principalColumn: "CaseStudyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_medical_cdha_case_study_ktv",
                        column: x => x.ktvId,
                        principalTable: "ktv",
                        principalColumn: "ktvId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_medical_cdha_case_study_medicalcdha",
                        column: x => x.medicalCdhaId,
                        principalTable: "medical_cdha",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_medical_cdha_case_study_report_reportId",
                        column: x => x.reportId,
                        principalTable: "report",
                        principalColumn: "reportId",
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
                name: "IX_medical_cdha_case_study_caseStudyId",
                table: "medical_cdha_case_study",
                column: "caseStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_medical_cdha_case_study_ktvId",
                table: "medical_cdha_case_study",
                column: "ktvId");

            migrationBuilder.CreateIndex(
                name: "IX_medical_cdha_case_study_reportId",
                table: "medical_cdha_case_study",
                column: "reportId");

            migrationBuilder.CreateIndex(
                name: "userId",
                table: "nurse",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_CasestudyId",
                table: "Prescription",
                column: "CasestudyId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_PatientId",
                table: "Prescription",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedication_MedicationId",
                table: "PrescriptionMedication",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedication_PrescriptionId",
                table: "PrescriptionMedication",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "doctorId",
                table: "report",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_report_caseStudyId",
                table: "report",
                column: "caseStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_report_KtvId",
                table: "report",
                column: "KtvId");

            migrationBuilder.CreateIndex(
                name: "patientId1",
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
                name: "medical_cdha_case_study");

            migrationBuilder.DropTable(
                name: "nurse");

            migrationBuilder.DropTable(
                name: "PrescriptionMedication");

            migrationBuilder.DropTable(
                name: "medical_cdha");

            migrationBuilder.DropTable(
                name: "report");

            migrationBuilder.DropTable(
                name: "Medication");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "ktv");

            migrationBuilder.DropTable(
                name: "casestudy");

            migrationBuilder.DropTable(
                name: "doctor");

            migrationBuilder.DropTable(
                name: "patient");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
