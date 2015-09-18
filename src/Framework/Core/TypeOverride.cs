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

        public object Value { get; private set; }
        public Type Type { get; private set; }

    }

    public class TypeOverride<T> : TypeOverride
    {
        public new T Value { get; set; }

        public TypeOverride(object value) : base(typeof(T), value)
        {
        }
    }
}