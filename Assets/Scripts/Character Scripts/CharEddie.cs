using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;


public class CharEddie : Character, IClick
{
    protected ModeManager mm;
    public Sprite sSus_Neutral;
    public Sprite sSus_ArmsCrossed;
    public Sprite sNeutral_Neutral;
    public Sprite sNeutral_ArmsCrossed;
    public Sprite sHappy_Neutral;
    public Sprite sHappy_HeadScratch;
    public Sprite sGrumpy_ArmsCrossed;
    public Sprite sDissapointed_Neutral;
    public Sprite sDissapointed_HeadScratch;
    public Sprite sDissapointed_ArmsCrossed;


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
        SpriteChange(sSus_Neutral);

        // SEQUENCE 1
        sequence1.Add("Can I help you?");
        sequence1.Add("I was wondering if you wanted to talk.");
        sequence1.Add("Talk? About what?");
        sequence1.Add("I don’t know… anything really, just to pass the time.");
        sequence1.Add("Out of everyone here you walked up to me, why?");
        

        // SEQUENCE 1_1
        sequence1_1.Add("What's that supposed to mean? …Whatever, I’ll take it as a compliment.");


        // SEQUENCE 1_2
        sequence1_2.Add("Haha… at least you're honest.");

        // SEQUENCE 1_3
        sequence1_3.Add("So, what's on your mind kid?");
        sequence1_3.Add("Tell me a bit about yourself.");
        sequence1_3.Add("Well, I like to kill and eat people for fun.");
        sequence1_3.Add("Wh-what….?");
        sequence1_3.Add("You know, cannibalism.");
        sequence1_3.Add("I…uh...");
        sequence1_3.Add("…..");
        sequence1_3.Add("You know I’m kidding right?");
        sequence1_3.Add("Oh… yeah totally...");
        sequence1_3.Add("There isn’t much to say about me, maybe I’ll tell ya another time. You can call me Eddy by the way.");

        // SEQUENCE 2
        sequence2.Add("Well, look who survived another round. How's it goin kid?");
        sequence2.Add("Hey Eddy.");
        sequence2.Add("So, did you really wanna know more about me? Is that why you came back?");
        sequence2.Add("I just wanted to know why you joined this game.");
        sequence2.Add("...");
        sequence2.Add("Say kid, do you have anything you regret? And not something like I wish I saw that movie. I’m talking about something you think about every night.");

        // SEQUENCE 2_1
        sequence2_1.Add("Really? You know, I’m kinda surprised. Maybe it's true that everyone has regrets, but I think what matters is how we move on from them. Don’t let the things you can't change ruin the things you can.");

        // SEQUENCE 2_2
        sequence2_2.Add("Heh, I envy you kid. I hope it stays that way. Regrets are something you can’t do anything about. It does horrible things to a person, it turns them into their worst selves.");

        // SEQUENCE 2_3
        sequence2_3.Add("Sorry to go all preacher on ya kid.");
        sequence2_3.Add("It's alright.");
        sequence2_3.Add("Haha, that kinda took it out of me. Look, if I’m still around next time feel free to see me again.");
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
        mm.cameras[4].gameObject.SetActive(true);
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
                SwitchName(curName);
                SwitchStyle(FontStyle.Normal);
                break;
            
            case 1:
                SwitchName("You");
                break;

            case 2:
                SwitchName(curName);
                break;
            
            case 3:
                SwitchName("You");          
                break;

            case 4:
                SpriteChange(sSus_ArmsCrossed);
                SwitchName(curName);

                ShowButtons();
                responses.Clear();
                responses.Add("You seemed interesting.");
                responses.Add("I picked randomly.");
                mm.responseButtonTexts[0].GetComponent<Text>().text = responses[0];
                mm.responseButtonTexts[1].GetComponent<Text>().text = responses[1]; 
                break;
        }
    }

    private void play1_1(){
        lines = sequence1_1;
        curSeq = "1_1";

        switch(curLine){
            case 0:
                SpriteChange(sGrumpy_ArmsCrossed);
                SwitchName(curName);
                break;
            case 1:
                curLine = -1;
                seqMethod = () => play1_3();
                AdvanceTalk();
                break;
        }
    }

    private void play1_2(){
        lines = sequence1_2;
        curSeq = "1_2";

        switch(curLine){
            case 0:
                SpriteChange(sGrumpy_ArmsCrossed);
                SwitchName(curName);
                break;
            case 1:
                curLine = -1;
                seqMethod = () => play1_3();
                AdvanceTalk();
                break;
        }
    }

    private void play1_3(){
        lines = sequence1_3;
        curSeq = "1_3";

        switch(curLine){
            case 0:
                SpriteChange(sNeutral_ArmsCrossed);
                SwitchName(curName);
                break;
            case 1:
                SwitchName("You");
                break;
            case 2:
                SpriteChange(sGrumpy_ArmsCrossed);
                SwitchName(curName);
                break;
            case 3:
                SwitchName("You");
                break;
            case 4:
                SwitchName(curName);
                break;
            case 5:
                SwitchName("You");
                break;
            case 6:
                SpriteChange(sNeutral_ArmsCrossed);
                SwitchName(curName);
                break;
            case 7:
                SpriteChange(sHappy_Neutral);
                break;
            case 8:
                SwitchName("You");
                break;
            case 9:
                curName = "<color=#C19A6Bff>Eddy</color>";
                SwitchName(curName);
                break;
            case 10:
                EndTalk();
                break;
        }
    }

    private void play2(){
        lines = sequence2;
        curSeq = "2";

        switch(curLine){
            case 0:
                SpriteChange(sNeutral_Neutral);
                SwitchName(curName);
                break;

            case 1:
                SwitchName("You");
                break;
  
            case 2:
                SpriteChange(sNeutral_ArmsCrossed);
                SwitchName(curName);
                break;
            
            case 3:
                SwitchName("You");          
                break;

            case 4:
                SwitchName(curName);
                break;

            case 5:
                SpriteChange(sDissapointed_ArmsCrossed);
                SwitchName(curName);

                ShowButtons();
                responses.Clear();
                responses.Add("Yes.");
                responses.Add("No.");
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
                SpriteChange(sDissapointed_HeadScratch);
                SwitchName(curName);
                break;
            case 1:
                curLine = -1;
                seqMethod = () => play2_3();
                AdvanceTalk();
                break;
        }
    }

    private void play2_2(){
        lines = sequence2_2;
        curSeq = "2_2";

        switch(curLine){
            case 0:
                SpriteChange(sGrumpy_ArmsCrossed);
                SwitchName(curName);
                break;
            case 1:
                curLine = -1;
                seqMethod = () => play2_3();
                AdvanceTalk();
                break;
        }
    }


    private void play2_3(){
        lines = sequence2_3;
        curSeq = "2_3";

        switch(curLine){
            case 0:
                SpriteChange(sDissapointed_HeadScratch);
                SwitchName(curName);
                break;
            case 1:
                SwitchName("You");
                break;
            case 2:
                SpriteChange(sHappy_HeadScratch);
                SwitchName(curName);
                break;
            case 3:
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
        mm.cameras[4].gameObject.SetActive(false);
        mm.cameras[0].gameObject.SetActive(true);
        mm.EndConversation();
    }

    public override void Response1()
    {
        mm.responseButtons[0].SetActive(false);
        mm.responseButtons[1].SetActive(false);
        curLine = -1;

        switch(curSeq){
            case "1":
                seqMethod = () => play1_1();
                AdvanceTalk();
                break;
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
            case "1":
                seqMethod = () => play1_2();
                AdvanceTalk();
                break;
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
