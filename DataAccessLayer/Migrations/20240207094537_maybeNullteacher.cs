using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class maybeNullteacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
         name: "TeacherId",
         table: "Answers",
         nullable: true, // Make the TeacherId column nullable
         oldClrType: typeof(string),
         oldType: "nvarchar(max)",
         oldMaxLength: 255,
         oldNullable: true);


            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "477fa484-b904-4afd-8811-c8abf1d667cc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "2fbadce4-6426-45b2-98e7-2b8614cdfce5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "fdd4e3ad-b271-4e58-a83a-6bec667aa416");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
               name: "TeacherId",
               table: "Answers",
               type: "nvarchar(max)",
               maxLength: 255,
               nullable: true,
               oldClrType: typeof(string),
               oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b8d75c3c-da60-405f-ab4a-ccd0b3626068");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "942bb7e6-8ae5-4daa-9b2e-5be716c7630d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "223e7f4f-e520-454f-ab9b-5b51d5eb8bd6");
        }
    }
}
