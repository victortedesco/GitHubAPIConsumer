using GitHubAPIConsumer.Api;
using GitHubAPIConsumer.App;

namespace GitHubAPIConsumer.Menus.User
{
    internal class UserInfoMenu : Menu
    {
        public override void ExecuteCommand(int id)
        {
            switch (id)
            {
                case 0:
                    AppState.MenuType = Type.SetUserId;
                    break;
                case 1:
                    AppState.MenuType = Type.UserInfo;
                    break;
                case 2:
                    AppState.MenuType = Type.SetRepositoryId;
                    break;
            }
        }

        public override void Print()
        {
            UserInfo userInfo = ResponseState.UserInfo;

            Console.WriteLine($"Usuário: {AppState.UserId}");
            Console.WriteLine();
            Console.WriteLine($"Nome: {userInfo.Name}");
            Console.WriteLine($"Descrição: {userInfo.Description}");
            Console.WriteLine($"Quantidade de seguidores: {userInfo.FollowerCount}");
            Console.WriteLine($"Quantidade de usuário seguidos: {userInfo.FollowingCount}");
            Console.WriteLine();
            Console.WriteLine("1. Escolher outro usuário.");
        }
    }
}
