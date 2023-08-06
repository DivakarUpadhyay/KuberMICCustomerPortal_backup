namespace KuberMICManager.Core.Domain.HelperDataModels
{
    public class LoanAvgAppraisalDataModel
    {
        public string LoanRecID { get; set; }
        public string Account { get; set; }

        public decimal? AverageAppraisalDaysToDate { get; set; }
        public decimal? AverageAppraiserFmv { get; set; }
    }
}