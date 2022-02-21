using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public bool hasBeenPlayed;
    public int handIndex;
    private GameManager gm;

    private void Start(){
        gm = FindObjectOfType<GameManager>();
    }

    public void OnMouseDown(){
        if(hasBeenPlayed == false){
            //play the card
            MoveToPlayedPile();
            hasBeenPlayed = true;
            gm.freeCardSlots[handIndex] = true;
        }
    }

    void MoveToPlayedPile(){
        gm.playedPile.Add(this);
        gameObject.SetActive(false);
    }
}
