using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour, IClick
{
    public void onClickAction() {
        Debug.Log("Clicking Deck");
        Destroy(gameObject);
    }
}
