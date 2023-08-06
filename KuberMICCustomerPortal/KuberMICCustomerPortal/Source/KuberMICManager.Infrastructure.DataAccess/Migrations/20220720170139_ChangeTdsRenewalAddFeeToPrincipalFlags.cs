using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuberMICManager.Infrastructure.DataAccess.Migrations
{
    public partial class ChangeTdsRenewalAddFeeToPrincipalFlags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IDExpired",
                table: "TDSLoanRenewals",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "FireInsuranceExpired",
                table: "TDSLoanRenewals",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddAdminFeeToPrinBal",
                table: "TDSLoanRenewals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddAppraisalFeeToPrinBal",
                table: "TDSLoanRenewals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddBrokerFeeToPrinBal",
                table: "TDSLoanRenewals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddLenderFeeToPrinBal",
                table: "TDSLoanRenewals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddRenewalFeeToPrinBal",
                table: "TDSLoanRenewals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "NewPrinBal",
                table: "TDSLoanRenewals",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrinBal",
                table: "TDSLoanRenewals",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddAdminFeeToPrinBal",
                table: "TDSLoanRenewals");

            migrationBuilder.DropColumn(
                name: "AddAppraisalFeeToPrinBal",
                table: "TDSLoanRenewals");

            migrationBuilder.DropColumn(
                name: "AddBrokerFeeToPrinBal",
                table: "TDSLoanRenewals");

            migrationBuilder.DropColumn(
                name: "AddLenderFeeToPrinBal",
                table: "TDSLoanRenewals");

            migrationBuilder.DropColumn(
                name: "AddRenewalFeeToPrinBal",
                table: "TDSLoanRenewals");

            migrationBuilder.DropColumn(
                name: "NewPrinBal",
                table: "TDSLoanRenewals");

            migrationBuilder.DropColumn(
                name: "PrinBal",
                table: "TDSLoanRenewals");

            migrationBuilder.AlterColumn<bool>(
                name: "IDExpired",
                table: "TDSLoanRenewals",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "FireInsuranceExpired",
                table: "TDSLoanRenewals",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
