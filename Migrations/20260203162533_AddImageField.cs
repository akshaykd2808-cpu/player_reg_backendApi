using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace playerregproject.Migrations
{
    /// <inheritdoc />
    public partial class AddImageField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldValues_CustomFieldId",
                table: "CustomFieldValues",
                column: "CustomFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFieldValues_CustomFields_CustomFieldId",
                table: "CustomFieldValues",
                column: "CustomFieldId",
                principalTable: "CustomFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFieldValues_CustomFields_CustomFieldId",
                table: "CustomFieldValues");

            migrationBuilder.DropIndex(
                name: "IX_CustomFieldValues_CustomFieldId",
                table: "CustomFieldValues");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Forms");
        }
    }
}
