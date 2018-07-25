using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using SDC.Coach.Models;

namespace SDC.Coach.Google.Drive
{
    public class FilesResponse
    {
        [JsonProperty("incompleteSearch")]
        public Boolean IsIncompleteSearch { get; set; }
        [JsonProperty("nextPageToken")]
        public String NextPageToken { get; set; }
        [JsonProperty("files")]
        public GFile[] Files { get; set; }
    }
}
