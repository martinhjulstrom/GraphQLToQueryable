using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLToQueryable.EfCore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OtherEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChildEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OtherEntityId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildEntity_OtherEntity_OtherEntityId",
                        column: x => x.OtherEntityId,
                        principalTable: "OtherEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RootEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OtherId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootEntities_OtherEntity_OtherId",
                        column: x => x.OtherId,
                        principalTable: "OtherEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildEntity_OtherEntityId",
                table: "ChildEntity",
                column: "OtherEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RootEntities_OtherId",
                table: "RootEntities",
                column: "OtherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildEntity");

            migrationBuilder.DropTable(
                name: "RootEntities");

            migrationBuilder.DropTable(
                name: "OtherEntity");
        }
    }
}
