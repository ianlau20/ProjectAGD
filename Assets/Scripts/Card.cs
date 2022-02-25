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

    public void UseCard(){
        if(hasBeenPlayed == false){
            //play the card
            MoveToPlayedPile();
            hasBeenPlayed = true;
            
        }
    }

    void MoveToPlayedPile(){
        gm.PlayCard(this);
        gameObject.SetActive(false);
    }
}