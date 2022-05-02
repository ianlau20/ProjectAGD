using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;


public class CharSebastian : Character, IClick
{
    protected ModeManager mm;
    public Sprite sNormal;
    public Sprite sCrying;
    public SpriteRenderer self;
    public AudioSource UI_Feedback;
    public AudioClip SFX_clicked;
    protected List<string> sequence1 = new List<string>();
    protected List<string> sequence2 = new List<string>();

    

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
        sequence1.Add("*Before you stands a tall and slender man, with perfect posture and grace. He smells like fresh flowers and his aura oozes perfection and class*");
        sequence1.Add("*Just seeing him makes you stand up straight and unclench your jaw like you got in trouble with the principal in middle school* ");
        sequence1.Add("Why am I acting like this? I’m a fully grown adult here. It’s just something about them."); //bold
        sequence1.Add("Well hello there, let me introduce myself. I am Sebastion Duke Ainsworth, head butler for the house of Windsor.");
        sequence1.Add("Oh..um, I’m Jessie from uh house of… my parents.");
        sequence1.Add("Well, Jessie from the house of parents, it is a pleasure to make your acquaintance. ");
        sequence1.Add("Nice to meet you too Sebastian Doot Ainswan from the house of Wonka.");
        sequence1.Add("Sebastian will suffice. ");
        sequence1.Add("Ok Sebastian. ");
        sequence1.Add("Is there a reason you approached me? Master, Jessie.");
        sequence1.Add("Oh, I just wanted to get to know everyone a bit better, so I am introducing myself.");
        sequence1.Add("Is that really the only reason?");
        sequence1.Add("What? Um, yeah. ");
        sequence1.Add("Well, Master Jessie is there anything you would like to know?");
        sequence1.Add("What's it like being a butler?");
        sequence1.Add("Being a butler is my calling, my destiny. I cannot see myself doing anything but this in my life. I strive for greatness, excellence, and class, and nothing will stop me from completing my tasks.");
        sequence1.Add("Oh so do-");
        sequence1.Add("Hard work, dedication, and honor are just a few things that make a butler special. It takes years of training to learn everything a family might need. ");
        sequence1.Add("Like wha-");
        sequence1.Add("I’m glad you asked: cooking, cleaning, laundry, raising children, chauffeuring, shopping, tying up loose ends, …");
        sequence1.Add("What was that last part?");
        sequence1.Add("If a butler cannot perform these tasks, then they do not deserve to call themselves a butler. And besides, that does not even begin to scratch the surface of a butler's responsibilities. ");
        sequence1.Add("Wh-");
        sequence1.Add("Not only this, but they must be perfect at every task. Simply being able to carry out these activities is not enough! They must master it. Nothing but perfection is acceptable. ");
        sequence1.Add("I sense some confusion coming from you Master Jessie. Shall I explain it from the top?");
        sequence1.Add("What? No, it’s totally clear! Drive the clothes and cook the kids. Got it. ");
        sequence1.Add("Well then, I will bore you with my ramblings no longer. Till another time Master Jessie.");
        sequence1.Add("Au revoir, Sebastián.");


        // SEQUENCE 2
        sequence2.Add("Hello Sebastian.");
        sequence2.Add("Ah, young master, I see you have survived another round, congratulations. ");
        sequence2.Add("Congrats to you for making it as well. ");
        sequence2.Add("Much obliged, for the sake of my honor and pride I cannot fail just yet.");
        sequence2.Add("Was there something else you wanted to discuss with me, young master?");
        sequence2.Add("Can you teach me your ways?");
        sequence2.Add("Teach you?");
        sequence2.Add("...");
        sequence2.Add("Etiquette and butlering aren’t a game, it takes years of dedication and practice. Are you sure you’re up for it?");
        sequence2.Add("Yes, yes I am.");
        sequence2.Add("Very well, obviously we don't have years to practice so, I will just be giving you the basics of etiquette. ");
        sequence2.Add("Let's do this. ");
        sequence2.Add("At formal parties and events, always hold your drink in your left hand. ");
        sequence2.Add("Why is that?");
        sequence2.Add("This ties into another rule, always shake with your right hand, you don’t want any liquid from your glass to get onto your shaking hand.");
        sequence2.Add("This also applies to anything else you might be carrying, like purses or handbags. ");
        sequence2.Add("Got it!");
        sequence2.Add("Good.");
        sequence2.Add("Next lesson, in any event where you are given name tags, never wear your nametag over your heart. Always wear it on the right side of your chest, that way it will still be visible during handshakes. ");
        sequence2.Add("Handshakes seem to be very important.");
        sequence2.Add("Extremely. I could go on for years about important handshake etiquette but for the sake of time, I will give you one more rule. Ready?");
        sequence2.Add("Ready.");
        sequence2.Add("When giving a handshake, make sure your grip is firm, not bone-crushing. Then, once you connect hands, the handshake should last about 3 seconds or 3 hand pumps, no more no less. ");
        sequence2.Add("Ok, 3 pumps got it.");
        sequence2.Add("Would you like to practice your handshake, young master?");
        sequence2.Add("Yea!");
        sequence2.Add("Very well.");
        sequence2.Add("Well done young master, you have a very firm grip. Seems you have learned a lot in such a short time.");
        sequence2.Add("I’m learning from the best, what can I say.");
        sequence2.Add("I shall prepare another lesson for you if you wish to see me next time, young master.");
        sequence2.Add("Farewell Sebastian. ");

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
        mm.cameras[5].gameObject.SetActive(true);
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
            case 1:
                SwitchName("");
                SwitchStyle(FontStyle.Italic);
                break;
            case 2:
                SwitchName("You");
                SwitchStyle(FontStyle.Bold);         
                break;
            case 3:
                curName = "<color=#FFD700ff>Sebastian</color>";
                SwitchStyle(FontStyle.Normal);
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
                break;
            case 12:
                SwitchName("You");          
                break;
            case 13:
                SwitchName(curName);
                break;
            case 14:
                SwitchName("You");          
                break;
            case 15:
                SwitchName(curName);
                break;
            case 16:
                SwitchName("You");          
                break;
            case 17:
                SwitchName(curName);
                break;
            case 18:
                SwitchName("You");          
                break;
            case 19:
                SwitchName(curName);
                break;
            case 20:
                SwitchName("You");          
                break;
            case 21:
                SwitchName(curName);
                break;
            case 22:
                SwitchName("You");          
                break;
            case 23:
            case 24:
                SwitchName(curName);
                break;
            case 25:
                SwitchName("You");          
                break;
            case 26:
                SwitchName(curName);
                break;
            case 27:
                SwitchName("You");          
                break;
            case 28:
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
                break;
            case 1:
                SwitchName(curName);
                break;
            case 2:
                SwitchName("You");          
                break;
            case 3:
            case 4:
                SwitchName(curName);
                break;
            case 5:
                SwitchName("You");          
                break;
            case 6:
            case 7:
            case 8:
                SwitchName(curName);
                break;
            case 9:
                SwitchName("You");          
                break;
            case 10:
                SwitchName(curName);
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
            case 15:
                SwitchName(curName);
                break;
            case 16:
                SwitchName("You");          
                break;
            case 17:
            case 18:
                SwitchName(curName);
                break;
            case 19:
                SwitchName("You");          
                break;
            case 20:
                SwitchName(curName);
                break;
            case 21:
                SwitchName("You");          
                break;
            case 22:
                SwitchName(curName);
                break;
            case 23:
                SwitchName("You");          
                break;
            case 24:
                SwitchName(curName);
                break;
            case 25:
                SwitchName("You");     
                break;
            case 26:
            case 27:
                SwitchName(curName);
                break;
            case 28:
                SwitchName("You");     
                break;
            case 29:
                SwitchName(curName);
                break;
            case 30:
                SwitchName("You");     
                break;
            case 31:
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

        }
    }

    public override void Response2()
    {
        mm.responseButtons[0].SetActive(false);
        mm.responseButtons[1].SetActive(false);
        curLine = -1;

        switch(curSeq){

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
