using GitHubAPIConsumer.Menus;

namespace GitHubAPIConsumer.App
{
    public class AppState
    {
        public static string UserId { get; set; }
        public static string RepositoryId { get; set; }
        public static Menu.Type MenuType { get; set; } = Menu.Type.SetUserId;
    }
}
