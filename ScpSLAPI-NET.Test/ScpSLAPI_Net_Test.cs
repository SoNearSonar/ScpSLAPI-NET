using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScpSLAPI_NET.Exceptions;
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
        public void TestGetServerInfo_NoApiKeyProvided_ThrowsException()
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
                Assert.IsTrue(ex.InnerException is SLRequestException);
                Assert.IsTrue(ex.InnerException.Message.Equals("BadRequest code - Request was not successful"));
            }
        }

        [TestMethod]
        public void TestGetAlternativeServerInfo_InvalidURLString_ThrowsException()
        {
            ScpSLManager gameManager = new ScpSLManager();

            try
            {
                ServerInfo servers = gameManager.GetAlternativeServerInfoAsync("invalid_url", mockSearchSettings()).Result;
                Assert.IsNotNull(servers);
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is SLRequestException);
                Assert.IsTrue(ex.InnerException.Message.Equals("Invalid URL provided"));
            }
        }

        [TestMethod]
        public void TestGetAlternativeServerInfo_InvalidURL_ThrowsException()
        {
            ScpSLManager gameManager = new ScpSLManager();

            try
            {
                ServerInfo servers = gameManager.GetAlternativeServerInfoAsync("https://jsonplaceholder.typicode.com/todos/1", mockSearchSettings()).Result;
                Assert.IsNotNull(servers);
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is SLRequestJsonException);
                Assert.IsTrue(!string.IsNullOrWhiteSpace(ex.InnerException.Message));
            }
        }

        [TestMethod]
        public void TestGetFullServerList_NoApiKeyProvided_ThrowsException()
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
                Assert.IsTrue(ex.InnerException is SLRequestException);
                Assert.IsTrue(ex.InnerException.Message.Equals("Forbidden code - Request was not successful"));
            }
        }

        [TestMethod]
        public void TestGetAlternativeFullServersList_ReturnsServerListAsJson()
        {
            ScpSLManager gameManager = new ScpSLManager();
            List<FullServer> servers = gameManager.GetAlternativeFullServerListAsync("https://api.scpsecretlab.pl/lobbylist").Result.SortFullServerList();
            Assert.IsNotNull(servers);
        }

        [TestMethod]
        public void TestGetAlternativeFullServersList_InvalidURLString_ThrowsException()
        {
            ScpSLManager gameManager = new ScpSLManager();

            try
            {
                List<FullServer> servers = gameManager.GetAlternativeFullServerListAsync("invalid_url").Result;
                Assert.IsNotNull(servers);
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is SLRequestException);
                Assert.IsTrue(ex.InnerException.Message.Equals("Invalid URL provided"));
            }
        }

        [TestMethod]
        public void TestGetAlternativeFullServersList_InvalidURL_ThrowsException()
        {
            ScpSLManager gameManager = new ScpSLManager();

            try
            {
                List<FullServer> servers = gameManager.GetAlternativeFullServerListAsync("https://jsonplaceholder.typicode.com/todos/1").Result;
                Assert.IsNotNull(servers);
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is SLRequestJsonException);
                Assert.IsTrue(!string.IsNullOrWhiteSpace(ex.InnerException.Message));
            }
        }

        // This test requires an API key to run (ApiKey = "value") - Ignore this
        [Ignore]
        [TestMethod]
        public void TestGetServerInfo_ReturnsServerInfoAsJson()
        {
            ScpSLManager gameManager = new ScpSLManager();
            ServerInfo servers = gameManager.GetServerInfoAsync(mockSearchSettings()).Result;
            Assert.IsNotNull(servers);
        }

        // This test requires an API key to run (ApiKey = "value") - Ignore this
        [Ignore]
        [TestMethod]
        public void TestGetFullServerList_ReturnsServerListAsJson()
        {
            ScpSLManager gameManager = new ScpSLManager();
            List<FullServer> servers = gameManager.GetFullServerListAsync(mockFullSearchSettings()).Result;
            Assert.IsNotNull(servers);
        }

        // This test requires an API key to run (ApiKey = "value") - Ignore this
        [Ignore]
        [TestMethod]
        public void TestGetAlternativeServerInfo_ReturnsServerInfoAsJson()
        {
            ScpSLManager gameManager = new ScpSLManager();
            ServerInfo servers = gameManager.GetAlternativeServerInfoAsync("https://api.scpsecretlab.pl/serverinfo", mockSearchSettings()).Result;
            Assert.IsNotNull(servers);
        }

        ServerSearchSettings mockSearchSettings()
        {
            return new ServerSearchSettings()
            {
                ID = 1,
                ApiKey = string.Empty,
                AddIsOnline = true,
                AddPastebin = true,
                AddVersion = true
            };
        }

        FullServerSearchSettings mockFullSearchSettings()
        {
            return new FullServerSearchSettings()
            {
                IsMinimalSearch = true,
                ApiKey = string.Empty
            };
        }
    }
}