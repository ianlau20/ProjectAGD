using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour, IClick
{
    private GameManager gm;
    private void Start(){
        gm = FindObjectOfType<GameManager>();
    }
    public void onClickAction() {
        gm.DrawCard();
        gm.NextTurn();
    }
}
