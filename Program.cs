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

            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e)
            {
                e.Cancel = true;
                Console.Clear();
                Environment.Exit(0);
            };

            while (true)
            {
                Console.Clear();
                await PrintMenu();
                int value = 0;
                if (AppState.MenuType is not Menu.Type.SetUserId and not Menu.Type.SetRepositoryId)
                {
                    var isValidOption = int.TryParse(Console.ReadLine(), out value);
                    while (!isValidOption)
                    {
                        Console.Clear();
                        await PrintMenu();
                        Console.WriteLine("Digite um número inteiro!");
                        isValidOption = int.TryParse(Console.ReadLine(), out value);
                    }
                }
                await ExecuteMenu(value);
            }
        }

        private static Task PrintMenu()
        {
            return AppState.MenuType switch
            {
                Menu.Type.SetUserId => _setUserIdMenu.Print(),
                Menu.Type.SetRepositoryId => _setRepositoryIdMenu.Print(),
                Menu.Type.UserInfo => _userInfoMenu.Print(),
                Menu.Type.RepositoryInfo => _repositoryInfoMenu.Print(),
                _ => Task.FromException(new ArgumentOutOfRangeException(null, nameof(AppState.MenuType)))
            };
        }

        private static Task ExecuteMenu(int id)
        {
            return AppState.MenuType switch
            {
                Menu.Type.SetUserId => _setUserIdMenu.ExecuteCommand(id),
                Menu.Type.SetRepositoryId => _setRepositoryIdMenu.ExecuteCommand(id),
                Menu.Type.UserInfo => _userInfoMenu.ExecuteCommand(id),
                Menu.Type.RepositoryInfo => _repositoryInfoMenu.ExecuteCommand(id),
                _ => Task.FromException(new ArgumentOutOfRangeException(null, nameof(AppState.MenuType)))
            };
        }
    }
}
