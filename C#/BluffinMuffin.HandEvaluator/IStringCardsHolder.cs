using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluffinMuffin.HandEvaluator
{
    public interface IStringCardsHolder
    {
        IEnumerable<string> PlayerCards { get; }
        IEnumerable<string> CommunityCards { get; }
    }
}
