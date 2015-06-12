using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace BluffinMuffin.HandEvaluator.Exceptions
{
    public class NotInEnumScopeException : Exception
    {
        public NotInEnumScopeException(object value, Type t)
            : base(string.Format("Value '{0}' not in scope of {1}.", value, t.Name))
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
