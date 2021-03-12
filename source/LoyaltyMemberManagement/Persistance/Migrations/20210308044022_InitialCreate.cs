using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
namespace Persistance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    createdby = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedby = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.id);
                });
            migrationBuilder.CreateTable(
                name: "memberaccounts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    balance = table.Column<decimal>(type: "numeric", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    memberid = table.Column<long>(type: "bigint", nullable: true),
                    createdby = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedby = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_memberaccounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_memberaccounts_members_memberid",
                        column: x => x.memberid,
                        principalTable: "members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateIndex(
                name: "IX_memberaccounts_memberid",
                table: "memberaccounts",
                column: "memberid");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "memberaccounts");
            migrationBuilder.DropTable(
                name: "members");
        }
    }
}
