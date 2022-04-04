using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public char suit;
    public string value;
    public bool hasBeenPlayed;
    public int handIndex;
    private GameManager gm;

    private void Start(){
        gm = FindObjectOfType<GameManager>();
    }

    public void UseCard(){
        if(hasBeenPlayed == false){
            //play the card
            gm.PlayCard(this);
        }
    }

    public void MoveToPlayedPile(){
        hasBeenPlayed = true;
        gameObject.SetActive(false);
    }
}
