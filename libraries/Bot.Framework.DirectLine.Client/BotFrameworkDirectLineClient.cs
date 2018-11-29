using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Framework.DirectLine.Client
{
    public class BotFrameworkDirectLineClient
    {
        private readonly string clientSecret;

        public BotFrameworkDirectLineClient(string clientSecret)
        {
            this.clientSecret = clientSecret ?? throw new ArgumentNullException("Client secret for Bot Framework Directline client is required.");
        }

        public async Task<TResponse> GenerateDirectLineTokenForUserAsync<TResponse>(string endpointUrl, string userId) where TResponse : class
        {
            if (endpointUrl == null)
            {
                throw new ArgumentNullException("Endpoint url for Bot Framework Directline server is required.");
            }

            TResponse response = null;

            using (HttpClient httpClient = new HttpClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, endpointUrl);
                httpRequestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", clientSecret);

                httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject
                    (new { User = new { Id = userId } }),
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var body = await httpResponseMessage.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<TResponse>(body);
                }

                return response;
            }
        }
    }
}
