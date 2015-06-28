﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluffinMuffin.HandEvaluator.Demo
{
    class Program
    {
        private class Player : IStringCardsHolder
        {
            public string Name { get; private set; }
            public string[] Cards { get; private set; }

            public Player(string name, params string[] cards)
            {
                Name = name;
                Cards = cards;
            }

            public override string ToString()
            {
                return String.Format("{0}: [{1}]", Name, String.Join(",", Cards));
            }

            public string[] StringCards { get { return Cards; } }
        }

        static void Main(string[] args)
        {
            Player[] players = new[]
            {
                new Player("P1", "Ks", "5s", "8d", "As", "10s", "2s", "8s"),
                new Player("P2", "2h", "5h", "4h", "Ah", "10s", "3h", "4c"),
                new Player("P3", "Ks", "5c", "Qd", "Ac", "10c", "2c", "Js"),
                new Player("P4", "2s", "2c", "2d", "3c", "5d", "9c", "3h"),
                new Player("P5", "2s", "2c", "5d", "3c", "3d", "9c", "3h"),
                new Player("P6", "4s", "4c", "4d", "3c", "3d", "9c", "4h"),
                new Player("P7", "4s", "4c", "4d", "3c"),
                new Player("P8", "Ks", "5h", "8d", "Ac", "7s", "10h", "2s"),
                new Player("P9", "Ks", "5h", "8d", "Ac", "7s", "10h", "Kh"),
                new Player("PA", "Ks", "5h", "8d", "7c", "7s", "10h", "Kh"),
                new Player("PB", "Ks", "5h", "8d", "Kc", "7s", "10h", "Kh"),
                new Player("PC", "Ks", "5h", "Ad", "Kc", "Qs", "10h", "Jh"),
                new Player("PD", "Ks", "5s", "As", "Kc", "Qs", "10s", "Jh"),
                new Player("PE", "Ks", "5h", "8d", "7c", "5s", "5h", "Kh"),
                new Player("PF", "Ks", "5h", "5d", "7c", "5s", "5h", "Kh"),
                new Player("PG", "Ks", "5h", "Ah", "Kh", "Qh", "10h", "Jh"),
            };

            foreach (Player p in players)
                Console.WriteLine(p);

            Console.WriteLine();
            Console.WriteLine();

            foreach (var p in HandEvaluator.Evaluate(players).SelectMany(x => x))
                Console.WriteLine("{0}: {1} -> {2}", p.Rank == int.MaxValue ? "  " : p.Rank.ToString(), ((Player)p.CardsHolder).Name, p.Evaluation);

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}