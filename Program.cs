using GitHubAPIConsumer.App;
using GitHubAPIConsumer.Menus;
using GitHubAPIConsumer.Menus.Repository;
using GitHubAPIConsumer.Menus.User;

namespace GitHubAPIConsumer
{
    internal class Program
    {
        private readonly static SetUserIdMenu _setUserIdMenu = new();
        private readonly static SetRepositoryIdMenu _setRepositoryIdMenu = new();
        private readonly static UserInfoMenu _userInfoMenu = new();
        private readonly static RepositoryInfoMenu _repositoryInfoMenu = new();

        async static Task Main(string[] args)
        {
            while (!AppState.CloseApp)
            {
                if (AppState.MenuType == Menu.Type.SetUserId)
                {
                    Console.Clear();
                    _setUserIdMenu.Print();
                    await _setUserIdMenu.ExecuteCommand(0);
                    continue;
                }
                if (AppState.MenuType == Menu.Type.SetRepositoryId)
                {
                    Console.Clear();
                    _setRepositoryIdMenu.Print();
                    await _setRepositoryIdMenu.ExecuteCommand(0);
                    continue;
                }
                PrintMenu();
                var isValidOption = int.TryParse(Console.ReadLine(), out int value);
                while (!isValidOption)
                {
                    Console.Clear();
                    Console.WriteLine("Digite um número inteiro!");
                    isValidOption = int.TryParse(Console.ReadLine(), out value);
                }
                PerformMenu(value);
            }
        }

        private static void PrintMenu()
        {
            var menuType = AppState.MenuType;
            Console.Clear();
            switch (menuType)
            {
                case Menu.Type.UserInfo:
                    _userInfoMenu.Print();
                    break;
                case Menu.Type.RepositoryInfo:
                    _repositoryInfoMenu.Print();
                    break;
                default:
                    AppState.CloseApp = true;
                    break;
            }
        }

        private async static void PerformMenu(int id)
        {
            var menuType = AppState.MenuType;
            switch (menuType)
            {
                case Menu.Type.UserInfo:
                    await _userInfoMenu.ExecuteCommand(id);
                    break;
                case Menu.Type.RepositoryInfo:
                    await _repositoryInfoMenu.ExecuteCommand(id);
                    break;
                default:
                    AppState.CloseApp = true;
                    break;
            }
        }
    }
}
