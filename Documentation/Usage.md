# Using ScpSLAPI-NET
ScpSLAPI-NET is a C# API wrapper for api.scpslgame.com and other 3rd party lobby lists. 

It supports:
- Getting IP address
- Getting server info
- Getting lobby lists (works for 3rd party API's)

## Note
- Exceptions are in the form of AggregateException with the InnerException property being HttpRequestException
- List<FullServer> has an extension method to sort the results by a variety of keys (according to how Northwood sorts their lists) called SortFullServerList()

## Examples
Below are examples of C# API calls for getting resources from these API's

### Getting IP address
```csharp
ScpSLManager gameManager = new ScpSLManager();
string IPAddress = await gameManager.GetIpAddressAsync();
Console.WriteLine("IP Address: " + IPAddress);
```

### Getting server info
```csharp
ScpSLManager gameManager = new ScpSLManager();
ServerSearchSettings settings = new ServerSearchSettings()
{
	ID = 123456,
	ApiKey = "test_api_key"
	AddIsOnline = true,
	AddPastebin = true,
	AddVersion = true
};

ServerInfo serverList = await gameManager.GetServerInfoAsync(settings);

foreach (Server server in serverList.Servers)
{
	Console.WriteLine("Server ID: " + server.ID);
	Console.WriteLine("Server port: " + server.Port);
	Console.WriteLine("Server is online? " + server.Online);
	Console.WriteLine("Server was last online: " + server.LastOnline);
	Console.WriteLine("Server version: " + server.Version);
	Console.WriteLine("Server pastebin ID: " + server.Pastebin);
}
```

### Getting lobby list from api.scpslgame.com
```csharp
ScpSLManager gameManager = new ScpSLManager();
FullServerSearchSettings settings = new FullServerSearchSettings()
{
	IsMinimalSearch = true,
	ApiKey = "test_api_key"
};

List<FullServer> servers = await gameManager.GetFullServerListAsync(settings);

foreach (FullServer server in servers)
{
	Console.WriteLine("Server IP: " + server.IP);
	Console.WriteLine("Server port: " + server.Port);
	Console.WriteLine("Server distance: " + server.Distance);
	Console.WriteLine("Server info: " + server.Info);
	Console.WriteLine("Server version: " + server.Version);
	Console.WriteLine("Server pastebin ID: " + server.Pastebin);
	Console.WriteLine("Server is modded: " + server.IsModded);
	Console.WriteLine("# of players on server: " + server.Players);
}
```

### Getting lobby list from 3rd party API
```csharp
ScpSLManager gameManager = new ScpSLManager();
List<FullServer> servers = await gameManager.GetAlternativeFullServerListAsync("https://api.scpsecretlab.pl/lobbylist");

foreach (FullServer server in servers)
{
	Console.WriteLine("Server IP: " + server.IP);
	Console.WriteLine("Server port: " + server.Port);
	Console.WriteLine("Server distance: " + server.Distance);
	Console.WriteLine("Server info: " + server.Info);
	Console.WriteLine("Server version: " + server.Version);
	Console.WriteLine("Server pastebin ID: " + server.Pastebin);
	Console.WriteLine("Server is modded: " + server.IsModded);
	Console.WriteLine("# of players on server: " + server.Players);
}
```