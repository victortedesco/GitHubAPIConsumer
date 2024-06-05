using GitHubAPIConsumer.App;
using System.Text.Json.Nodes;

namespace GitHubAPIConsumer.Api
{
    public class RepositoryInfo
    {
        private HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("https://api.instagram.com/v1/users/"),
        };

        public bool IsValid { get; set; } = false;
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Archived { get; set; }
        public string DefaultBranch { get; set; }
        public uint Watchers { get; set; }
        public uint StarCount { get; set; }
        public uint ForkCount { get; set; }

        public RepositoryInfo(string repositoryId)
        {
            _httpClient = new()
            {
                BaseAddress = new Uri($"https://api.github.com/repos/{AppState.UserId}/{repositoryId}"),
            };
        }

        public async Task Update()
        {
            var httpRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Get
            };
            httpRequest.Headers.Add("User-Agent", "mozilla");
            httpRequest.Headers.Add("Accept", "application/vnd.github+json");
            var httpResponseMessage = await _httpClient.SendAsync(httpRequest);

            if (httpResponseMessage is null)
            {
                return;
            }
            if (httpResponseMessage.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return;
            }

            var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            var data = JsonObject.Parse(jsonResponse);

            Name = data["name"].ToString();
            Description = data["description"] != null ? data["description"].ToString() : "???";
            Archived = bool.Parse(data["archived"].ToString());
            DefaultBranch = data["default_branch"].ToString();
            Watchers = uint.Parse(data["watchers_count"].ToString());
            StarCount = uint.Parse(data["stargazers_count"].ToString());
            ForkCount = uint.Parse(data["forks_count"].ToString());
            IsValid = true;
        }
    }
}
