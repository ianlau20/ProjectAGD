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
    public Sprite sNeutral_KnucklesCrack;
    public Sprite sNeutral_ArmsCrossed;
    public Sprite sIrate_KnucklesCrack;
    public Sprite sIrate_ArmsCrossed;
    public Sprite sBrowsRaised_KnucklesCrack;
    public Sprite sBrowsRaised_ArmsCrossed;
    public Sprite sBrowsFurrowed_KnucklesCrack;
    public Sprite sBrowsFurrowed_ArmsCrossed;
    public Sprite sAngry_KnucklesCrack;
    public Sprite sAngry_ArmsCrossed;


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
    protected List<string> sequenceEnemy = new List<string>();
    protected List<string> sequence3 = new List<string>();
    protected List<string> sequence4 = new List<string>();
    protected List<string> sequenceSad = new List<string>();

    private bool enemyMode = false;
    

    // LoadDialogue is called after name is input
    public override void LoadDialogue()
    {
        mm = FindObjectOfType<ModeManager>();
        curLine = -1;
        session = 0;
        curSeq = "0";
        curName = "<color=#800020ff>???</color>";
        lines = new List<string>();
        responses = new List<string>();
        SpriteChange(sNeutral_ArmsCrossed);

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

        // SEQUENCE ENEMY
        sequenceEnemy.Add("Leave.");

        // SEQUENCE 3
        sequence3.Add("Hey, Cody.");
        sequence3.Add("…");
        sequence3.Add("How are you?");
        sequence3.Add("I made it this far. Although, it has been mostly through luck.");
        sequence3.Add("Card games and strategy aren't exactly my thing. I’m sort of a punch first, think about the consequences later kind of guy.");
        sequence3.Add("Ya don’t say…");
        sequence3.Add("Has that strategy been successful? ");
        sequence3.Add("Haven’t lost an argument yet. Why don't I show you how it works?");
        sequence3.Add("What?");
        sequence3.Add("Let’s spar. Right here, right now.");
        sequence3.Add("Um, I don’t…");
        sequence3.Add("There is no better way for people to bond than combat, putting everything on the line. Fist to face, foot to chest. ");
        sequence3.Add("Great, now I gotta worry about getting killed outside of the game.");
        sequence3.Add("Why don’t we just talk, like friends?!");
        sequence3.Add("Friends that talk…. Interesting. What do we even talk about? ");
        sequence3.Add("Well, do you have any hobbies? Other than beating people up…");
        sequence3.Add("Hmmm. Well, I like fixing up cars. It puts my mind at ease. I end up zoning out and working for hours at a time. ");
        sequence3.Add("I don’t know anything about cars, but we are making some more progress here. ");
        sequence3.Add("What's your favorite part about fixing cars then?");
        sequence3.Add("Upgrading. I take an old car and add newer parts. I just got this Turbocharged 2.5-Liter-Inline-Five that I am trying to make fit into a classic Audi. It might be impossible, but I like the challenge. ");
        sequence3.Add("That's awesome! I like the look classic cars have. I feel like cars nowadays don't have the same personality. ");
        sequence3.Add("Exactly! Every car nowadays looks the same with no diversity. You get it, huh. If we met under different circumstances, maybe I could have taken you for a ride. ");
        sequence3.Add("Maybe in another life. ");
        sequence3.Add("By the way, there's been something I have been meaning to ask you.");
        sequence3.Add("Shoot.");
        sequence3.Add("You have a pretty interesting look with the sunglasses and bandana. Is there any special meaning behind them?");
        sequence3.Add("…");
        sequence3.Add("It's a long story, but I don’t think I am ready to tell it just yet.");
        sequence3.Add("*Cody lets out a deep sigh* ");
        sequence3.Add("If both of us make it to the next round, I will tell you everything about it. How about that?");
        sequence3.Add("Okay, I will see you then, Cody.");
        sequence3.Add("Yep.");

        // SEQUENCE 4
        sequence4.Add("Hey, Cody.");
        sequence4.Add("Hey, you made it. ");
        sequence4.Add("Yep, still kicking it seems.");
        sequence4.Add("So, you really are that interested in what I'm wearing huh? I guess a deal is a deal.");
        sequence4.Add("I was a runaway. I left the orphanage I was at when I was around 12 years old. It was a cold night and after I couldn’t run anymore, I found a foam mat in an alley to sleep on.");
        sequence4.Add("Right when I was about to close my eyes, a door opened in the alley and I was pulled inside. I thought I was done for. I should have known better. Running away at 12? I barely knew how to make cereal!");
        sequence4.Add("When I came to my senses, two giant figures stood over me. It felt like they were each eight feet tall. Then the lights turned on and it was two men. They looked like professional bodybuilders. ");
        sequence4.Add("They just stood there, staring at me. They started asking me a bunch of questions. “Who are you? Where are your parents? What are you doing in our alley?” I told them I ran away.");
        sequence4.Add("Then, they asked me why. I honestly didn’t have a good answer. I was well taken care of at the orphanage. Got to eat 3 meals a day, and had a roof over my head. ");
        sequence4.Add("I just felt that… Something was missing.");
        sequence4.Add("I felt like I didn’t belong. I never talked to any of the other kids. I just sat in my room and stared out the window. ");
        sequence4.Add("You could say me running away was just one big impulsive decision, but I knew that I didn’t want to go back no matter what.");
        sequence4.Add("Despite not having a real answer to give them, they understood me. It was almost like they were in a similar situation before. From there, they pretty much raised me.");
        sequence4.Add("They taught me how to shave, how to drive, and how to fight; everything a kid like me needed to know growing up.");
        sequence4.Add("I was with them for about 15 years until one day, someone took them from me. I will never forget that day.");
        sequence4.Add("I was walking back home after running some errands for them. Once I got closer to our building, I knew something was wrong. ");
        sequence4.Add("The front door was open and the lights were off. I dropped all the bags I was carrying and opened the door. ");
        sequence4.Add("In front of me were both their bodies in a pool of blood. Bullet holes in the walls, and stuff knocked over. It looked like there was a struggle.");
        sequence4.Add("To this day, I still don’t know who did it or why. It could have been a targeted attack or some burglar who got scared and pulled the trigger.");
        sequence4.Add("This bandana and these sunglasses are the last things I have that were theirs. I wear them so I never forget where I came from. ");
        sequence4.Add("I just want them back. I don’t care about anything else... I knew there was nothing I could do to bring them back, but how can I just move on from something like that? ");
        sequence4.Add("Which is why I’m here. If this cat person really can grant any wish, then I know what I need to do.");
        sequence4.Add("I have to win.");
        sequence4.Add("It’s a shame it had to be like this though. I am sure everyone else here are good people in similar situations as me. ");
        sequence4.Add("Even you, taking the time to talk to me and hear my story. You’re the first person to ever do that… Thank you.");
        sequence4.Add("It was very brave of you to share that with me, Cody. Thank you as well. ");
        sequence4.Add("Yeah… I think I want to be alone for a while just to gather my thoughts. I appreciate you talking to me through all this. ");
        sequence4.Add("Sure thing Cody, take care.");

        // SEQUENCE SAD
        sequenceSad.Add("I think I want to be alone for a while just to gather my thoughts. Thanks for understanding.");


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
            case 2:
                if(enemyMode){
                    seqMethod = () => playEnemy();
                }
                else{
                    seqMethod = () => play3();
                }
                break;
            case 3:
                if(enemyMode){
                    seqMethod = () => playEnemy();
                }
                else{
                    seqMethod = () => play4();
                }
                break;
            case int session when session > 3:
                if(enemyMode){
                    seqMethod = () => playEnemy();
                }
                else{
                    seqMethod = () => playSad();
                }
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
                SpriteChange(sBrowsRaised_ArmsCrossed);
                SwitchName(curName);
                break;
            
            case 2:
                SwitchName("You");          
                break;

            case 3:
                SpriteChange(sIrate_ArmsCrossed);
                SwitchName(curName);
                break;
            
            case 4:
                SwitchName("You");          
                break;
            case 5:
                SpriteChange(sAngry_ArmsCrossed);
                SwitchName(curName);
                break;
            
            case 6:
                SwitchName("You");          
                break;
            case 7:
                SpriteChange(sIrate_ArmsCrossed);
                SwitchName(curName);
                break;
            
            case 8:
                SwitchName("You");          
                break;
            case 9:
                SpriteChange(sNeutral_ArmsCrossed);
                SwitchName(curName);
                break;
            
            case 10:
                SwitchName("You");          
                break;
            case 11:
                SwitchName(curName);
                SpriteChange(sIrate_ArmsCrossed);
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
                SpriteChange(sNeutral_ArmsCrossed);
                SwitchName("You");
                SwitchStyle(FontStyle.Bold);
                break;
  
            case 1:
                SwitchStyle(FontStyle.Normal);
                break;
            
            case 2:
                SpriteChange(sIrate_ArmsCrossed);
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
                SpriteChange(sBrowsRaised_ArmsCrossed);
                SwitchName(curName);
                SwitchStyle(FontStyle.Normal);
                break;
            case 11:
                SwitchName("You");          
                break;
            case 12:
                SpriteChange(sIrate_KnucklesCrack);
                SwitchName(curName);
                break;
            
            case 13:
                SwitchName("You");          
                break;
            case 14:
                SpriteChange(sBrowsRaised_KnucklesCrack);
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
                SpriteChange(sAngry_KnucklesCrack);
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
                SpriteChange(sIrate_ArmsCrossed);
                SwitchName(curName);
                break;
            case 1:
                SwitchName("You");
                break;
            case 2:
                SwitchName(curName);
                break;
            case 3:
                SpriteChange(sNeutral_ArmsCrossed);
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

    private void play3(){
        lines = sequence3;
        curSeq = "3";

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
                SwitchName(curName);
                break;
            case 5:
                SwitchStyle(FontStyle.Bold);
                SwitchName("You");
                break;
            case 6:
                SwitchStyle(FontStyle.Normal);
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
                SwitchStyle(FontStyle.Bold);
                SwitchName("You");
                break;
            case 13:
                SwitchStyle(FontStyle.Normal);
                SwitchName("You");
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
                SwitchStyle(FontStyle.Bold);
                SwitchName("You");
                break;
            case 18:
                SwitchStyle(FontStyle.Normal);
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
                SwitchName("You");
                break;
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
                SwitchName(curName);
                break;
            case 28:
                SwitchName("");
                break;
            case 29:
                SwitchName(curName);
                break;
            case 30:
                SwitchName("You");
                break;
            case 31:
                SwitchName(curName);
                break;
            case 32:
                EndTalk();
                break;
        }
        
    }

    private void play4(){
        lines = sequence4;
        curSeq = "4";

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
                
                break;
            case 5:
                
                break;
            case 6:
                
                break;
            case 7:
                
                break;
            case 8:
                
                break;
            case 9:
                
                break;
            case 10:
                
                break;
            case 11:
                
                break;
            case 12:
                
                break;
            case 13:
                
                break;
            case 14:
                
                break;
            case 15:
                
                break;
            case 16:
                
                break;
            case 17:
                
                break;
            case 18:
                
                break;
            case 19:
                
                break;
            case 20:
            case 21:
            case 22:
            case 23:
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
                EndTalk();
                break;
        }
        
    }

    private void playEnemy(){
        lines = sequenceEnemy;
        curSeq = "Enemy";

        switch(curLine){
            case 0:
                SpriteChange(sIrate_ArmsCrossed);
                SwitchName(curName);
                break;
            case 1:
                EndTalk();
                break;
        }
        
    }

    private void playSad(){
        lines = sequenceSad;
        curSeq = "Sad";

        switch(curLine){
            case 0:
                SwitchName(curName);
                break;
            case 1:
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
        mm.cameras[3].gameObject.SetActive(false);
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
