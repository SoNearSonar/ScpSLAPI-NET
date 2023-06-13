using System.Text.Json;
using ScpSLAPI_NET.Exceptions;
using ScpSLAPI_NET.Models;
using System.Net;

namespace ScpSLAPI_NET
{
    public class ScpSLManager
    {
        private readonly string _url = "https://api.scpslgame.com";
        private string _apiKey = string.Empty;

        public ScpSLManager(string apiKey)
        {
            _apiKey = apiKey;
        }

        public ScpSLManager() { }

        public async Task<string> GetIpAddressAsync()
        {
            return await MakeApiIpCall<string>(_url).ConfigureAwait(false);
        }

        public async Task<ServerInfo> GetServerInfoAsync(ServerSearchSettings settings)
        {
            if (string.IsNullOrWhiteSpace(_apiKey))
            {
                throw new SLRequestException("This method call requires an API key to use");
            }

            return await MakeApiCall<ServerInfo>($"{_url}/serverinfo.php", settings).ConfigureAwait(false);
        }

        public async Task<List<FullServer>> GetFullServerListAsync(FullServerSearchSettings settings)
        {
            if (string.IsNullOrWhiteSpace(_apiKey))
            {
                throw new SLRequestException("This method call requires an API key to use");
            }

            return await MakeApiCall<List<FullServer>>($"{_url}/lobbylist.php", settings).ConfigureAwait(false);
        }

        public async Task<ServerInfo> GetAlternativeServerInfoAsync(string alternativeUrl, ServerSearchSettings settings)
        {
            bool result = Uri.TryCreate(alternativeUrl, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!result)
            {
                throw new SLRequestException("Invalid URL provided");
            }
            else if (string.IsNullOrWhiteSpace(_apiKey))
            {
                throw new SLRequestException("This method call requires an API key to use");
            }

            return await MakeApiCall<ServerInfo>(alternativeUrl, settings).ConfigureAwait(false);
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
            string query = QueryUtility.FormatQueryParams(settings);
            if (!string.IsNullOrWhiteSpace(_apiKey))
            {
                query += QueryUtility.AddQueryParam("key", _apiKey);
            }
            string queryString = $"{apiUrl}?{query}";

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
                return JsonSerializer.Deserialize<T>(contents);
            }
            catch (JsonException ex)
            {
                throw new SLRequestJsonException($"There was an error formatting the response to the correct JSON object: {ex.Message}");
            }

        }

        private async Task<HttpResponseMessage> CreateApiCall(string apiUrl)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ScpSLAPI-NET/2.0");
            return await client.GetAsync(apiUrl);
        }
    }
}