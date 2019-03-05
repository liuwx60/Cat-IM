using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cat.EntityFramework.Migrations
{
    public partial class Cat3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Body = table.Column<string>(maxLength: 500, nullable: true),
                    Sender = table.Column<Guid>(nullable: false),
                    Receiver = table.Column<Guid>(nullable: false),
                    SendOn = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Received = table.Column<bool>(nullable: false),
                    Read = table.Column<bool>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    UpdateOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRecord", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatRecord");
        }
    }
}
