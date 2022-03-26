using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IClick
{
    private ModeManager mm;

    // Start is called before the first frame update
    void Start()
    {
        mm = FindObjectOfType<ModeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickAction() {
        mm.StartRound();
    }
}
