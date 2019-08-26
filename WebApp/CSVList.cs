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

    public static async Task<List<string>> LoadList()
    {
        string url = "https://api.github.com/repos/mono/mono/contents/mcs/tools/linker";
        var list = await GetList(url);
    }

    public static async Task<List<string>> GetList(string url)
    {
        try {
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("User-Agent", "curl/7.54.0");

            var data = await client.GetStringAsync( new Uri(url));
            string[] obj;



        }
    }
}