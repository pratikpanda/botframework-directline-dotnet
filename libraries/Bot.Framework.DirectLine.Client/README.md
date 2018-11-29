# Bot.Framework.DirectLine.Client
Client for retrieving access tokens from the Bot Framework DirectLine Server.

## Usage
The component uses a HTTP client for connecting and retrieving access token from Bot Framework DirectLine Server. To use this component, you will need to have a DirectLine secret, which can be easily obtained from the Bot Connector Service.
You can use the default DirectLineTokenResponse model as the token response or provide your own implementation of the model.
Following is an example on how to use this client:

```csharp
var directLineClient = new BotFrameworkDirectLineClient("SECRET");
var directLineTokenResponse = await directLineClient.GenerateDirectLineTokenForUserAsync<DirectLineTokenResponse>("TOKEN-ENDPOINT-URL", "USER-ID");
```
