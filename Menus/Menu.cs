namespace GitHubAPIConsumer.Menus
{
    public abstract class Menu
    {
        public abstract void Print();
        public abstract Task<bool> ExecuteCommand(int id);

        public enum Type : ushort
        {
            SetUserId,
            SetRepositoryId,
            UserInfo,
            RepositoryInfo,
        }
    }
}
