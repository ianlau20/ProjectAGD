using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharCody : Character, IClick
{
    protected ModeManager mm;
    public AudioSource UI_Feedback;
    public AudioClip SFX_clicked;

    // Start is called before the first frame update
    void Start()
    {
        mm = FindObjectOfType<ModeManager>();
        curLine = 0;
        sequence1 = new List<string>();
        responses = new List<List<string>>();
        sequence1.Add("What do you want?");
        responses.Add(new List<string> {"Uhh.", "Nothing..."});
        sequence1.Add("Beat it.");
        responses.Add(new List<string> {"Sorry.", "Whatever."});
    }

    public void onClickAction() {
        // Open Dialogue
        StartTalk();
        UI_Feedback.clip = SFX_clicked;
        UI_Feedback.Play();
    }

    private void StartTalk(){
        mm.curPerson = this;
        mm.cameras[0].gameObject.SetActive(false);
        mm.cameras[3].gameObject.SetActive(true);
        mm.StartConversation();
        nameUI.GetComponent<Text>().text = "???";
        textUI.GetComponent<TMPro.TextMeshProUGUI>().text = sequence1[curLine];
        mm.responseButtonTexts[0].GetComponent<Text>().text = responses[curLine][0];
        mm.responseButtonTexts[1].GetComponent<Text>().text = responses[curLine][1]; 
        mm.responseButtons[0].SetActive(true);
        mm.responseButtons[1].SetActive(true);
    }

    private void AdvanceTalk(){
        curLine++;
        textUI.GetComponent<TMPro.TextMeshProUGUI>().text = sequence1[curLine];
        mm.responseButtonTexts[0].GetComponent<Text>().text = responses[curLine][0];
        mm.responseButtonTexts[1].GetComponent<Text>().text = responses[curLine][1]; 
    }

    private void EndTalk(){
        curLine = 0;
        mm.cameras[3].gameObject.SetActive(false);
        mm.cameras[0].gameObject.SetActive(true);
        mm.EndConversation();
    }

    public override void Response1()
    {
        if(curLine < 1){
            AdvanceTalk();
        }
        else{
            EndTalk();
        }
    }

    public override void Response2()
    {
        if(curLine < 1){
            AdvanceTalk();
        }
        else{
            EndTalk();
        }
    }

    public override void Response3()
    {
        
    }

    public override void SkipText()
    {
        //AdvanceTalk();
    }
}
