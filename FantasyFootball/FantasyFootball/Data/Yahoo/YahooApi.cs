using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFootball.Data.Yahoo
{
    public class YahooApi
    {
        private static readonly HttpClient client = new HttpClient();

        const string CLIENT_ID = "dj0yJmk9Y3BNYTZOOVVxTENxJmQ9WVdrOVpuQkJOVUZoTjJrbWNHbzlNQS0tJnM9Y29uc3VtZXJzZWNyZXQmeD04MQ--";
        const string CLIENT_SECRET = "377092d1b9c985e3f49bcd7b6c6c6f50b7cacecf";

        public static void Authorize()
        {
            Dictionary<string, string> queryArguments = new Dictionary<string, string>
            {
                { "client_id", CLIENT_ID },
                { "redirect_uri", "oob" },
                { "response_type", "code" },
                { "language", "en-us" }
            };

            UriBuilder uriBuilder = new UriBuilder
            {
                Scheme = Uri.UriSchemeHttps,
                Host = "api.login.yahoo.com",
                Path = "oauth2/request_auth",
                Query = DictionaryToQueryString(queryArguments)
            };

            string html = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriBuilder.ToString());
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

        }

        public static async Task GetTokenAsync()
        {
            Dictionary<string, string> formValues = new Dictionary<string, string>
            {
                { "client_id", CLIENT_ID },
                { "client_secret", CLIENT_SECRET },
                { "redirect_uri", "oob" },
                { "code", "n6x24r9" },
                { "grant_type", "authorization_code" }
            };

            UriBuilder uriBuilder = new UriBuilder
            {
                Scheme = Uri.UriSchemeHttps,
                Host = "api.login.yahoo.com",
                Path = "oauth2/get_token"
            };

            string html = string.Empty;
            var formContent = new FormUrlEncodedContent(formValues);

            var response = await client.PostAsync(uriBuilder.ToString(), formContent);
            var responseString = await response.Content.ReadAsStringAsync();
        }

        public static string DictionaryToQueryString(Dictionary<string, string> dictionary)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var entry in dictionary)
            {
                sb.Append($"{WebUtility.UrlEncode(entry.Key)}={WebUtility.UrlEncode(entry.Value)}&");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
    }
}
