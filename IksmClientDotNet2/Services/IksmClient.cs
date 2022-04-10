using IksmClientDotNet.Core.RawJson;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace IksmClientDotNet.Core.Services
{
    public enum GameRule
    {
        SplatZones,
        TowerControl,
        Rainmaker,
        ClamBlitz,
    }

    public class IksmClient
    {
        private readonly JsonSerializerSettings jsonSerializerSettings;
        private readonly string iksmSession;

        public IksmClient(string iksmSession)
        {
            this.iksmSession = iksmSession;

            jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new SnakeCaseContractResolver()
            };
        }

        public async Task<string> Request(string requestUrl)
        {
            using var handler = new HttpClientHandler()
            {
                UseCookies = false,
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            using var client = new HttpClient(handler);
            using var request = new HttpRequestMessage(HttpMethod.Get, $"https://app.splatoon2.nintendo.net/{requestUrl}");
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Linux; Android 5.1.1; SM-N950F Build/NMF26X) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/39.0.0.0 Mobile Safari/537.36");

            request.Headers.Host = "app.splatoon2.nintendo.net";
            request.Headers.Add("x-unique-id", "32449507786579989234");
            request.Headers.Add("x-requested-with", "XMLHttpRequest");
            request.Headers.Add("x-timezone-offset", "-540");
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("*/*"));
            request.Headers.Referrer = new Uri("https://app.splatoon2.nintendo.net/home");
            request.Headers.AcceptEncoding.Add(StringWithQualityHeaderValue.Parse("gzip"));
            request.Headers.AcceptEncoding.Add(StringWithQualityHeaderValue.Parse("deflate"));
            request.Headers.AcceptLanguage.Add(StringWithQualityHeaderValue.Parse("ja-JP"));

            request.Headers.Add("Cookie", $"iksm_session={iksmSession};");

            var response = await client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetHome()
        {
            return await Request("home");
        }

        public async Task<ResultRoot> GetBattleResults()
        {
            var result = await Request("api/results");
            return JsonConvert.DeserializeObject<ResultRoot>(result, jsonSerializerSettings);
        }

        public async Task<string> GetBattleResultDetail(int battleId)
        {
            return await Request($"api/results/{battleId}");
        }

        public Task<string> GetRankingRaw(int year, int month, GameRule gameRule, int page)
        {
            var rankingUrlBuilder = new RankingUrlBuilder(year, month, gameRule, page);
            return GetRankingRaw(rankingUrlBuilder);
        }

        public async Task<string> GetRankingRaw(RankingUrlBuilder rankingUrlBuilder)
        {
            var json = await Request(rankingUrlBuilder.Url);

            return json;
        }
    }
}