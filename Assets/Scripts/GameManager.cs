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
    public Deck deckObj;
    public Transform[] cardSlots;
    public bool[] freeCardSlots;
    public List<MaoHand> hands;
    private int TurnIndex = -1;
    private Renderer deckRend;
    private bool dealing = true;
    private Card latestCard;
    private Vector3 scaleChange = new Vector3(0.00f, 0.0025f, 0.00f);
    private Vector3 resetHeight = new Vector3(0.10f, 0.00f, 0.15f);
    private Vector3 resetPos = new Vector3(2f, 0.59f, -0.5f);

    void Start(){
        deckRend = deckObj.GetComponent<Renderer>();
        for (int i = 0; i < 5; i++){
            DrawCard();
            TurnIndex++;
            foreach(MaoHand h in hands){
                DrawCardAI();
                TurnIndex++;
            }
            TurnIndex = -1;
        }
        dealing = false;
    }

    public void DrawCard(){
        if(freeCardSlots[freeCardSlots.Length-1] == true){
            Card randCard = deck[Random.Range(0, deck.Count)];

            // Physical Deck Change
            deckObj.transform.localScale -= scaleChange;
            deckObj.transform.position -= scaleChange/2;

            for (int i = 0; i < freeCardSlots.Length; i++){
                // This is a double-check that can prob be removed
                if(freeCardSlots[i] == true){
                    randCard.gameObject.SetActive(true);
                    randCard.handIndex = i;

                    randCard.transform.transform.position = cardSlots[i].position;
                    randCard.hasBeenPlayed = false;

                    freeCardSlots[i] = false;
                    deck.Remove(randCard);

                    if(!dealing)
                        NextTurn();
                    return;
                }
            }
        }
    }

    public void DrawCardAI(){
        Debug.Log("DrawCardAI Called");
        if(hands[TurnIndex].currHand.Count < 7){
            Card randCard = deck[Random.Range(0, deck.Count)];
            randCard.gameObject.SetActive(true);
            // Dont show AI cards on screen
            randCard.gameObject.transform.position = new Vector3(1000f, 10000f, 0f);

            // Physical Deck Change
            deckObj.transform.localScale -= scaleChange;
            deckObj.transform.position -= scaleChange/2;

            randCard.hasBeenPlayed = false;
            hands[TurnIndex].AddToHand(randCard);
            deck.Remove(randCard);

        }
        if(!dealing)
            NextTurn();
        return;
    }

    public void PlayCard(Card playedCard){
        if (TurnIndex == -1){
            freeCardSlots[playedCard.handIndex] = true;
        }

        // Show the pile and top card
        pileObj.gameObject.SetActive(true);
        TopOfPile.SetActive(true);
        TopOfPile.GetComponent<SpriteRenderer>().sprite = playedCard.GetComponent<Image>().sprite;

        // Make physical adjustments
        playedPile.Add(playedCard);
        pileObj.transform.localScale += scaleChange;
        pileObj.transform.position += scaleChange/2;
        TopOfPile.transform.position = pileObj.transform.position + new Vector3(0f, (0.001f + pileObj.transform.localScale.y/2), 0f);

        latestCard = playedCard;

        // End turn
        NextTurn();
    }

    private void NextTurn(){
        TurnIndex++;
        if (deck.Count == 0){
            deckRend.enabled = false;
            Shuffle();
        }
        // If not player turn, play AI
        Debug.Log("hands.Count = " + hands.Count);
        if (TurnIndex < hands.Count){
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

    private async Task DelayedPlay()
    {
        await Task.Delay(500);
        hands[TurnIndex].Play();
    }

    public Card GetLatestCard(){
        return latestCard;
    }
}
