namespace GitHubAPIConsumer.Menus
{
    public abstract class Menu
    {
        public abstract Task Print();
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
