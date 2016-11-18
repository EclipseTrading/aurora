namespace Aurora.Core.Actions
{
    public interface IActionParameter
    {
        string Key { get; }
        object Value { get; }
        bool Optional { get; }
    }
}