using Bot.Framework.DirectLine.Client.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Bot.Framework.DirectLine.Client.Integration.Tests
{
    [TestClass]
    [TestCategory("Integration")]
    [TestCategory("DirectLine Client")]
    public class DirectLineClientTests : DirectLineBaseTests
    {
        [TestInitialize]
        public void Initialize()
        {
            // Get identity server and client configurations from external file.
            var config = new ConfigurationBuilder()
                .AddJsonFile("directlinesettings.json")
                .Build();

            // Initialize identity server settings.
            directLineServerSettings = new DirectLineServerSettings
            {
                HostUrl = config["DirectLineServerSettings:HostUrl"],
                TokenEndpoint = config["DirectLineServerSettings:TokenEndpoint"],
            };

            // Initialize identity client settings.
            directLineClientSettings = new DirectLineClientSettings
            {
                ClientSecret = config["DirectLineClientSettings:ClientSecret"]
            };

            // Initialize user Id
            userId = Guid.NewGuid().ToString();
        }

        [TestMethod]
        public void ConstructorTest_ValidOptions()
        {
            var directLineClient = new BotFrameworkDirectLineClient(directLineClientSettings.ClientSecret);
        }

        [TestMethod]
        public void Constructor_Should_Throw_Exception_On_InvalidOptions()
        {
            // No Options. Should throw. 
            Assert.ThrowsException<ArgumentNullException>(() => new BotFrameworkDirectLineClient(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GenerateDirectLineTokenForUserAsync_Should_Throw_Exception_On_InvalidOptions()
        {
            // No endpoint url. Should throw. 
            var directLineClient = new BotFrameworkDirectLineClient(directLineClientSettings.ClientSecret);
            var tokenResponse = await directLineClient.GenerateDirectLineTokenForUserAsync<DirectLineTokenResponse>(null, userId);
        }

        [TestMethod]
        public async Task GenerateDirectLineTokenForUserAsync_ValidOptions()
        {
            // Valid endpoint url and user id. Should return a valid token response.

            // Arrange
            var directLineClient = new BotFrameworkDirectLineClient(directLineClientSettings.ClientSecret);
            var tokenEndpointUrl = string.Concat(directLineServerSettings.HostUrl, directLineServerSettings.TokenEndpoint);

            // Act
            var tokenResponse = await directLineClient.GenerateDirectLineTokenForUserAsync<DirectLineTokenResponse>(tokenEndpointUrl, userId);

            // Assert
            Assert.IsNotNull(tokenResponse);
        }
    }
}
