using Newtonsoft.Json;
using ScpSLAPI_NET.Exceptions;
using ScpSLAPI_NET.Models;
using System.Net;

namespace ScpSLAPI_NET
{
    public class ScpSLManager
    {
        private readonly string _url = "https://api.scpslgame.com";

        public async Task<string> GetIpAddressAsync()
        {
            return await MakeApiIpCall<string>(_url).ConfigureAwait(false);
        }

        public async Task<ServerInfo> GetServerInfoAsync(ServerSearchSettings settings)
        {
            return await MakeApiCall<ServerInfo>($"{_url}/serverinfo.php", settings).ConfigureAwait(false);
        }

        public async Task<List<FullServer>> GetFullServerListAsync(FullServerSearchSettings settings)
        {
            return await MakeApiCall<List<FullServer>>($"{_url}/lobbylist.php", settings).ConfigureAwait(false);
        }

        public async Task<List<FullServer>> GetAlternativeFullServerListAsync(string alternativeUrl)
        {
            bool result = Uri.TryCreate(alternativeUrl, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!result)
            {
                throw new SLRequestException("Invalid URL provided");
            }
            return await MakeApiCall<List<FullServer>>(alternativeUrl);
        }

        private async Task<T> MakeApiCall<T>(string apiUrl, ServerSearchSettings settings)
        {
            string queryString = QueryUtility.FormatQueryParams(settings);
            HttpResponseMessage message = await CreateApiCall($"{apiUrl}?{queryString}");
            if (message.StatusCode == HttpStatusCode.OK)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<T>(response);
            }

            throw new SLRequestException($"{message.StatusCode} code - Request was not successful");
        }

        private async Task<T> MakeApiCall<T>(string apiUrl, FullServerSearchSettings settings = null)
        {
            string queryString = $"{apiUrl}?{QueryUtility.FormatQueryParams(settings)}";

            HttpResponseMessage message = await CreateApiCall(queryString);
            if (message.StatusCode == HttpStatusCode.OK)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<T>(response);
            }

            throw new SLRequestException($"{message.StatusCode} code - Request was not successful");
        }

        private async Task<string> MakeApiIpCall<T>(string apiUrl)
        {
            HttpResponseMessage message = await CreateApiCall(apiUrl + "/ip.php");
            if (message.StatusCode == HttpStatusCode.OK)
            {
                return await message.Content.ReadAsStringAsync();
            }

            throw new SLRequestException($"{message.StatusCode} code - Request was not successful");

        }

        private T DeserializeObject<T>(string contents)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(contents);
            }
            catch (JsonSerializationException ex)
            {
                throw new SLRequestJsonException("The information to parse is not in the right JSON format");
            }

        }

        private async Task<HttpResponseMessage> CreateApiCall(string apiUrl)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ScpSLGame-NET/1.0");
            return await client.GetAsync(apiUrl);
        }
    }
}