using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuberMICManager.Infrastructure.DataAccess.Migrations
{
    public partial class AddTDSLoanRenewalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TDSLoanRenewals",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanRecID = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Account = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MaturityDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RenewalStatus = table.Column<int>(type: "int", nullable: false),
                    RenewalTerms = table.Column<int>(type: "int", nullable: false),
                    MortgageType = table.Column<int>(type: "int", nullable: false),
                    PrimeInterestRate = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: true),
                    RenewalIR = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: true),
                    RenewalIRIsVariable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    RenewalFee = table.Column<decimal>(type: "money", nullable: true),
                    RenewalFeeIsDollar = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    LenderFee = table.Column<decimal>(type: "money", nullable: true),
                    LenderFeeIsDollar = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    BrokerFee = table.Column<decimal>(type: "money", nullable: true),
                    BrokerFeeIsDollar = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    AdminFee = table.Column<decimal>(type: "money", nullable: true),
                    AppraisalFee = table.Column<decimal>(type: "money", nullable: true),
                    OtherFees = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IDExpired = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FireInsuranceExpired = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDS_Loan_Renewal_RecID", x => x.RecId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TDS_Loan_Renewal_LoanRecID",
                table: "TDSLoanRenewals",
                column: "LoanRecID");

            migrationBuilder.CreateIndex(
                name: "IX_TDSLoanRenewals_LoanRecID_MaturityDate",
                table: "TDSLoanRenewals",
                columns: new[] { "LoanRecID", "MaturityDate" },
                unique: true,
                filter: "[LoanRecID] IS NOT NULL AND [MaturityDate] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TDSLoanRenewals");
        }
    }
}
