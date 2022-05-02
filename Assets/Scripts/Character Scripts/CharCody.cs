using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;


public class CharCody : Character, IClick
{
    protected ModeManager mm;
    public Sprite sNormal;
    public Sprite sCrying;
    public SpriteRenderer self;
    public AudioSource UI_Feedback;
    public AudioClip SFX_clicked;
    protected List<string> sequence1 = new List<string>();
    protected List<string> sequence1_1 = new List<string>();
    protected List<string> sequence1_2 = new List<string>();
    protected List<string> sequence1_3 = new List<string>();
    protected List<string> sequence2 = new List<string>();
    protected List<string> sequence2_1 = new List<string>();
    protected List<string> sequence2_2 = new List<string>();
    protected List<string> sequence2_3 = new List<string>();
    

    // Start is called before the first frame update
    void Start()
    {
        mm = FindObjectOfType<ModeManager>();
        curLine = -1;
        session = 0;
        curSeq = "0";
        curName = "<color=#C0C0C0ff>???</color>";
        lines = new List<string>();
        responses = new List<string>();
        SpriteChange(sCrying);

        // SEQUENCE 1
        sequence1.Add("He-hey how’s it going?");
        sequence1.Add("…….");
        sequence1.Add("What's your name?");
        sequence1.Add("…….");
        sequence1.Add("I uh … This game is kinda scary isn’t it?");
        sequence1.Add("…….");
        sequence1.Add("…….");
        sequence1.Add("…….");
        sequence1.Add("…….");
        sequence1.Add("…….");
        sequence1.Add("What's your name?");
        sequence1.Add("grunt");
        

        // SEQUENCE 2
        sequence2.Add("Why am I talking to this guy again WHY!?"); //bold
        sequence2.Add("Heyyyy….. how's it going?");
        sequence2.Add("…….");
        sequence2.Add("There it is."); //bold
        sequence2.Add("So uh, what's your name?");
        sequence2.Add("Cody.");
        sequence2.Add("So you can talk?!");
        sequence2.Add("I just said that out loud didn’t I, He is gonna kill me!"); //bold
        sequence2.Add("…….");
        sequence2.Add("Phew, dodged a bullet there."); //bold
        sequence2.Add("Why are you trying to be friendly with me? I am your enemy.");
        sequence2.Add("What?");
        sequence2.Add("In this game, there can only be one winner. Therefore, I am your enemy.");
        sequence2.Add("Well, I… um.");
        sequence2.Add("Trying to find any weakness I have?");

        // SEQUENCE 2_1
        sequence2_1.Add("Hmph, cheap tricks will get you nowhere.");

        // SEQUENCE 2_2
        sequence2_2.Add("……. Really.");
        sequence2_2.Add("YES!");
        sequence2_2.Add(".......");
        sequence2_2.Add("Well…. my name is Cody.");
        sequence2_2.Add("Nice to meet you, Cody.");
        sequence2_2.Add(".......");
        sequence2_2.Add("Well I’ll be going now, it was nice talking to you!");
        sequence2_2.Add(".......");
        sequence2_2.Add("Lots of progress this time! "); //bold

    }

    public void onClickAction() {
        // Open Dialogue
        StartTalk();
        UI_Feedback.clip = SFX_clicked;
        UI_Feedback.Play();
        session++;
    }

    private void StartTalk(){
        mm.curPerson = this;
        mm.cameras[0].gameObject.SetActive(false);
        mm.cameras[3].gameObject.SetActive(true);
        mm.StartConversation();

        curLine = -1;
        SwitchStyle(FontStyle.Normal);
        switch(session){
            case 0:
                seqMethod = () => play1();
                break;
            case 1:
                seqMethod = () => play2();
                break;
        }
        
        AdvanceTalk();
    }

    private void play1(){
        lines = sequence1;
        curSeq = "1";

        switch(curLine){
            case 0:
                SwitchName("You");
                break;

            case 1:
                SwitchName(curName);
                break;
            
            case 2:
                SwitchName("You");          
                break;

            case 3:
                SwitchName(curName);
                break;
            
            case 4:
                SwitchName("You");          
                break;
            case 5:
                SwitchName(curName);
                break;
            
            case 6:
                SwitchName("You");          
                break;
            case 7:
                SwitchName(curName);
                break;
            
            case 8:
                SwitchName("You");          
                break;
            case 9:
                SwitchName(curName);
                break;
            
            case 10:
                SwitchName("You");          
                break;
            case 11:
                SwitchName(curName);
                SwitchStyle(FontStyle.Italic);
                break;

            case 12:
                EndTalk();
                break;
        }
    }


    private void play2(){
        lines = sequence2;
        curSeq = "2";

        switch(curLine){
            case 0:
                SwitchName("You");
                SwitchStyle(FontStyle.Bold);
                break;
  
            case 1:
                SwitchStyle(FontStyle.Normal);
                break;
            
            case 2:
                SwitchName(curName);
                break;

            case 3:
                SwitchName("You");
                SwitchStyle(FontStyle.Bold);
                break;
  
            case 4:
                SwitchStyle(FontStyle.Normal);
                break;

            case 5:
                curName = "<color=#800020ff>Cody</color>";
                SwitchName(curName);
                break;

            case 6:
                SwitchName("You");
                break;

            case 7:
                SwitchStyle(FontStyle.Bold);
                break;
            case 8:
                SwitchName(curName);
                SwitchStyle(FontStyle.Normal);
                break;
            case 9:
                SwitchName("You");
                SwitchStyle(FontStyle.Bold);
                break;
            case 10:
                SwitchName(curName);
                SwitchStyle(FontStyle.Normal);
                break;
            case 11:
                SwitchName("You");          
                break;
            case 12:
                SwitchName(curName);
                break;
            
            case 13:
                SwitchName("You");          
                break;
            case 14:
                SwitchName(curName);

                ShowButtons();
                responses.Clear();
                responses.Add("Yes I am, and you fell for it!");
                responses.Add("What!? No!");
                mm.responseButtonTexts[0].GetComponent<Text>().text = responses[0];
                mm.responseButtonTexts[1].GetComponent<Text>().text = responses[1]; 
                break;
        }
    }

    private void play2_1(){
        lines = sequence2_1;
        curSeq = "2_1";

        switch(curLine){
            case 0:
                SwitchName(curName);
                break;
            case 1:
                EndTalk();
                //Make it so they can never talk to cody again
                session = 1000;
                break;
        }
    }

    private void play2_2(){
        lines = sequence2_2;
        curSeq = "2_2";

        switch(curLine){
            case 0:
                SwitchName(curName);
                break;
            case 1:
                SwitchName("You");
                break;
            case 2:
                SwitchName(curName);
                break;
            case 3:
                SwitchName(curName);
                break;
            case 4:
                SwitchName("You");
                break;
            case 5:
                SwitchName(curName);
                break;
            case 6:
                SwitchName("You");
                break;
            case 7:
                SwitchName(curName);
                break;
            case 8:
                SwitchName("You");
                SwitchStyle(FontStyle.Bold);
                break;
            case 9:
                EndTalk();
                break;
        }
        
    }


    private void AdvanceTalk(){
        curLine++;
        seqMethod();
        textUI.GetComponent<TMPro.TextMeshProUGUI>().text = lines[curLine];
    }

    private void EndTalk(){
        curLine = -1;
        mm.cameras[2].gameObject.SetActive(false);
        mm.cameras[0].gameObject.SetActive(true);
        mm.EndConversation();
    }

    public override void Response1()
    {
        mm.responseButtons[0].SetActive(false);
        mm.responseButtons[1].SetActive(false);
        curLine = -1;

        switch(curSeq){
            case "2":
                seqMethod = () => play2_1();
                AdvanceTalk();
                break;
        }
    }

    public override void Response2()
    {
        mm.responseButtons[0].SetActive(false);
        mm.responseButtons[1].SetActive(false);
        curLine = -1;

        switch(curSeq){
            case "2":
                seqMethod = () => play2_2();
                AdvanceTalk();
                break;
        }

    }

    public override void Response3()
    {
        mm.responseButtons[0].SetActive(false);
        mm.responseButtons[1].SetActive(false);
        mm.responseButtons[2].SetActive(false);
        curLine = -1;
    }

    public override void SkipText()
    {
        AdvanceTalk();
    }

    private void ShowButtons()
    {
        mm.responseButtons[0].SetActive(true);
        mm.responseButtons[1].SetActive(true);
    }

    private void SwitchName(string name)
    {
        nameUI.GetComponent<Text>().text = name;
    }

    private void SwitchStyle(FontStyle style)
    {
        textUI.GetComponent<TMPro.TextMeshProUGUI>().fontStyle = (TMPro.FontStyles)style;
    }

    private void SpriteChange(Sprite sprite){
        self.sprite = sprite;
    }

}
