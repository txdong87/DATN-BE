using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RemoveDoctorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    Roleld = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Roleld);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    userld = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user = table.Column<string>(type: "longtext", nullable: true),
                    fullname = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    RoleId = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.userld);
                    table.ForeignKey(
                        name: "FK_user_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "role",
                        principalColumn: "Roleld");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "doctor",
                columns: table => new
                {
                    doctorld = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    userld = table.Column<int>(type: "int(11)", nullable: false),
                    doctorRole = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.doctorld);
                    table.ForeignKey(
                        name: "fk_user",
                        column: x => x.userld,
                        principalTable: "user",
                        principalColumn: "userld",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ktv",
                columns: table => new
                {
                    ktvld = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    userld = table.Column<int>(type: "int(11)", nullable: false),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    ktvName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    roleIndication = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ktvld);
                    table.ForeignKey(
                        name: "FK_ktv_user_userld",
                        column: x => x.userld,
                        principalTable: "user",
                        principalColumn: "userld",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "nurse",
                columns: table => new
                {
                    nurseld = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    userld = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.nurseld);
                    table.ForeignKey(
                        name: "nurse_ibfk_1",
                        column: x => x.userld,
                        principalTable: "user",
                        principalColumn: "userld",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    patientld = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    patientName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    sex = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    dob = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "'NULL'"),
                    phone = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    createdAt = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "'NULL'"),
                    patientCode = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    Doctorld = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.patientld);
                    table.ForeignKey(
                        name: "FK_patient_doctor_Doctorld",
                        column: x => x.Doctorld,
                        principalTable: "doctor",
                        principalColumn: "doctorld");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "casestudy",
                columns: table => new
                {
                    CaseStudyId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    patientld = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    report = table.Column<string>(type: "longtext", nullable: true, defaultValueSql: "'NULL'"),
                    reportCount = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    Reason = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    Status = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "'NULL'"),
                    conclusion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    diagnostic = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    DoctorId = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.CaseStudyId);
                    table.ForeignKey(
                        name: "casestudy_ibfk_1",
                        column: x => x.patientld,
                        principalTable: "patient",
                        principalColumn: "patientld",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_casestudy_doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctor",
                        principalColumn: "doctorld");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "report",
                columns: table => new
                {
                    reportld = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    patientld = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    patientName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    doctorld = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    doctorName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    image = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    state = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    conclusion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    ktvld = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    diagnostic = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.reportld);
                    table.ForeignKey(
                        name: "report_ibfk_1",
                        column: x => x.patientld,
                        principalTable: "patient",
                        principalColumn: "patientld",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "report_ibfk_2",
                        column: x => x.doctorld,
                        principalTable: "doctor",
                        principalColumn: "doctorld",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medical_cdha",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    patientld = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    doctorld = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    ktvld = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    CaseStudyId = table.Column<int>(type: "int", nullable: true),
                    observationType = table.Column<string>(type: "longtext", nullable: true, defaultValueSql: "'NULL'"),
                    dateCreate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "'NULL'"),
                    timeEstimate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "'NULL'"),
                    imageName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    imageLink = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    nonDicom = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'NULL'"),
                    DoctorldNavigationDoctorld = table.Column<int>(type: "int(11)", nullable: true),
                    PatientIdNavigationPatientld = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medical_cdha", x => x.id);
                    table.ForeignKey(
                        name: "FK_medical_cdha_doctor_DoctorldNavigationDoctorld",
                        column: x => x.DoctorldNavigationDoctorld,
                        principalTable: "doctor",
                        principalColumn: "doctorld");
                    table.ForeignKey(
                        name: "FK_medical_cdha_patient_PatientIdNavigationPatientld",
                        column: x => x.PatientIdNavigationPatientld,
                        principalTable: "patient",
                        principalColumn: "patientld");
                    table.ForeignKey(
                        name: "medical_cdha_ibfk_1",
                        column: x => x.patientld,
                        principalTable: "casestudy",
                        principalColumn: "CaseStudyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "medical_cdha_ibfk_3",
                        column: x => x.ktvld,
                        principalTable: "ktv",
                        principalColumn: "ktvld",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medical_indication",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CaseStudyId = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'")
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
                    patientld = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    doctorld = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    CaseStudyId = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    ktvld = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'"),
                    observationType = table.Column<string>(type: "longtext", nullable: true, defaultValueSql: "'NULL'"),
                    dateCreate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "'NULL'"),
                    timeEstimate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "'NULL'"),
                    testName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    DoctorldNavigationDoctorld = table.Column<int>(type: "int(11)", nullable: true),
                    PatientIdNavigationPatientld = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medical_test", x => x.id);
                    table.ForeignKey(
                        name: "FK_medical_test_doctor_DoctorldNavigationDoctorld",
                        column: x => x.DoctorldNavigationDoctorld,
                        principalTable: "doctor",
                        principalColumn: "doctorld");
                    table.ForeignKey(
                        name: "FK_medical_test_patient_PatientIdNavigationPatientld",
                        column: x => x.PatientIdNavigationPatientld,
                        principalTable: "patient",
                        principalColumn: "patientld");
                    table.ForeignKey(
                        name: "medical_test_ibfk_1",
                        column: x => x.CaseStudyId,
                        principalTable: "casestudy",
                        principalColumn: "CaseStudyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "medical_test_ibfk_3",
                        column: x => x.ktvld,
                        principalTable: "ktv",
                        principalColumn: "ktvld",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_casestudy_DoctorId",
                table: "casestudy",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "patientld",
                table: "casestudy",
                column: "patientld");

            migrationBuilder.CreateIndex(
                name: "IX_doctor_userld",
                table: "doctor",
                column: "userld");

            migrationBuilder.CreateIndex(
                name: "IX_ktv_userld",
                table: "ktv",
                column: "userld");

            migrationBuilder.CreateIndex(
                name: "doctorld",
                table: "medical_cdha",
                column: "doctorld");

            migrationBuilder.CreateIndex(
                name: "IX_medical_cdha_DoctorldNavigationDoctorld",
                table: "medical_cdha",
                column: "DoctorldNavigationDoctorld");

            migrationBuilder.CreateIndex(
                name: "IX_medical_cdha_PatientIdNavigationPatientld",
                table: "medical_cdha",
                column: "PatientIdNavigationPatientld");

            migrationBuilder.CreateIndex(
                name: "ktvld",
                table: "medical_cdha",
                column: "ktvld");

            migrationBuilder.CreateIndex(
                name: "patientld1",
                table: "medical_cdha",
                column: "patientld");

            migrationBuilder.CreateIndex(
                name: "CaseStudyId",
                table: "medical_indication",
                column: "CaseStudyId");

            migrationBuilder.CreateIndex(
                name: "doctorld1",
                table: "medical_test",
                column: "doctorld");

            migrationBuilder.CreateIndex(
                name: "IX_medical_test_CaseStudyId",
                table: "medical_test",
                column: "CaseStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_medical_test_DoctorldNavigationDoctorld",
                table: "medical_test",
                column: "DoctorldNavigationDoctorld");

            migrationBuilder.CreateIndex(
                name: "IX_medical_test_PatientIdNavigationPatientld",
                table: "medical_test",
                column: "PatientIdNavigationPatientld");

            migrationBuilder.CreateIndex(
                name: "ktvld1",
                table: "medical_test",
                column: "ktvld");

            migrationBuilder.CreateIndex(
                name: "patientld2",
                table: "medical_test",
                column: "patientld");

            migrationBuilder.CreateIndex(
                name: "userld",
                table: "nurse",
                column: "userld");

            migrationBuilder.CreateIndex(
                name: "IX_patient_Doctorld",
                table: "patient",
                column: "Doctorld");

            migrationBuilder.CreateIndex(
                name: "doctorld2",
                table: "report",
                column: "doctorld");

            migrationBuilder.CreateIndex(
                name: "patientld3",
                table: "report",
                column: "patientld");

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
