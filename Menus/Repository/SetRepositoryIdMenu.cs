using GitHubAPIConsumer.App;

namespace GitHubAPIConsumer.Menus.Repository
{
    internal class SetRepositoryIdMenu : Menu
    {
        public async override void ExecuteCommand(int id)
        {
            string userId = Console.ReadLine();

            while (!ResponseState.UserInfo.IsValid)
            {
                Console.Clear();
                Console.WriteLine($"Esse repositório não existe ou não pertence ao usuário {AppState.UserId}!");
                userId = Console.ReadLine();
                await ResponseState.UserInfo.Update();
            }
            AppState.UserId = userId;
            AppState.MenuType = Type.RepositoryInfo;
        }

        public override void Print()
        {
            Console.WriteLine($"Digite o ID do repositório do usúario {AppState.UserId}.");
        }
    }
}
