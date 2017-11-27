using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;
using Utilities;

namespace FantasyFootball.Data.Yahoo
{
    public class YahooApi
    {
        const string CLIENT_ID = "dj0yJmk9Y3BNYTZOOVVxTENxJmQ9WVdrOVpuQkJOVUZoTjJrbWNHbzlNQS0tJnM9Y29uc3VtZXJzZWNyZXQmeD04MQ--";
        const string CLIENT_SECRET = "377092d1b9c985e3f49bcd7b6c6c6f50b7cacecf";

        static readonly string fantasyUri = @"https://fantasysports.yahooapis.com/fantasy/v2";
        static HttpClient client = new HttpClient();

        private YahooToken OAuthToken;

        #region Private Methods

        private void CheckAuthorization()
        {
            try
            {
                LoadLocalToken();
            }
            catch
            {
                Authorize();
                LoadLocalToken();
            }
        }

        private void Authorize()
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
                Query = UriJ.DictionaryToQueryString(queryArguments)
            };

            System.Diagnostics.Process.Start(uriBuilder.ToString());

            Console.Write("Please paste access code from Yahoo: ");
            GetToken(Console.ReadLine());
        }

        private void GetToken(string authCode)
        {
            Dictionary<string, string> formValues = new Dictionary<string, string>
            {
                { "client_id", CLIENT_ID },
                { "client_secret", CLIENT_SECRET },
                { "redirect_uri", "oob" },
                { "code", authCode },
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

            var response = client.PostAsync(uriBuilder.ToString(), formContent);
            Task.WaitAll(response);

            var responseString = response.Result.Content.ReadAsStringAsync();
            Task.WaitAll(responseString);

            File.WriteAllText(Path.Combine(Files.ProjectDirectory, @"Data\Yahoo\token.json"), responseString.Result);
        }

        private void LoadLocalToken()
        {
            OAuthToken = new YahooToken();
            using (var reader = new StreamReader(Path.Combine(Files.ProjectDirectory, @"Data\Yahoo\token.json")))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(OAuthToken.GetType());
                OAuthToken = ser.ReadObject(reader.BaseStream) as YahooToken;
            }
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(OAuthToken.TokenType, OAuthToken.AccessToken);
        }

        #endregion

        public ApiResult<League> GetLeague(string leagueId)
        {
            CheckAuthorization();

            UriBuilder uriBuilder = new UriBuilder(fantasyUri + @"\league\" + leagueId);

            var response = client.GetAsync(uriBuilder.ToString());
            Task.WaitAll(response);

            var responseStream = response.Result.Content.ReadAsStreamAsync();
            Task.WaitAll(responseStream);

            XDocument doc = XDocument.Load(responseStream.Result);
            ApiResult<League> result = new ApiResult<League>();

            XmlSerializer s = new XmlSerializer(typeof(League));
            League league = (League)s.Deserialize(doc.Root.Element("league").CreateReader());
            result.FantasyResult.Add(league);

            return result;
        }

        public ApiResult<Team> GetTeam(string teamId)
        {
            CheckAuthorization();

            UriBuilder uriBuilder = new UriBuilder(fantasyUri + @"\team\" + teamId);

            var response = client.GetAsync(uriBuilder.ToString());
            Task.WaitAll(response);

            var responseStream = response.Result.Content.ReadAsStreamAsync();
            Task.WaitAll(responseStream);

            XDocument doc = XDocument.Load(responseStream.Result);
            ApiResult<Team> result = new ApiResult<Team>();

            XmlSerializer s = new XmlSerializer(typeof(Team));
            Team team = (Team)s.Deserialize(doc.Root.Element("team").CreateReader());
            result.FantasyResult.Add(team);

            return result;
        }
    }
}
