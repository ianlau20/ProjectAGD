using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaoHand : MonoBehaviour
{
    public List<Card> currHand;
    private GameManager gm;

    private void Start(){
        gm = FindObjectOfType<GameManager>();
    }

    public void Play(){
        // Fake AI
        if (currHand.Count == 0) {
            gm.DrawCardAI();
            return;
        }
        currHand[0].UseCard();
        currHand.RemoveAt(0);
        return;
    }
}
