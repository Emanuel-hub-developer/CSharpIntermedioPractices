using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Rest.Migrations
{
    /// <inheritdoc />
    public partial class AddingNewCampIsActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "RecordRefreshTokens",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "RecordRefreshTokens");
        }
    }
}
