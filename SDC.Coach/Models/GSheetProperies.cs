using System;
using Newtonsoft.Json;
namespace SDC.Coach.Models
{
    public class GSheetProperies : GProperty
    {
        [JsonProperty("sheetId")]
        public Int32 Id { get; set; }
        public Int32 Index { get; set; }
    }
}