using System;
using System.IO;
using System.Threading.Tasks;

namespace KuberMICManager.Core.Domain.Interfaces.Services
{
    public interface IExportService
    {
        Task<Stream> ExportToPDF(string contentString);
        Task<byte[]> ExportBBCToExcel(DateTime? endDate);
    }
}