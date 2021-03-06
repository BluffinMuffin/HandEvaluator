# BluffinMuffin.HandEvaluator

BluffinMuffin HandEvaluator is a .Net PokerHand Evaluator that supports [standard list of poker hands](https://en.wikipedia.org/wiki/List_of_poker_hands). This project aims for simplicity of code, simplicity of use and extensibility. If what you are looking for is execution speed, I recommend looking at [this project](http://www.codeproject.com/Articles/12279/Fast-Texas-Holdem-Hand-Evaluation-and-Analysis). But, for most implementations, this library will be fast enough!

The project will be released using [Semantic Versioning](http://semver.org) and developped using [Vincent Driessen's Git Model](http://nvie.com/posts/a-successful-git-branching-model/).

###Current Version: 3.1.2 *(2015-11-15)*
<table align="center" width="100%">
    <tbody>
        <tr>
            <td rowspan=2>.Net</td>
            <td align="center">
            <a href="https://www.nuget.org/packages/BluffinMuffin.HandEvaluator/" target="_blank">
            BluffinMuffin.HandEvaluator <br />
            <img src="https://raw.githubusercontent.com/NuGet/Home/master/resources/nuget.png" alt="NuGet" width=150 />
            </a>
            </td>
            <td align="left">
                <div class="nuget-badge">
                    <b>PM&gt; Install-Package BluffinMuffin.HandEvaluator </b> <br />
                    or Install via VS <a href="https://docs.nuget.org/consume/package-manager-dialog" target="_blank">Package Management</a> window.
                </div>
            </td>
        </tr>
        <tr>
            <td align="left" colspan=2>
                <div class="vs-package-management">
                <a href="https://github.com/Ericmas001/BluffinMuffin.HandEvaluator/releases/tag/v3.1.2" target="_blank">Download Manually</a>
                </div>
            </td>
        </tr>
    </tbody>
</table>
    
####Known Implementations
 * **[BluffinMuffin.Server 0.11.0](https://github.com/BluffinMuffin/Server)** *(Evaluator v3.1.0)*


####Changelog
 * EvaluatedCardHolder now use generics to simplify
 * EvaluatedCardHoldersExtensions.RankOf is now available
 * HandEvaluators.Evaluate with CardHolders signature has changed for easier implementation
 * *[Full changelog ...](https://github.com/Ericmas001/BluffinMuffin.HandEvaluator/blob/master/CHANGELOG.md)*

<p align=center><img src="https://github.com/Ericmas001/BluffinMuffin.HandEvaluator/blob/master/Documentation/hands_strength.png?raw=true" alt="Hand Strengths"></p>


=====================================================
=====================================================
##Documentation

The class `HandEvaluators` exposes 2 static "Evaluate" methods that you can use.
 * **`HandEvaluationResult Evaluate(IEnumerable<string> playerCards, IEnumerable<string> communityCards, EvaluationParams parms = null)`**
   
   This method evaluates the best hand found with the given player cards and the given community cards. Cards are given in the 'vs' format where `v = [2,3,4,5,6,7,8,9,10,J,Q,K,A]` and `s = [S,D,H,C]`. Example: '3S','4C' means a three of spades and a four of clubs. 
   
   If there is no community cards, this parameter can be null, but don't forget to set the "Selector" property to "new OnlyHoleCardsSelector()"

   See **EvaluationParams** below for more information on the parameters.

   See **HandEvaluationResult** below for more information on the output.
 
 * **`IEnumerable<IGrouping<int, EvaluatedCardHolder>> Evaluate(IStringCardsHolder[] cardHolders, EvaluationParams parms = null)`**

   This method evaluates and ranks the different CardHolders. CardHolders implements IStringCardsHolder who simply have a `IEnumerable<string> PlayerCards` property and a `IEnumerable<string> CommunityCards` property. 
   
   The cards of the CardHolder includes player cards and community cards.    
   
   If there is no community cards, this parameter can be null, but don't forget to set the "Selector" property to "new OnlyHoleCardsSelector()"
   
   CardHolders will come back grouped by rank (where 1 is the best rank). 

   See **EvaluationParams** below for more information on the parameters.
   
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
   

####EvaluationParams

The class "EvaluationParams" contains the parameters that you can give to alter the result of the evaluation
 * **`bool UseSuitRanking`**
 
   * *(default)* **False:** Suits don't affect ranking. 3 of clubs and 3 of hearts are exactly the same during evaluation
   * **True:** [Suits affect ranking](https://en.wikipedia.org/wiki/High_card_by_suit#Poker). Spades > Hearts > Diamond > Clubs.

 * **`bool UseAceForLowStraight`**
 
   * *(default)* **True:** When looking for potential straights, Ace can be used as the lowest card, therefore the lowest straight in a regular deck would be A-2-3-4-5
   * **False:** When looking for potential straights, Ace will only be used as the highest card, therefore the lowest straight in a regular deck would be 2-3-4-5-6
   
 * **`NominalValueEnum[] UsedCardValues`**
 
   * *(default)* **[2,3,4,5,6,7,8,9,10,J,Q,K,A]:** A full 52 cards deck is used. This is important for example for calculating lowest straight, in this case A-2-3-4-5
   * **Any subset of default:** A subset of the normal 52 cards deck is used. This is important for example for calculating lowest straight, in a 7-to-Ace stripped deck, it would be A-7-8-9-10
   
 * **`AbstractCardsSelector Selector`**
 
   * *(default)* **UseAllCardsSelector:** Use all player cards and comunnity cards and make the best hand out of it.
   * **Use2Player3CommunitySelector:** Use any 2 cards of player cards and any 3 cards of comunnity cards and make the best hand out of it.
   * **OnlyHoleCardsSelector:** Use only player cards to make the best hand out of it.

 * **`AbstractEvaluatorFactory EvaluatorFactory`**
 
   * *(default)* **BasicEvaluatorFactory:** Evaluates for HighCard, OnePair, TwoPair, ThreeOfAKind, Straight, Flush, FullHouse, FourOfAKind and StraightFlush
   * **NoStraightNoFlushEvaluatorFactory:** Evaluates for HighCard, OnePair, TwoPair, ThreeOfAKind, FullHouse and FourOfAKind
   * **SingleEvaluatorFactory<T>:** Evaluates for T, where T is any Evaluator (Ex: OnePair)

 * **`AbstractHandRanker HandRanker`**
 
   * *(default)* **BasicHandRanker:** Rank hands is this order, lower to higher: HighCard, OnePair, TwoPair, ThreeOfAKind, Straight, Flush, FullHouse, FourOfAKind and StraightFlush
   * **FlushBeatsFullHouseHandRanker:** Rank hands is this order, lower to higher: HighCard, OnePair, TwoPair, ThreeOfAKind, Straight, FullHouse, Flush, FourOfAKind and StraightFlush
