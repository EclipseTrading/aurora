namespace Aurora.Core.Actions
{
    public class ActionParameter : IActionParameter
    {
        public string Key { get; }
        public object Value { get; }
        public bool Optional { get; }

        public ActionParameter(string key, object value, bool optional = false)
        {
            Key = key;
            Value = value;
            Optional = optional;
        }

        public override string ToString()
        {
            return $"{nameof(Key)}: {Key}, {nameof(Value)}: {Value}, {nameof(Optional)}: {Optional}";
        }
    }
}
