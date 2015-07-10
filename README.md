# BluffinMuffin.HandEvaluator

BluffinMuffin HandEvaluator is a .Net PokerHand Evaluator that supports [standard list of poker hands](https://en.wikipedia.org/wiki/List_of_poker_hands). This project aims for simplicity of code, simplicity of use and extensibility. If what you are looking for is execution speed, I recommend looking at [this project](http://www.codeproject.com/Articles/12279/Fast-Texas-Holdem-Hand-Evaluation-and-Analysis). But, for most implementations, this library will be fast enough!

The project will be released using [Semantic Versioning](http://semver.org) and developped using [Vincent Driessen's Git Model](http://nvie.com/posts/a-successful-git-branching-model/).
    
####Known Implementations
 * **[BluffinMuffin.Server](http://ericmas001.github.io/BluffinMuffin.Server)** *(Evaluator v1.0.0)*


####Current Version: ** [2.1.0](https://github.com/Ericmas001/BluffinMuffin.HandEvaluator/releases/tag/v2.1.0)** *(2015-07-09)*
 * EvaluationType is now obsolete, it was a mistake
 * Asking for CardSelectionType is way better
 * Signatures of HandEvaluators have changed to reflect above changes. Old signatures are obsolete.
 * *[Full changelog ...](https://github.com/Ericmas001/BluffinMuffin.HandEvaluator/blob/master/CHANGELOG.md)*

<p align=center><img src="https://github.com/Ericmas001/BluffinMuffin.HandEvaluator/blob/master/Documentation/hands_strength.png?raw=true" alt="Hand Strengths"></p>


=====================================================
=====================================================
##Documentation

The class `HandEvaluators` exposes 2 static "Evaluate" methods that you can use.
 * **`HandEvaluationResult Evaluate(CardSelectionEnum selection, IEnumerable<string> playerCards, IEnumerable<string> communityCards)`**
   
   This method evaluates the best hand found with the given player cards and the given community cards. Cards are given in the 'vs' format where `v = [2,3,4,5,6,7,8,9,10,J,Q,K,A]` and `s = [S,D,H,C]`. Example: '3S','4C' means a three of spades and a four of clubs. 
   
   A total minimum of 5 cards must be given to be evaluated. 
   
   * In texas hold'em, you would send the 2 cards of the player, and the five cards on the board. 
   * In omaha hold'em, you would send the 4 cards of the player, and the five cards on the board. 
   
   The *selection* parameter define what type of hand evaluation will be applied.
   Supported type are:
   * AllPlayerAndAllCommunity
   * TwoPlayersAndThreeCommunity 

   See **HandEvaluationResult** below for more information on the output.
 
 * **`IEnumerable<IGrouping<int, EvaluatedCardHolder>> Evaluate(CardSelectionEnum selection, params IStringCardsHolder[] cardHolders)`**

   This method evaluates and ranks the different CardHolders. CardHolders implements IStringCardsHolder who simply have a `IEnumerable<string> PlayerCards` property and a `IEnumerable<string> CommunityCards` property. 
   
   The cards of the CardHolder includes player cards and community cards. 
   
   CardHolders will come back grouped by rank (where 1 is the best rank). 
   
   The *selection* parameter define what type of hand evaluation will be applied.
   Supported type are:
   * AllPlayerAndAllCommunity
   * TwoPlayersAndThreeCommunity
   
   See **EvaluatedCardHolder** below for more information on the output.
   
####HandEvaluationResult

The class "HandEvaluationResult" contains the result of the evaluation of a set of cards. This class implements `IComparable` and the best result will be greater than the worst.
 * **`HandEnum Hand`**

   This property contains the type of the best Hand found with the given cards (Examples: StraightFlush, FullHouse, HighCard).

 * **`List<PlayingCard[]> Cards`**

   This property contains the 5 cards that were used in the best hand. Each item of the list is a group of card, and the first card of the group will be evaluated when similar hands are compared. The following examples are based on the "TexasHoldem" evaluation
   
    * Example 1: {3s, 5h}, {7d, 9c, Js, Qh, Ad} will return **HighCard** with `Cards = {[Ad],[Qh],[Js],[9c],[7d]}`. When comparing against another hand, the evaluator will compare Hand type. If equal, it will compare the first card of the first group (Ad). If the nominal value (A) is equal, it will compare the first card of the next group (Qh). And so on. If all the evaluated cards are equal, the 2 hands are equal.
    * Example 2: {3s, 5h}, { 7d, 9c, Js, 3h, 5d} will return **TwoPairs** with `Cards = {[5h,5d],[3s,3h],[Js]}`. When comparing against another hand, the evaluator will compare Hand type. If equal, it will compare the first card of the first group (5h). If the nominal value (5) is equal, it will compare the first card of the next group (3s). And so on. If all the evaluated cards are equal, the 2 hands are equal.
    * Example 3: {3s, 5h}, { 7d, 9c, Js, 4h, 6d} will return **Straight** with `Cards = {[7d,6d,5h,4h,3s]}`. When comparing against another hand, the evaluator will compare Hand type. If equal, it will compare the first card of the first group (7d). If the nominal value (7) is equal, the 2 hands are equal.
    * Example 4: {3c, 5c}, { 7c, 9c, Jc, Qc, Ac} will return **Flush** with `Cards = {[Ac],[Qc],[Jc],[9c],[7c]}`. When comparing against another hand, the evaluator will compare Hand type. If equal, it will compare the first card of the first group (Ac). If the nominal value (A) is equal, it will compare the first card of the next group (Qc). And so on. If all the evaluated cards are equal, the 2 hands are equal.


####EvaluatedCardHolder

The class "EvaluatedCardHolder" contains the result of the evaluation of a CardHolder.
 * **`IStringCardsHolder CardsHolder`**

   This property contains the original CardsHolder that was evaluated.
   
 * **`HandEvaluationResult Evaluation`**

   This property contains the best Hand found with the cards of the CardHolder.

 * **`int Rank`**

   This property contains the rank of the CardsHolder when compared to others. 1 is the best rank.
