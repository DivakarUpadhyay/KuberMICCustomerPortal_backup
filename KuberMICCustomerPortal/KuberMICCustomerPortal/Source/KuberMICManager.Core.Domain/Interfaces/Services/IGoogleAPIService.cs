using System.IO;
using System.Threading.Tasks;

namespace KuberMICManager.Core.Domain.Interfaces.Services
{
    public interface IGoogleAPISerivce
    {
        Task GetGDriveFileByName(string fileName, MemoryStream outputStream);
    }
}