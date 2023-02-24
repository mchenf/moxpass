using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moxpass.Help
{
    public class HelpHandler
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string urlBase = @"https://github.com/mchenf/moxpass/wiki/";

        public static async Task PrintHelp (string uri)
        {
            string fullUrl = uri;
            Console.WriteLine("Trying to get web content here:");
            Console.WriteLine(uri);
            using (HttpResponseMessage res = await client.GetAsync(uri))
            {
                res.EnsureSuccessStatusCode();
                string responseBody = await client.GetStringAsync(uri);
                Console.WriteLine(responseBody);
            }
        }

    }
}
