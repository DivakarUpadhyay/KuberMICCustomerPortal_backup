using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using KuberMICManager.Core.Domain.Interfaces.Services;
using KuberMICManager.Core.Domain.ReportModels;
using Microsoft.Extensions.Logging;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static KuberMICManager.Core.Domain.Entities.Application.Common;
using A = DocumentFormat.OpenXml.Drawing;
using Xdr = DocumentFormat.OpenXml.Drawing.Spreadsheet;

namespace KuberMICManager.Core.Application.HelperSerivces
{
    public class ExportService : IExportService
    {
        private readonly ILogger<ExportService> _logger;
        private readonly IReportService _reportService;

        public ExportService(ILogger<ExportService> logger, IReportService reportService)
        {
            _logger = logger;
            _reportService = reportService;
        }

        public async Task<Stream> ExportToPDF(string contentString)
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultChromiumRevision);
            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            await using var page = await browser.NewPageAsync();
            await page.EmulateMediaTypeAsync(MediaType.Screen);
            //await page.AddStyleTagAsync("https://micmanager.kubermic.com/css/template-styles.css");
            await page.SetContentAsync(contentString);
            return await page.PdfStreamAsync(new PdfOptions
            {
                Format = PaperFormat.A4,
                DisplayHeaderFooter = true,

                MarginOptions = new MarginOptions
                {
                    Top = "20px",
                    Right = "40px",
                    Bottom = "80px",
                    Left = "40px"
                },
                FooterTemplate = $"<div id=\"footer-template\" style=\"font-size:10px !important; color:#808080; padding-left:30px; padding-bottom:20px;\">Copyright &copy; {DateTime.Now.Year} - Kuber MIC - <strong style=\"color: red;\">CONFIDENTIAL</strong></div>"
            });
        }

        public async Task<byte[]> ExportBBCToExcel(DateTime? endDate)
        {
            _logger.LogInformation($"Calling: ExportToExcelService.ExportBBCToExcel(): End Date, {endDate}\n");

            BBCReportModel BBCReportData = await _reportService.GetLoanDataForBBCExcelReport(endDate);

            MemoryStream stream = new MemoryStream();
            // Create a spreadsheet document by supplying a stream
            SpreadsheetDocument document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook);

            // Add a Workbook to the document
            WorkbookPart workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();

            // Add Styles to the Workbook
            WorkbookStylesPart stylePart = workbookPart.AddNewPart<WorkbookStylesPart>();
            stylePart.Stylesheet = GenerateStylesheet();
            stylePart.Stylesheet.Save();

            // Add Sheets to the Workbook
            Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

            /** BBC Summary Start **/
            // Add the BBC Summary Worksheet to the workbook.
            WorksheetPart BBCSummaryWorkSeetPart = AddBBCSummaryWorkSheet(workbookPart, BBCReportData, endDate);
            // Append a new worksheet and associate it with the workbook.
            Sheet BBCSheet = new Sheet() { Id = workbookPart.GetIdOfPart(BBCSummaryWorkSeetPart), SheetId = 1, Name = "BBC" };
            sheets.Append(BBCSheet);
            /** BBC Summary End **/

            Sheet FirstMortgagesSheet = null;
            Sheet SecondMortgagesSheet = null;
            Sheet ThirdMortgagesSheet = null;
            Sheet LoansOwnerOccupied1stMortgagesSheetLTVLessThan50GTA = null;
            Sheet LoansOwnerOccupied1stMortgagesSheetOther = null;
            Sheet LoansOwnerOccupied2ndMortgagesSheet = null;
            Sheet LoansNonOwnerOccupied1stMortgagesSheet = null;
            Sheet LoansCommercial1stMortgagesSheet = null;
            Sheet Arrears1stMortgagesSheet = null;
            Sheet Arrears2ndMortgagesSheet = null;
            Sheet DelinquentMortgagesSheet = null;

            // Must create this here. When created in GetLoanSheet method, crashing for out of range.
            WorksheetPart FirstMortgagesWorkSeetPart = workbookPart.AddNewPart<WorksheetPart>();
            WorksheetPart SecondMortgagesWorkSeetPart = workbookPart.AddNewPart<WorksheetPart>();
            WorksheetPart ThirdMortgagesWorkSeetPart = workbookPart.AddNewPart<WorksheetPart>();
            WorksheetPart OwnerOccupied1stMortgagesLTVLessThan50GTAWorkSeetPart = workbookPart.AddNewPart<WorksheetPart>();
            WorksheetPart OwnerOccupied1stMortgagesOtherWorkSeetPart = workbookPart.AddNewPart<WorksheetPart>();
            WorksheetPart OwnerOccupied2ndMortgagesWorkSeetPart = workbookPart.AddNewPart<WorksheetPart>();
            WorksheetPart NonOwnerOccupied1stMortgagesWorkSeetPart = workbookPart.AddNewPart<WorksheetPart>();
            WorksheetPart Commercial1stMortgagesWorkSeetPart = workbookPart.AddNewPart<WorksheetPart>();
            WorksheetPart Arrears1stMortgagesWorkSeetPart = workbookPart.AddNewPart<WorksheetPart>();
            WorksheetPart Arrears2ndMortgagesWorkSeetPart = workbookPart.AddNewPart<WorksheetPart>();
            WorksheetPart DelinquentMortgagesWorkSeetPart = workbookPart.AddNewPart<WorksheetPart>();

            // Add BBC Loan Sheets for Each Category - Run in parallel
            Parallel.Invoke(() => FirstMortgagesSheet = GetLoanSheet(BBCReportData.FirstMortgages, workbookPart, FirstMortgagesWorkSeetPart, 2, BBCReportData.PrincipalBalanceTotal, BBCCategory.FirstMortgage, endDate),
                            () => SecondMortgagesSheet = GetLoanSheet(BBCReportData.SecondMortgages, workbookPart, SecondMortgagesWorkSeetPart, 3, BBCReportData.PrincipalBalanceTotal, BBCCategory.SecondMortgage, endDate),
                            () => ThirdMortgagesSheet = GetLoanSheet(BBCReportData.ThirdMortgages, workbookPart, ThirdMortgagesWorkSeetPart, 4, BBCReportData.PrincipalBalanceTotal, BBCCategory.ThirdMortgage, endDate),
                            () => LoansOwnerOccupied1stMortgagesSheetLTVLessThan50GTA = GetLoanSheet(BBCReportData.OwnerOccupied1stMortgagesLTVLessThan50GTA, workbookPart, OwnerOccupied1stMortgagesLTVLessThan50GTAWorkSeetPart, 5, BBCReportData.PrincipalBalanceTotal, BBCCategory.OwnerOccupied1stMortgagesLTVLessThan50GTA, endDate, addExtraColumns: true),
                            () => LoansOwnerOccupied1stMortgagesSheetOther = GetLoanSheet(BBCReportData.OwnerOccupied1stMortgagesOther, workbookPart, OwnerOccupied1stMortgagesOtherWorkSeetPart, 6, BBCReportData.PrincipalBalanceTotal, BBCCategory.OwnerOccupied1stMortgagesOther, endDate, addExtraColumns: true),
                            () => LoansOwnerOccupied2ndMortgagesSheet = GetLoanSheet(BBCReportData.OwnerOccupied2ndMortgages, workbookPart, OwnerOccupied2ndMortgagesWorkSeetPart, 7, BBCReportData.PrincipalBalanceTotal, BBCCategory.OwnerOccupied2ndMortgages, endDate, addExtraColumns: true),
                            () => LoansNonOwnerOccupied1stMortgagesSheet = GetLoanSheet(BBCReportData.NonOwnerOccupied1stMortgages, workbookPart, NonOwnerOccupied1stMortgagesWorkSeetPart, 8, BBCReportData.PrincipalBalanceTotal, BBCCategory.NonOwner1stMortgages, endDate, addExtraColumns: true),
                            () => LoansCommercial1stMortgagesSheet = GetLoanSheet(BBCReportData.Commercial1stMortgages, workbookPart, Commercial1stMortgagesWorkSeetPart, 9, BBCReportData.PrincipalBalanceTotal, BBCCategory.Commercial1stMortgages, endDate, addExtraColumns: true),
                            () => Arrears1stMortgagesSheet = GetLoanSheet(BBCReportData.Arrears1stMortgages, workbookPart, Arrears1stMortgagesWorkSeetPart, 10, BBCReportData.PrincipalBalanceTotal, BBCCategory.Arrears1stMortgages, endDate),
                            () => Arrears2ndMortgagesSheet = GetLoanSheet(BBCReportData.Arrears2ndMortgages, workbookPart, Arrears2ndMortgagesWorkSeetPart, 11, BBCReportData.PrincipalBalanceTotal, BBCCategory.Arrears2ndMortgages, endDate),
                            () => DelinquentMortgagesSheet = GetLoanSheet(BBCReportData.DelinquentMortgages, workbookPart, DelinquentMortgagesWorkSeetPart, 12, BBCReportData.PrincipalBalanceTotal, BBCCategory.DelinquentMortgages, endDate));

            sheets.Append(FirstMortgagesSheet);
            sheets.Append(SecondMortgagesSheet);
            sheets.Append(ThirdMortgagesSheet);
            sheets.Append(LoansOwnerOccupied1stMortgagesSheetLTVLessThan50GTA);
            sheets.Append(LoansOwnerOccupied1stMortgagesSheetOther);
            sheets.Append(LoansOwnerOccupied2ndMortgagesSheet);
            sheets.Append(LoansNonOwnerOccupied1stMortgagesSheet);
            sheets.Append(LoansCommercial1stMortgagesSheet);
            sheets.Append(Arrears1stMortgagesSheet);
            sheets.Append(Arrears2ndMortgagesSheet);
            sheets.Append(DelinquentMortgagesSheet);

            /** Notes Start **/
            // Add Notes
            WorksheetPart notesWorkSeetPart = AddNotesSheet(workbookPart);
            Sheet notesSheet = new Sheet() { Id = workbookPart.GetIdOfPart(notesWorkSeetPart), SheetId = 13, Name = "Notes" };
            sheets.Append(notesSheet);
            /** Notes End **/

            workbookPart.Workbook.Save();

            document.Close();

            return stream.ToArray();
        }

        private WorksheetPart AddBBCSummaryWorkSheet(WorkbookPart workbookPart, BBCReportModel BBCReportData, DateTime? endDate)
        {
            // Add a WorksheetPart to the WorkbookPart.
            WorksheetPart BBCSummaryWorkSeetPart = workbookPart.AddNewPart<WorksheetPart>();
            BBCSummaryWorkSeetPart.Worksheet = new Worksheet();

            // Step 1: Add columns to work with
            Columns MasterColumn = new Columns(
                    new Column { Min = 1, Max = 1, Width = 10, CustomWidth = true },
                    new Column { Min = 2, Max = 2, Width = 10, CustomWidth = true },
                    new Column { Min = 3, Max = 3, Width = 10, CustomWidth = true },
                    new Column { Min = 4, Max = 4, Width = 10, CustomWidth = true },
                    new Column { Min = 5, Max = 5, Width = 10, CustomWidth = true },
                    new Column { Min = 6, Max = 6, Width = 20, CustomWidth = true },
                    new Column { Min = 7, Max = 7, Width = 10, CustomWidth = true },
                    new Column { Min = 8, Max = 8, Width = 10, CustomWidth = true },
                    new Column { Min = 9, Max = 9, Width = 10, CustomWidth = true });
            BBCSummaryWorkSeetPart.Worksheet.AppendChild(MasterColumn);

            // Step 2: Create the sheet, add rows, add cells with data
            SheetData BBCSheet = BBCSummaryWorkSeetPart.Worksheet.AppendChild(new SheetData());

            MergeCells MergeCells = new MergeCells();
            MergeCells.Append(new MergeCell() { Reference = new StringValue("E2:J2") });
            MergeCells.Append(new MergeCell() { Reference = new StringValue("E3:J3") });
            MergeCells.Append(new MergeCell() { Reference = new StringValue("B15:E15") });
            MergeCells.Append(new MergeCell() { Reference = new StringValue("C16:E16") });
            MergeCells.Append(new MergeCell() { Reference = new StringValue("B17:F17") });
            MergeCells.Append(new MergeCell() { Reference = new StringValue("B18:E18") });
            MergeCells.Append(new MergeCell() { Reference = new StringValue("C19:E19") });
            MergeCells.Append(new MergeCell() { Reference = new StringValue("B20:F20") });
            MergeCells.Append(new MergeCell() { Reference = new StringValue("B21:E21") });
            MergeCells.Append(new MergeCell() { Reference = new StringValue("C22:E22") });
            MergeCells.Append(new MergeCell() { Reference = new StringValue("B23:F23") });
            MergeCells.Append(new MergeCell() { Reference = new StringValue("B24:E24") });
            MergeCells.Append(new MergeCell() { Reference = new StringValue("C25:E25") });
            MergeCells.Append(new MergeCell() { Reference = new StringValue("B26:F26") });
            MergeCells.Append(new MergeCell() { Reference = new StringValue("B27:E27") });
            MergeCells.Append(new MergeCell() { Reference = new StringValue("C28:E28") });
            MergeCells.Append(new MergeCell() { Reference = new StringValue("B29:F29") });
            MergeCells.Append(new MergeCell() { Reference = new StringValue("C30:E30") });
            BBCSummaryWorkSeetPart.Worksheet.InsertAfter(MergeCells, BBCSummaryWorkSeetPart.Worksheet.Elements<SheetData>().First());

            // Add title and date details
            BBCSheet.AppendChild(new Row(new Cell { DataType = (CellValues.String), CellReference = "E2", CellValue = new CellValue("BORROWING BASE CERTIFICATE"), StyleIndex = 8 }) 
                                { RowIndex = 2 });
            BBCSheet.AppendChild(new Row(new Cell { DataType = (CellValues.String), CellReference = "E3", CellValue = new CellValue($"As of {String.Format("{0:MMMM dd, yyyy}", endDate)}"),  StyleIndex = 15 }));

            // Add Kuber Logo
            AddImage(BBCSummaryWorkSeetPart, Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/ExcelImages/KuberLogo.png", "Logo", 1, 6, 1000000, 1000000);
            // Add Company name and address
            BBCSheet.AppendChild(new Row(new Cell { DataType = (CellValues.String), CellReference = "A9", CellValue = new CellValue("Kuber Mortgage Investment Corportation") })
                                { RowIndex = 9 });

            BBCSheet.AppendChild(new Row(WriteToCell("406-3852 Finch Avenue East Toronto, ON M1T 3T9", CellValues.String)));

            // Summary Table
            BBCSheet.AppendChild(new Row(new Cell { CellReference = "B15", CellValue = new CellValue("Owner Occupied - LTV < 50% GTA - 1st Mortgages"), DataType = CellValues.String, StyleIndex = 31 },
                                         new Cell { CellReference = "C15", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 29 },
                                         new Cell { CellReference = "D15", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 29 },
                                         new Cell { CellReference = "E15", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 29 },
                                         new Cell { CellReference = "F15", CellValue = new CellValue(Convert.ToString(BBCReportData.QualifiedAmountOwnerOccupied1stMortgagesLTVLessThan50GTA)), DataType = CellValues.Number, StyleIndex = 40 })
                                { RowIndex = 15 });
            
            BBCSheet.AppendChild(new Row(new Cell { CellReference = "B16", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 27 },
                                         new Cell { CellReference = "C16", CellValue = new CellValue("Eligible Amount:"), DataType = CellValues.String },
                                         new Cell { CellReference = "F16", CellValue = new CellValue(Convert.ToString(BBCReportData.EligibleAmountOwnerOccupied1stMortgagesLTVLessThan50GTA)), DataType = CellValues.Number, StyleIndex = 36 }));

            BBCSheet.AppendChild(new Row(new Cell { CellReference = "B17", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 27 },
                                         new Cell { CellReference = "F17", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 28 }));

            BBCSheet.AppendChild(new Row(new Cell { CellReference = "B18", CellValue = new CellValue("Owner Occupied (Excluding LTV < 50% GTA) - 1st Mortgages"), DataType = CellValues.String, StyleIndex = 27 },
                                         new Cell { CellReference = "F18", CellValue = new CellValue(Convert.ToString(BBCReportData.QualifiedAmountOwnerOccupied1stMortgagesOther)), DataType = CellValues.Number, StyleIndex = 36 }));
            BBCSheet.AppendChild(new Row(new Cell { CellReference = "B19", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 27 },
                                         new Cell { CellReference = "C19", CellValue = new CellValue("Eligible Amount:"), DataType = CellValues.String },
                                         new Cell { CellReference = "F19", CellValue = new CellValue(Convert.ToString(BBCReportData.EligibleAmountOwnerOccupied1stMortgagesOther)), DataType = CellValues.Number, StyleIndex = 36 }));

            BBCSheet.AppendChild(new Row(new Cell { CellReference = "B20", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 27 },
                                         new Cell { CellReference = "F20", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 28 }));

            BBCSheet.AppendChild(new Row(new Cell { CellReference = "B21", CellValue = new CellValue("2nd Mortgages"), DataType = CellValues.String, StyleIndex = 27 },
                                         new Cell { CellReference = "F21", CellValue = new CellValue(Convert.ToString(BBCReportData.QualifiedAmountOwnerOccupied2ndMortgages)), DataType = CellValues.Number, StyleIndex = 36 }));
            BBCSheet.AppendChild(new Row(new Cell { CellReference = "B22", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 27 }, 
                                         new Cell { CellReference = "C22", CellValue = new CellValue("Eligible Amount:"), DataType = CellValues.String },
                                         new Cell { CellReference = "F22", CellValue = new CellValue(Convert.ToString(BBCReportData.EligibleAmountOwnerOccupied2ndMortgages)), DataType = CellValues.Number, StyleIndex = 36 }));

            BBCSheet.AppendChild(new Row(new Cell { CellReference = "B23", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 27 },
                                         new Cell { CellReference = "F23", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 28 }));

            BBCSheet.AppendChild(new Row(new Cell { CellReference = "B24", CellValue = new CellValue("Non Owner Occupied - 1st Mortgages"), DataType = CellValues.String, StyleIndex = 27 },
                                         new Cell { CellReference = "F24", CellValue = new CellValue(Convert.ToString(BBCReportData.QualifiedAmountNonOwnerOccupied1stMortgages)), DataType = CellValues.Number, StyleIndex = 36 }));
            BBCSheet.AppendChild(new Row(new Cell { CellReference = "B25", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 27 }, 
                                         new Cell { CellReference = "C25", CellValue = new CellValue("Eligible Amount:"), DataType = CellValues.String },
                                         new Cell { CellReference = "F25", CellValue = new CellValue(Convert.ToString(BBCReportData.EligibleAmountNonOwnerOccupied1stMortgages)), DataType = CellValues.Number, StyleIndex = 36 }));

            BBCSheet.AppendChild(new Row(new Cell { CellReference = "B26", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 27 },
                                         new Cell { CellReference = "F26", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 28 }));

            BBCSheet.AppendChild(new Row(new Cell { CellReference = "B27", CellValue = new CellValue("Commercial - 1st Mortgages"), DataType = CellValues.String, StyleIndex = 27 },
                                         new Cell { CellReference = "F27", CellValue = new CellValue(Convert.ToString(BBCReportData.QualifiedAmountCommercial1stMortgages)), DataType = CellValues.Number, StyleIndex = 36 }));
            BBCSheet.AppendChild(new Row(new Cell { CellReference = "B28", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 27 },
                                         new Cell { CellReference = "C28", CellValue = new CellValue("Eligible Amount:"), DataType = CellValues.String },
                                         new Cell { CellReference = "F28", CellValue = new CellValue(Convert.ToString(BBCReportData.EligibleAmountCommercial1stMortgages)), DataType = CellValues.Number, StyleIndex = 36 }));

            BBCSheet.AppendChild(new Row(new Cell { CellReference = "B29", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 27 },
                                         new Cell { CellReference = "F29", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 28 }));

            BBCSheet.AppendChild(new Row(new Cell { CellReference = "B30", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 34 },
                                         new Cell { CellReference = "C30", CellValue = new CellValue("Total Amount:"), DataType = CellValues.String, StyleIndex = 43 },
                                         new Cell { CellReference = "D30", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 30 },
                                         new Cell { CellReference = "E30", CellValue = new CellValue(""), DataType = CellValues.String, StyleIndex = 30 },
                                         new Cell { CellReference = "F30", CellValue = new CellValue(Convert.ToString(BBCReportData.GetTotalEligibleAmount())), DataType = CellValues.Number, StyleIndex = 44 }));

            return BBCSummaryWorkSeetPart;
        }

        private Sheet GetLoanSheet(IEnumerable<BBCExcelExportLoanDataModel> loanList, WorkbookPart workbookPart, WorksheetPart worksheetPart, UInt32Value sheetId, decimal principalBalanceTotal, BBCCategory BBCCatagory, DateTime? endDate, bool addExtraColumns = false)
        {
            worksheetPart.Worksheet = new Worksheet();
            Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = sheetId, Name = BBCCatagory.ToDescription() };

            GetLoansSheet(loanList, worksheetPart, principalBalanceTotal, addExtraColumns, BBCCatagory, endDate);

            return sheet;
        }

        private void GetLoansSheet(IEnumerable<BBCExcelExportLoanDataModel> bbcExcelDataList, WorksheetPart loanWorkSheet, decimal principalBalanceTotal, bool isQualified, BBCCategory BBCCategory, DateTime? endDate)
        {
            UInt32Value index = 1;
            Columns LoanColumn = new Columns(
                   new Column { Min = index, Max = index++, Width = 8, CustomWidth = true }, // Account Number
                   new Column { Min = index, Max = index++, Width = Math.Max(bbcExcelDataList.Max(l => l.FullName?.Length) ?? 0, "Borrower Name".Length), CustomWidth = true },
                   new Column { Min = index, Max = index++, Width = Math.Max(bbcExcelDataList.Max(l => l.OtherBorrwers?.Length) ?? 0, "Secondary Borrower".Length), CustomWidth = true });

            if (isQualified)
            {
                LoanColumn.Append(
                    new Column { Min = index, Max = index++, Width = "Qualified Amount".Length, CustomWidth = true },
                    new Column { Min = index, Max = index++, Width = 20, CustomWidth = true }); // Lessor of the Appraisal Value or Purchase Price
            }

            LoanColumn.Append(
                   new Column { Min = index, Max = index++, Width = Math.Max(bbcExcelDataList.Max(l => l.PropertyType?.Length) ?? 0, "Property Type".Length), CustomWidth = true },
                   new Column { Min = index, Max = index++, Width = 15, CustomWidth = true }, // Aggregate Appraised Value
                   new Column { Min = index, Max = index++, Width = 7, CustomWidth = true },  // Loan Priority
                   new Column { Min = index, Max = index++, Width = 7, CustomWidth = true },  // Terms Left
                   new Column { Min = index, Max = index++, Width = 15, CustomWidth = true }, // Aggregate Senior Liens
                   new Column { Min = index, Max = index++, Width = 15, CustomWidth = true }, // Original Balance
                   new Column { Min = index, Max = index++, Width = 16, CustomWidth = true }, // Principal Balance
                   new Column { Min = index, Max = index++, Width = 7, CustomWidth = true }, // Note Rate
                   new Column { Min = index, Max = index++, Width = 10, CustomWidth = true }, // Closing Date
                   new Column { Min = index, Max = index++, Width = 10, CustomWidth = true }); // Maturity Date

            if (isQualified)
            {
                LoanColumn.Append(
                    new Column { Min = index, Max = index++, Width = Math.Max(bbcExcelDataList.Max(l => l.LoanTerms?.Length) ?? 0, "Loan Terms".Length), CustomWidth = true },
                    new Column { Min = index, Max = index++, Width = 12, CustomWidth = true }); // Renewal or Refinance Date
            }

           LoanColumn.Append(
                new Column { Min = index, Max = index++, Width = Math.Max(bbcExcelDataList.Max(l => l.CreditScore?.Length) ?? 0, "Credit Score".Length),  CustomWidth = true },
                new Column { Min = index, Max = index++, Width = 10, CustomWidth = true }, // Property LTV  
                new Column { Min = index, Max = index++,  Width = "Property Occupancy".Length, CustomWidth = true },
                new Column { Min = index, Max = index++, Width = "Property County".Length,  CustomWidth = true },
                new Column { Min = index, Max = index++, Width = "Property City".Length, CustomWidth = true },
                new Column { Min = index, Max = index++, Width = Math.Max(bbcExcelDataList.Max(l => l.PropertyAddress?.Length) ?? 0, "Property Address".Length), CustomWidth = true });

            if (isQualified)
            {
                LoanColumn.Append(
                    new Column { Min = index, Max = index++, Width = Math.Max(bbcExcelDataList.Max(l => l.LegalDescription?.Length) ?? 0, "Legal Description".Length), CustomWidth = true },
                    new Column { Min = index, Max = index++, Width = Math.Max(bbcExcelDataList.Max(l => l.PinNumber?.Length) ?? 0, "PIN Number".Length), CustomWidth = true });
            }

            loanWorkSheet.Worksheet.AppendChild(LoanColumn);

            SheetData loanSheet = loanWorkSheet.Worksheet.AppendChild(new SheetData());

            Row headerRow = new Row() { Height = 50, CustomHeight = true };

            headerRow.Append(
                WriteToCell("Account Number", CellValues.String, 3),
                WriteToCell("Borrower Name", CellValues.String, 3),
                WriteToCell("Secondary Borrower", CellValues.String, 3));

            if (isQualified)
            {
                headerRow.Append(
                    WriteToCell("Qualified Amount", CellValues.String, 46),
                    WriteToCell("Lessor of the Appraisal Value or Purchase Price", CellValues.String, 3));
            }

            headerRow.Append(
                WriteToCell("Property Type", CellValues.String, 3),
                WriteToCell("Aggregate Appraised Value", CellValues.String, 45),
                WriteToCell("Loan Priority", CellValues.String, 45),
                WriteToCell("Terms Left", CellValues.String, 45),
                WriteToCell("Aggregate Senior Liens", CellValues.String, 45),
                WriteToCell("Original Balance", CellValues.String, 45),
                WriteToCell("Principal Balance", CellValues.String, 45),
                WriteToCell("Note Rate", CellValues.String, 45),
                WriteToCell("Closing Date", CellValues.String, 45),
                WriteToCell("Maturity Date", CellValues.String, 45));

            if (isQualified)
            {
                headerRow.Append(
                    WriteToCell("Loan Terms", CellValues.String, 45),
                    WriteToCell("Renewal or Refinance Date", CellValues.String, 45));
            }

            headerRow.Append(
                WriteToCell("Credit Score", CellValues.String, 45),
                WriteToCell("Property LTV", CellValues.String, 45),
                WriteToCell("Property Occupancy", CellValues.String, 45),
                WriteToCell("Property County", CellValues.String, 45),
                WriteToCell("Property City", CellValues.String, 45),
                WriteToCell("Property Address", CellValues.String, 3));

            if (isQualified)
            {
                headerRow.Append(
                    WriteToCell("Legal Description", CellValues.String, 3),
                    WriteToCell("PIN Number", CellValues.String, 3));
            }

            loanSheet.AppendChild(headerRow);

            // Populate data
            UInt32Value rowIndex = 1;
            if (isQualified)
            {
                foreach (BBCExcelExportLoanDataModel bbcExcelData in bbcExcelDataList.OrderBy(l => l.Account))
                {
                    addLoanRow(isQualified, loanSheet, bbcExcelData);

                    rowIndex++;
                }
            }
            else
            {
                foreach (PropertyCategory propertyCategory in Enum.GetValues(typeof(PropertyCategory)))
                {
                    IEnumerable<BBCExcelExportLoanDataModel> loanListByPropertyCategory = bbcExcelDataList.Where(d => d.PropertyCategory == propertyCategory);
                    if (loanListByPropertyCategory.Any())
                    {
                        if (propertyCategory == PropertyCategory.Residential)
                        {
                            foreach (PropertyType propertyType in new List<PropertyType>() {PropertyType.SFRCMADetached, 
                                                                                            PropertyType.SFRCADetached, 
                                                                                            PropertyType.SFRCMASemiDetached, 
                                                                                            PropertyType.SFRCMARowHousing, 
                                                                                            PropertyType.SFRCARowHousing})
                            {
                                foreach (BBCExcelExportLoanDataModel bbcExcelData in loanListByPropertyCategory.Where(p => p.PropertyType == propertyType.ToDescription()))
                                {
                                    addLoanRow(isQualified, loanSheet, bbcExcelData);

                                    rowIndex++;
                                }
                            }
                        }
                        else
                        {
                            foreach (BBCExcelExportLoanDataModel bbcExcelData in loanListByPropertyCategory.OrderBy(l => l.PropertyType))
                            {
                                addLoanRow(isQualified, loanSheet, bbcExcelData);

                                rowIndex++;
                            }
                        }
                        
                        // Add Sub Total
                        if (BBCCategory != BBCCategory.Arrears1stMortgages && BBCCategory != BBCCategory.Arrears2ndMortgages && BBCCategory != BBCCategory.DelinquentMortgages)
                        {
                            rowIndex += 2;
                            Row subtotalRow = new Row() { RowIndex = rowIndex };
                            subtotalRow.Append(new Cell { CellReference = "I" + rowIndex.ToString(), CellValue = new CellValue("Total O/S"), DataType = CellValues.String, StyleIndex = 15 });
                            subtotalRow.Append(new Cell { CellReference = "J" + rowIndex.ToString(), CellValue = new CellValue(Convert.ToString(loanListByPropertyCategory.Sum(l => l.PrinBal))), DataType = CellValues.Number, StyleIndex = 25 });
                            loanSheet.AppendChild(subtotalRow);
                            rowIndex++;
                            loanSheet.AppendChild(new Row());
                        }
                    }
                }
            }
            
            if (isQualified)
            {
                rowIndex = (uint)bbcExcelDataList.Count() + 3;
                // Add Qualified Total
                Row subtotalRow = new Row() { RowIndex = rowIndex };
                subtotalRow.Append(new Cell { CellReference = "C" + rowIndex.ToString(), CellValue = new CellValue("Total Q/A"), DataType = (CellValues.String), StyleIndex = 15 });
                subtotalRow.Append(new Cell { CellReference = "D" + rowIndex.ToString(), CellValue = new CellValue(Convert.ToString(bbcExcelDataList.Sum(l => l.QualifiedAmount))), DataType = CellValues.Number, StyleIndex = 25 });
                loanSheet.AppendChild(subtotalRow);
            }
            else
            {
                // Add Principal Total
                if(bbcExcelDataList.Count() > 0)
                {
                    rowIndex += 2;
                    Row subtotalRow = new Row() { RowIndex = rowIndex };
                    subtotalRow.Append(new Cell { CellReference = "I" + rowIndex.ToString(), CellValue = new CellValue($"{BBCCategory.ToDescription()} Total"), DataType = CellValues.String, StyleIndex = 15 });
                    subtotalRow.Append(new Cell { CellReference = "J" + rowIndex.ToString(), CellValue = new CellValue(Convert.ToString(Math.Round((decimal)bbcExcelDataList.Sum(l => l.PrinBal), 2))), DataType = CellValues.Number, StyleIndex = 21 });
                    loanSheet.AppendChild(subtotalRow);

                }

                if (BBCCategory == BBCCategory.FirstMortgage)
                {
                    rowIndex += 2;
                    Row totalRow = new Row() { RowIndex = rowIndex };
                    totalRow.Append(new Cell { CellReference = "I" + rowIndex.ToString(), CellValue = new CellValue($"Total O/S Mortgages as of {String.Format("{0:MMMM dd, yyyy}", endDate)}"), DataType = (CellValues.String), StyleIndex = 26 });
                    totalRow.Append(new Cell { CellReference = "J" + rowIndex.ToString(), CellValue = new CellValue(Convert.ToString(Math.Round(principalBalanceTotal, 2))), DataType = CellValues.Number, StyleIndex = 21 });
                    loanSheet.AppendChild(totalRow);
                }
            }

            void addLoanRow(bool isQualified, SheetData loanSheet, BBCExcelExportLoanDataModel bbcExcelData)
            {
                Row dataRow = new Row();

                dataRow.Append(
                    WriteToCell(bbcExcelData.Account, CellValues.String),
                    WriteToCell(bbcExcelData.FullName, CellValues.String),
                    WriteToCell(bbcExcelData.OtherBorrwers, CellValues.String));

                if (isQualified)
                {
                    dataRow.Append(
                        WriteToCell(Convert.ToString(bbcExcelData.QualifiedAmount), CellValues.Number,  20),
                        WriteToCell(Convert.ToString(bbcExcelData.LessorOfTheAppraisalValueorPurchasePrice.ToDecimal()), CellValues.Number, 20));
                }

                dataRow.Append(
                    WriteToCell(bbcExcelData.PropertyType, CellValues.String),
                    WriteToCell(Convert.ToString(bbcExcelData.AggregateAppraiserFmv), CellValues.Number, 20),
                    WriteToCell(((int)bbcExcelData.Priority).Ordinal().ToString(), CellValues.String, 24),
                    WriteToCell(Convert.ToString(bbcExcelData.TermsLeft), CellValues.Number, 23),
                    WriteToCell(Convert.ToString(bbcExcelData.AggregateSeniorLiens), CellValues.Number, 20),
                    WriteToCell(Convert.ToString(bbcExcelData.OrigBal), CellValues.Number, 20),
                    WriteToCell(Convert.ToString(bbcExcelData.PrinBal), CellValues.Number, 20),
                    WriteToCell(Convert.ToString(bbcExcelData.NoteRate/100), CellValues.Number, 22),
                    WriteToCell(String.Format("{0:MM-dd-yyyy}", bbcExcelData.ClosingDate), CellValues.String, 24),
                    WriteToCell(String.Format("{0:MM-dd-yyyy}", bbcExcelData.MaturityDate), CellValues.String, 24));

                if (isQualified)
                {
                    dataRow.Append(
                        WriteToCell(bbcExcelData.LoanTerms, CellValues.String),
                        WriteToCell(String.Format("{0:MM-dd-yyyy}", String.IsNullOrEmpty(bbcExcelData.RenewalOrRefinanceDate) ? "" : DateTime.Parse(bbcExcelData.RenewalOrRefinanceDate)), CellValues.String, 24));
                }

                dataRow.Append(
                    WriteToCell(bbcExcelData.CreditScore, CellValues.String, 24),
                    WriteToCell(Convert.ToString(bbcExcelData.CalculatedLtv/100), CellValues.Number, 22),
                    WriteToCell(bbcExcelData.PropertyOccupancy, CellValues.String),
                    WriteToCell(bbcExcelData.PropertyCounty, CellValues.String),
                    WriteToCell(bbcExcelData.PropertyCity, CellValues.String),
                    WriteToCell(bbcExcelData.PropertyAddress, CellValues.String));

                if (isQualified)
                {
                    dataRow.Append(
                        WriteToCell(bbcExcelData.LegalDescription, CellValues.String),
                        WriteToCell(bbcExcelData.PinNumber, CellValues.String));
                }

                loanSheet.AppendChild(dataRow);
            }
        }

        private WorksheetPart AddNotesSheet(WorkbookPart workbookPart)
        {
            // Add a WorksheetPart to the WorkbookPart.
            WorksheetPart notesWorksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            notesWorksheetPart.Worksheet = new Worksheet();

            notesWorksheetPart.Worksheet.AppendChild(new Columns(new Column
            {
                Min = 1,
                Max = 1,
                Width = "SFR - Single Family Residential".Length,
                CustomWidth = true
            }));

            SheetData notesSheet = notesWorksheetPart.Worksheet.AppendChild(new SheetData());

            // Header
            notesSheet.AppendChild(new Row(WriteToCell("Notes", CellValues.String, 2)));

            // Data
            notesSheet.AppendChild(new Row(WriteToCell("SFR - Single Family Residential", CellValues.String)));
            notesSheet.AppendChild(new Row(WriteToCell("CMA - Census Metropolitan Area", CellValues.String)));
            notesSheet.AppendChild(new Row(WriteToCell("CA -Census Agglomeration", CellValues.String)));

            return notesWorksheetPart;
        }

        private Cell WriteToCell(string value, CellValues dataType, uint styleIndex = 0)
        {
            return new Cell()
            {
                CellValue = new CellValue(value),
                DataType = new EnumValue<CellValues>(dataType),
                StyleIndex = styleIndex,
            };
        }

        private static void AddImage(WorksheetPart worksheetPart, string imageFileName, string imgDesc, int colNumber, int rowNumber, int width, int height)
        {
            using (var imageStream = new FileStream(imageFileName, FileMode.Open))
            {
                // We need the image stream more than once, thus we create a memory copy
                MemoryStream imageMemStream = new MemoryStream();
                imageStream.Position = 0;
                imageStream.CopyTo(imageMemStream);
                imageStream.Position = 0;

                var drawingsPart = worksheetPart.DrawingsPart;
                if (drawingsPart == null)
                    drawingsPart = worksheetPart.AddNewPart<DrawingsPart>();

                if (!worksheetPart.Worksheet.ChildElements.OfType<Drawing>().Any())
                {
                    worksheetPart.Worksheet.Append(new Drawing { Id = worksheetPart.GetIdOfPart(drawingsPart) });
                }

                if (drawingsPart.WorksheetDrawing == null)
                {
                    drawingsPart.WorksheetDrawing = new Xdr.WorksheetDrawing();
                }

                var worksheetDrawing = drawingsPart.WorksheetDrawing;

                System.Drawing.Bitmap bm = new System.Drawing.Bitmap(imageMemStream);
                var imagePart = drawingsPart.AddImagePart(GetImagePartTypeByBitmap(bm));
                imagePart.FeedData(imageStream);

                A.Extents extents = new A.Extents();
                var extentsCx = bm.Width * (long)(width / bm.HorizontalResolution);
                var extentsCy = bm.Height * (long)(height / bm.VerticalResolution);
                bm.Dispose();

                var colOffset = 0;
                var rowOffset = 0;

                var nvps = worksheetDrawing.Descendants<Xdr.NonVisualDrawingProperties>();
                var nvpId = nvps.Count() > 0
                    ? (UInt32Value)worksheetDrawing.Descendants<Xdr.NonVisualDrawingProperties>().Max(p => p.Id.Value) + 1
                    : 1U;

                var oneCellAnchor = new Xdr.OneCellAnchor(
                    new Xdr.FromMarker
                    {
                        ColumnId = new Xdr.ColumnId((colNumber - 1).ToString()),
                        RowId = new Xdr.RowId((rowNumber - 1).ToString()),
                        ColumnOffset = new Xdr.ColumnOffset(colOffset.ToString()),
                        RowOffset = new Xdr.RowOffset(rowOffset.ToString())
                    },
                    new Xdr.Extent { Cx = extentsCx, Cy = extentsCy },
                    new Xdr.Picture(
                        new Xdr.NonVisualPictureProperties(
                            new Xdr.NonVisualDrawingProperties { Id = nvpId, Name = "Picture " + nvpId, Description = imgDesc },
                            new Xdr.NonVisualPictureDrawingProperties(new A.PictureLocks { NoChangeAspect = true })
                        ),
                        new Xdr.BlipFill(
                            new A.Blip { Embed = drawingsPart.GetIdOfPart(imagePart), CompressionState = A.BlipCompressionValues.Print },
                            new A.Stretch(new A.FillRectangle())
                        ),
                        new Xdr.ShapeProperties(
                            new A.Transform2D(
                                new A.Offset { X = 5, Y = 5 },
                                new A.Extents { Cx = extentsCx, Cy = extentsCy }
                            ),
                            new A.PresetGeometry { Preset = A.ShapeTypeValues.Rectangle }
                        )
                    ),
                    new Xdr.ClientData()
                );

                worksheetDrawing.Append(oneCellAnchor);
            }
        }
        
        private static ImagePartType GetImagePartTypeByBitmap(System.Drawing.Bitmap image)
        {
            if (System.Drawing.Imaging.ImageFormat.Png.Equals(image.RawFormat))
                return ImagePartType.Png;
            else
                throw new Exception("Image type could not be determined.");
        }

        private Stylesheet GenerateStylesheet()
        {
            Fonts fonts = new Fonts(
                new Font(new FontName() { Val = "Calibri" }, new FontSize() { Val = 11 }),
                new Font(new FontName() { Val = "Calibri" }, new FontSize() { Val = 11 }, new Color() { Rgb = "FFFFFF" }, new Underline()),
                new Font(new FontName() { Val = "Calibri" }, new FontSize() { Val = 11 }, new Bold(), new Color() { Rgb = "FFFFFF" }),
                new Font(new FontName() { Val = "Calibri" }, new FontSize() { Val = 18 }, new Bold(), new Color() { Rgb = "FFFFFF" }),
                new Font(new FontName() { Val = "Calibri" }, new FontSize() { Val = 24 }),
                new Font(new FontName() { Val = "Calibri" }, new FontSize() { Val = 11 }, new Color() { Rgb = "FF0000" }),
                new Font(new FontName() { Val = "Calibri" }, new FontSize() { Val = 36 }, new Bold(), new Color() { Rgb = new HexBinaryValue() { Value = "44546a" } }),
                new Font(new FontName() { Val = "Calibri" }, new FontSize() { Val = 30 }, new Bold(), new Color() { Rgb = new HexBinaryValue() { Value = "44546a" } }),
                new Font(new FontName() { Val = "Calibri" }, new FontSize() { Val = 11 }, new Bold()),
                new Font(new FontName() { Val = "Calibri" }, new FontSize() { Val = 11 }, new Italic(), new Bold())
            );

            Fills fills = new Fills(
                new Fill(new PatternFill() { PatternType = PatternValues.None }), // Index 0 - default
                new Fill(new PatternFill() { PatternType = PatternValues.Gray125 }), // Index 1 - default
                new Fill(new PatternFill(new ForegroundColor { Rgb = new HexBinaryValue() { Value = "44546a" } })
                { PatternType = PatternValues.Solid })
            );

            Borders borders = new Borders(
                new Border(),
                new Border(
                    new LeftBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin }),
                new Border(
                    new RightBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin }),
                new Border(
                    new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin }),
                new Border(
                    new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin }),
                new Border( // 5
                    new LeftBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                    new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin }),
                new Border(
                    new RightBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                    new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin }),
                new Border(
                    new RightBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                    new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin }),
                new Border(
                    new LeftBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                    new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin }),
                new Border( // 9
                    new LeftBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                    new RightBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                    new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                    new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin }),
                new Border( // 10
                    new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                    new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Double }),

                new Border( // 11
                    new LeftBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Medium }),
                new Border(
                    new RightBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Medium }),
                new Border(
                    new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Medium }),
                new Border( // 14
                    new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Medium }),
                new Border( // 15
                    new LeftBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Medium },
                    new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Medium }),
                new Border(
                    new RightBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Medium },
                    new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Medium }),
                new Border(
                    new RightBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Medium },
                    new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Medium }),
                new Border(
                    new LeftBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Medium },
                    new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Medium }),
                new Border( // 19
                    new LeftBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Medium },
                    new RightBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Medium },
                    new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Medium },
                    new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Medium })
            );

            NumberingFormats numberingFormats = new NumberingFormats(
                new NumberingFormat() { NumberFormatId = 1, FormatCode = "$#,##0.00_);[Red]($#,##0.00)" },
                new NumberingFormat() { NumberFormatId = 2, FormatCode = "#,##0_);[Red](#,##0)" }
            );

            CellFormats cellFormats = new CellFormats(
                    new CellFormat(),
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true },
                    new CellFormat() { FontId = 2, FillId = 0, BorderId = 1, ApplyFill = true },
                    new CellFormat(new Alignment { Vertical = VerticalAlignmentValues.Center, WrapText = true}) { FontId = 8, FillId = 0, BorderId = 4, ApplyBorder = false },
                    new CellFormat() { FontId = 2, FillId = 2, BorderId = 0, ApplyFill = true },
                    new CellFormat() { FontId = 1, FillId = 2, BorderId = 1, ApplyFill = true },
                    new CellFormat (){ FontId = 0, FillId = 2, BorderId = 0, ApplyFill = true },
                    new CellFormat(new Alignment { Horizontal = HorizontalAlignmentValues.Center }) { FontId = 3, FillId = 2, BorderId = 1, ApplyFill = true, ApplyAlignment = true },
                    new CellFormat(new Alignment { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }) { FontId = 4, FillId = 0, BorderId = 0, ApplyFill = false, ApplyAlignment = true },
                    new CellFormat(new Alignment { Horizontal = HorizontalAlignmentValues.Center }) { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true },
                    new CellFormat(new Alignment { WrapText = true }) { FontId = 0, FillId = 0, BorderId = 0, ApplyBorder = false },
                    new CellFormat(new Alignment { WrapText = true }) { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true },
                    new CellFormat() { FontId = 5 }, // 12
                    new CellFormat(new Alignment { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }) { FontId = 6 },
                    new CellFormat(new Alignment { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }) { FontId = 7, FillId = 0, BorderId = 0, ApplyFill = true, ApplyAlignment = true },
                    new CellFormat(new Alignment { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }) { FontId = 8, FillId = 0, BorderId = 0, ApplyFill = false, ApplyAlignment = true },
                    new CellFormat() { BorderId = 1 }, // 16 - thin
                    new CellFormat() { BorderId = 2 },
                    new CellFormat() { BorderId = 3 },
                    new CellFormat() { BorderId = 4 },

                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 0, NumberFormatId = 1, ApplyFill = false, ApplyAlignment = true }, // 20 - Dollar
                    new CellFormat() { FontId = 8, FillId = 0, BorderId = 0, NumberFormatId = 1, ApplyFill = false, ApplyAlignment = true }, // Bold Dollar
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 0, NumberFormatId = (UInt32Value)10U, FormatId = (UInt32Value)0U, ApplyNumberFormat = true, ApplyFill = false, ApplyAlignment = true }, // 22 - %
                    new CellFormat(new Alignment { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }) { FontId = 0, FillId = 0, BorderId = 0, NumberFormatId = 2, ApplyFill = false, ApplyAlignment = true }, // 23 - Number
                    new CellFormat(new Alignment { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }), // 24 - Center
                    new CellFormat(new Alignment { Horizontal = HorizontalAlignmentValues.Right }) { FontId = 8, FillId = 0, BorderId = 10, NumberFormatId = 1, ApplyFill = false, ApplyAlignment = true },
                    new CellFormat(new Alignment { Horizontal = HorizontalAlignmentValues.Right, Vertical = VerticalAlignmentValues.Center }) { FontId = 9, FillId = 0, BorderId = 0, ApplyFill = false, ApplyAlignment = true },

                    new CellFormat() { BorderId = 11 }, // 27 - left-medium-text
                    new CellFormat() { BorderId = 12 }, // 28 - right-medium-text
                    new CellFormat() { BorderId = 13 }, // 29 - top-medium-text
                    new CellFormat() { BorderId = 14 }, // 30 - bottom-medium-text

                    new CellFormat() { BorderId = 15 }, // 31 - left-top-medium-text
                    new CellFormat() { BorderId = 16 }, // 32 - top-right-medium-text
                    new CellFormat() { BorderId = 17 }, // 33 - right-bottom-medium-text
                    new CellFormat() { BorderId = 18 }, // 34 - bottom-left-medium-text

                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 11, NumberFormatId = 1, ApplyFill = false, ApplyAlignment = true }, // 35 - left-medium-Dollar
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 12, NumberFormatId = 1, ApplyFill = false, ApplyAlignment = true }, // 36 - right-medium-Dollar
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 13, NumberFormatId = 1, ApplyFill = false, ApplyAlignment = true }, // 37 - top-medium-Dollar
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 14, NumberFormatId = 1, ApplyFill = false, ApplyAlignment = true }, // 38 - bottom-medium-Dollar

                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 15, NumberFormatId = 1, ApplyFill = false, ApplyAlignment = true }, // 39 - left-top-medium-Dollar
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 16, NumberFormatId = 1, ApplyFill = false, ApplyAlignment = true }, // 40 - top-right-medium-Dollar
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 17, NumberFormatId = 1, ApplyFill = false, ApplyAlignment = true }, // 41 - right-bottom-medium-Dollar
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 18, NumberFormatId = 1, ApplyFill = false, ApplyAlignment = true }, // 42 - bottom-left-medium-Dollar

                    new CellFormat() { FontId = 8, BorderId = 14 }, // 43 - bottom-medium-Bold-text
                    new CellFormat() { FontId = 8, FillId = 0, BorderId = 17, NumberFormatId = 1, ApplyFill = false, ApplyAlignment = true }, // 44 - right-bottom-medium-Bold-Dollar


                    new CellFormat(new Alignment { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }) { FontId = 8, FillId = 0, BorderId = 4, ApplyBorder = false },
                    new CellFormat(new Alignment { Horizontal = HorizontalAlignmentValues.Right, Vertical = VerticalAlignmentValues.Center, WrapText = true }) { FontId = 8, FillId = 0, BorderId = 4, ApplyBorder = false }
                );

            Stylesheet styleSheet = new Stylesheet(fonts, fills, borders, cellFormats);
            styleSheet.NumberingFormats = numberingFormats;

            return styleSheet;
        }
    }
}