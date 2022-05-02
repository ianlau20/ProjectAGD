using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;


public class CharCade : Character, IClick
{
    protected ModeManager mm;
    public Sprite sNormal;
    public Sprite sCrying;
    public SpriteRenderer self;
    public AudioSource UI_Feedback;
    public AudioClip SFX_clicked;
    protected List<string> sequence1 = new List<string>();
    protected List<string> sequence2 = new List<string>();
    protected List<string> sequence2_1_3 = new List<string>();
    protected List<string> sequence2_2 = new List<string>();
    protected List<string> sequence2_4 = new List<string>();
    protected List<string> sequence2_5_7 = new List<string>();
    protected List<string> sequence2_6 = new List<string>();
    protected List<string> sequence2_8 = new List<string>();
    protected List<string> sequence2_8a = new List<string>();
    protected List<string> sequence2_8b = new List<string>();
    protected List<string> sequence2_9 = new List<string>();
    
    

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
        sequence1.Add("*In front of you is a young man, squatting on the floor and subtly nodding his head to some rock music.*");
        sequence1.Add("Where did he get that radio? Did he sneak it in with him? I guess the game master doesn't mind, since they probably would have confiscated it by now.");
        sequence1.Add("* You swear in the corner of your eye you see the game master nodding along with the music.*");
        sequence1.Add("*The boy looks up and notices you. Suddenly, he stands up.*");
        sequence1.Add("The hell are you looking at!?!");
        sequence1.Add("Oh nothing! Just admiring your tunes haha. ");
        sequence1.Add("What!? Speak up! What are ya a mouse!?");
        sequence1.Add("*He turns the volume on his radio down*");
        sequence1.Add("So, what the fuck do you want brat?");
        sequence1.Add("Brat? I’m probably older than you. No more mumbling, I gotta hold my ground.");
        sequence1.Add("I wanted to get to know everyone, so here I am.");
        sequence1.Add("Huh. You a narc or something? What if I got nothing to share? ");
        sequence1.Add("I’m not going down that easy.");
        sequence1.Add("That sticker on your radio. Do you like Death Grips?");
        sequence1.Add("Wait, you know Death Grips?");
        sequence1.Add("Of course I do. They are one of my favorite bands. ");
        sequence1.Add("I don't believe you. Name 3 songs right now. ");
        sequence1.Add("Black Paint, World of Dogs, I Break, I Break Mirrors With My Face in The United States. ");
        sequence1.Add("Thank God my old roommate was a musicophile. ");
        sequence1.Add("Hm. Maybe you aren't a poser after all. ");
        sequence1.Add("Me? No way never-never. ");
        sequence1.Add("I had you painted out to be a massive dork loser. Guess I was wrong. ");
        sequence1.Add("Name’s Cade, Cade Vicious. How's it fuckin goin?");
        sequence1.Add("I’m Jessie.");
        sequence1.Add("So other than a god-tier music taste, what else is there to know about you?");
        sequence1.Add("I’m a pretty simple man. This city is my kingdom and I’m the king. I am a pretty chill king though. Don't piss me off and I won't bash your face in. Easy. ");
        sequence1.Add("Sounds simple enough.");
        sequence1.Add("Yup, me and my gang run this town. They are my ride or dies, my family. If you can handle yourself in a fight and can ride a bike, you might fit right in.");
        sequence1.Add("And not one with pedals, this ain't mommy's brunch hour. I am talkin’ two-cylinder all gas no breaks. ");
        sequence1.Add("Well I might have to take you up on that offer. I'll see ya around Cade.");
        sequence1.Add("Later weenie. ");
        

        // SEQUENCE 2
        sequence2.Add("What’s up Cade?");
        sequence2.Add("Huh? Oh, it's you. What's up brat?");
        sequence2.Add("Still not letting go of brat I guess.");
        sequence2.Add("Not much.");
        sequence2.Add("Yeah, that's not surprising. By the way, can you ride a bike? I don’t think I got an answer last time. ");
        sequence2.Add("Yep, I haven't used training wheels since I was like 6 either. ");
        sequence2.Add("Training wheels? NO! I’m talking about a motorcycle idiot!");
        sequence2.Add("Oh, no I don't have a license. I've never even sat on one either.");
        sequence2.Add("What? A license? ");
        sequence2.Add("You don't have a license either? ");
        sequence2.Add("Why the hell would I need a license? I can ride a bike fine! That's all that matters anyway. ");
        sequence2.Add("I pray you never get pulled over.");
        sequence2.Add("Why are you asking by the way?");
        sequence2.Add("Simple, if you are gonna join my gang, you are gonna need to know how to ride. 1000% mandatory requirement. ");
        sequence2.Add("And you seem like the prime candidate to join. That Cody guy seemed cool. He even had the leather jacket, but the dude doesn't open his damn mouth. ");
        sequence2.Add("I'm honored that you're asking me to join. ");
        sequence2.Add("Hey! Don’t get ahead of yourself. We aren't there yet. What did I just say?! You need to know how to ride. But don’t worry, I’m the best damn teacher around. I never give up on a student unlike those damn teachers at school. ");
        sequence2.Add("Alright well, how am I gonna learn? I’m guessing you didn't manage to sneak an entire motorcycle in with you like that radio. ");
        sequence2.Add("Oh no no no my starry-eyed student. Before you even think about sittin your ass on a bike, you gotta learn the history. ");
        sequence2.Add("Why do I have to know that? ");
        sequence2.Add("Are you questioning my teaching method? Don’t you want to know what you're sitting on exactly before you are going 100 something miles per hour down the highway?");
        sequence2.Add("I guess that makes sense.");
        sequence2.Add("Of course it does!");
        sequence2.Add("For your first lesson I’m gonna give you a quick quiz to see what I’m working with here. ");
        sequence2.Add("Ok, let's go.");
        sequence2.Add("Question one. Who invented the motorcycle?");
        

        // SEQUENCE 2_1_3
        sequence2_1_3.Add("Wrong! Next question.");

        // SEQUENCE 2_2
        sequence2_2.Add("Ding dong! Congrats! Alright, next question.");

        // SEQUENCE 2_4
        sequence2_4.Add("Who was the first person to ever go 300mph on a motorcycle?");

        // SEQUENCE 2_5_7
        sequence2_5_7.Add("Nope! Last question.");

        // SEQUENCE 2_6
        sequence2_6.Add("Bing bong! Nice job, time for the last question.");

        // SEQUENCE 2_8
        sequence2_8.Add("Are motorcycles the most badass, best, coolest, and most awesome method of transportation?");

        // SEQUENCE 2_8a
        sequence2_8a.Add("Good, very good.");

        // SEQUENCE 2_8b
        sequence2_8b.Add("How dare you.");

        // SEQUENCE 2_9
        sequence2_9.Add("I think I have a lot on my plate, but I can work with this.");
        sequence2_9.Add("So you can make me into a badass biker?");
        sequence2_9.Add("*Cade puts his hand on your shoulder*");
        sequence2_9.Add("Eventually, yes, but there is much to learn young padawan.");
        sequence2_9.Add("Class is dismissed for now. ");
        sequence2_9.Add("Later Cade. ");

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
        mm.cameras[7].gameObject.SetActive(true);
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
                SwitchName("");
                SwitchStyle(FontStyle.Italic);
                break;
            case 1:
                SwitchName("You");
                SwitchStyle(FontStyle.Bold);
                break;
            case 2:
            case 3:
                SwitchName("");
                SwitchStyle(FontStyle.Italic);
                break;

            case 4:
                SwitchStyle(FontStyle.Normal);
                SwitchName(curName);
                break;
            case 5:
                SwitchName("You");          
                break;
            case 6:
                SwitchName(curName);
                break;
            case 7:
                SwitchName("");
                SwitchStyle(FontStyle.Italic);
                break;
            case 8:
                SwitchStyle(FontStyle.Normal);
                SwitchName(curName);
                break;
            case 9:
                SwitchName("You");
                SwitchStyle(FontStyle.Bold);
                break;
            case 10:
                SwitchName("You");   
                SwitchStyle(FontStyle.Normal);       
                break;
            case 11:
                SwitchName(curName);
                break;
            case 12:
                SwitchName("You");
                SwitchStyle(FontStyle.Bold);
                break;
            case 13:
                SwitchName("You");   
                SwitchStyle(FontStyle.Normal);       
                break;
            case 14:
                SwitchName(curName);
                break;
            case 15:
                SwitchName("You");        
                break;
            case 16:
                SwitchName(curName);
                break;
            case 17:
                SwitchName("You");
                break;
            case 18:
                SwitchName("You");   
                SwitchStyle(FontStyle.Bold);       
                break;
            case 19:
                SwitchName(curName);
                SwitchStyle(FontStyle.Normal); 
                break;
            case 20:
                SwitchName("You");        
                break;
            case 21:
                SwitchName(curName);
                break;
            case 22:
                curName = "<color=#A020F0ff>Cade</color>";
                SwitchName(curName);
                break;
            case 23:
                SwitchName("You");        
                break;
            case 24:
                SwitchName("You");        
                break;
            case 25:
                SwitchName(curName);
                break;
            case 26:
                SwitchName("You");        
                break;
            case 27:
                SwitchName(curName);
                break;
            case 28:
                SwitchName(curName);
                break;
            case 29:
                SwitchName("You");        
                break;
            case 30:
                SwitchName(curName);
                break;

            case 31:
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
                SwitchStyle(FontStyle.Normal);
                SwitchName(curName);
                break;
            case 2:
                SwitchName("You");
                SwitchStyle(FontStyle.Bold);
                break;
            case 3:
                SwitchName("You");   
                SwitchStyle(FontStyle.Normal);       
                break;
            case 4:
                SwitchName(curName);
                break;
            case 5:
                SwitchName("You");        
                break;
            case 6:
                SwitchName(curName);
                break;
            case 7:
                SwitchName("You");        
                break;
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
                SwitchStyle(FontStyle.Bold);    
                break;
            case 12:
                SwitchName("You");   
                SwitchStyle(FontStyle.Normal);       
                break;
            case 13:
            case 14:
                SwitchName(curName);
                break;
            case 15:
                SwitchName("You");        
                break;
            case 16:
                SwitchName(curName);
                break;
            case 17:
                SwitchName("You");        
                break;
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
            case 23:
                SwitchName(curName);
                break;
            case 24:
                SwitchName("You");        
                break;
            case 25:
                SwitchName(curName);

                ShowButtons();
                responses.Clear();
                responses.Add("Thomas Jefferson.");
                responses.Add("E.J. Pennington.");
                responses.Add("Alexander Winton.");
                mm.responseButtonTexts[0].GetComponent<Text>().text = responses[0];
                mm.responseButtonTexts[1].GetComponent<Text>().text = responses[1]; 
                mm.responseButtonTexts[2].GetComponent<Text>().text = responses[2]; 
                break;
        }
    }

    private void play2_1_3(){
        lines = sequence2_1_3;
        curSeq = "2_1_3";

        switch(curLine){
            case 0:
                SwitchName(curName);
                break;
            case 1:
                curLine = -1;
                seqMethod = () => play2_4();
                AdvanceTalk();
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
                curLine = -1;
                seqMethod = () => play2_4();
                AdvanceTalk();
                break;
        }
    }

    private void play2_4(){
        lines = sequence2_4;
        curSeq = "2_4";

        switch(curLine){
            case 0:
                SwitchName(curName);

                ShowButtons();
                responses.Clear();
                responses.Add("Michael Schumacher.");
                responses.Add("Don Vesco.");
                responses.Add("Lightning McQueen.");
                mm.responseButtonTexts[0].GetComponent<Text>().text = responses[0];
                mm.responseButtonTexts[1].GetComponent<Text>().text = responses[1]; 
                mm.responseButtonTexts[2].GetComponent<Text>().text = responses[2]; 
                break;
        }
    }

    private void play2_5_7(){
        lines = sequence2_5_7;
        curSeq = "2_5_7";

        switch(curLine){
            case 0:
                SwitchName(curName);
                break;
            case 1:
                curLine = -1;
                seqMethod = () => play2_8();
                AdvanceTalk();
                break;
        }
    }

    private void play2_6(){
        lines = sequence2_6;
        curSeq = "2_6";

        switch(curLine){
            case 0:
                SwitchName(curName);
                break;
            case 1:
                curLine = -1;
                seqMethod = () => play2_8();
                AdvanceTalk();
                break;
        }
    }

    private void play2_8(){
        lines = sequence2_8;
        curSeq = "2_8";

        switch(curLine){
            case 0:
                SwitchName(curName);
                break;
            case 1:
                SwitchName(curName);

                ShowButtons2();
                responses.Clear();
                responses.Add("Yes, obviously.");
                responses.Add("No.");
                mm.responseButtonTexts[0].GetComponent<Text>().text = responses[0];
                mm.responseButtonTexts[1].GetComponent<Text>().text = responses[1]; 
                break;
        }
    }

    private void play2_8a(){
        lines = sequence2_8a;
        curSeq = "2_8a";

        switch(curLine){
            case 0:
                SwitchName(curName);
                break;
            case 1:
                curLine = -1;
                seqMethod = () => play2_9();
                AdvanceTalk();
                break;
        }
    }

    private void play2_8b(){
        lines = sequence2_8b;
        curSeq = "2_8b";

        switch(curLine){
            case 0:
                SwitchName(curName);
                break;
            case 1:
                curLine = -1;
                seqMethod = () => play2_9();
                AdvanceTalk();
                break;
        }
    }


    private void play2_9(){
        lines = sequence2_9;
        curSeq = "2_9";

        switch(curLine){
            case 0:
                SwitchName(curName);
                break;
            case 1:
                SwitchName("You");
                break;
            case 2:
                SwitchName("");
                SwitchStyle(FontStyle.Italic);
                break;
            case 3:
            case 4:
                SwitchName(curName);
                SwitchStyle(FontStyle.Normal);
                break;
            case 5:
                SwitchName("You");
                break;
            case 6:
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
        mm.cameras[7].gameObject.SetActive(false);
        mm.cameras[0].gameObject.SetActive(true);
        mm.EndConversation();
    }

    public override void Response1()
    {
        mm.responseButtons[0].SetActive(false);
        mm.responseButtons[1].SetActive(false);
        mm.responseButtons[2].SetActive(false);
        curLine = -1;

        switch(curSeq){
            case "2":
                seqMethod = () => play2_1_3();
                AdvanceTalk();
                break;
            case "2_4":
                seqMethod = () => play2_5_7();
                AdvanceTalk();
                break;
            case "2_8":
                seqMethod = () => play2_8a();
                AdvanceTalk();
                break;
        }
    }

    public override void Response2()
    {
        mm.responseButtons[0].SetActive(false);
        mm.responseButtons[1].SetActive(false);
        mm.responseButtons[2].SetActive(false);
        curLine = -1;

        switch(curSeq){
            case "2":
                seqMethod = () => play2_2();
                AdvanceTalk();
                break;
            case "2_4":
                seqMethod = () => play2_6();
                AdvanceTalk();
                break;
            case "2_8":
                seqMethod = () => play2_8b();
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

        switch(curSeq){
            case "2":
                seqMethod = () => play2_1_3();
                AdvanceTalk();
                break;
            case "2_4":
                seqMethod = () => play2_5_7();
                AdvanceTalk();
                break;
        }
    }

    public override void SkipText()
    {
        AdvanceTalk();
    }

    private void ShowButtons()
    {
        mm.responseButtons[0].SetActive(true);
        mm.responseButtons[1].SetActive(true);
        mm.responseButtons[2].SetActive(true);
    }

    private void ShowButtons2()
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
