using System;

namespace BluffinMuffin.HandEvaluator.Exceptions
{
    public class InvalidStringRepresentationException : Exception
    {
        public InvalidStringRepresentationException(string stringRepresentation, string reason)
            : base($"'{stringRepresentation}' is not a valid Card Reprensentation (Invalid {reason}). Use the 'vs' format where v = [2,3,4,5,6,7,8,9,10,J,Q,K,A] and s = [S,D,H,C]")
        {
            
        }
    }
}
