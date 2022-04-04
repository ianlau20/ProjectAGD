using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaoHand : MonoBehaviour
{
    public List<Card> currHand;
    public List<GameObject> cardBacks;
    public GameObject cardBack;
    public Vector3 nextCardPos;
    public Vector3 cardShift;
    public int cardRotation;
    private GameManager gm;

    private void Start(){
        gm = FindObjectOfType<GameManager>();
    }

    public void Play(){
        // If no previous card, play anything
        if (gm.GetLatestCard() == null){
            UpdateAndPlay(currHand[0]);
            return;
        }

        char lastSuit = gm.GetLatestCard().suit;
        string lastVal = gm.GetLatestCard().value;

        // If hand has valid ace, play it
        foreach(Card c in currHand){
            if ((c.suit == lastSuit || c.value == lastVal) && c.value == "cat"){
                UpdateAndPlay(c);
                return;
            }
        }

        // If hand has playable card, play it
        foreach(Card c in currHand){
            if (c.suit == lastSuit || c.value == lastVal){
                UpdateAndPlay(c);
                return;
            }
        }

        // Else draw card
        gm.DrawCardAI();
        gm.NextTurn();     
    }

    public void AddToHand(Card c){
        currHand.Add(c);
        GameObject cb = GameObject.Instantiate(cardBack);
        cardBacks.Add(cb);
        cardBacks[cardBacks.Count-1].transform.position = nextCardPos;
        cardBacks[cardBacks.Count-1].transform.Rotate(0, cardRotation, 0);
        nextCardPos += cardShift;
    }

    private void UpdateAndPlay(Card c){
        c.UseCard();
        Destroy(cardBacks[cardBacks.Count-1]);
        cardBacks.RemoveAt(cardBacks.Count-1);
        nextCardPos -= cardShift;
    }
}
