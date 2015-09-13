using System;

namespace BluffinMuffin.HandEvaluator.Exceptions
{
    public class NotInEnumScopeException : Exception
    {
        public NotInEnumScopeException(object value, Type t)
            : base($"Value '{value}' not in scope of {t.Name}.")
        {
        }
    }

    public class NotInEnumScopeException<T> : NotInEnumScopeException
    {
        public NotInEnumScopeException(T value)
            : base(value, value.GetType())
        {
        }
    }
}
