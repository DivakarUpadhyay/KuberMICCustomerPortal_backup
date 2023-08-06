using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuberMICManager.Infrastructure.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteSettings",
                columns: table => new
                {
                    SiteSettingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    SettingValue = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.SiteSettingID);
                    table.UniqueConstraint("AK_SiteSettings_Key", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "TDSLoanRenewal",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanRecID = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    EmailSent = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaturityDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SysTimeStamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    SysCreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SysCreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDS_Loan_Renewal_RecID", x => x.RecId);
                });

            migrationBuilder.CreateTable(
                name: "UserLogs",
                columns: table => new
                {
                    UserLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<int>(type: "int", maxLength: 32, nullable: false),
                    Event = table.Column<int>(type: "int", maxLength: 32, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Timestamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result = table.Column<int>(type: "int", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogs", x => x.UserLogId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "61da4343-2f9a-44d9-8197-a1d27f5528ac", 0, "Kuber MIC", "455b087f-ccb0-4805-a753-3cbf9378b08a", "srihari@kubermic.com", true, "Srihari", "Mylvaganam", false, null, "SRIHARI@KUBERMIC.COM", "SRIHARI", "AEjGI7KsCJNZUYEkHc+q9A9W1R/fUzVA+577nfx/uIHFgoJQOHb/o6rqZQIFLp8gGA==", "+16475235055", true, "ddaabfbe-58cb-4378-bcc2-2aa87472ede6", false, "srihari" },
                    { "92269bf5-c156-44ff-8df7-5bce66e029f4", 0, "Kuber MIC", "d27e7aca-882b-4698-b6c7-66ac7aad2395", "suthakunam@kubermic.com", true, "Sutharsan", "Kunaratnam", false, null, "SUTHAKUNAM@KUBERMIC.COM", "SUTHAKUNAM", "AEjGI7KsCJNZUYEkHc+q9A9W1R/fUzVA+577nfx/uIHFgoJQOHb/o6rqZQIFLp8gGA==", "+14168246605", true, "26e3fcbd-c986-44d6-8336-4f1de935f6ba", false, "suthakunam" },
                    { "cbcfe9b3-1769-4c66-b87e-6efb7d31a208", 0, "Kuber MIC", "e382678f-839e-4327-8cfb-c15e4ca22b60", "vasanthan@kubermic.com", true, "Vasanthan", "Balasubramaniam", false, null, "VASANTHAN@KUBERMIC.COM", "VASANTHAN", "AEjGI7KsCJNZUYEkHc+q9A9W1R/fUzVA+577nfx/uIHFgoJQOHb/o6rqZQIFLp8gGA==", "+14168176575", true, "f6092c12-cbb6-43cd-8589-2040d9ca876a", false, "vasanthan" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "CanManageUsers", "true", "61da4343-2f9a-44d9-8197-a1d27f5528ac" },
                    { 2, "CanChangePassword", "true", "61da4343-2f9a-44d9-8197-a1d27f5528ac" },
                    { 3, "CanViewEventLogs", "true", "61da4343-2f9a-44d9-8197-a1d27f5528ac" },
                    { 4, "CanAccessTools", "true", "61da4343-2f9a-44d9-8197-a1d27f5528ac" },
                    { 5, "CanManageReports", "true", "61da4343-2f9a-44d9-8197-a1d27f5528ac" },
                    { 6, "CanManageLoans", "true", "61da4343-2f9a-44d9-8197-a1d27f5528ac" },
                    { 7, "CanManageInvestments", "true", "61da4343-2f9a-44d9-8197-a1d27f5528ac" },

                    { 8, "CanManageUsers", "true", "92269bf5-c156-44ff-8df7-5bce66e029f4" },
                    { 9, "CanChangePassword", "true", "92269bf5-c156-44ff-8df7-5bce66e029f4" },
                    { 10, "CanViewEventLogs", "true", "92269bf5-c156-44ff-8df7-5bce66e029f4" },
                    { 11, "CanAccessTools", "true", "92269bf5-c156-44ff-8df7-5bce66e029f4" },
                    { 12, "CanManageReports", "true", "92269bf5-c156-44ff-8df7-5bce66e029f4" },
                    { 13, "CanManageLoans", "true", "92269bf5-c156-44ff-8df7-5bce66e029f4" },
                    { 14, "CanManageInvestments", "true", "92269bf5-c156-44ff-8df7-5bce66e029f4" },

                    { 15, "CanManageUsers", "true", "cbcfe9b3-1769-4c66-b87e-6efb7d31a208" },
                    { 16, "CanChangePassword", "true", "cbcfe9b3-1769-4c66-b87e-6efb7d31a208" },
                    { 17, "CanViewEventLogs", "true", "cbcfe9b3-1769-4c66-b87e-6efb7d31a208" },
                    { 18, "CanAccessTools", "true", "cbcfe9b3-1769-4c66-b87e-6efb7d31a208" },
                    { 19, "CanManageReports", "true", "cbcfe9b3-1769-4c66-b87e-6efb7d31a208" },
                    { 20, "CanManageLoans", "true", "cbcfe9b3-1769-4c66-b87e-6efb7d31a208" },
                    { 21, "CanManageInvestments", "true", "cbcfe9b3-1769-4c66-b87e-6efb7d31a208" },

                    { 22, "CanManageTrustAccounts", "true", "61da4343-2f9a-44d9-8197-a1d27f5528ac" },
                    { 23, "CanManageTrustAccounts", "true", "92269bf5-c156-44ff-8df7-5bce66e029f4" },
                    { 24, "CanManageTrustAccounts", "true", "cbcfe9b3-1769-4c66-b87e-6efb7d31a208" },

                    { 25, "CanManageSiteOptions", "true", "61da4343-2f9a-44d9-8197-a1d27f5528ac" },
                    { 26, "CanManageSiteOptions", "true", "92269bf5-c156-44ff-8df7-5bce66e029f4" },
                    { 27, "CanManageSiteOptions", "true", "cbcfe9b3-1769-4c66-b87e-6efb7d31a208" }
                });

            migrationBuilder.InsertData(
                table: "SiteSettings",
                columns: new[] { "SiteSettingID", "Category", "Description", "Key", "SettingValue" },
                values: new object[,]
                {
                    { 1, 2, "Number Of Days Loans Up For Renewal", "NOOFDAYSLOANSUPFORRENEWAL", "45" },
                    { 2, 2, "Weighted LTV Threshold", "WEIGHTEDLTVTHRESHOLD", "60" },
                    { 3, 2, "Weighted Beacon Score Threshold", "WEIGHTEDBEACONSCORETHRESHOLD", "700" },
                    { 4, 2, "Weighted Maturity Date In Months Threshold", "WEIGHTEDMATURITYDATEINMONTHSTHRESHOLD", "6" },
                    { 5, 2, "Default Average Credit Score Threshold", "DEFAULTAVERAGECREDITSCORE", "600" },
                    { 6, 2, "BMO - Credit Facility Limit", "BMOCREDITFACILITYLIMIT", "40000000" },
                    { 7, 2, "BMO - 2nd Mortgage Limit In Percent", "BMO2NDMORTGAGELIMITINPERCENT", "20" },
                    { 8, 2, "BMO - Rental Mortgage Limit In Percent", "BMORENTALMORTGAGELIMITINPERCENT", "20" },
                    { 9, 2, "BMO - Commercial Mortgage Limit In Percent", "BMOCOMMERCIALMORTGAGELIMITINPERCENT", "15" },
                    { 10, 2, "BMO - Residential Maximum Mortgage Limit Per Loan", "BMORESIDENTIALMAXLIMITPERLOAN", "1200000" },
                    { 11, 2, "BMO - Commercial Maximum Mortgage Limit Per Loan", "BMOCOMMERCIALMAXLIMITPERLOAN", "2000000" },
                    { 12, 2, "BMO - Aggragate Maximum Mortgage Limit Per SIN", "BMOAGGRAGATEMAXLIMITPERSIN", "2000000" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TDS_Loan_Renewal_LoanRecID",
                table: "TDSLoanRenewal",
                column: "LoanRecID");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogs_Area_Event_UserName",
                table: "UserLogs",
                columns: new[] { "Area", "Event", "UserName" });

            migrationBuilder.CreateIndex(
                name: "IX_UserLogs_Timestamp",
                table: "UserLogs",
                column: "Timestamp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "SiteSettings");

            migrationBuilder.DropTable(
                name: "TDSLoanRenewal");

            migrationBuilder.DropTable(
                name: "UserLogs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
