using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public string mode;
    private GameManager gm;
    public List<GameObject> gameUI;
    public List<GameObject> chatUI;
    public List<Character> people;
    public List<Camera> cameras;
    public List<GameObject> responseButtons;
    public List<GameObject> responseButtonTexts;
    public Character curPerson;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        StartChat();
    }

    public void StartRound(){
        mode = "play";
        // Switch to main cam
        foreach(Camera cam in cameras){
            cam.gameObject.SetActive(false);
        }
        cameras[0].gameObject.SetActive(true);
        // Turn off chat UI
        foreach(GameObject ui_element in chatUI){
            ui_element.SetActive(false);
        }
        // Turn on game UI
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

        // disable hitboxes in startround()?
    }

    public void Response1(){
        curPerson.Response1();
    }
    public void Response2(){
        curPerson.Response2();
    }
    public void Response3(){
        curPerson.Response3();
    }
}
