namespace GitHubAPIConsumer.Menus
{
    internal abstract class Menu
    {
        public abstract void Print();
        public abstract void ExecuteCommand(int id);

        public enum Type : ushort
        {
            SetUserId,
            SetRepositoryId,
            UserInfo,
            RepositoryInfo,
        }
    }
}
