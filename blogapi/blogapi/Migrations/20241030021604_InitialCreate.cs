using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blogapi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Triples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Subject = table.Column<string>(type: "TEXT", unicode: false, maxLength: 254, nullable: true),
                    Predicate = table.Column<string>(type: "TEXT", unicode: false, maxLength: 254, nullable: true),
                    Object = table.Column<string>(type: "TEXT", unicode: false, maxLength: 254, nullable: true),
                    Value = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Triples_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TriplesCrossRef",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TripleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChildId = table.Column<int>(type: "INTEGER", nullable: true),
                    ParentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriplesCrossRef", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Triples_Object",
                table: "Triples",
                column: "Object");

            migrationBuilder.CreateIndex(
                name: "IX_Triples_Predicate",
                table: "Triples",
                column: "Predicate");

            migrationBuilder.CreateIndex(
                name: "IX_Triples_Subject",
                table: "Triples",
                column: "Subject");

            migrationBuilder.CreateIndex(
                name: "IX_TriplesSubPredObj",
                table: "Triples",
                columns: new[] { "Subject", "Predicate", "Object" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TriplesCrossRef_ChildId",
                table: "TriplesCrossRef",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_TriplesCrossRef_ParentId",
                table: "TriplesCrossRef",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TriplesCrossRef_TripleId",
                table: "TriplesCrossRef",
                column: "TripleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Triples");

            migrationBuilder.DropTable(
                name: "TriplesCrossRef");
        }
    }
}
