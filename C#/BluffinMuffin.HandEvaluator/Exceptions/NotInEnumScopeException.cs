using System;

namespace BluffinMuffin.HandEvaluator.Exceptions
{
    public class NotInEnumScopeException<T> : Exception
    {
        public NotInEnumScopeException(T value)
            : base($"Value '{value}' not in scope of {value.GetType().Name}.")
        {
        }
    }
}
