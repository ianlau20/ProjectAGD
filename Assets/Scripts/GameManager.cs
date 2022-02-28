using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;

public class GameManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> playedPile = new List<Card>();

    public PhysicalPile pileObj;
    public GameObject TopOfPile;
    public GameObject latestCardUI;
    public GameObject WinUI;
    public GameObject LoseUI;
    public Deck deckObj;
    public Transform[] cardSlots;
    public bool[] freeCardSlots;
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
    private int TurnIndex = -1;
    private Renderer deckRend;
    private Card latestCard;
    private Card currentCard;
    private List<Card> playerHand = new List<Card>();
    List<Func<bool>> limitRules = new List<Func<bool>>();
    List<Action> abilityRules = new List<Action>();
    private Vector3 scaleChange = new Vector3(0.00f, 0.0025f, 0.00f);
    private Vector3 resetHeight = new Vector3(0.10f, 0.00f, 0.15f);
    private Vector3 resetPos = new Vector3(2f, 0.59f, -0.5f);

    void Start(){
        deckRend = deckObj.GetComponent<Renderer>();
        Deal();

        // Create Rule Lists
        Func<bool> rule;
        rule = SameSuitOrVal;
        limitRules.Add(rule);
        abilityRules.Add(() => AceSkip(currentCard));
        abilityRules.Add(() => SevenPlusOne(currentCard));
    }

    public void DrawCard(){
        if(freeCardSlots[freeCardSlots.Length-1] == true){
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
    }

    public void DrawCardAI(){
        if(enemyHands[TurnIndex].currHand.Count < 14){
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
    }

    public void PlayCard(Card playedCard){
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
            freeCardSlots[playedCard.handIndex] = true;
            playerHand.Remove(playedCard);
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
        CheckForWinner();
        IncTurnIndex();
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

    public void Shuffle(){
        if(playedPile.Count >= 1){
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
    }

    private void CheckForWinner(){
        if (playerHand.Count == 0){
            UI_Feedback.clip = SFX_win;
            UI_Feedback.Play();
            WinUI.SetActive(true);
        }
        foreach(MaoHand mh in enemyHands){
            if (mh.currHand.Count == 0){
                UI_Feedback.clip = SFX_lose;
                UI_Feedback.Play();
                LoseUI.SetActive(true);
            }
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

    // Check if card shares suit or value
    private bool IsValidCard(Card c){
        if (latestCard == null){
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
    private void AceSkip(Card c){
        if (c.value == 1){
            IncTurnIndex();
        }
    }
    private void SevenPlusOne(Card c){
        if (c.value == 7){
            Debug.Log("Played a seven!");
            IncTurnIndex();
            DrawCorrect();
            DecTurnIndex();
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

    private void IncTurnIndex(){
        if (TurnIndex < enemyHands.Count-1){
            TurnIndex++;
        }
        else{
            TurnIndex = -1;
        }
    }

    private void DecTurnIndex(){
        if (TurnIndex != -1){
            TurnIndex--;
        }
        else{
            TurnIndex = enemyHands.Count-1;
        }
    }

    private async Task DelayedPlay()
    {
        await Task.Delay(750);
        enemyHands[TurnIndex].Play();
    }

    public Card GetLatestCard(){
        return latestCard;
    }

    // Reload current scene
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
