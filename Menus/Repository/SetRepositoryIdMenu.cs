﻿using GitHubAPIConsumer.App;

namespace GitHubAPIConsumer.Menus.Repository
{
    public class SetRepositoryIdMenu : Menu
    {
        public async override Task<bool> ExecuteCommand(int id)
        {
            var repositoryId = Console.ReadLine();
            ResponseState.RepositoryInfo = new(repositoryId);
            await ResponseState.RepositoryInfo.Update();

            if (!ResponseState.RepositoryInfo.IsValid)
            {
                Console.Clear();
                Console.WriteLine($"Esse repositório não existe, não pertence ao usuário \"{AppState.UserId}\", ou você não tem permissão para vê-lo.");
                Console.ReadKey();
                AppState.MenuType = Type.UserInfo;
                return false;
            }

            AppState.RepositoryId = repositoryId;
            AppState.MenuType = Type.RepositoryInfo;

            return true;
        }

        public override Task Print()
        {
            Console.WriteLine($"Digite o @ do repositório do usúario \"{AppState.UserId}\".");
            return Task.CompletedTask;
        }
    }
}
