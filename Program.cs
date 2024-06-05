using GitHubAPIConsumer.App;
using GitHubAPIConsumer.Menus;
using GitHubAPIConsumer.Menus.Repository;
using GitHubAPIConsumer.Menus.User;

namespace GitHubAPIConsumer
{
    internal class Program
    {
        private static SetUserIdMenu _setUserIdMenu = new();
        private static SetRepositoryIdMenu _setRepositoryIdMenu = new();
        private static UserInfoMenu _userInfoMenu = new();
        private static RepositoryInfoMenu _repositoryInfoMenu = new();

        static void Main(string[] args)
        {
            while (!AppState.CloseApp)
            {
                if (AppState.MenuType == Menu.Type.SetUserId)
                {
                    Console.Clear();
                    _setUserIdMenu.Print();
                    _setUserIdMenu.ExecuteCommand(0);
                    continue;
                }
                if (AppState.MenuType == Menu.Type.SetRepositoryId)
                {
                    Console.Clear();
                    _setRepositoryIdMenu.Print();
                    _setRepositoryIdMenu.ExecuteCommand(0);
                    continue;
                }
                PrintMenu();
                bool isValidOption = int.TryParse(Console.ReadLine(), out int value);
                while (!isValidOption)
                {
                    Console.Clear();
                    Console.WriteLine("Digite uma opção válida!");
                    isValidOption = int.TryParse(Console.ReadLine(), out value);
                }
                PerformMenu(value);
            }
        }

        private static void PrintMenu()
        {
            Menu.Type menuType = AppState.MenuType;
            Console.Clear();
            switch (menuType)
            {
                case Menu.Type.UserInfo:
                    _userInfoMenu.Print();
                    break;
                case Menu.Type.RepositoryInfo:
                    _userInfoMenu.Print();
                    break;
                default:
                    AppState.CloseApp = true;
                    break;
            }
        }

        private static void PerformMenu(int id)
        {
            Menu.Type menuType = AppState.MenuType;
            switch (menuType)
            {
                case Menu.Type.UserInfo:
                    _userInfoMenu.ExecuteCommand(id);
                    break;
                case Menu.Type.RepositoryInfo:
                    _repositoryInfoMenu.ExecuteCommand(id);
                    break;
                default:
                    AppState.CloseApp = true;
                    break;
            }
        }
    }
}
