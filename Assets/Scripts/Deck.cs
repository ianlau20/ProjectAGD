using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour, IClick
{
    private GameManager gm;
    private ModeManager mm;
    private void Start(){
        gm = FindObjectOfType<GameManager>();
        mm = FindObjectOfType<ModeManager>();
    }
    public void onClickAction() {
        if (mm.mode == "play"){
            gm.DrawCard();
            gm.NextTurn();
        } 
    }
}
