﻿using GitHubAPIConsumer.App;

namespace GitHubAPIConsumer.Menus.Repository
{
    public class RepositoryInfoMenu : Menu
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
                AppState.MenuType = Type.UserInfo;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public override void Print()
        {
            var repositoryInfo = ResponseState.RepositoryInfo;

            Console.WriteLine($"Repositório: https://github.com/{AppState.UserId}/{AppState.RepositoryId}");
            Console.WriteLine();
            Console.WriteLine($"Nome: {repositoryInfo.Name}");
            Console.WriteLine($"Descrição: {repositoryInfo.Description}");
            Console.WriteLine($"Arquivado: {FormatBool(repositoryInfo.Archived)}");
            Console.WriteLine($"Branch padrão: {repositoryInfo.DefaultBranch}");
            Console.WriteLine($"Quantidade de estrelas: {repositoryInfo.StarCount}");
            Console.WriteLine($"Quantidade de forks: {repositoryInfo.ForkCount}");
            Console.WriteLine();
            Console.WriteLine("1. Ver outro repositório.");
            Console.WriteLine("2. Voltar.");
        }

        private static string FormatBool(bool value)
        {
            return value ? "Sim" : "Não";
        }
    }
}
