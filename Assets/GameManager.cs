using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> playedPile = new List<Card>();

    public PhysicalPile pileObj;
    public Deck deckObj;
    public Renderer deckRend;
    public Transform[] cardSlots;
    public bool[] freeCardSlots;
    private Vector3 scaleChange = new Vector3(0.00f, +0.01f, 0.00f);
    private Vector3 resetHeight = new Vector3(0.10f, 0.00f, 0.15f);
    private Vector3 resetPos = new Vector3(2f, 0.63f, -0.5f);

    void Start(){
        deckRend = deckObj.GetComponent<Renderer>();
    }

    public void DrawCard(){
        Debug.Log("Draw Card Func Called");
        if(deck.Count >= 1 && freeCardSlots[freeCardSlots.Length-1] == true){
            Card randCard = deck[Random.Range(0, deck.Count)];

            // Physical Deck Change
            deckObj.transform.localScale -= scaleChange;
            deckObj.transform.position -= scaleChange/2;

            for (int i = 0; i < freeCardSlots.Length; i++){
                if(freeCardSlots[i] == true){
                    randCard.gameObject.SetActive(true);
                    randCard.handIndex = i;

                    randCard.transform.position = cardSlots[i].position;
                    randCard.hasBeenPlayed = false;

                    freeCardSlots[i] = false;
                    deck.Remove(randCard);
                    if (deck.Count == 0){
                        deckRend.enabled = false;
                    }
                    return;
                }
            }
        }
    }

    public void PlayCard(Card playedCard){
        pileObj.gameObject.SetActive(true);
        playedPile.Add(playedCard);
        pileObj.transform.localScale += scaleChange;
        pileObj.transform.position += scaleChange/2;
    }

    public void Shuffle(){
        if(playedPile.Count >= 1){
            pileObj.transform.localScale = resetHeight;
            pileObj.transform.position = resetPos;
            pileObj.gameObject.SetActive(false);
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

}
