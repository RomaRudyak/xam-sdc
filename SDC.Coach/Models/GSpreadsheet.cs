using System;
using Newtonsoft.Json;
namespace SDC.Coach.Models
{
    public class GSpreadsheet
    {
        [JsonProperty("spreadsheetId")]
        public String Id { get; set; }
        [JsonProperty("properties")]
        public GProperty Properties { get; set; }
        public GSheet[] Sheets { get; set; }
    }
}
