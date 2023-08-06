using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using KuberMICManager.Core.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace KuberMICManager.Core.Application.HelperSerivces
{
    public class GoogleAPISerivce : IGoogleAPISerivce
    {
        // inject the dependencies
        private readonly ILogger<LoanService> _logger;

        public GoogleAPISerivce(ILogger<LoanService> logger)
        {
            _logger = logger;
        }

        public async Task GetGDriveFileByName(string fileName, MemoryStream outputStream)
        {
            UserCredential credential;

            string[] Scopes = { DriveService.Scope.DriveReadonly };

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "KMICManager"
            });

            // Define parameters of request.
            var request = service.Files.List();
            request.IncludeItemsFromAllDrives = true;
            request.SupportsAllDrives = true;
            request.DriveId = "0AEdQFtip6591Uk9PVA"; // Kuber MIC Shared Drive
            request.Corpora = "drive";
            request.Q = $"name = '{fileName}'"; // File name
            var results = await request.ExecuteAsync();

            service.Files.Get(results.Files[0].Id).Download(outputStream);
        }
    }
}