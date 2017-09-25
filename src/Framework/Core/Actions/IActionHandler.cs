namespace Aurora.Core.Actions
{
    public interface IActionHandler
    {
        bool Execute(ActionEvent evt);
    }
}
