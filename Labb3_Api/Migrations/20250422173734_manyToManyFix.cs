using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb3_Api.Migrations
{
    /// <inheritdoc />
    public partial class manyToManyFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Persons_PersonId",
                table: "Interests");

            migrationBuilder.DropIndex(
                name: "IX_Interests_PersonId",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Interests");

            migrationBuilder.CreateTable(
                name: "InterestPerson",
                columns: table => new
                {
                    InterestsId = table.Column<int>(type: "int", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestPerson", x => new { x.InterestsId, x.PeopleId });
                    table.ForeignKey(
                        name: "FK_InterestPerson_Interests_InterestsId",
                        column: x => x.InterestsId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestPerson_Persons_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestPerson_PeopleId",
                table: "InterestPerson",
                column: "PeopleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestPerson");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Interests",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Interests_PersonId",
                table: "Interests",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_Persons_PersonId",
                table: "Interests",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
