using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cat.EntityFramework.Migrations
{
    public partial class Cat2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friend",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    FriendId = table.Column<Guid>(nullable: false),
                    Blacked = table.Column<bool>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    UpdateOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friend", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friend");
        }
    }
}
