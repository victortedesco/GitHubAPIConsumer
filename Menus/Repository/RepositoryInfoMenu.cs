using GitHubAPIConsumer.Api;
using GitHubAPIConsumer.App;

namespace GitHubAPIConsumer.Menus.Repository
{
    internal class RepositoryInfoMenu : Menu
    {
        public override void ExecuteCommand(int id)
        {
            switch (id)
            {
                case 1:
                    AppState.MenuType = Type.RepositoryInfo;
                    break;
                case 2:
                    AppState.MenuType = Type.UserInfo;
                    break;
            }
        }

        public override void Print()
        {
            RepositoryInfo repositoryInfo = ResponseState.RepositoryInfo;

            Console.WriteLine($"Repositório: {AppState.UserId}/{AppState.RepositoryId}");
            Console.WriteLine();
            Console.WriteLine($"Nome: {repositoryInfo.Name}");
            Console.WriteLine($"Descrição: {repositoryInfo.Description}");
            Console.WriteLine($"Quantidade de estrelas: {repositoryInfo.StarCount}");
            Console.WriteLine($"Quantidade de Forks: {repositoryInfo.ForkCount}");
            Console.WriteLine();
            Console.WriteLine("1. Ver outro repositório.");
            Console.WriteLine("2. Voltar.");
        }
    }
}
