using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluffinMuffin.HandEvaluator.Exceptions
{
    public class InvalidStringRepresentationException : Exception
    {
        public InvalidStringRepresentationException(string stringRepresentation, string reason)
            : base(String.Format("'{0}' is not a valid Card Reprensentation (Invalid {1}). Use the 'vs' format where v = [2,3,4,5,6,7,8,9,10,J,Q,K,A] and s = [S,D,H,C]", stringRepresentation, reason))
        {
            
        }
    }
}
