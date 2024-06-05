using GitHubAPIConsumer.App;

namespace GitHubAPIConsumer.Menus.User
{
    public class SetUserIdMenu : Menu
    {
        public async override Task<bool> ExecuteCommand(int id)
        {
            var userId = Console.ReadLine();
            ResponseState.UserInfo = new(userId);
            await ResponseState.UserInfo.Update();

            while (!ResponseState.UserInfo.IsValid)
            {
                Console.Clear();
                Console.WriteLine("Esse @ desse usuário não existe!");
                Console.WriteLine("Digite um usuário válido.");
                userId = Console.ReadLine();
                ResponseState.UserInfo = new(userId);
                await ResponseState.UserInfo.Update();
            }
            AppState.UserId = userId;
            AppState.MenuType = Type.UserInfo;

            return true;
        }

        public override void Print()
        {
            Console.WriteLine("Digite o @ do usuário.");
        }
    }
}
