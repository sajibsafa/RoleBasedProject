using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoleBased.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Createalltable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Emp");

            migrationBuilder.CreateTable(
                name: "LoginDB",
                schema: "Emp",
                columns: table => new
                {
                    RegNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginDB", x => x.RegNo);
                });

            migrationBuilder.CreateTable(
                name: "StudentInfo",
                schema: "Emp",
                columns: table => new
                {
                    RegNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfo", x => x.RegNo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoginDB_Role",
                schema: "Emp",
                table: "LoginDB",
                column: "Role");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfo_Name",
                schema: "Emp",
                table: "StudentInfo",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginDB",
                schema: "Emp");

            migrationBuilder.DropTable(
                name: "StudentInfo",
                schema: "Emp");
        }
    }
}
