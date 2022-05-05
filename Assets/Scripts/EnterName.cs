using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterName : MonoBehaviour
{
    private ModeManager mm;
    public GameObject textField;

    void Start()
    {
        mm = FindObjectOfType<ModeManager>();
    }

    void Update()
    {
        
    }

    public void ReadStringInput(string s){
        mm.username = s;
        Debug.Log(mm.username);
        mm.LoadAllDialogue();
        mm.StartIntro();
        textField.SetActive(false);
    }

}
