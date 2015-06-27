using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluffinMuffin.HandEvaluator.Demo
{
    class Program
    {
        private class Player
        {
            public string Name { get; private set; }
            public string[] Cards { get; private set; }
            public HandEvaluationResult Evaluation { get; private set; }

            public Player(string name, string[] cards)
            {
                Name = name;
                Cards = cards;
                Evaluation = HandEvaluator.Evaluate(cards);
            }

            public override string ToString()
            {
                return String.Format("{0}: [{1}]", Name, String.Join(",", Cards));
            }
        }

        static void Main(string[] args)
        {
            Player[] players = new[]
            {
                new Player("P1", new[] {"Ks", "5s", "8d", "As", "10s", "2s", "8s"}),
                new Player("P2", new[] {"2h", "5h", "4h", "Ah", "10s", "3h", "4c"}),
                new Player("P3", new[] {"Ks", "5c", "Qd", "Ac", "10c", "2c", "Js"}),
                new Player("P4", new[] {"2s", "2c", "2d", "3c", "5d", "9c", "3h"}),
                new Player("P5", new[] {"2s", "2c", "5d", "3c", "3d", "9c", "3h"}),
                new Player("P6", new[] {"4s", "4c", "4d", "3c", "3d", "9c", "4h"}),
                new Player("P7", new[] {"4s", "4c", "4d", "3c"}),
                new Player("P8", new[] {"Ks", "5h", "8d", "Ac", "7s", "10h", "2s"}),
                new Player("P9", new[] {"Ks", "5h", "8d", "Ac", "7s", "10h", "Kh"}),
                new Player("PA", new[] {"Ks", "5h", "8d", "7c", "7s", "10h", "Kh"}),
                new Player("PB", new[] {"Ks", "5h", "8d", "Kc", "7s", "10h", "Kh"}),
                new Player("PC", new[] {"Ks", "5h", "Ad", "Kc", "Qs", "10h", "Jh"}),
                new Player("PD", new[] {"Ks", "5s", "As", "Kc", "Qs", "10s", "Jh"}),
                new Player("PE", new[] {"Ks", "5h", "8d", "7c", "5s", "5h", "Kh"}),
                new Player("PF", new[] {"Ks", "5h", "5d", "7c", "5s", "5h", "Kh"}),
                new Player("PG", new[] {"Ks", "5h", "Ah", "Kh", "Qh", "10h", "Jh"}),
            };

            foreach (Player p in players)
                Console.WriteLine(p);

            Console.WriteLine();
            Console.WriteLine();


            Player[] orderedPlayers = players.OrderByDescending(p => p.Evaluation).ToArray();

            for (int i = 0; i < orderedPlayers.Count(); ++i)
            {
                var pos = i;
                for(int last = i - 1; last >= 0; --last)
                    if (orderedPlayers[i].Evaluation != null && orderedPlayers[i].Evaluation.CompareTo(orderedPlayers[last].Evaluation) == 0)
                        pos = last;

                Console.WriteLine("{0}: {1} -> {2}", pos + 1, orderedPlayers[i].Name, orderedPlayers[i].Evaluation);
            }

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
