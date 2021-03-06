using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;

public class GameManager : MonoBehaviour
{
    private ModeManager mm;
    public List<Card> deck = new List<Card>();
    public List<Card> playedPile = new List<Card>();

    public PhysicalPile pileObj;
    public GameObject TopOfPile;
    public Sprite cardBackSprite;
    public Sprite playerSprite;

    // UI
    public GameObject latestCardUI;
    public GameObject WinUI;
    public GameObject LoseUI;
    public GameObject SurvivedUI;
    public GameObject drawButton;
    public GameObject nextPageUI;
    public GameObject previousPageUI;
    public GameObject curTurnSprite;

    public Deck deckObj;
    public Transform[] cardSlots;
    public bool[] freeCardSlots;
    private List<Card> playerHand = new List<Card>();
    public List<MaoHand> enemyHands;

    // Sounds
    public AudioSource UI_Feedback;
    public AudioSource UI_Feedback2;
    public AudioClip SFX_draw;
    public AudioClip SFX_cant_draw;
    public AudioClip SFX_play_card;
    public AudioClip SFX_shuffle;
    public AudioClip SFX_win;
    public AudioClip SFX_lose;
    public AudioClip SFX_survived;
    public AudioClip SFX_effect;
    public AudioClip SFX_death;
    private int TurnIndex = -1;
    private int pageCount = 1;
    private int curPage = 0;
    private Renderer deckRend;
    private Card latestCard;
    private Card currentCard;
    public bool coolDown = false;
    public bool playerLost = false;
    private bool fillEnabled = false;
    private bool reverseEnabled = false;
    private bool successionEnabled = false;
    
    List<Func<bool>> limitRules = new List<Func<bool>>();
    List<Action> abilityRules = new List<Action>();
    List<Action> enableRules = new List<Action>();
    private Vector3 scaleChange = new Vector3(0.00f, 0.001f, 0.00f);
    private Vector3 resetHeight = new Vector3(0.07f, 0.00f, 0.105f);
    private Vector3 resetPos = new Vector3(1.92200005f,0.532400012f,0.725000024f);
    private MaoHand loser;

    void Start(){
        mm = FindObjectOfType<ModeManager>();
        deckRend = deckObj.GetComponent<Renderer>();

        // Create Rule Lists
        Func<bool> rule;
        rule = SameSuitOrVal;
        limitRules.Add(rule);

        System.Random r = new System.Random();
        //TEMPORARY DECREASED TO ONLY INCLUDE 1 & 2
        int ruleSet = r.Next(1, 3);
        Debug.Log("Rule set: " + ruleSet);

        if (ruleSet == 1){
            abilityRules.Add(() => RatSkip(currentCard));
            abilityRules.Add(() => TigerPlusTwo(currentCard));
            enableRules.Add(() => WildDragon(currentCard));
        }
        if (ruleSet == 2){
            abilityRules.Add(() => OxPlusFour(currentCard));
            enableRules.Add(() => ReverseSnake(currentCard));
        }
        if (ruleSet == 3){
            abilityRules.Add(() => MonkeyAllDrawTwo(currentCard));
            enableRules.Add(() => FillDog(currentCard));
            enableRules.Add(() => SuccessionRooster(currentCard));
        }
    }

    public void SetupMatch(){
        Deal();

        // Enable UI
        EndUICoolDown();
    }

    public void DrawCard(){
        if (freeCardSlots[9] == false){
            NewPage();
        }
        UI_Feedback2.clip = SFX_draw;
        UI_Feedback2.Play();

        Card randCard = deck[UnityEngine.Random.Range(0, deck.Count)];

        // Physical Deck Change
        deckObj.transform.localScale -= scaleChange;
        deckObj.transform.position -= scaleChange/2;

        for (int i = 0; i < freeCardSlots.Length; i++){
            // This is a double-check that can prob be removed
            if(freeCardSlots[i] == true){
                randCard.gameObject.SetActive(true);
                randCard.gameObject.GetComponent<Button>().interactable = true;
                randCard.handIndex = i;
                playerHand.Add(randCard);

                randCard.transform.transform.position = cardSlots[i].position;
                randCard.hasBeenPlayed = false;

                freeCardSlots[i] = false;
                deck.Remove(randCard);
                break;
            }
        }
    }

    public void NewPage(){
        for (int i = 0; i < freeCardSlots.Length; i++){
            playerHand[i+(10*(pageCount-1))].gameObject.SetActive(false);
            freeCardSlots[i] = true;
        }
        pageCount++;
        nextPageUI.SetActive(true);
        previousPageUI.SetActive(true);
        curPage = pageCount-1;
    }

    public void RemovePage(){
        pageCount--;
        if (curPage == pageCount){
            curPage = pageCount-1;
        }
        for (int i = 0; i < freeCardSlots.Length; i++){
            playerHand[i+(10*(pageCount-1))].gameObject.SetActive(true);
            freeCardSlots[i] = false;
        }
        if (pageCount == 1){
            nextPageUI.SetActive(false);
            previousPageUI.SetActive(false);
        }
    }

    public void BackPage(){
        // if no previous page do nothing
        if (curPage == 0){
            return;
        }

        // turn off current page
        int startInd = 10*(curPage);
        while (startInd < playerHand.Count){
            playerHand[startInd].gameObject.SetActive(false);
            startInd++;
        }
        curPage--;
        //turn on previous
        for (int i = 0; i < freeCardSlots.Length; i++){
            playerHand[i+(10*curPage)].gameObject.SetActive(true);
            freeCardSlots[i] = false;
        }
    }

    public void NextPage(){
        // if no next page do nothing
        if (curPage >= pageCount-1){
            return;
        }

        // turn off current page
        int startInd = 10*(curPage);
        while (startInd < playerHand.Count){
            playerHand[startInd].gameObject.SetActive(false);
            startInd++;
        }
        curPage++;

        //turn on next
        for (int i = 0; i < freeCardSlots.Length; i++){
            if (i+(10*curPage) < playerHand.Count){
                playerHand[i+(10*curPage)].gameObject.SetActive(true);
            }
            freeCardSlots[i] = false;
        }
    }

    public void SlideCards(int removedCardInd){
        bool wasOnLastPage = (curPage == pageCount-1 && pageCount > 1);
        // If last page empty remove a page
        if (playerHand.Count % 10 == 0){
            RemovePage();
        }

        if (wasOnLastPage){
            return;
        }

        // Else Slide cards NOTE: might not have to mess with freeCardSlots so much
        int checkedPage = curPage;
        int checkedInd = removedCardInd;
        int slotInd = removedCardInd % 10;
        while (checkedInd < playerHand.Count){
            for (int i = slotInd; i < freeCardSlots.Length; i++){
                if (checkedInd > playerHand.Count-1){
                    break;
                }

                //change pos
                playerHand[checkedInd].transform.transform.position = cardSlots[i].position;

                //show slid card if necessary
                if (checkedPage == curPage){
                    playerHand[checkedInd].gameObject.SetActive(true);
                }
                
                playerHand[checkedInd].handIndex--;
                freeCardSlots[i] = false;

                // open up slot where card was just moved from
                if (i != freeCardSlots.Length-1){
                    freeCardSlots[i+1] = true;
                }
                else if(checkedPage != pageCount-1){
                    freeCardSlots[0] = true;
                }

                checkedInd++;
            }
            checkedPage++;
            slotInd = 0;
        }

        if (deck.Count < 1){
            deckRend.enabled = false;
            Shuffle();
        }
    }

    public void DrawCardAI(){
        UI_Feedback2.clip = SFX_draw;
        UI_Feedback2.Play();

        Card randCard = deck[UnityEngine.Random.Range(0, deck.Count)];
        randCard.gameObject.SetActive(true);
        // Dont show AI cards on screen
        randCard.gameObject.transform.position = new Vector3(1000f, 10000f, 0f);

        // Physical Deck Change
        deckObj.transform.localScale -= scaleChange;
        deckObj.transform.position -= scaleChange/2;

        randCard.hasBeenPlayed = false;
        enemyHands[TurnIndex].AddToHand(randCard);
        deck.Remove(randCard);

        if (deck.Count < 1){
            deckRend.enabled = false;
            Shuffle();
        }
    }

    public void PlayCard(Card playedCard){
        if (coolDown && playerHand.Contains(playedCard)){
            return;
        }

        // Test enabling rules
        EnableRuleCheck(playedCard);

        // If not a valid card, draw & end turn
        if(!IsValidCard(playedCard)){
            UI_Feedback.clip = SFX_cant_draw;
            UI_Feedback.Play();
            DrawCorrect();
            NextTurn();
            return;
        }

        UI_Feedback.clip = SFX_play_card;
        UI_Feedback.Play();

        //Remove card from corresponding hand
        if (TurnIndex == -1){
            freeCardSlots[playedCard.handIndex%10] = true;
            playerHand.Remove(playedCard);
            // Slide all cards left if didnt win
            if (playerHand.Count != 0){
                SlideCards(playedCard.handIndex);
            }
        }
        else{
            enemyHands[TurnIndex].currHand.Remove(playedCard);
        }


        // Show the pile and top card
        pileObj.gameObject.SetActive(true);
        TopOfPile.SetActive(true);
        TopOfPile.GetComponent<SpriteRenderer>().sprite = playedCard.GetComponent<Image>().sprite;
        latestCardUI.GetComponent<Image>().sprite = playedCard.GetComponent<Image>().sprite;

        // Make physical adjustments
        playedPile.Add(playedCard);
        pileObj.transform.localScale += scaleChange;
        pileObj.transform.position += scaleChange/2;
        TopOfPile.transform.position = pileObj.transform.position + new Vector3(0f, (0.001f + pileObj.transform.localScale.y/2), 0f);

        // Apply all card abilities
        CardAbilities(playedCard);

        // Turn off card
        playedCard.MoveToPlayedPile();
        latestCard = playedCard;  

        NextTurn();
    }

    public void NextTurn(){
        // End game if winner
        if(CheckForWinner()){
            CleanMatch();
            return;
        }

        IncTurnIndex();
        if (successionEnabled){
            DecTurnIndex();
            successionEnabled = false;
            UI_Feedback.clip = SFX_effect;
            UI_Feedback.Play();
        }

        // If not player turn, play AI
        if (TurnIndex != -1){
            Debug.Log("TurnIndex = " + TurnIndex);
            curTurnSprite.GetComponent<Image>().sprite = enemyHands[TurnIndex].ownerSprite;
            StartUICoolDown();
            DelayedPlay();
        }
        else{
            curTurnSprite.GetComponent<Image>().sprite = playerSprite;
            EndUICoolDown();
        }
    }

    

    private bool CheckForWinner(){
        if (playerHand.Count == 0){
            FindLoser();
            return true;
        }
        foreach(MaoHand mh in enemyHands){
            if (mh.currHand.Count == 0){
                FindLoser();
                return true;
            }
        }
        return false;
    }

    // find and remove the loser from the game
    private void FindLoser(){
        int mostCards = playerHand.Count;
        bool playerWon = false;
        bool playerSurvived = false;
        loser = enemyHands[0];

        // Find the loser
        foreach(MaoHand mh in enemyHands){
            if (mh.currHand.Count >= mostCards){
                loser = mh;
                mostCards = loser.currHand.Count;
                playerSurvived = true;
            }
        }

        // check if player won
        if (playerHand.Count == 0){
            UI_Feedback.clip = SFX_win;
            UI_Feedback.Play();
            WinUI.SetActive(true);
            playerWon = true;
        }

        // remove who lost
        if (playerSurvived == false && playerWon == false){
            UI_Feedback.clip = SFX_lose;
            UI_Feedback.Play();
            LoseUI.SetActive(true);
            //Delayed game restart
            DelayedRestart();
            playerLost = true;
            return;
        }
        else {
            if (!playerWon){
                //UI_Feedback.clip = SFX_survived;
                //UI_Feedback.Play();
                SurvivedUI.SetActive(true);
            }
            //play dying sound
            UI_Feedback.clip = SFX_death;
            UI_Feedback.Play();
            return;
        }
    }

    // Perform game clean up
    private void CleanMatch(){

        // Move cards from hands/playedPile to deck
        foreach (Card c in playerHand){
            deck.Add(c);
            c.hasBeenPlayed = false;

            // Physical Deck Change
            deckRend.enabled = true;
            deckObj.transform.localScale += scaleChange;
            deckObj.transform.position += scaleChange/2;
        }
        playerHand.Clear();
        foreach (MaoHand mh in enemyHands){
            foreach(Card c in mh.currHand){
                deck.Add(c);
            }
            mh.currHand.Clear();
            mh.ClearCardBacks();
        }

        // Reset Latest Card & Physical Deck/Play Pile
        latestCard = null;
        latestCardUI.GetComponent<Image>().sprite = cardBackSprite;

        // Takes care of cards in play pile
        Shuffle();


        // Hide all cards
        foreach(Card c in deck){
            c.hasBeenPlayed = false;
            c.gameObject.SetActive(false);
        }

        // Have the next game start with the player
        TurnIndex = -1;

        // REMOVE LOSER
        if (!playerLost){
            loser.gameObject.transform.parent.gameObject.SetActive(false);
            enemyHands.Remove(loser);
        }
        

        // <<LATER ADD SYSTEM THAT ALLOWS PLAYER TO CHOOSE NEW RULE>>


        // Clean open slots & pages
        for (int i = 0; i < freeCardSlots.Length; i++){
            freeCardSlots[i] = true;
        }
        curPage = 0;
        pageCount = 1;
        nextPageUI.SetActive(false);
        previousPageUI.SetActive(false);

        if (enemyHands.Count == 0){
            DelayedStartOutro();
        }
        else{
            DelayedStartTransition();
        }
    }

    // Deal Cards
    private void Deal(){
        for (int i = 0; i < 5; i++){
            DrawCorrect();
            IncTurnIndex();
            foreach(MaoHand h in enemyHands){
                DrawCorrect();
                IncTurnIndex();
            }
            TurnIndex = -1;
        }
    }

    public void Shuffle(){
        UI_Feedback2.clip = SFX_shuffle;
        UI_Feedback2.Play();
        pileObj.transform.localScale = resetHeight;
        pileObj.transform.position = resetPos;
        pileObj.gameObject.SetActive(false);
        TopOfPile.SetActive(false);
        foreach(Card card in playedPile){
            deck.Add(card);
            card.hasBeenPlayed = false;

            // Physical Deck Change
            deckRend.enabled = true;
            deckObj.transform.localScale += scaleChange;
            deckObj.transform.position += scaleChange/2;
        }
        playedPile.Clear();
    }

    // Check if card shares suit or value
    private bool IsValidCard(Card c){
        if (fillEnabled){
            UI_Feedback2.clip = SFX_effect;
            UI_Feedback2.Play();
        }

        // Special ability so card is valid
        if (latestCard == null || fillEnabled){
            fillEnabled = false;
            return true;
        }

        currentCard = c;
        // Rules that check if card is valid
        foreach (Func<bool> lRule in limitRules){
            if(!lRule()){
                successionEnabled = false;
                return false;
            }
        }
        
        // No rules returned false so the card is valid
        return true;
    }

    private void CardAbilities(Card c){
        currentCard = c;
        foreach (Action aRule in abilityRules){
            aRule();
        }
    }

    private void EnableRuleCheck(Card c){
        currentCard = c;
        foreach (Action aRule in enableRules){
            aRule();
        }
    }

    // ENABLING RULES
    private void WildDragon(Card c){
        if (c.value == "dragon"){
            fillEnabled = true;
        }
    }

    private void ReverseSnake(Card c){
        if (c.value == "snake"){
            reverseEnabled = !reverseEnabled;
            UI_Feedback2.clip = SFX_effect;
            UI_Feedback2.Play();
        }
    }

    private void WildOx(Card c){
        if (c.value == "ox"){
            fillEnabled = true;
        }
    }

    private void FillDog(Card c){
        if (c.value == "dog"){
            fillEnabled = true;
        }
    }

    private void SuccessionRooster(Card c){
        if (c.value == "rooster"){
            successionEnabled = true;
        }
    }

    // LIMIT RULES
    private bool SameSuitOrVal(){
        if (currentCard.suit == latestCard.suit || currentCard.value == latestCard.value){
            return true;
        }
        else{
            return false;
        }
    }

    // ABILITY RULES
    private void RatSkip(Card c){
        if (c.value == "rat"){
            IncTurnIndex();
            UI_Feedback2.clip = SFX_effect;
            UI_Feedback2.Play();
        }
    }
    private void TigerPlusTwo(Card c){
        if (c.value == "tiger"){
            Debug.Log("Played a tiger!");
            IncTurnIndex();
            DrawCorrect();
            DrawCorrect();
            DecTurnIndex();
            UI_Feedback2.clip = SFX_effect;
            UI_Feedback2.Play();
        }
    }

    private void OxPlusFour(Card c){
        if (c.value == "ox"){
            IncTurnIndex();
            DrawCorrect();
            DrawCorrect();
            DrawCorrect();
            DrawCorrect();
            DecTurnIndex();
            UI_Feedback2.clip = SFX_effect;
            UI_Feedback2.Play();
        }
    }

    private void MonkeyAllDrawTwo(Card c){
        if (c.value == "monkey"){
            int i = 0;
            while (i < enemyHands.Count){
                IncTurnIndex();
                DrawCorrect();
                DrawCorrect();
                i++;
            }
            IncTurnIndex();
            UI_Feedback2.clip = SFX_effect;
            UI_Feedback2.Play();
        }
    }

    // Call appropriate Draw function based on turn
    private void DrawCorrect(){
        if (TurnIndex == -1){
            DrawCard();
        }
        else{
            DrawCardAI();
        }
    }

    private void StartUICoolDown(){
        foreach(Card c in playerHand){
            c.gameObject.GetComponent<Button>().interactable = false;
        }
        drawButton.GetComponent<Button>().interactable = false;
        coolDown = true;
    }
    private void EndUICoolDown(){
        foreach(Card c in playerHand){
            c.gameObject.GetComponent<Button>().interactable = true;
        }
        drawButton.GetComponent<Button>().interactable = true;
        coolDown = false;
    }

    private void IncTurnIndex(){
        // Not reversed
        if (!reverseEnabled){
            if (TurnIndex < enemyHands.Count-1){
                TurnIndex++;
            }
            else{
                TurnIndex = -1;
            }
        }

        // Reversed
        else{
            if (TurnIndex != -1){
                TurnIndex--;
            }
            else{
                TurnIndex = enemyHands.Count-1;
            }
        }
    }

    private void DecTurnIndex(){
        // Not reversed
        if (!reverseEnabled){
            if (TurnIndex != -1){
                TurnIndex--;
            }
            else{
                TurnIndex = enemyHands.Count-1;
            }
        }

        // Reversed
        else {
            if (TurnIndex < enemyHands.Count-1){
                TurnIndex++;
            }
            else{
                TurnIndex = -1;
            }
        }
    }

    private async Task DelayedPlay()
    {
        await Task.Delay(1250);
        enemyHands[TurnIndex].Play();
    }

    private async Task DelayedEndUICooldown(){
        await Task.Delay(3750);
        EndUICoolDown();
    }

    private async Task DelayedHideWin(){
        await Task.Delay(3000);
        WinUI.SetActive(false);
    }

    private async Task DelayedHideLose(){
        await Task.Delay(3000);
        LoseUI.SetActive(false);
    }

    private async Task DelayedStartTransition(){
        await Task.Delay(3000);
        mm.StartTransition();
    }

    private async Task DelayedStartOutro(){
        await Task.Delay(3000);
        mm.StartEnding();
    }

    private async Task DelayedRestart(){
        await Task.Delay(3000);
        SceneManager.LoadScene(0);
    }

    public Card GetLatestCard(){
        return latestCard;
    }

    // Reload current scene
    public void RestartGame() {
        SceneManager.LoadScene(0);
    }
}
