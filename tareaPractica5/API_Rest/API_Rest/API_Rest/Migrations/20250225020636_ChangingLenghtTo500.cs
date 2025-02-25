using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Rest.Migrations
{
    /// <inheritdoc />
    public partial class ChangingLenghtTo500 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "RecordRefreshTokens",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "EsActivo",
                table: "RecordRefreshTokens",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComputedColumnSql: "iif(FechaExpiracion < getdate(), convert(bit,0), convert(bit,1))");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "RecordRefreshTokens",
                type: "bit",
                nullable: false,
                computedColumnSql: "iif(FechaExpiracion < getdate(), convert(bit,0), convert(bit,1))",
                stored: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "RecordRefreshTokens",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "RecordRefreshTokens",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComputedColumnSql: "iif(FechaExpiracion < getdate(), convert(bit,0), convert(bit,1))");

            migrationBuilder.AlterColumn<bool>(
                name: "EsActivo",
                table: "RecordRefreshTokens",
                type: "bit",
                nullable: false,
                computedColumnSql: "iif(FechaExpiracion < getdate(), convert(bit,0), convert(bit,1))",
                stored: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
