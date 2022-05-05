using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharCatman : Character, IClick
{
    protected ModeManager mm;
    public AudioSource UI_Feedback;
    public AudioClip SFX_clicked;
    public AudioClip SFX_drum;
    protected List<string> sequence1 = new List<string>();
    protected List<string> sequence1_1 = new List<string>();
    protected List<string> sequence1_2 = new List<string>();
    protected List<string> sequence2 = new List<string>();
    private bool starting;

    // LoadDialogue is called after name is input
    public override void LoadDialogue()
    {
        mm = FindObjectOfType<ModeManager>();
        curLine = 0;
        curName = "<color=#ffe449ff>???</color>";
        sequence1 = new List<string>();
        sequence2 = new List<string>();
        responses = new List<string>();
        sequence1.Add("Let's begin.");
        sequence2.Add("The round is over. If you wish to, take a break and talk amongst yourselves while I set up the next round.");
        responses.Clear();
        responses.Add("Yes");
        responses.Add("No");
    }

    public void onClickAction() {
        // Open Dialogue
        StartTalk();
    }

    public void StartTalk(){
        mm.curPerson = this;
        mm.cameras[0].gameObject.SetActive(false);
        mm.cameras[1].gameObject.SetActive(true);
        mm.StartConversation();
        UI_Feedback.clip = SFX_drum;
        UI_Feedback.Play();
        nameUI.GetComponent<Text>().text = curName;
        curLine = 0;
        textUI.GetComponent<TMPro.TextMeshProUGUI>().text = sequence1[curLine];
        starting = true;
    }

    public void StartTransition(){
        mm.curPerson = this;
        mm.cameras[0].gameObject.SetActive(false);
        mm.cameras[1].gameObject.SetActive(true);
        mm.StartConversation();
        UI_Feedback.clip = SFX_drum;
        UI_Feedback.Play();
        nameUI.GetComponent<Text>().text = curName;
        curLine = 0;
        textUI.GetComponent<TMPro.TextMeshProUGUI>().text = sequence2[curLine];
        starting = false;
    }

    private void EndTalk(){
        mm.cameras[1].gameObject.SetActive(false);
        mm.cameras[0].gameObject.SetActive(true);
        mm.EndConversation();
    }

    public override void Response1()
    {
        EndTalk();
        mm.StartRound();
    }

    public override void Response2()
    {
        EndTalk();
    }

    public override void Response3()
    {
        
    }

    public override void SkipText()
    {
        EndTalk();
        if (starting){
            mm.StartRound();
        }
        else{
            mm.StartChatMode();
        }
        
    }
}
