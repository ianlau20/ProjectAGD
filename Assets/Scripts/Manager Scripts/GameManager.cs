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

    // UI
    public GameObject latestCardUI;
    public GameObject WinUI;
    public GameObject LoseUI;
    public GameObject drawButton;
    public GameObject nextPageUI;
    public GameObject previousPageUI;

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
    public AudioClip SFX_effect;
    private int TurnIndex = -1;
    private int pageCount = 1;
    private int curPage = 0;
    private Renderer deckRend;
    private Card latestCard;
    private Card currentCard;
    public bool coolDown = false;
    private bool fillEnabled = false;
    private bool reverseEnabled = false;
    private bool successionEnabled = false;
    
    List<Func<bool>> limitRules = new List<Func<bool>>();
    List<Action> abilityRules = new List<Action>();
    List<Action> enableRules = new List<Action>();
    private Vector3 scaleChange = new Vector3(0.00f, 0.0025f, 0.00f);
    private Vector3 resetHeight = new Vector3(0.07f, 0.00f, 0.105f);
    private Vector3 resetPos = new Vector3(2f, 0.59f, -0.5f);

    void Start(){
        mm = FindObjectOfType<ModeManager>();
        deckRend = deckObj.GetComponent<Renderer>();
    }

    public void SetupMatch(){
        Deal();

        // Create Rule Lists
        Func<bool> rule;
        rule = SameSuitOrVal;
        limitRules.Add(rule);

        System.Random r = new System.Random();
        int ruleSet = r.Next(1, 4);
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

        // Enable UI
        foreach(Card c in playerHand){
            c.gameObject.GetComponent<Button>().interactable = true;
        }
        drawButton.GetComponent<Button>().interactable = true;
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
    }

    public void PlayCard(Card playedCard){
        if (coolDown && playerHand.Contains(playedCard)){
            return;
        }


        if (TurnIndex == -1){
            // Start UI Cooldown
            coolDown = true;
            foreach(Card c in playerHand){
                c.gameObject.GetComponent<Button>().interactable = false;
            }
            drawButton.GetComponent<Button>().interactable = false;
            DelayedEndUICooldown();
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
        }

        if (deck.Count == 0){
            deckRend.enabled = false;
            Shuffle();
        }
        // If not player turn, play AI
        if (TurnIndex != -1){
            Debug.Log("TurnIndex = " + TurnIndex);
            DelayedPlay();
        }
    }

    

    private bool CheckForWinner(){
        if (playerHand.Count == 0){
            UI_Feedback.clip = SFX_win;
            UI_Feedback.Play();
            WinUI.SetActive(true);
            DelayedHideWin();
            return true;
        }
        foreach(MaoHand mh in enemyHands){
            if (mh.currHand.Count == 0){
                UI_Feedback.clip = SFX_lose;
                UI_Feedback.Play();
                LoseUI.SetActive(true);
                DelayedHideLose();
                return true;
            }
        }
        return false;
    }

    // Perform game clean up
    private void CleanMatch(){

        // Move cards from hands/playedPile to deck
        foreach (Card c in playerHand){
            deck.Add(c);
        }
        playerHand.Clear();
        foreach (MaoHand mh in enemyHands){
            foreach(Card c in mh.currHand){
                deck.Add(c);
            }
            mh.currHand.Clear();
            mh.ClearCardBacks();
        }
        foreach(Card c in playedPile){
            deck.Add(c);
        }
        playedPile.Clear();

        // Reset Latest Card & Physical Deck/Play Pile
        latestCard = null;
        latestCardUI.GetComponent<Image>().sprite = cardBackSprite;
        Shuffle();


        // Hide all cards
        foreach(Card c in deck){
            c.hasBeenPlayed = false;
            c.gameObject.SetActive(false);
        }

        // Have the next game start with the player
        TurnIndex = -1;

        // Clear match rules
        limitRules.Clear();
        abilityRules.Clear();
        enableRules.Clear();

        // <<HAVE SOMETHING THAT REMOVES THE LOSER>>
        // <<LATER ADD SYSTEM THAT ALLOWS PLAYER TO CHOOSE NEW RULE>>

        // Clean open slots & pages
        for (int i = 0; i < freeCardSlots.Length; i++){
            freeCardSlots[i] = true;
        }
        curPage = 0;
        pageCount = 1;
        nextPageUI.SetActive(false);
        previousPageUI.SetActive(false);

        mm.StartChatMode();
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
        UI_Feedback.clip = SFX_shuffle;
        UI_Feedback.Play();
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
        if (latestCard == null || fillEnabled){
            fillEnabled = false;
            return true;
        }

        currentCard = c;
        // Rules that check if card is valid
        foreach (Func<bool> lRule in limitRules){
            if(!lRule()){
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
            UI_Feedback.clip = SFX_effect;
            UI_Feedback.Play();
        }
    }

    private void ReverseSnake(Card c){
        if (c.value == "snake"){
            reverseEnabled = !reverseEnabled;
            UI_Feedback.clip = SFX_effect;
            UI_Feedback.Play();
        }
    }

    private void WildOx(Card c){
        if (c.value == "ox"){
            fillEnabled = true;
            UI_Feedback.clip = SFX_effect;
            UI_Feedback.Play();
        }
    }

    private void FillDog(Card c){
        if (c.value == "dog"){
            fillEnabled = true;
            UI_Feedback.clip = SFX_effect;
            UI_Feedback.Play();
        }
    }

    private void SuccessionRooster(Card c){
        if (c.value == "rooster"){
            successionEnabled = true;
            UI_Feedback.clip = SFX_effect;
            UI_Feedback.Play();
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
            UI_Feedback.clip = SFX_effect;
            UI_Feedback.Play();
        }
    }
    private void TigerPlusTwo(Card c){
        if (c.value == "tiger"){
            Debug.Log("Played a tiger!");
            IncTurnIndex();
            DrawCorrect();
            DrawCorrect();
            DecTurnIndex();
            UI_Feedback.clip = SFX_effect;
            UI_Feedback.Play();
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
            UI_Feedback.clip = SFX_effect;
            UI_Feedback.Play();
        }
    }

    private void MonkeyAllDrawTwo(Card c){
        if (c.value == "monkey"){
            while (TurnIndex != -1){
                IncTurnIndex();
                DrawCorrect();
                DrawCorrect();
            }
            UI_Feedback.clip = SFX_effect;
            UI_Feedback.Play();
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

    public Card GetLatestCard(){
        return latestCard;
    }

    // Reload current scene
    public void RestartGame() {
        SceneManager.LoadScene(0);
    }
}
