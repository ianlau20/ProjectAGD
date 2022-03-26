using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    private string mode;
    private GameManager gm;
    public List<GameObject> gameUI;
    public List<Character> people;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        StartChat();
    }

    public void StartRound(){
        mode = "play";
        foreach(GameObject ui_element in gameUI){
            ui_element.SetActive(true);
        }
        gm.GetComponent<GameManager>().enabled = true;
    }

    public void StartChat(){
        mode = "chat";
        foreach(GameObject ui_element in gameUI){
            ui_element.SetActive(false);
        }
        gm.GetComponent<GameManager>().enabled = false;

        // disable hitboxes
    }
}
