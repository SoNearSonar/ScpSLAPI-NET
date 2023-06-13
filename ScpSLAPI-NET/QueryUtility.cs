using ScpSLAPI_NET.Models;

namespace ScpSLAPI_NET
{
    internal static class QueryUtility
    {
        internal static string FormatQueryParams(ServerSearchSettings settings)
        {
            string query = "";
            query += AddQueryParam("id", settings.ID);
            query += AddQueryParam("lo", settings.AddLastOnline);
            query += AddQueryParam("players", settings.AddPlayers);
            query += AddQueryParam("list", settings.AddPlayersList);
            query += AddQueryParam("info", settings.AddInfo);
            query += AddQueryParam("pastebin", settings.AddPastebin);
            query += AddQueryParam("version", settings.AddVersion);
            query += AddQueryParam("flags", settings.AddFlags);
            query += AddQueryParam("nicknames", settings.AddNicknames);
            query += AddQueryParam("online", settings.AddIsOnline);

            if (string.IsNullOrWhiteSpace(query))
            {
                return query;
            }
            else
            {
                return query.Substring(0, query.Length - 1);
            }
        }

        internal static string FormatQueryParams(FullServerSearchSettings settings)
        {
            string query = AddQueryParam("format", "json");
            if (settings != null)
            {
                query += AddMinimalQueryParam("minimal", settings.IsMinimalSearch);
            }
                
            return query.Substring(0, query.Length - 1);
        }

        internal static string AddQueryParam(string key, object value)
        {
            if (value != null)
            {
                return $"{key}={value}&";
            }
            else
            {
                return string.Empty;
            }
        }

        internal static string AddMinimalQueryParam(string key, bool? value)
        {
            if (value.HasValue && value.Value)
            {
                return $"{key}&";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
