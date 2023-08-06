using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuberMICManager.Infrastructure.DataAccess.Migrations
{
    public partial class ChangeTdsRenewalAddPrinPaydownField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrinPaydown",
                table: "TDSLoanRenewals",
                type: "money",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 1,
                column: "Category",
                value: 200);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 2,
                column: "Category",
                value: 200);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 3,
                column: "Category",
                value: 200);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 4,
                column: "Category",
                value: 200);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 5,
                column: "Category",
                value: 200);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 6,
                column: "Category",
                value: 300);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 7,
                column: "Category",
                value: 300);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 8,
                column: "Category",
                value: 300);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 9,
                column: "Category",
                value: 300);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 10,
                column: "Category",
                value: 300);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 11,
                column: "Category",
                value: 300);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 12,
                column: "Category",
                value: 300);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrinPaydown",
                table: "TDSLoanRenewals");

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 1,
                column: "Category",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 2,
                column: "Category",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 3,
                column: "Category",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 4,
                column: "Category",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 5,
                column: "Category",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 6,
                column: "Category",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 7,
                column: "Category",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 8,
                column: "Category",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 9,
                column: "Category",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 10,
                column: "Category",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 11,
                column: "Category",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "SiteSettingID",
                keyValue: 12,
                column: "Category",
                value: 2);
        }
    }
}
