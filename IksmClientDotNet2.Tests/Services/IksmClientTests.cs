using IksmClientDotNet.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IksmClientDotNet.Core.Services.Tests
{
    public class SecretSettings
    {
        public string IksmSession { get; set; } = "";
    }

    [TestClass()]
    public class IksmClientTests
    {
        private readonly string iksmSession;
        public IksmClientTests()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<IksmClientTests>()
                .Build();

            var secretSettings = config.Get<SecretSettings>();

            iksmSession = secretSettings.IksmSession;
        }

        [TestMethod()]
        public async Task GetBattleResultsTest()
        {
            var iksmClient = new IksmClient(iksmSession);

            var battleResults = await iksmClient.GetBattleResults();

            Assert.IsNotNull(battleResults);
            Assert.IsNotNull(battleResults.Results);
            Assert.IsTrue(battleResults.Results.Length <= 50);
        }
    }
}