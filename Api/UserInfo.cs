using System.Text.Json.Nodes;

namespace GitHubAPIConsumer.Api
{
    public class UserInfo
    {
        private readonly HttpClient _httpClient;

        public bool IsValid { get; private set; } = false;
        public string Name { get; private set; }
        public string Description { get; private set; }
        public uint FollowerCount { get; private set; }
        public uint FollowingCount { get; private set; }

        public UserInfo(string userId)
        {
            _httpClient = new()
            {
                BaseAddress = new Uri($"https://api.github.com/users/{userId}"),
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

            Name = data["name"] != null ? data["name"].ToString() : data["login"].ToString();
            Description = data["bio"] != null ? data["bio"].ToString() : "???";
            FollowerCount = uint.Parse(data["followers"].ToString());
            FollowingCount = uint.Parse(data["following"].ToString());
            IsValid = true;
        }
    }
}
