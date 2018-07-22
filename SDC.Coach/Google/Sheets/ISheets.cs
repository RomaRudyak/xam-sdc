using System;
using System.Threading.Tasks;
using Refit;
using SDC.Coach.Models;

namespace SDC.Coach.Google.Sheets
{
    public interface ISheets
    {
        [Get("/spreadsheets/{spreadsheetId}")]
        Task<GSpreadsheet> GetSheet(String spreadsheetId);
    }
}
