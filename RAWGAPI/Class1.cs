using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RAWGAPI
{
    public class Class1
    {
        private const string aPIKey = "?key=1d28751350144a4e835b8e6a355f9113";
        private const string uRL = "https://api.rawg.io/api/";
        private WebClient client = new WebClient();

        public string APICall()
        {
            //string response = client.DownloadString($"{uRL}games{aPIKey}");
            //System.IO.File.WriteAllText("games.txt", response);
            return System.IO.File.ReadAllText("games.txt");
        }

        public APIResponse GetAPIResponse()
        {
            return JsonConvert.DeserializeObject<APIResponse>(APICall());
        }
    }

    public class APIResponse
    {
        public long Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        [JsonProperty("Results")]
        public List<APIGameResult> APIGameResults { get; set; }
    }

    [DebuggerDisplay("{Name}")]
    public class APIGameResult
    {
        public long ID { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
    }
}
