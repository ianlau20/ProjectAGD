using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;


public class CharHana : Character, IClick
{
    protected ModeManager mm;
    public Sprite sNormal;
    public Sprite sCrying;
    public SpriteRenderer self;
    public AudioSource UI_Feedback;
    public AudioClip SFX_clicked;

    private Action seqMethod;

    // Start is called before the first frame update
    void Start()
    {
        mm = FindObjectOfType<ModeManager>();
        curLine = -1;
        curSeq = "0";
        lines = new List<string>();
        sequence1 = new List<string>();
        sequence1_1 = new List<string>();
        sequence1_2 = new List<string>();
        responses = new List<List<string>>();
        SpriteChange(sCrying);

        // SEQUENCE 1
        sequence1.Add("Gosh, where did I put my phone, I just had it! I swear I’d lose my head if it wasn’t attached.");
        sequence1.Add("Oh, Hi hi! I’m Hana, what's up dude!");

        sequence1.Add("Looks like she is over losing her phone."); //ITALIC
        sequence1.Add("Hey I’m Jessie, just wanted to see what's up.");

        sequence1.Add("Hella! Did you see that cat guy aren’t they like sooooooooo cute! I wonder what is behind that mask. Maybe a little kitty piloting a robot body!");

        sequence1.Add("Yea I guess it’s pretty cute.");
        sequence1.Add("What an active imagination."); //ITALIC

        sequence1.Add("BTDubs do you like, understand this game we are playing? I have no idea what's going on, zero, nada.");

        sequence1.Add("Well that's kind of the point I think, you have to figure out the rules as you play. Everyone is kinda in the same boat.");

        sequence1.Add("Awwwwwwwwwwwwww, that's waaaaay too hard, no wonder everyone looks like they aren't having fun. >.>");

        sequence1.Add("Well there are probably other reasons they aren’t having fun, a lot is at stake here.");

        sequence1.Add("Hm? Watcha mean? We are just like playing for funsies right?");

        sequence1.Add("Wait does she not know what's going on here? Do I tell her?"); //ITALIC
        responses.Add(new List<string> {"Yes", "No"});

        // SEQUENCE 1_1
        sequence1_1.Add("Did you not notice that everyone goes missing after they lose? This game is life or death. If you don't win you die.");

        sequence1_1.Add("pfft…. 	HAHAHA!!! DUDE THAT'S LIKE TOTALLY HILARIOUS! AHAHAAHA you totally had me scared for a second there too… that was hella funny dude. ");

        sequence1_1.Add("Oh no, she's"); //ITALIC
        sequence1_1.Add("She's"); //ITALIC
        sequence1_1.Add("STUPID!!!"); //ITALIC
        sequence1_1.Add("Well it's a good thing you're cute.");

        sequence1_1.Add("What was that?");

        sequence1_1.Add("Nothing! See you later Hana!");

        sequence1_1.Add("Deuces broski!");

        // SEQUENCE 1_2
        sequence1_2.Add("Yea, just for funsies, but winning is still pretty important to win.");

        sequence1_2.Add("Yea, I guessssss but I was never a competitive person ya know? I just wanna have fun! ^_^");

        sequence1_2.Add("Well that's nice, I think that is a good trait to have.");

        sequence1_2.Add("Thanks, dude! I wanna have fun with everybody, would make this place a lot brighter, doncha think!");

        sequence1_2.Add("Well I admire her passion."); //ITALIC
        sequence1_2.Add("Yea I think you’re right.");
        sequence1_2.Add("Well nice talking to you, Hana.");

        sequence1_2.Add("Lators gators!");
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
        mm.cameras[2].gameObject.SetActive(true);
        mm.StartConversation();

        curLine = -1;
        seqMethod = () => play1();
        AdvanceTalk();
    }

    private void play1(){
        lines = sequence1;
        curSeq = "1";

        switch(curLine){
            case 0:
                SwitchName("???");
                SwitchStyle(FontStyle.Normal);
                break;
            
            case 1:
                SwitchName("Hana");
                SpriteChange(sNormal);
                break;

            case 2:
                SwitchName("Me");
                SwitchStyle(FontStyle.Italic);
                break;

            case 3:
                SwitchStyle(FontStyle.Normal);
                break;
            
            case 4:
                SwitchName("Hana");
                break;
            
            case 5:
                SwitchName("Me");          
                break;

            case 6:
                SwitchStyle(FontStyle.Italic);//what an active..
                break;

            case 7:
                SwitchName("Hana");
                SwitchStyle(FontStyle.Normal);
                break;

            case 8:
                SwitchName("Me"); //thats kinda the point
                break;

            case 9:
                SwitchName("Hana");
                break;

            case 10:
                SwitchName("Me");
                break;

            case 11:
                SwitchName("Hana");
                break;

            case 12:
                SwitchName("Me");
                SwitchStyle(FontStyle.Italic);
                ShowButtons();
                mm.responseButtonTexts[0].GetComponent<Text>().text = responses[0][0];
                mm.responseButtonTexts[1].GetComponent<Text>().text = responses[0][1]; 
                break;
        }


    }

    private void play1_1(){
        lines = sequence1_1;
        curSeq = "1_1";

        switch(curLine){
            case 0:
                SwitchName("Me");
                SwitchStyle(FontStyle.Normal);
                break;
            case 1:
                SwitchName("Hana");
                break;
            case 2:
            case 3:
            case 4:
                SwitchName("Me");
                SwitchStyle(FontStyle.Italic);
                break;
            case 5:
                SwitchStyle(FontStyle.Normal);
                break;
            case 6:
                SwitchName("Hana");
                break;
            case 7:
                SwitchName("Me");
                break;
            case 8:
                SwitchName("Hana");
                break;
            case 9:
                EndTalk();
                break;
            
        }
        
    }

    private void play1_2(){
        lines = sequence1_2;
        curSeq = "1_2";

        switch(curLine){
            case 0:
                SwitchName("Me");
                SwitchStyle(FontStyle.Normal);
                break;
            case 1:
                SwitchName("Hana");
                break;
            case 2:
                SwitchName("Me");
                break;
            case 3:
                SwitchName("Hana");
                break;
            case 4:
                SwitchName("Me");
                SwitchStyle(FontStyle.Italic);
                break;
            case 5:
            case 6:
                SwitchStyle(FontStyle.Normal); //ur right
                break;
            case 7:
                SwitchName("Hana");
                break;
            case 8:
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

        if(curSeq == "1"){
            seqMethod = () => play1_1();
            AdvanceTalk();
        }
        else{
            EndTalk();
        }
    }

    public override void Response2()
    {
        mm.responseButtons[0].SetActive(false);
        mm.responseButtons[1].SetActive(false);
        curLine = -1;

        if(curSeq == "1"){
            seqMethod = () => play1_2();
            AdvanceTalk();
        }
        else{
            EndTalk();
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
