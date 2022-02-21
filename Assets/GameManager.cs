using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> playedPile = new List<Card>();
    public Transform[] cardSlots;
    public bool[] freeCardSlots;

    public void DrawCard(){
        Debug.Log("Draw Card Func Called");
        if(deck.Count >= 1){
            Card randCard = deck[Random.Range(0, deck.Count)];

            for (int i = 0; i < freeCardSlots.Length; i++){
                if(freeCardSlots[i] == true){
                    randCard.gameObject.SetActive(true);
                    randCard.handIndex = i;

                    randCard.transform.position = cardSlots[i].position;
                    randCard.hasBeenPlayed = false;

                    freeCardSlots[i] = false;
                    deck.Remove(randCard);
                    return;
                }
            }
        }
    }

    public void Shuffle(){
        if(playedPile.Count >= 1){
            foreach(Card card in playedPile){
                deck.Add(card);
            }
            playedPile.Clear();
        }
    }

}
