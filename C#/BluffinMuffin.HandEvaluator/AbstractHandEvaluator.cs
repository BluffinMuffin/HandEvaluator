﻿using System;
using BluffinMuffin.HandEvaluator.Enums;

namespace BluffinMuffin.HandEvaluator
{
    public abstract class AbstractHandEvaluator
    {
        public abstract HandEnum HandType { get; }

        public abstract HandEvaluationResult Evaluation(PlayingCard[] cards);

        public abstract String ResultToString(HandEvaluationResult res);
    }
}