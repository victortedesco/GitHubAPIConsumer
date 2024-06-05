using GitHubAPIConsumer.App;
using System.Text.Json.Nodes;

namespace GitHubAPIConsumer.Api
{
    public class UserInfo
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("https://api.instagram.com/v1/users/"),
        };

        public bool IsValid { get; set; } = false;
        public string Name { get; set; }
        public string Description { get; set; }
        public uint FollowerCount { get; set; }
        public uint FollowingCount { get; set; }

        public async Task Update()
        {
            using HttpResponseMessage response = await _httpClient.GetAsync(AppState.UserId);
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
            FollowerCount = uint.Parse(data["data.counts.followed_by"].ToString());
            FollowingCount = uint.Parse(data["data.counts.follows"].ToString());
            IsValid = true;
        }
    }
}
