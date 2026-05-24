using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_guncelleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            //migrationBuilder.DropColumn(
            //    name: "HeadingID1",
            //    table: "Contents");

            //migrationBuilder.DropColumn(
            //    name: "WriterID1",
            //    table: "Contents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeadingID1",
                table: "Contents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WriterID1",
                table: "Contents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contents_HeadingID1",
                table: "Contents",
                column: "HeadingID1");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_WriterID1",
                table: "Contents",
                column: "WriterID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Headings_HeadingID1",
                table: "Contents",
                column: "HeadingID1",
                principalTable: "Headings",
                principalColumn: "HeadingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Writers_WriterID1",
                table: "Contents",
                column: "WriterID1",
                principalTable: "Writers",
                principalColumn: "WriterID");
        }
    }
}
