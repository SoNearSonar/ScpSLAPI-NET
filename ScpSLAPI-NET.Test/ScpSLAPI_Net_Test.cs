using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScpSLAPI_NET.Models;

namespace ScpSLAPI_NET.Test
{
    [TestClass]
    public class ScpSLAPI_Net_Test
    {
        [TestMethod]
        public void TestGetIP_ReturnsIPAsString()
        {
            ScpSLManager gameManager = new ScpSLManager();
            string IPAddress = gameManager.GetIpAddressAsync().Result;
            Assert.IsNotNull(IPAddress);
        }

        [TestMethod]
        public void TestGetServerInfo_NoApiKeyProvided_ReturnsError()
        {
            ScpSLManager gameManager = new ScpSLManager();
            ServerSearchSettings settings = new ServerSearchSettings()
            {
                ID = 1,
                AddIsOnline = true,
                AddPastebin = true,
                AddVersion = true
            };

            try
            {
                ServerInfo servers = gameManager.GetServerInfoAsync(settings).Result;
                Assert.IsNotNull(servers);
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is HttpRequestException);
            }
        }

        [TestMethod]
        public void TestGetFullServerList_NoApiKeyProvided_ReturnsError()
        {
            ScpSLManager gameManager = new ScpSLManager();
            FullServerSearchSettings settings = new FullServerSearchSettings()
            {
                IsMinimalSearch = true,
            };

            try
            {
                List<FullServer> servers = gameManager.GetFullServerListAsync(settings).Result;
                Assert.IsNotNull(servers);
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is HttpRequestException);
            }
        }

        [TestMethod]
        public void TestGetAlternativeFullServersList_ReturnsServerListAsJson()
        {
            ScpSLManager gameManager = new ScpSLManager();
            List<FullServer> servers = gameManager.GetAlternativeFullServerListAsync("https://api.scpsecretlab.pl/lobbylist").Result.SortFullServerList();
            Assert.IsNotNull(servers);
        }

        // This test requires an API key to run (ApiKey = "value") - Ignore this
        [Ignore]
        [TestMethod]
        public void TestGetServerInfo_ReturnsServerInfoAsJson()
        {
            ScpSLManager gameManager = new ScpSLManager();
            ServerSearchSettings settings = new ServerSearchSettings()
            {
                ID = 1,
                ApiKey = string.Empty,
                AddIsOnline = true,
                AddPastebin = true,
                AddVersion = true
            };
            ServerInfo servers = gameManager.GetServerInfoAsync(settings).Result;
            Assert.IsNotNull(servers);
        }

        // This test requires an API key to run (ApiKey = "value") - Ignore this
        [Ignore]
        [TestMethod]
        public void TestGetFullServerList_ReturnsServerListAsJson()
        {
            ScpSLManager gameManager = new ScpSLManager();
            FullServerSearchSettings settings = new FullServerSearchSettings()
            {
                IsMinimalSearch = true,
                ApiKey = string.Empty
            };
            List<FullServer> servers = gameManager.GetFullServerListAsync(settings).Result;
            Assert.IsNotNull(servers);
        }
    }
}