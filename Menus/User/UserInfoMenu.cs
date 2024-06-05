using GitHubAPIConsumer.App;

namespace GitHubAPIConsumer.Menus.User
{
    internal class UserInfoMenu : Menu
    {
        public override Task<bool> ExecuteCommand(int id)
        {
            if (id == 1)
            {
                AppState.MenuType = Type.SetRepositoryId;
                return Task.FromResult(true);
            }
            if (id == 2)
            {
                AppState.MenuType = Type.SetUserId;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public override void Print()
        {
            var userInfo = ResponseState.UserInfo;

            Console.WriteLine($"Usuário: {AppState.UserId}");
            Console.WriteLine();
            Console.WriteLine($"Nome: {userInfo.Name}");
            Console.WriteLine($"Descrição: {userInfo.Description}");
            Console.WriteLine($"Quantidade de seguidores: {userInfo.FollowerCount}");
            Console.WriteLine($"Quantidade de usuário seguidos: {userInfo.FollowingCount}");
            Console.WriteLine();
            Console.WriteLine("1. Ver informações de um repositório desse usuário.");
            Console.WriteLine("2. Escolher outro usuário.");
        }
    }
}
