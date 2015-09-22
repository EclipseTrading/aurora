using System;

namespace Aurora.Core
{
    public class TypeOverride
    {
        public TypeOverride(Type type, object value)
        {
            Type = type;
            Value = value;
        }

        public object Value { get; }
        public Type Type { get; }

    }

    public class TypeOverride<T> : TypeOverride
    {
        public new T Value { get; set; }

        public TypeOverride(object value) : base(typeof(T), value)
        {
        }
    }
}