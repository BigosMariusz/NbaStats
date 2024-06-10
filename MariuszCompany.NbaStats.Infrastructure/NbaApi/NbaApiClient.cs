using MariuszCompany.NbaStats.Application.Dto.NbaIntegration;
using MariuszCompany.NbaStats.Application.Interfaces;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;

namespace MariuszCompany.NbaStats.Infrastructure.NbaApi
{
    public class NbaApiClient : INbaApiClient
    {
        private const int _maxPerPage = 100;

        private readonly IConfiguration _configuration;

        public NbaApiClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<NbaTeam>> GetAllTeams()
        {
            return await MakeStandardListRequest<NbaTeam>("teams");
        }

        public async Task<List<NbaPlayer>> GetPlayers()
        {
            var result = new List<NbaPlayer>();
            var paginator = new NbaApiPaginator(13);

            do
            {
                var queryParams = new Dictionary<string, string>
                    {
                        { "cursor", paginator.NextCursor.ToString() },
                        { "per_page", _maxPerPage.ToString() }
                    };

                var response = await MakeRequest<NbaApiPaginatedListResponse<NbaPlayer>>("players", queryParams);
                result.AddRange(response.Data);

                paginator.SaveRequest(response.Meta.Next_cursor);
            }
            while (!paginator.AllPagesDownloaded);

            return result;
        }

        public async Task<List<NbaGame>> GetGames()
        {
            var result = new List<NbaGame>();
            var paginator = new NbaApiPaginator(13);

            do
            {
                var queryParams = new Dictionary<string, string>
                    {
                        { "cursor", paginator.NextCursor.ToString() },
                        { "per_page", _maxPerPage.ToString() },
                        { "start_date", _configuration["NbaApiClient:FirstGameOfSeasonDate"] }
                    };

                var response = await MakeRequest<NbaApiPaginatedListResponse<NbaGame>>("games", queryParams);
                result.AddRange(response.Data);

                paginator.SaveRequest(response.Meta.Next_cursor);
            }
            while (!paginator.AllPagesDownloaded);

            return result;
        }

        private async Task<List<T>> MakeStandardListRequest<T>(string path, Dictionary<string, string>? queryParams = null)
        {
            var result = await MakeRequest<NbaApiListResponse<T>>(path, queryParams);

            return result.Data;
        }

        private async Task<T> MakeRequest<T>(string path, Dictionary<string, string>? queryParams = null)
        {
            var basePath = _configuration["NbaApiClient:BasePath"]; 
            var apiKeyHeaderName = _configuration["NbaApiClient:ApiKeyHeaderName"];
            var apiKeyValue = _configuration["NbaApiClient:ApiKeyValue"];

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(basePath);
            httpClient.DefaultRequestHeaders.Add(apiKeyHeaderName, apiKeyValue);

            var pathToSend = queryParams != null ? QueryHelpers.AddQueryString(path + "/", queryParams) : path;

            var result = await httpClient.GetAsync(pathToSend);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var stringValue = await result.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<T>(stringValue);
                if (deserialized != null)
                {
                    return deserialized;
                }
            }

            throw new Exception($"HttpErrorCode: {result.StatusCode}, Resp content: {result.Content.ReadAsStringAsync()}");
        }

    }
}
