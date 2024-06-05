using GitHubAPIConsumer.Api;

namespace GitHubAPIConsumer.App
{
    internal class ResponseState
    {
        public static UserInfo UserInfo { get; set; }
        public static RepositoryInfo RepositoryInfo { get; set; }
    }
}
