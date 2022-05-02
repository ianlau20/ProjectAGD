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
    public Sprite sWorry_Neutral;
    public Sprite sWorry_FistsRaised;
    public Sprite sSob_Neutral;
    public Sprite sSob_FistsRaised;
    public Sprite sNeutral_Peace;
    public Sprite sNeutral_Neutral;
    public Sprite sNeutral_FistsRaised;
    public Sprite sGrin_Peace;
    public Sprite sGrin_Neutral;
    public Sprite sGrin_FistsRaised;
    public Sprite sDetermined_Peace;
    public Sprite sDetermined_Neutral;
    public Sprite sDetermined_FistsRaised;

    public SpriteRenderer self;
    public AudioSource UI_Feedback;
    public AudioClip SFX_clicked;
    protected List<string> sequence1 = new List<string>();
    protected List<string> sequence1_1 = new List<string>();
    protected List<string> sequence1_2 = new List<string>();
    protected List<string> sequence2 = new List<string>();
    protected List<string> sequence2_1 = new List<string>();
    protected List<string> sequence2_1a = new List<string>();
    protected List<string> sequence2_1b = new List<string>();
    protected List<string> sequence2_2 = new List<string>();
    

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
        SpriteChange(sWorry_Neutral);

        // SEQUENCE 1
        sequence1.Add("Gosh, where did I put my phone, I just had it! I swear I’d lose my head if it wasn’t attached.");
        sequence1.Add("*She looks up and notices you standing there*");
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
        

        // SEQUENCE 1_1
        sequence1_1.Add("Did you not notice that everyone goes missing after they lose? This game is life or death. If you don't win you die.");
        sequence1_1.Add("pfft…. 	HAHAHA!!! DUDE THAT'S LIKE TOTALLY HILARIOUS! AHAHAAHA you totally had me scared for a second there too… that was hella funny dude.");
        sequence1_1.Add("You're is too pure for this world."); //ITALIC
        sequence1_1.Add("What was that?");
        sequence1_1.Add("Nothing! See you later Hana!");
        sequence1_1.Add("Lators gators!");

        // SEQUENCE 1_2
        sequence1_2.Add("Yea, just for funsies, but winning is still pretty important to win.");
        sequence1_2.Add("Yea, I guessssss but I was never a competitive person ya know? I just wanna have fun! ^_^");
        sequence1_2.Add("Well that's nice, I think that is a good trait to have.");
        sequence1_2.Add("Thanks, dude! I wanna have fun with everybody, would make this place a lot brighter, doncha think!");
        sequence1_2.Add("Well I admire her passion."); //ITALIC
        sequence1_2.Add("Yea I think you’re right.");
        sequence1_2.Add("Well nice talking to you, Hana.");
        sequence1_2.Add("Lators gators!");

        // SEQUENCE 2
        sequence2.Add("Hey Hana.");
        sequence2.Add("Oh! Hey dude! What's up?");
        sequence2.Add("You know, the usual. Trying to not die I guess. ");
        sequence2.Add("Haha. You are like so hilarious! ");
        sequence2.Add("BTW, I think I figured something out. I can play another tiger on top of a tiger!");
        sequence2.Add("That adds up, I think that confirms that matching Zodiacs are a rule.");
        sequence2.Add("Did you notice anything else like that happening?");
        sequence2.Add("Hmmm…. I don’t think so, but I will definitely let you know! ^_^");
        sequence2.Add("Alsoooooo, did you notice all the animals and the zodiac calendars everywhere?");
        sequence2.Add("I love zodiac signs, can I guess yours?");

        // SEQUENCE 2_1
        sequence2_1.Add("*Hana grabs your hand and closes her eyes.*");
        sequence2_1.Add("Hmmmmm…. Haha just kidding!");
        sequence2_1.Add("*She opens her eyes and lets go of your hand.*");
        sequence2_1.Add("That was all for show. Did I get you? You for sure thought I was reading your mind or something LOL!");
        sequence2_1.Add("But, I think… you are a dragon! Well? Well? Am I right?!");

        // SEQUENCE 2_1a
        sequence2_1a.Add("HAHA YES! I knew it!");
        sequence2_1a.Add("You know how I could tell?");
        sequence2_1a.Add("I think there is something about you. I noticed you talked to other people and even me. Your energy and there is something about you that's…. special…");
        sequence2_1a.Add("Thanks, I try my best. I feel like there is some way to make this situation better.");
        sequence2_1a.Add("YEAH! I always try my best to make everyone happy! Seeing you talking to people inspired me to try my hardest too! ");
        sequence2_1a.Add("Thanks, Hana I will keep doing everything I can. I’ll see ya.");
        sequence2_1a.Add("See ya hyena!");

        // SEQUENCE 2_1b
        sequence2_1b.Add("Awww, well that stuff is kind of just speculation anyway, right?");
        sequence2_1b.Add("I think you still act like a dragon at least. You are outgoing and stand out in a crowd. Even in this crowd of diverse people you still manage to have a presence. ");
        sequence2_1b.Add("Thanks Hana. I mean it. That gives me a bit more confidence haha. I’ll be seeing you.");
        sequence2_1b.Add("See ya hyena!");

        // SEQUENCE 2_2
        sequence2_2.Add("Oh ok, no worries haha.");
        sequence2_2.Add("Well I’m gonna get going now. Later Hana.");
        sequence2_2.Add("See ya hyena…");
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
        mm.cameras[2].gameObject.SetActive(true);
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
                SwitchName("");
                SwitchStyle(FontStyle.Italic);
                break;
            
            case 2:
                SpriteChange(sGrin_Peace);
                curName = "<color=#ff69b4ff>Hana</color>";
                SwitchName(curName);
                SwitchStyle(FontStyle.Normal);
                break;

            case 3:
                SwitchName("You");
                SwitchStyle(FontStyle.Bold);
                break;

            case 4:
                SwitchStyle(FontStyle.Normal);
                break;
            
            case 5:
                SpriteChange(sGrin_FistsRaised);
                SwitchName(curName);
                break;
            
            case 6:
                SwitchName("You");          
                break;

            case 7:
                SwitchStyle(FontStyle.Bold);//what an active..
                break;

            case 8:
                SpriteChange(sNeutral_Neutral);
                SwitchName(curName);
                SwitchStyle(FontStyle.Normal);
                break;

            case 9:
                SwitchName("You"); //thats kinda the point
                break;

            case 10:
                SpriteChange(sWorry_FistsRaised);
                SwitchName(curName);
                break;

            case 11:
                SwitchName("You");
                break;

            case 12:
                SpriteChange(sNeutral_Neutral);
                SwitchName(curName);
                break;

            case 13:
                SwitchName("You");
                SwitchStyle(FontStyle.Bold);
                ShowButtons();

                responses.Clear();
                responses.Add("Yes");
                responses.Add("No");
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
                SwitchName("You");
                SwitchStyle(FontStyle.Normal);
                break;
            case 1:
                SpriteChange(sGrin_Neutral);
                SwitchName(curName);
                break;
            case 2:
                SwitchName("You");
                break;
            case 3:
                SpriteChange(sNeutral_Neutral);
                SwitchName(curName);
                break;
            case 4:
                SwitchName("You");
                break;
            case 5:
                SpriteChange(sGrin_Peace);
                SwitchName(curName);
                break;
            case 6:
                EndTalk();
                break;
            
        }
        
    }

    private void play1_2(){
        lines = sequence1_2;
        curSeq = "1_2";

        switch(curLine){
            case 0:
                SwitchName("You");
                SwitchStyle(FontStyle.Normal);
                break;
            case 1:
                SpriteChange(sGrin_Neutral);
                SwitchName(curName);
                break;
            case 2:
                SwitchName("You");
                break;
            case 3:
                SpriteChange(sNeutral_Peace);
                SwitchName(curName);
                break;
            case 4:
                SwitchName("You");
                SwitchStyle(FontStyle.Bold);
                break;
            case 5:
            case 6:
                SwitchStyle(FontStyle.Normal); //ur right
                break;
            case 7:
                SpriteChange(sGrin_Peace);
                SwitchName(curName);
                break;
            case 8:
                EndTalk();
                break;
        }
    }

    private void play2(){
        lines = sequence2;
        curSeq = "2";

        switch(curLine){
            case 0:
                SpriteChange(sGrin_Peace);
                SwitchName("You");
                SwitchStyle(FontStyle.Normal);
                break;
            
            case 1:
                SwitchName(curName);
                break;

            case 2:
                SwitchName("You");
                break;

            case 3:     
                SpriteChange(sNeutral_Neutral);
                SwitchName(curName);
                break;
            case 4:
                SpriteChange(sGrin_FistsRaised);
                break;
            
            case 5:
                SwitchName("You");
                SwitchStyle(FontStyle.Bold);        
                break;
            case 6:
                SwitchStyle(FontStyle.Normal);
                break;

            case 7:
                SpriteChange(sNeutral_Neutral);
                SwitchName(curName);
                break;
            case 8:
                SpriteChange(sGrin_Neutral);
                break;
            case 9:
                ShowButtons();
                responses.Clear();
                responses.Add("Yea, sure.");
                responses.Add("No, sorry.");
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
                SpriteChange(sGrin_FistsRaised);
                SwitchName("");
                SwitchStyle(FontStyle.Italic);
                break;
            case 1:
                SwitchStyle(FontStyle.Normal);
                SwitchName(curName);
                break;
            case 2:
                SwitchName("");
                SwitchStyle(FontStyle.Italic);
                break;
            case 3:
                SpriteChange(sGrin_Neutral);
                SwitchStyle(FontStyle.Normal);
                SwitchName(curName);
                break;
            case 4:
                ShowButtons();
                responses.Clear();
                responses.Add("Yeah, that's right.");
                responses.Add("Nope.");
                mm.responseButtonTexts[0].GetComponent<Text>().text = responses[0];
                mm.responseButtonTexts[1].GetComponent<Text>().text = responses[1];
                break;
            
        }
        
    }

    private void play2_1a(){
        lines = sequence2_1a;
        curSeq = "2_1a";

        switch(curLine){
            case 0:
                SwitchStyle(FontStyle.Normal);
                SpriteChange(sGrin_Peace);
                SwitchName(curName);
                break;
            case 1:
            case 2:
                SpriteChange(sNeutral_Neutral);
                break;
            case 3:
                SwitchName("You");
                break;
            case 4:
                SpriteChange(sNeutral_FistsRaised);
                SwitchName(curName);
                break;
            case 5:
                SwitchName("You");
                break;
            case 6:
                SpriteChange(sGrin_Peace);
                SwitchName(curName);
                break;
            case 7:
                EndTalk();
                break;
        }
        
    }

    private void play2_1b(){
        lines = sequence2_1b;
        curSeq = "2_1b";

        switch(curLine){
            case 0:
                SwitchStyle(FontStyle.Normal);
                SpriteChange(sWorry_Neutral);
                SwitchName(curName);
                break;
            case 1:
                SpriteChange(sNeutral_Neutral);
                break;
            case 2:
                SwitchName("You");
                break;
            case 3:
                SpriteChange(sGrin_Peace);
                SwitchName(curName);
                break;
            case 4:
                EndTalk();
                break;
        }
        
    }

    private void play2_2(){
        lines = sequence2_2;
        curSeq = "2_2";

        switch(curLine){
            case 0:
                SwitchStyle(FontStyle.Normal);
                SpriteChange(sWorry_Neutral);
                SwitchName(curName);
                break;
            case 1:
                SwitchName("You");
                break;
            case 2:
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
            case "1":
                seqMethod = () => play1_1();
                AdvanceTalk();
                break;
            case "2":
                seqMethod = () => play2_1();
                AdvanceTalk();
                break;
            case "2_1":
                seqMethod = () => play2_1a();
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
            case "2_1":
                seqMethod = () => play2_1b();
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
