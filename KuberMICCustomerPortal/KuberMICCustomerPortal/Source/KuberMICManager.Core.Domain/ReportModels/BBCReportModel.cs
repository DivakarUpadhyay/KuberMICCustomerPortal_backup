using System.Collections.Generic;

namespace KuberMICManager.Core.Domain.ReportModels
{
    public class BBCReportModel
    {
        public IEnumerable<BBCExcelExportLoanDataModel> FirstMortgages { get; set; }
        public IEnumerable<BBCExcelExportLoanDataModel> SecondMortgages { get; set; }
        public IEnumerable<BBCExcelExportLoanDataModel> ThirdMortgages { get; set; }

        // public IEnumerable<BBCExcelExportLoanDataModel> LoansOwnerOccupied1stMortgages { get; set; } - Replaced with LTV < 50% GTA & Other
        public IEnumerable<BBCExcelExportLoanDataModel> OwnerOccupied1stMortgagesLTVLessThan50GTA { get; set; }
        public IEnumerable<BBCExcelExportLoanDataModel> OwnerOccupied1stMortgagesOther { get; set; }
        public IEnumerable<BBCExcelExportLoanDataModel> OwnerOccupied1stMortgages { get; set; }
        public IEnumerable<BBCExcelExportLoanDataModel> OwnerOccupied2ndMortgages { get; set; }
        public IEnumerable<BBCExcelExportLoanDataModel> NonOwnerOccupied1stMortgages { get; set; }
        public IEnumerable<BBCExcelExportLoanDataModel> Commercial1stMortgages { get; set; }
        public IEnumerable<BBCExcelExportLoanDataModel> Arrears1stMortgages { get; set; }
        public IEnumerable<BBCExcelExportLoanDataModel> Arrears2ndMortgages { get; set; }
        public IEnumerable<BBCExcelExportLoanDataModel> DelinquentMortgages { get; set; }

        //-------Overall//-------
        public decimal PrincipalBalanceTotal { get; set; }

        //-------Active Loans-------
        // *** BORROWING BASE CERTIFICATE ***
        // Owner Occupied - 1st Mortgages - All - Not used now - Replaced with LTV < 50% GTA & Other
        public int NoOfLoansOwnerOccupied1stMortgages { get; set; }
        public decimal EligibleAmountOwnerOccupied1stMortgages { get; set; }
        public decimal QualifiedAmountOwnerOccupied1stMortgages { get; set; }
        public decimal PctOfAUMOwnerOccupied1stMortgages { get; set; }

        // Owner Occupied - 1st Mortgages - LTV < 50% GTA
        public int NoOfLoansOwnerOccupied1stMortgagesLTVLessThan50GTA { get; set; }
        public decimal EligibleAmountOwnerOccupied1stMortgagesLTVLessThan50GTA { get; set; }
        public decimal QualifiedAmountOwnerOccupied1stMortgagesLTVLessThan50GTA { get; set; }
        public decimal PctOfAUMOwnerOccupied1stMortgagesLTVLessThan50GTA { get; set; }

        // Owner Occupied - 1st Mortgages - Other (All - LTV < 50% GTA)
        public int NoOfLoansOwnerOccupied1stMortgagesOther { get; set; }
        public decimal EligibleAmountOwnerOccupied1stMortgagesOther { get; set; }
        public decimal QualifiedAmountOwnerOccupied1stMortgagesOther { get; set; }
        public decimal PctOfAUMOwnerOccupied1stMortgagesOther { get; set; }

        // Owner Occupied - 2nd Mortgages
        public int NoOfLoansOwnerOccupied2ndMortgages { get; set; }
        public decimal EligibleAmountOwnerOccupied2ndMortgages { get; set; }
        public decimal QualifiedAmountOwnerOccupied2ndMortgages { get; set; }
        public decimal PctOfAUMOwnerOccupied2ndMortgages { get; set; }

        // Non Owner Occupied - 1st Mortgages
        public int NoOfLoansNonOwnerOccupied1stMortgages { get; set; }
        public decimal EligibleAmountNonOwnerOccupied1stMortgages { get; set; }
        public decimal QualifiedAmountNonOwnerOccupied1stMortgages { get; set; }
        public decimal PctOfAUMNonOwnerOccupied1stMortgages { get; set; }

        // Commercial Mortgages
        public int NoOfLoansCommercial1stMortgages { get; set; }
        public decimal EligibleAmountCommercial1stMortgages { get; set; }
        public decimal QualifiedAmountCommercial1stMortgages { get; set; }
        public decimal PctOfAUMCommercial1stMortgages { get; set; }

        public decimal GetTotalNoOfLoans()
        {
            return NoOfLoansOwnerOccupied1stMortgagesLTVLessThan50GTA +
                   NoOfLoansOwnerOccupied1stMortgagesOther +
                   NoOfLoansOwnerOccupied2ndMortgages +
                   NoOfLoansNonOwnerOccupied1stMortgages +
                   NoOfLoansCommercial1stMortgages;
        }

        public decimal GetTotalEligibleAmount()
        {
            return EligibleAmountOwnerOccupied1stMortgagesLTVLessThan50GTA +
                   EligibleAmountOwnerOccupied1stMortgagesOther +
                   EligibleAmountOwnerOccupied2ndMortgages +
                   EligibleAmountNonOwnerOccupied1stMortgages +
                   EligibleAmountCommercial1stMortgages;
        }

        public decimal GetTotalQualifiedAmount()
        {
            return QualifiedAmountOwnerOccupied1stMortgagesLTVLessThan50GTA +
                   QualifiedAmountOwnerOccupied1stMortgagesOther +
                   QualifiedAmountOwnerOccupied2ndMortgages +
                   QualifiedAmountNonOwnerOccupied1stMortgages +
                   QualifiedAmountCommercial1stMortgages;
        }

        public decimal GetTotalPct()
        {
            return PctOfAUMOwnerOccupied1stMortgagesLTVLessThan50GTA +
                   PctOfAUMOwnerOccupied1stMortgagesOther +
                   PctOfAUMOwnerOccupied2ndMortgages +
                   PctOfAUMNonOwnerOccupied1stMortgages +
                   PctOfAUMCommercial1stMortgages;
        }
    }
}