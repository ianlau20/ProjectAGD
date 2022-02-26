using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> playedPile = new List<Card>();

    public PhysicalPile pileObj;
    public GameObject TopOfPile;
    public GameObject latestCardUI;
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
    private bool dealing = true;
    private Card latestCard;
    private List<Card> playerHand = new List<Card>();
    private Vector3 scaleChange = new Vector3(0.00f, 0.0025f, 0.00f);
    private Vector3 resetHeight = new Vector3(0.10f, 0.00f, 0.15f);
    private Vector3 resetPos = new Vector3(2f, 0.59f, -0.5f);

    void Start(){
        deckRend = deckObj.GetComponent<Renderer>();
        Deal();
    }

    public void DrawCard(){
        if(freeCardSlots[freeCardSlots.Length-1] == true){
            UI_Feedback2.clip = SFX_draw;
            UI_Feedback2.Play();

            Card randCard = deck[Random.Range(0, deck.Count)];

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
            if(!dealing)
                NextTurn();
            return;
        }
    }

    public void DrawCardAI(){
        Debug.Log("DrawCardAI Called");
        if(enemyHands[TurnIndex].currHand.Count < 14){
            UI_Feedback2.clip = SFX_draw;
            UI_Feedback2.Play();

            Card randCard = deck[Random.Range(0, deck.Count)];
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
        if(!dealing)
            NextTurn();
        return;
    }

    public void PlayCard(Card playedCard){
        // If not a valid card, draw & end turn
        if(!IsValidCard(playedCard)){
            UI_Feedback.clip = SFX_cant_draw;
            UI_Feedback.Play();
            DrawCorrect();
            return;
        }

        UI_Feedback.clip = SFX_play_card;
        UI_Feedback.Play();

        if (TurnIndex == -1){
            freeCardSlots[playedCard.handIndex] = true;
            playerHand.Remove(playedCard);
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

        // Turn off card
        playedCard.MoveToPlayedPile();
        latestCard = playedCard;
        
        // End turn
        NextTurn();
    }

    private void NextTurn(){
        CheckForWinner();
        TurnIndex++;
        if (deck.Count == 0){
            deckRend.enabled = false;
            Shuffle();
        }
        // If not player turn, play AI
        Debug.Log("hands.Count = " + enemyHands.Count);
        if (TurnIndex < enemyHands.Count){
            Debug.Log("TurnIndex = " + TurnIndex);
            DelayedPlay();
        }
        // Else reset index and let player play
        else {
            TurnIndex = -1;
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
        }
        foreach(MaoHand mh in enemyHands){
            if (mh.currHand.Count == 0){
                UI_Feedback.clip = SFX_lose;
                UI_Feedback.Play();
            }
        }
    }

    // Deal Cards
    private void Deal(){
        for (int i = 0; i < 5; i++){
            DrawCorrect();
            TurnIndex++;
            foreach(MaoHand h in enemyHands){
                DrawCorrect();
                TurnIndex++;
            }
            TurnIndex = -1;
        }
        dealing = false;
    }

    // Check if card shares suit or value
    private bool IsValidCard(Card c){
        if (latestCard == null){
            return true;
        }
        if (c.suit == latestCard.suit || c.value == latestCard.value){
            return true;
        }
        else{
            return false;
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
    private async Task DelayedPlay()
    {
        await Task.Delay(500);
        enemyHands[TurnIndex].Play();
    }

    public Card GetLatestCard(){
        return latestCard;
    }
}
