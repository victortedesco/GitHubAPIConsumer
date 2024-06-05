using GitHubAPIConsumer.App;

namespace GitHubAPIConsumer.Menus.User
{
    internal class SetUserIdMenu : Menu
    {
        public async override void ExecuteCommand(int id)
        {
            string userId = Console.ReadLine();

            while (!ResponseState.UserInfo.IsValid)
            {
                Console.Clear();
                Console.WriteLine("Esse @ de usuário não existe!");
                userId = Console.ReadLine();
                await ResponseState.UserInfo.Update();
            }
            AppState.UserId = userId;
            AppState.MenuType = Type.UserInfo;
        }

        public override void Print()
        {
            Console.WriteLine("Digite o @ do usuário.");
        }
    }
}
