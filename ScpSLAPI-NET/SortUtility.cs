using ScpSLAPI_NET.Models;

namespace ScpSLAPI_NET
{
    public static class SortUtility
    {
        public static List<FullServer> SortFullServerList(this List<FullServer> list)
        {
            return list.OrderByDescending(ls => ls.OfficialCode)
                .ThenBy(ls => ls.Distance)
                .ThenBy(ls => ls.AccountId)
                .ThenBy(ls => ls.Port)
                .ToList();
        }
    }
}
