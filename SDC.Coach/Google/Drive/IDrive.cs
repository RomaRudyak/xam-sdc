using System;
using System.Threading.Tasks;
using System.Net.Http;
using Refit;

namespace SDC.Coach.Google.Drive
{
    public interface IDrive
    {
        [Get("/files")]
        Task<FilesResponse> GetFiles();
    }
}
