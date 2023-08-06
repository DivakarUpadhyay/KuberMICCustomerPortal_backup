using KuberMICManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KuberMICManager.Core.Domain.ViewModels
{
    public class PartnerViewModel
    {
        public PssPartner Partner { get; set; }
        public PssPool Pool { get; set; }
        public PssTrustee Trustee { get; set; }
        public IEnumerable<PssCertificate> Certificates { get; set; }
        public IEnumerable<PssTransaction> Transactions { get; set; }
        public IEnumerable<PssDistribution> Distributions { get; set; }

        // Shared
        public IEnumerable<AppAttachment> Attachments { get; set; }
        public AppNote Notes { get; set; }
        public IEnumerable<UdfField> UDFFields { get; set; }
        public IEnumerable<UdfValue> UDFValues { get; set; }
        public IEnumerable<UdfTab> UDFTabs { get; set; }

        // Methods for Certificates tab
        public decimal GetTotalOriginalShares(string certificateRecID)
        {
            return Transactions.Where(t => t.CertificateRecId == certificateRecID && (bool)t.Drip == false).Sum(t => t.Shares) ?? 0;
        }

        public decimal GetTotalDripShares(string certificateRecID)
        {
            return Transactions.Where(t => t.CertificateRecId == certificateRecID && (bool)t.Drip).Sum(t => t.Shares) ?? 0;
        }

        public decimal GetTotalShares(string certificateRecID)
        {
            return Transactions.Where(t => t.CertificateRecId == certificateRecID)?.Sum(t => t.Shares) ?? 0;
        }

        public decimal GetSharePrice(string certificateRecID)
        {
            return Transactions.FirstOrDefault(t => t.CertificateRecId == certificateRecID && (bool)t.Drip == false)?.SharePrice ?? 0;
        }

        public decimal GetTotalAmountPaid(string certificateRecID)
        {
            return Transactions.Where(t => t.CertificateRecId == certificateRecID).Sum(t => t.Amount) ?? 0;
        }

        // Methods for Transactions Tab
        public decimal GetTotalShares()
        {
            return Transactions?.Sum(t => t.Shares) ?? 0;
        }

        public string GetCertificateNumber(string recID)
        {
            return Certificates.FirstOrDefault(c => c.RecId == recID)?.Number;
        }
    }
}