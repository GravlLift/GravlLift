using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Utilities
{
    public static class UriJ
    {
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
