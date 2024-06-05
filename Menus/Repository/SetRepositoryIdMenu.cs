using GitHubAPIConsumer.App;

namespace GitHubAPIConsumer.Menus.Repository
{
    internal class SetRepositoryIdMenu : Menu
    {
        public async override Task<bool> ExecuteCommand(int id)
        {
            var repositoryId = Console.ReadLine();
            ResponseState.RepositoryInfo = new(repositoryId);
            await ResponseState.RepositoryInfo.Update();

            if (!ResponseState.RepositoryInfo.IsValid)
            {
                Console.Clear();
                Console.WriteLine($"Esse repositório não existe ou não pertence ao usuário {AppState.UserId}!");
                Console.ReadKey();
                AppState.MenuType = Type.UserInfo;
                return false;
            }

            AppState.RepositoryId = repositoryId;
            AppState.MenuType = Type.RepositoryInfo;

            return true;
        }

        public override void Print()
        {
            Console.WriteLine($"Digite o ID do repositório do usúario {AppState.UserId}.");
        }
    }
}
