using IksmClientDotNet.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IksmClientDotNet.Core.Services.Tests
{
    [TestClass()]
    public class IksmClientTests
    {
        [TestMethod()]
        public async Task GetBattleResultsTest()
        {
            var iksmClient = new IksmClient("hoge");

            var battleResults = await iksmClient.GetBattleResults();

            Assert.IsNotNull(battleResults);
            Assert.IsNotNull(battleResults.Results);
            Assert.IsTrue(battleResults.Results.Length <= 50);
        }
    }
}