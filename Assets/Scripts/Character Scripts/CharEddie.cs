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
    protected List<string> sequence3 = new List<string>();
    protected List<string> sequence3_1 = new List<string>();
    protected List<string> sequence3_2 = new List<string>();
    protected List<string> sequence3_3 = new List<string>();
    protected List<string> sequence3_4 = new List<string>();
    protected List<string> sequence4 = new List<string>();
    protected List<string> sequenceSad = new List<string>();
    

    // LoadDialogue is called after name is input
    public override void LoadDialogue()
    {
        mm = FindObjectOfType<ModeManager>();
        curLine = -1;
        session = 0;
        curSeq = "0";
        curName = "<color=#C19A6Bff>???</color>";
        lines = new List<string>();
        responses = new List<string>();
        SpriteChange(sSus_Neutral);

        // SEQUENCE 1
        sequence1.Add("You approach a tall man slouched over, starting to light a cigarette. He smells like smoke."); //italics
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
        sequence1_3.Add("There isn’t much to say about me. Maybe I’ll tell ya another time. You can call me Eddy, by the way.");

        // SEQUENCE 2
        sequence2.Add("Well, look who survived another round. How's it goin kid?");
        sequence2.Add("Hey Eddy.");
        sequence2.Add("So, did you really wanna know more about me? Is that why you came back?");
        sequence2.Add("I just wanted to know why you joined this game.");
        sequence2.Add("...");
        sequence2.Add("Say kid, do you have anything you regret? And not something like I wish I saw that movie. I’m talking about something you think about every night.");

        // SEQUENCE 2_1
        sequence2_1.Add("Really? You know, I’m kinda surprised. Maybe it's true that everyone has regrets, but I think what matters is how we move on from them.");
        sequence2_1.Add("Don’t let the things you can't change ruin the things you can.");

        // SEQUENCE 2_2
        sequence2_2.Add("Heh, I envy you kid. I hope it stays that way. Regrets are something you can’t do anything about.");
        sequence2_2.Add("It does horrible things to a person; it turns them into their worst selves.");

        // SEQUENCE 2_3
        sequence2_3.Add("Sorry to go all preacher on ya kid.");
        sequence2_3.Add("It's alright.");
        sequence2_3.Add("Haha, that kinda took it out of me. Look, if I’m still around next time feel free to see me again.");

        // SEQUENCE 3
        sequence3.Add("Hey, Eddy.");
        sequence3.Add("Looks like you’re still kickin. How ya holdin up kid? ");
        sequence3.Add("Just trying to stay positive I guess.");
        sequence3.Add("Well, that's the important part, right? No matter what life throws at ya, just keep on keepin on.");
        sequence3.Add("I’m probably the millionth person to have said that, but if it's been said so many times, it’s gotta have some truth to it right?");
        sequence3.Add("You seem to be saying stuff like that a lot. Is it coming from personal experience?");
        sequence3.Add("Ha, is it that obvious? Yeah, I guess you could say I have some experience in screwing up.");
        sequence3.Add("Oh sorry, I didn’t mean it like that.");
        sequence3.Add("Don’t sweat it, kid. If anything, see it as an old man trying to give some advice.");
        sequence3.Add("Well, in that case, I feel like even though we have talked a few times, I still don’t know anything about you.");
        sequence3.Add("You're persistent, aren’t ya.");
        sequence3.Add("Well then, what do you wanna know?");

        // SEQUENCE 3_1
        sequence3_1.Add("Sheesh, that’s a heavy hitter. I have a lot of regrets, but I think my biggest one would be giving in to my vices... ");
        sequence3_1.Add("I eventually quit, but by the time I did, the damage was already done.");

        // SEQUENCE 3_2
        sequence3_2.Add("I worked. I worked a lot. Had 3 jobs, none of them anything special, but I needed the cash. ");

        // SEQUENCE 3_3
        sequence3_3.Add("My dream huh. ");
        sequence3_3.Add("…");
        sequence3_3.Add("Restoring my life to what it was before. I want to fix my mistakes and make things go back to the way they were.");

        // SEQUENCE 3_4
        sequence3_4.Add("Thanks for sharing with me, Eddy. I bet it took a lot to say those things.");
        sequence3_4.Add("No problem, kid. Thanks for talking to me. It feels good to talk about it.");
        sequence3_4.Add("Anytime, Eddy.");
        sequence3_4.Add("I’m gonna relax a bit before the next round. Feel free to see me again if I make it to the next one. There are some things I want to talk to you about.");
        sequence3_4.Add("Okay. Take care, Eddy.");

        // SEQUENCE 4
        sequence4.Add("Hey, Eddy.");
        sequence4.Add("Oh, it's you. Glad you made it another round, kid.");
        sequence4.Add("Same to you, Eddy. ");
        sequence4.Add("You said last time that there was something you wanted to tell me?");
        sequence4.Add("Yeah, I wanted to tell you my story. It doesn’t mean much, but I wanted to repay you for taking the time to talk to an old man like me. ");
        sequence4.Add("Sure thing, Eddy. ");
        sequence4.Add("Hell, maybe you might learn a thing or two. ");
        sequence4.Add("Well, let's see. My childhood wasn’t anything special. I was a normal kid with a decent family. I think my life really started after I graduated college. ");
        sequence4.Add("I was always someone who admired hard work and tried my best in whatever I was doing. You could say that was also my greatest weakness. ");
        sequence4.Add("My hard work in college landed me a cushy office job. ");
        sequence4.Add("It wasn't anything special, but the pay was good, the workload was light, it had great benefits, and my coworkers were some great people.");
        sequence4.Add("That office job was when everything in my life started. There was a lady who worked down the hall from me. She was beautiful. ");
        sequence4.Add("Until this point, I was too busy focusing on my work to ever build any meaningful relationships, whether it be friends or a significant other. ");
        sequence4.Add("This lady, however, changed my life. We started talking, which led to dating, and eventually, we got married and even had a daughter.");
        sequence4.Add("She gave me a new purpose in life.");
        sequence4.Add("I never thought I’d be a family man, but when I was holding my newborn girl in my arms, I knew I had to do everything I could to make their lives amazing.");
        sequence4.Add("That moment was also my greatest downfall. I developed a mindset that I was never good enough.");
        sequence4.Add("I was never doing enough. I needed a way to provide more for my family.");
        sequence4.Add("In my desperation, I started gambling. What a perfect way to earn money quickly, right? I think you can guess how well that went.");
        sequence4.Add("I lost everything. I got stuck in a loop trying to win back what I lost by putting in more money. ");
        sequence4.Add("The stress drove me to drink and smoke. I even stopped showing up to work and eventually got fired. ");
        sequence4.Add("Everything was falling apart in front of me, but I didn’t realize it until I had lost everything. ");
        sequence4.Add("My wife divorced me and I lost custody of my daughter. By the time I realized what had happened, I was in too deep. ");
        sequence4.Add("So now, instead of trying to provide for my family, I have to prove to myself that I have changed. ");
        sequence4.Add("I sobered up and started working multiple jobs to pull myself out of debt, and well, I saw this opportunity and caved. ");
        sequence4.Add("It was my gambling problem all over again. I took a shortcut and now I’m in a death game run by some crazy cat thing. ");
        sequence4.Add("All in all, I took shortcuts and they screwed me over. Not to say shortcuts are necessarily bad, but some people draw the short stick in life. ");
        sequence4.Add("Sometimes there is only so much they can do before resorting to some sort of shortcut. ");
        sequence4.Add("The problem is there are a lot of people out there who prey on that desperation…");
        sequence4.Add("luring people who are down on their luck with the promises of greatness and wealth.");
        sequence4.Add("I should have done my research before going in, but desperation is a strong force to keep at bay.");
        sequence4.Add("So, that's everything kid. Nothing special, but that's me. Sorry for talking your ears off.");
        sequence4.Add("You don't have to say anything. That was a long ramble.");
        sequence4.Add("I just wanna say one last thing, thanks.");
        sequence4.Add("Thanks for not giving up on me and hearing me out. I appreciate it.");
        sequence4.Add("Yeah, of course, Eddy. Thanks for telling me your story.");
        sequence4.Add("Heh, no worries kid. I think I’m gonna take a smoke break. I’m kind of exhausted after all that. See ya around.");
        sequence4.Add("Goodbye, Eddy.");

        // SEQUENCE SAD
        sequenceSad.Add("Hey kid, still a bit too tired to talk right now, sorry.");

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
            case 2:
                seqMethod = () => play3();
                break;
            case 3:
                seqMethod = () => play4();
                break;
            case int session when session > 3:
                seqMethod = () => playSad();
                break;
        }
        
        AdvanceTalk();
    }

    private void play1(){
        lines = sequence1;
        curSeq = "1";

        switch(curLine){
            case 0:
                SpriteChange(sSus_Neutral);
                SwitchName("");
                SwitchStyle(FontStyle.Italic);
                break;
            case 1:
                SwitchName(curName);
                SwitchStyle(FontStyle.Normal);
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
                SpriteChange(sSus_ArmsCrossed);
                SwitchName(curName);

                ShowButtons2();
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

                ShowButtons2();
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
                break;
            case 2:
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
                break;
            case 2:
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

    private void play3(){
        lines = sequence3;
        curSeq = "3";

        switch(curLine){
            case 0:
                SwitchStyle(FontStyle.Normal);
                SwitchName("You");
                break;
            case 1:
                SpriteChange(sHappy_Neutral);
                SwitchName(curName);
                break;
            case 2:
                SwitchName("You");
                break;
            case 3:
                SpriteChange(sNeutral_ArmsCrossed);
                SwitchName(curName);
                break;
            case 4:
                SpriteChange(sDissapointed_HeadScratch);
                SwitchName(curName);
                break;
            case 5:
                SwitchName("You");
                break;
            case 6:
                SpriteChange(sHappy_HeadScratch);
                SwitchName(curName);
                break;
            case 7:
                SwitchName("You");
                break;
            case 8:
                SpriteChange(sHappy_Neutral);
                SwitchName(curName);
                break;
            case 9:
                SwitchName("You");
                break;
            case 10:
                SpriteChange(sNeutral_ArmsCrossed);
                SwitchName(curName);
                break;
            case 11:
                SwitchName(curName);

                ShowButtons();
                responses.Clear();
                responses.Add("What is your biggest regret?");
                responses.Add("What did you do before?");
                responses.Add("What is your dream?");
                mm.responseButtonTexts[0].GetComponent<Text>().text = responses[0];
                mm.responseButtonTexts[1].GetComponent<Text>().text = responses[1]; 
                mm.responseButtonTexts[2].GetComponent<Text>().text = responses[2]; 
                break;
        }
    }

      private void play3_1(){
        lines = sequence3_1;
        curSeq = "3_1";

        switch(curLine){
            case 0:
                SpriteChange(sHappy_HeadScratch);
                break;
            case 1:
                SpriteChange(sGrumpy_ArmsCrossed);
                SwitchName(curName);
                break;
            case 2:
                curLine = -1;
                seqMethod = () => play3_4();
                AdvanceTalk();
                break;
        }
    }

    private void play3_2(){
        lines = sequence3_2;
        curSeq = "3_2";

        switch(curLine){
            case 0:
                SpriteChange(sNeutral_Neutral);
                SwitchName(curName);
                break;
            case 1:
                curLine = -1;
                seqMethod = () => play3_4();
                AdvanceTalk();
                break;
        }
    }

    private void play3_3(){
        lines = sequence3_3;
        curSeq = "3_3";

        switch(curLine){
            case 0:
                SpriteChange(sDissapointed_HeadScratch);
                break ;
            case 1:
                SpriteChange(sSus_ArmsCrossed);
                break;
            case 2:
                SpriteChange(sNeutral_ArmsCrossed);
                SwitchName(curName);
                break;
            case 3:
                curLine = -1;
                seqMethod = () => play3_4();
                AdvanceTalk();
                break;
        }
    }

    private void play3_4(){
        lines = sequence3_4;
        curSeq = "3_4";

        switch(curLine){
            case 0:
                SwitchName("You");
                break;
            case 1:
                SpriteChange(sHappy_HeadScratch);
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
                EndTalk();
                break;
        }
    }

    private void play4(){
        lines = sequence4;
        curSeq = "4";
        SwitchStyle(FontStyle.Normal);

        switch(curLine){
            case 0:
                SpriteChange(sHappy_HeadScratch);
                SwitchName("You");
                break;
            case 1:
                SwitchName(curName);
                break;
            case 2:
                SwitchName("You");
                break;
            case 3:
                SwitchName("You");
                break;
            case 4:
                SpriteChange(sNeutral_ArmsCrossed);
                SwitchName(curName);
                break;
            case 5:
                SwitchName("You");
                break;
            case 6:
                SpriteChange(sHappy_HeadScratch);
                SwitchName(curName);
                break;
            case 7:
            case 8:
                SpriteChange(sNeutral_ArmsCrossed);
                break;
            case 9:
            case 10:
                SpriteChange(sHappy_HeadScratch);
                break;
            case 11:
            case 12:
                SpriteChange(sNeutral_ArmsCrossed);
                break;
            case 13:
            case 14:
                SpriteChange(sHappy_Neutral);
                break;
            case 15:
                SpriteChange(sHappy_HeadScratch);
                break;
            case 16:
            case 17:
                SpriteChange(sSus_Neutral);
                break;
            case 18:
                SpriteChange(sSus_ArmsCrossed);
                break;
            case 19:
                SpriteChange(sSus_Neutral);
                break;
            case 20:
            case 21:
                SpriteChange(sDissapointed_ArmsCrossed);
                break;
            case 22:
                SpriteChange(sDissapointed_Neutral);
                break;
            case 23:
                SpriteChange(sDissapointed_HeadScratch);
                break;
            case 24:
                SpriteChange(sNeutral_ArmsCrossed);
                break;
            case 25:
                SpriteChange(sSus_ArmsCrossed);
                break;
            case 26:
                SpriteChange(sNeutral_ArmsCrossed);
                break;
            case 27:
                SpriteChange(sDissapointed_HeadScratch);
                break;
            case 28:
            case 29:
                SpriteChange(sSus_ArmsCrossed);
                break;
            case 30:
                SpriteChange(sDissapointed_Neutral);
                break;
            case 31:
                SpriteChange(sHappy_HeadScratch);
                break;
            case 32:
                SpriteChange(sNeutral_Neutral);
                break;
            case 33:
            case 34:
                SpriteChange(sHappy_Neutral);
                SwitchName(curName);
                break;
            case 35:
                SwitchName("You");
                break;
            case 36:
                SpriteChange(sHappy_HeadScratch);
                SwitchName(curName);
                break;
            case 37:
                SwitchName("You");
                break;
            case 38:
                EndTalk();
                break;
        }
    }

    private void playSad(){
        lines = sequenceSad;
        curSeq = "Sad";

        switch(curLine){
            case 0:
                SpriteChange(sHappy_HeadScratch);
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
        mm.cameras[4].gameObject.SetActive(false);
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
            case "1":
                seqMethod = () => play1_1();
                AdvanceTalk();
                break;
            case "2":
                seqMethod = () => play2_1();
                AdvanceTalk();
                break;
            case "3":
                seqMethod = () => play3_1();
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
            case "1":
                seqMethod = () => play1_2();
                AdvanceTalk();
                break;
            case "2":
                seqMethod = () => play2_2();
                AdvanceTalk();
                break;
            case "3":
                seqMethod = () => play3_2();
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
            case "3":
                seqMethod = () => play3_3();
                AdvanceTalk();
                break;
        }
    }

    public override void SkipText()
    {
        AdvanceTalk();
    }

    private void ShowButtons2()
    {
        mm.responseButtons[0].SetActive(true);
        mm.responseButtons[1].SetActive(true);
    }

    private void ShowButtons()
    {
        mm.responseButtons[0].SetActive(true);
        mm.responseButtons[1].SetActive(true);
        mm.responseButtons[2].SetActive(true);
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
