# 3.*

## 3.1.*

### [3.1.0](https://github.com/Ericmas001/BluffinMuffin.HandEvaluator/releases/tag/v3.1.0) *(2015-09-14)*
 * Bug correction Issue #5: A-2-3-4-5 was too strong !
 * Bug correction Issue #3: Ace as LowCard on stripped deck !
 * Enhancement Issue #4: Decide if yes or no ace can be a lowcard in straights !

## 3.0.*

### [3.0.0](https://github.com/Ericmas001/BluffinMuffin.HandEvaluator/releases/tag/v3.0.0) *(2015-09-13)*
 * Changing signature in HandEvaluators with parameters as a way to reduce incompatibilities every versions
 * Adding the FlushBeatsFullHouse support so games with stripped deck can be evaluated correctly
 * Adding the NoStraightNoFlush as a first step to be able to support Ace-to-five lowball poker

# 2.*

## 2.2.*

### [2.2.0](https://github.com/Ericmas001/BluffinMuffin.HandEvaluator/releases/tag/v2.2.0) *(2015-09-13)*
 * Adding 2 CardSelectionType: OnlyHoleCards and OnlyHoleCardsWithSuitRanking
 * Making evalutation of partial hand possible. Not all HandEvaluator requires 5 cards. 
   * HighCard only needs 1 card
   * OnePair only needs 2 cards
   * ThreeOfAKinbd only needs 3 cards
   * TwoPairs only needs 4 cards
   * FourOfAKind only needs 4 cards

## 2.1.*

### [2.1.0](https://github.com/Ericmas001/BluffinMuffin.HandEvaluator/releases/tag/v2.1.0) *(2015-07-09)*
 * EvaluationType is now obsolete, it was a mistake
 * Asking for CardSelectionType is way better
 * Signatures of HandEvaluators have changed to reflect above changes. Old signatures are obsolete.

## 2.0.*

### [2.0.0](https://github.com/Ericmas001/BluffinMuffin.HandEvaluator/releases/tag/v2.0.0) *(2015-07-08)*
 * Making distinction between PlayerCards and ComunityCards
 * Asking for Evaluation Type
 * Adding Supports for Omaha Poker Evaluation

# 1.*

## 1.0.*

### [1.0.0](https://github.com/Ericmas001/BluffinMuffin.HandEvaluator/releases/tag/v1.0.0) *(2015-06-28)*
 * First version.
