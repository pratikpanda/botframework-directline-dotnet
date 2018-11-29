using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.Framework.DirectLine.Client.Models
{
    public class DirectLineTokenResponse
    {
        [JsonProperty("conversationId")]
        public string ConversationId { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
