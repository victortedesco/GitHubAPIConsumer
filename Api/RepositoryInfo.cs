using GitHubAPIConsumer.App;
using System.Text.Json.Nodes;

namespace GitHubAPIConsumer.Api
{
    public class RepositoryInfo
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("https://api.instagram.com/v1/users/"),
        };

        public bool IsValid { get; set; } = false;
        public string Name { get; set; }
        public string Description { get; set; }
        public uint StarCount { get; set; }
        public uint ForkCount { get; set; }

        public async Task Update()
        {
            using HttpResponseMessage response = await _httpClient.GetAsync(AppState.RepositoryId);
            if (response is null)
            {
                return;
            }
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return;
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var data = JsonObject.Parse(jsonResponse);

            Name = data["data.full_name"].ToString();
            Description = data["data.description"].ToString();
            StarCount = uint.Parse(data["data.counts.followed_by"].ToString());
            ForkCount = uint.Parse(data["data.counts.follows"].ToString());
            IsValid = true;
        }
    }
}
