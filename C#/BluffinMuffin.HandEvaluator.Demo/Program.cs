using System;
using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.HandEvaluator.Selectors;
using static System.String;

namespace BluffinMuffin.HandEvaluator.Demo
{
    internal static class Program
    {
        private class Player : IStringCardsHolder
        {
            public string Name { get; }
            private string[] Cards { get; }

            public Player(string name, params string[] cards)
            {
                Name = name;
                Cards = cards;
            }

            public override string ToString()
            {
                return $"{Name}: [{Join(",", Cards)}]";
            }

            public IEnumerable<string> PlayerCards => Cards.Take(2);

            public IEnumerable<string> CommunityCards => Cards.Skip(2);
        }

        private static void Main()
        {
            IStringCardsHolder[] players =
            {
                new Player("P1", "Ks", "5s", "8d", "As", "10s", "2s", "8s"),
                new Player("P2", "2h", "5h", "4h", "Ah", "10s", "3h", "4c"),
                new Player("P3", "Ks", "5c", "Qd", "Ac", "10c", "2c", "Js"),
                new Player("P4", "2s", "2c", "2d", "3c", "5d", "9c", "3h"),
                new Player("P5", "2s", "2c", "5d", "3c", "3d", "9c", "3h"),
                new Player("P6", "4c", "4s", "4d", "3c", "3d", "9c", "4h"),
                new Player("P7", "4c", "4d", "4c", "3c"),
                new Player("P8", "Ks", "5h", "8d", "Ac", "7s", "10h", "2s"),
                new Player("P9", "Ks", "5h", "8d", "Ac", "7s", "10h", "Kh"),
                new Player("PA", "Ks", "5h", "8d", "7c", "7s", "10h", "Kh"),
                new Player("PB", "Ks", "5h", "8d", "Kc", "7s", "10h", "Kh"),
                new Player("PC", "Ks", "5h", "Ad", "Kc", "Qs", "10h", "Jh"),
                new Player("PD", "Ks", "5s", "As", "Kc", "Qs", "10s", "Jh"),
                new Player("PE", "Ks", "5h", "8d", "7c", "5s", "5h", "Kh"),
                new Player("PF", "Ks", "5h", "5d", "7c", "5s", "5h", "Kh"),
                new Player("PG", "Ks", "5h", "Ah", "Kh", "Qh", "10h", "Jh"),
                new Player("PH", "4s"),
                new Player("PI", "2s", "3h"),
            };

            foreach (IStringCardsHolder p in players)
                Console.WriteLine(p);

            Console.WriteLine();
            Console.WriteLine("=============NORMAL=============");

            foreach (var p in HandEvaluators.Evaluate(players).SelectMany(x => x))
                Console.WriteLine("{0}: {1} -> {2}", p.Rank == int.MaxValue ? "  " : p.Rank.ToString(), ((Player) p.CardsHolder).Name, p.Evaluation);

            Console.WriteLine();
            Console.WriteLine("=============ONLY HAND=============");

            foreach (var p in HandEvaluators.Evaluate(players, new EvaluationParams { Selector = new OnlyHoleCardsSelector() }).SelectMany(x => x))
                Console.WriteLine("{0}: {1} -> {2}", p.Rank == int.MaxValue ? "  " : p.Rank.ToString(), ((Player) p.CardsHolder).Name, p.Evaluation);

            Console.WriteLine();
            Console.WriteLine("=============ONLY HAND WITH SUIT=============");

            foreach (var p in HandEvaluators.Evaluate(players, new EvaluationParams { Selector = new OnlyHoleCardsSelector(), UseSuitRanking = true}).SelectMany(x => x))
                Console.WriteLine("{0}: {1} -> {2}", p.Rank == int.MaxValue ? "  " : p.Rank.ToString(), ((Player) p.CardsHolder).Name, p.Evaluation);

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}