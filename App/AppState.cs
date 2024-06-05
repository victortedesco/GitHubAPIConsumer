using GitHubAPIConsumer.Menus;

namespace GitHubAPIConsumer.App
{
    internal class AppState
    {
        public static string UserId { get; set; }
        public static string RepositoryId { get; set; }
        public static bool CloseApp { get; set; } = false;
        public static Menu.Type MenuType { get; set; } = Menu.Type.SetUserId;
    }
}
