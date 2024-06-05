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

        async static Task Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (!AppState.CloseApp)
            {
                PrintMenu();
                int value = 0;
                if (AppState.MenuType is not Menu.Type.SetUserId and not Menu.Type.SetRepositoryId)
                {
                    var isValidOption = int.TryParse(Console.ReadLine(), out value);
                    while (!isValidOption)
                    {
                        Console.Clear();
                        Console.WriteLine("Digite um número inteiro!");
                        isValidOption = int.TryParse(Console.ReadLine(), out value);
                    }
                }
                await PerformMenu(value);
            }
        }

        private static void PrintMenu()
        {
            Console.Clear();
            switch (AppState.MenuType)
            {
                case Menu.Type.SetUserId:
                    _setUserIdMenu.Print();
                    break;
                case Menu.Type.SetRepositoryId:
                    _setRepositoryIdMenu.Print();
                    break;
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

        private static Task PerformMenu(int id)
        {
            switch (AppState.MenuType)
            {
                case Menu.Type.SetUserId:
                    return _setUserIdMenu.ExecuteCommand(id);
                case Menu.Type.SetRepositoryId:
                    return _setRepositoryIdMenu.ExecuteCommand(id);
                case Menu.Type.UserInfo:
                    return _userInfoMenu.ExecuteCommand(id);
                case Menu.Type.RepositoryInfo:
                    return _repositoryInfoMenu.ExecuteCommand(id);
            }
            AppState.CloseApp = true;
            return Task.CompletedTask;
        }
    }
}
