using System;
using System.Threading.Tasks;
using System.Net.Http;
using Refit;

namespace SDC.Coach.Google.Drive
{
    public interface IDrive
    {
        [Get("/files?q=mimeType%3D%27application%2Fvnd.google-apps.spreadsheet%27")]
        Task<FilesResponse> GetSpreadsheets();
        [Get("/files?q=mimeType%3D%27application%2Fvnd.google-apps.spreadsheet%27")]
        Task<FilesResponse> GetSpreadsheets([AliasAs("pageToken")]String nextPageToken);
    }
}
