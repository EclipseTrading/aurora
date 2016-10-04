namespace Aurora.Core.Container
{
    public interface ICommandBarServiceHost
    {
        void RegisterCommandBarService(string barName, ICommandBarService commandBarService);
        void RegisterDefaultCommandBarService(ICommandBarService commandBarService);
        ICommandBarService GetCommandBarService(string barName);
    }
}