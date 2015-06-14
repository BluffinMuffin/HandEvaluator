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
                new Player("P1", new[] {"Kc", "5s", "8d", "As", "10s", "2s", "8s"}),
                new Player("P2", new[] {"Kd", "5d", "8h", "Ah", "10s", "Ad", "8c"}),
                new Player("P3", new[] {"Ks", "5c", "Qd", "Ac", "10c", "2c", "Js"}),
                new Player("P4", new[] {"2s", "2c", "2d", "3c", "5d", "9c", "3h"}),
            };

            foreach (Player p in players)
                Console.WriteLine(p);

            Console.WriteLine();
            Console.WriteLine();


            Player[] orderedPlayers = players.OrderByDescending(p => p.Evaluation).ToArray();

            for (int i = 0; i < orderedPlayers.Count(); ++i)
                Console.WriteLine("{0}: {1} -> {2}", i + 1, orderedPlayers[i].Name, orderedPlayers[i].Evaluation);

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
