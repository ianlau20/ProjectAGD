using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaoHand : MonoBehaviour
{
    public List<Card> currHand;
    public List<GameObject> cardBacks;
    public GameObject cardBack;
    public Vector3 nextCardPos;
    private GameManager gm;

    private void Start(){
        gm = FindObjectOfType<GameManager>();
    }

    public void Play(){
        char lastSuit = gm.GetLatestCard().suit;
        int lastVal = gm.GetLatestCard().value;

        // If has playable card, play it
        foreach(Card c in currHand){
            if (c.suit == lastSuit || c.value == lastVal){
                c.UseCard();
                currHand.Remove(c);
                Destroy(cardBacks[cardBacks.Count-1]);
                cardBacks.RemoveAt(cardBacks.Count-1);
                nextCardPos -= new Vector3(0.1f, 0f, 0f);
                return;
            }
        }

        // Else draw card
        gm.DrawCardAI();        
    }

    public void AddToHand(Card c){
        currHand.Add(c);
        GameObject cb = GameObject.Instantiate(cardBack);
        cardBacks.Add(cb);
        cardBacks[cardBacks.Count-1].transform.position = nextCardPos;
        nextCardPos += new Vector3(0.1f, 0f, 0f);
    }
}
