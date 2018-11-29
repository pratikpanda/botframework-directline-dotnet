using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.Framework.DirectLine.Client.Integration.Tests
{
    public class DirectLineServerSettings
    {
        public string HostUrl { get; set; }
        public string TokenEndpoint { get; set; }
    }

    public class DirectLineClientSettings
    {
        public string ClientSecret { get; set; }
    }

    public class DirectLineBaseTests
    {
        protected DirectLineServerSettings directLineServerSettings;
        protected DirectLineClientSettings directLineClientSettings;
        protected string userId;
    }
}
