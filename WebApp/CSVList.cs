using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

class CSVList {
    static HttpClient client = new HttpClient();

    public static async Task<(string name, string path) []> GetList()
    {
        string url = "https://api.github.com/repos/mono/mono/contents/mcs/tools/linker";
        try {
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("User-Agent", "curl/7.54.0");

            var data = await client.GetStringAsync( new Uri(url));
            var obj = new [] {
                new {
                    name = "",
                    path = ""
                }    
            };

            return JsonConvert.DeserializeAnonymousType (data, obj).Where(o => o.name.Substring(o.name.Length-3) == "csv").Select( o=> ValueTuple.Create(o.name, o.path)).ToArray();
        } catch (Exception e) {
            return Array.Empty<(string name, string path)>();
        }
    }
}