using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diary.Entity.Migrations
{
    public partial class IdentityServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedule_class_ClassID",
                table: "schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_schedule_subject_SubjectID",
                table: "schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_schedule_teacher_TeacherID",
                table: "schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_student_class_ClassID",
                table: "student");

            migrationBuilder.DropForeignKey(
                name: "FK_student_school_SchoolID",
                table: "student");

            migrationBuilder.DropForeignKey(
                name: "FK_teacherInClass_class_ClassID",
                table: "teacherInClass");

            migrationBuilder.DropForeignKey(
                name: "FK_teacherInClass_teacher_TeacherID",
                table: "teacherInClass");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "student",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "student",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "student",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "student",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "student",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "student",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "student",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "student",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "student",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_student_UserId",
                        column: x => x.UserId,
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_student_UserId",
                        column: x => x.UserId,
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_student_UserId",
                        column: x => x.UserId,
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_student_UserId",
                        column: x => x.UserId,
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "student",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "student",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_schedule_class_ClassID",
                table: "schedule",
                column: "ClassID",
                principalTable: "class",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_schedule_subject_SubjectID",
                table: "schedule",
                column: "SubjectID",
                principalTable: "subject",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_schedule_teacher_TeacherID",
                table: "schedule",
                column: "TeacherID",
                principalTable: "teacher",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_student_class_ClassID",
                table: "student",
                column: "ClassID",
                principalTable: "class",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_student_school_SchoolID",
                table: "student",
                column: "SchoolID",
                principalTable: "school",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_teacherInClass_class_ClassID",
                table: "teacherInClass",
                column: "ClassID",
                principalTable: "class",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_teacherInClass_teacher_TeacherID",
                table: "teacherInClass",
                column: "TeacherID",
                principalTable: "teacher",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedule_class_ClassID",
                table: "schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_schedule_subject_SubjectID",
                table: "schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_schedule_teacher_TeacherID",
                table: "schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_student_class_ClassID",
                table: "student");

            migrationBuilder.DropForeignKey(
                name: "FK_student_school_SchoolID",
                table: "student");

            migrationBuilder.DropForeignKey(
                name: "FK_teacherInClass_class_ClassID",
                table: "teacherInClass");

            migrationBuilder.DropForeignKey(
                name: "FK_teacherInClass_teacher_TeacherID",
                table: "teacherInClass");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "student");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "student");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "student");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "student");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "student");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "student");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "student");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "student");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "student");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "student");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "student");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "student");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "student");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "student");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "student");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "student");

            migrationBuilder.AddForeignKey(
                name: "FK_schedule_class_ClassID",
                table: "schedule",
                column: "ClassID",
                principalTable: "class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_schedule_subject_SubjectID",
                table: "schedule",
                column: "SubjectID",
                principalTable: "subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_schedule_teacher_TeacherID",
                table: "schedule",
                column: "TeacherID",
                principalTable: "teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_student_class_ClassID",
                table: "student",
                column: "ClassID",
                principalTable: "class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_student_school_SchoolID",
                table: "student",
                column: "SchoolID",
                principalTable: "school",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacherInClass_class_ClassID",
                table: "teacherInClass",
                column: "ClassID",
                principalTable: "class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacherInClass_teacher_TeacherID",
                table: "teacherInClass",
                column: "TeacherID",
                principalTable: "teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
