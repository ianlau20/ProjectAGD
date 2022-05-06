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
    protected List<string> sequence3 = new List<string>();
    protected List<string> sequence4 = new List<string>();
    protected List<string> sequenceSad = new List<string>();

    

    // LoadDialogue is called after name is input
    public override void LoadDialogue()
    {
        mm = FindObjectOfType<ModeManager>();
        curLine = -1;
        session = 0;
        curSeq = "0";
        curName = "<color=#ff69b4ff>???</color>";
        lines = new List<string>();
        responses = new List<string>();
        SpriteChange(sWorry_Neutral);

        // SEQUENCE 1
        sequence1.Add("A girl stands in front of you, looking desperately looking through her bag.");   //italics
        sequence1.Add("Gosh, where did I put my phone, I just had it! I swear I’d lose my head if it wasn’t attached.");
        sequence1.Add("She looks up and notices you standing there.");
        sequence1.Add("Oh, hi hi! I’m Hana. What's up, dude?");
        sequence1.Add("Looks like she is over losing her phone…"); //ITALIC
        sequence1.Add("Hey, I’m "+ mm.username +". Just wanted to see what's up.");
        sequence1.Add("Hella! Did you see that cat guy? They are, like, sooooooooo cute! I wonder what is behind that mask. Maybe a little kitty piloting a robot body!");
        sequence1.Add("Yeah, I guess it’s pretty cute.");
        sequence1.Add("What an active imagination."); //ITALIC
        sequence1.Add("Bee-Tee-Dubs, do you, like, understand this game we are playing? I have no idea what's going on. Zero. Nada.");
        sequence1.Add("Well, that's kind of the point, I think. You have to figure out the rules as you play. Everyone is kinda in the same boat.");
        sequence1.Add("Awwwwwwwwwwwwww, that's waaaaay too hard. No wonder everyone looks like they aren't having fun. ∑(O_O;)");
        sequence1.Add("Well, there are probably other reasons they aren’t having fun. A lot is at stake here.");
        sequence1.Add("Hm? What’cha mean? We are just, like, playing for funsies, right?");
        sequence1.Add("Wait, does she not know what's going on here? Do I tell her?"); //ITALIC
        

        // SEQUENCE 1_1
        sequence1_1.Add("Didn’t you notice that people go missing after they lose? I think this is a game of life or death. If you don't win, you die!");
        sequence1_1.Add("Pfft…	HAHAHA!!! DUDE, THAT'S, LIKE, TOTALLY HILARIOUS! AHAHAHA! You totally had me scared for a second there, too… That was hella funny, dude.");
        sequence1_1.Add("You’re too pure for this world…"); //ITALIC
        sequence1_1.Add("What was that?");
        sequence1_1.Add("Nothing! See you later Hana!");
        sequence1_1.Add("Lators, gators!");

        // SEQUENCE 1_2
        sequence1_2.Add("Yeah, just for funsies, but winning is still pretty important.");
        sequence1_2.Add("Yeah, I guessssss, but I was never a competitive person, ya know? I just wanna have fun! (o^w^o)");
        sequence1_2.Add("Well, that's nice. I think that is a good trait to have.");
        sequence1_2.Add("Thanks, dude! I wanna have fun with everybody. It would make this place a lot brighter, don’cha think!");
        sequence1_2.Add("Well, I admire her passion."); //ITALIC
        sequence1_2.Add("Yeah, I think you’re right!");
        sequence1_2.Add("Well, nice talking to you, Hana.");
        sequence1_2.Add("Lators, gators!");

        // SEQUENCE 2
        sequence2.Add("Hey, Hana.");
        sequence2.Add("Oh! Hey, dude! What's up?");
        sequence2.Add("You know, the usual. Trying to not die, I guess.");
        sequence2.Add("Haha. You are, like, so hilarious!");
        sequence2.Add("BTW, I think I figured something out. I can play a tiger on top of another tiger!");
        sequence2.Add("That adds up. I think that confirms that matching Zodiacs are a rule.");
        sequence2.Add("Did you notice anything else like that happening?");
        sequence2.Add("Hmmm…. I don’t think so, but I will definitely let you know! (´ v ` *)");
        sequence2.Add("Alsoooooo, did you notice all the animals and the zodiac calendars everywhere?");
        sequence2.Add("I love zodiac signs. Can I guess yours?");

        // SEQUENCE 2_1
        sequence2_1.Add("Hana grabs your hand and closes her eyes.");
        sequence2_1.Add("Hmmmmm….");
        sequence2_1.Add("Haha, just kidding!");
        sequence2_1.Add("She opens her eyes and lets go of your hand.");
        sequence2_1.Add("That was all for show. Did I get you? You for sure thought I was reading your mind or something, LOL!");
        sequence2_1.Add("But, I think…. You are a dragon! Well? Well? Am I right?!");

        // SEQUENCE 2_1a
        sequence2_1a.Add("HAHA YES! I knew it!");
        sequence2_1a.Add("Hana starts jumping around in circles and cheering.");
        sequence2_1a.Add("You know how I could tell?");
        sequence2_1a.Add("I think there is something about you. I noticed you talked to other people and even me.");
        sequence2_1a.Add("It's your energy. There is something about you that's… special.");
        sequence2_1a.Add("Hana starts to twirl her hair with her finger.");
        sequence2_1a.Add("Thanks, I try my best. I feel like there is some way to make this situation better.");
        sequence2_1a.Add("YEAH! I always try my best to make everyone happy! Seeing you talking to people inspired me to try my hardest too!");
        sequence2_1a.Add("Thanks, Hana. I will keep doing everything I can. I’ll see ya.");
        sequence2_1a.Add("See ya, hyena!");

        // SEQUENCE 2_1b
        sequence2_1b.Add("Awww, well that stuff is kind of just speculation anyway, right?");
        sequence2_1b.Add("I think you still act like a dragon, at least.");
        sequence2_1b.Add("You are outgoing and stand out in a crowd. Even in this crowd of diverse people, you still manage to have a presence.");
        sequence2_1b.Add("Thanks, Hana. I mean it. That gives me a bit more confidence, haha. I’ll be seeing you.");
        sequence2_1b.Add("See ya, hyena!");

        // SEQUENCE 2_2
        sequence2_2.Add("Oh ok, no worries, haha.");
        sequence2_2.Add("Well, I’m gonna get going now. Later Hana.");
        sequence2_2.Add("Hana looks a little sad, but manages to get some words out.");
        sequence2_2.Add("See ya, hyena…");

        // SEQUENCE 3
        sequence3.Add("…");
        sequence3.Add("Is something wrong, Hana?");
        sequence3.Add("I can't do this anymore. I've reached my limit.");
        sequence3.Add("Oh...");
        sequence3.Add("I need to move! It’s so cramped in this room. I can’t find a good way to stretch my legs.");
        sequence3.Add("Oh, that's what she meant.");//bold
        sequence3.Add("Do you exercise often?");
        sequence3.Add("Every weekday! Exercise is a great way to clear the mind and feel good!");
        sequence3.Add("Nice! Do you play any sports or something?");
        sequence3.Add("No, not really. I never really liked sports cuz I can't go at my own pace ya know? Which is why I like just working out at the gym.");
        sequence3.Add("Oh! I also love going for walks or runs. You should come with me on a run some time! (^o^)/");
        sequence3.Add("You would probably leave me in the dust, haha.");
        sequence3.Add("Aw, don't worry. It's not a race! Well, I guess it technically is, but not like that!");
        sequence3.Add("I think it's important to do things, especially exercising—at your own pace.");
        sequence3.Add("Besides, you are doing it for yourself, right? So who cares what anyone else thinks!");
        sequence3.Add("Ugh, I feel like I’m gonna die if I can't get some physical activity…");
        sequence3.Add("You know what? Let's do some push-ups, like, right now! You and me!");
        sequence3.Add("What!? Right here, right now?! What if everyone else sees us?!");
        sequence3.Add("Huh? Who cares?! Let’s goooooo!");
        sequence3.Add("Before you can say another word, Hana is on the floor doing push-ups.");
        sequence3.Add("1, 2, 3, 4–c’mon, dude, don’t leave me hanging!");
        sequence3.Add("Some stronger force overcomes you, and as soon as you know it, you’re on the ground too.");
        sequence3.Add("I can't believe I’m doing this…");
        sequence3.Add("That's the spirit! Let's try 100 more!");
        sequence3.Add("100?!");
        sequence3.Add("Or just do however much you're comfortable with! (oω<)*");
        sequence3.Add("After a few minutes, you both stand up.");
        sequence3.Add("WHOOO! Wasn't that great!?!");
        sequence3.Add("You know what, I feel a lot better. Even my sinuses cleared up. ");
        sequence3.Add("Told ya! Exercising makes you feel sooo good!");
        sequence3.Add("It's a very lenient activity, so you can fit it in your schedule whenever.");
        sequence3.Add("Maybe I’ll do some push-ups every morning from now on.");
        sequence3.Add("Hella! Doing some light exercise is a great way to start your day!");
        sequence3.Add("Thanks, Hana! This was a lot of fun. See ya around!");
        sequence3.Add("Toodle-oo, cockatoo!");


        // SEQUENCE 4
        sequence4.Add("Hey, dude!");
        sequence4.Add("Hey, Hana.");
        sequence4.Add("Everything going alright? You seem kind of down.");
        sequence4.Add("Well, a lot has happened recently with this game and all, and I think it's finally getting to me.");
        sequence4.Add("…");
        sequence4.Add("Well, do you want to listen to me ramble for a bit? Maybe it can help get your mind off things. Let's sit.");
        sequence4.Add("Sure, I’d like that.");
        sequence4.Add("You and Hana sit on the floor next to each other, leaning against the wall.");
        sequence4.Add("Well, there are a lot of things in life that make me… Stressed out, ya know?");
        sequence4.Add("Like, big exams or any formal occasion, things that make me feel like I have to repress my true self.");
        sequence4.Add("Do you ever feel like that sometimes?");
        sequence4.Add("Yeah, I do. I think everyone goes through something similar.");
        sequence4.Add("Exactly! I think every human goes through stressful things, but… I think the way we deal with it is what matters.");
        sequence4.Add("Yeah, sometimes you let things bottle up for too long.");
        sequence4.Add("Yep! You need ways to release that energy, and there are so many ways to do it. I love to exercise, as you know, but I really love talking to people.");
        sequence4.Add("I’m the type of person who wants everyone in the room to be my friend, or at least be able to rely on me if they need to.");
        sequence4.Add("Ha, I think that's what I’m doing right now.");
        sequence4.Add("Well? Do you feel better yet?");
        sequence4.Add("I’m just kidding, but it makes me happy that you came to talk to me.");
        sequence4.Add("When I’m around her, it makes me feel like I'm absorbing everything great about humanity."); //bold
        sequence4.Add("I’m happy I came to talk to you, too.");
        sequence4.Add("Can I share a funny story with you?");
        sequence4.Add("Go ahead.");
        sequence4.Add("This is something I think about when I feel down. It never fails to cheer me up.");
        sequence4.Add("I was the new kid in middle school. I just moved from out of state.");
        sequence4.Add("I remember wearing this red sweater with a black skirt.");
        sequence4.Add("I had a matching red hairband and these cute black dress shoes with red flower buttons in the middle.");
        sequence4.Add("I struggled trying to find someone to talk to, believe it or not, so I ended up spending the entire first day by myself.");
        sequence4.Add("At the end of the last period, everyone was getting ready to leave.");
        sequence4.Add("It rained a lot the previous day, so the ground was muddy.");
        sequence4.Add("I wasn’t used to walking in the mud, so when I walked out of class, I lost my footing and slipped.");
        sequence4.Add("It was like a cartoon banana peel. My leg swung over in front of my head, and I fell right on my butt.");
        sequence4.Add("Mud splashed all over me, and you know what?");
        sequence4.Add("I started laughing and couldn’t help myself. I can’t remember laughing harder in my life. Everyone must have thought I was crazy.");
        sequence4.Add("People walking by staring at me, while the quiet new girl laughed by herself in the mud.");
        sequence4.Add("Then, a girl almost twice my height walked up to me, grabbed both my hands, and pulled me up.");
        sequence4.Add("We both looked at each other and started laughing together. She instantly became my best friend.");
        sequence4.Add("We spent every day together. We were gonna graduate and travel the world. I miss her lots.");
        sequence4.Add("Ah! Sorry, I got a little dark at the end there, and I totally talked your ears off! I'm so sorry!");
        sequence4.Add("That's alright. It seems like an important story to you.");
        sequence4.Add("Yeah. I think times like that are important to remember. They can help you out far into the future.");
        sequence4.Add("Thanks for sharing it with me.");
        sequence4.Add("Of course! Thanks for listening. I think I’m gonna rest for a while, if that's okay.");
        sequence4.Add("Sure thing. See ya, Hana.");
        sequence4.Add("Take care, bear!");

        // SEQUENCE SAD
        sequenceSad.Add("Oh hey dude! I’m still a little tired, so I’m gonna rest a bit more. Sorry!");
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
                SpriteChange(sWorry_Neutral);
                SwitchName("");
                SwitchStyle(FontStyle.Italic);
                break;

            case 1:
                SwitchName(curName);
                SwitchStyle(FontStyle.Normal);
                break;

            case 2:
                SwitchName("");
                SwitchStyle(FontStyle.Italic);
                break;
            
            case 3:
                SpriteChange(sGrin_Peace);
                curName = "<color=#ff69b4ff>Hana</color>";
                SwitchName(curName);
                SwitchStyle(FontStyle.Normal);
                break;

            case 4:
                SwitchName("You");
                SwitchStyle(FontStyle.Italic);
                break;

            case 5:
                SwitchStyle(FontStyle.Normal);
                break;
            
            case 6:
                SpriteChange(sGrin_FistsRaised);
                SwitchName(curName);
                break;
            
            case 7:
                SwitchName("You");          
                break;

            case 8:
                SwitchStyle(FontStyle.Italic);//what an active..
                break;

            case 9:
                SpriteChange(sNeutral_Neutral);
                SwitchName(curName);
                SwitchStyle(FontStyle.Normal);
                break;

            case 10:
                SwitchName("You"); //thats kinda the point
                break;

            case 11:
                SpriteChange(sWorry_FistsRaised);
                SwitchName(curName);
                break;

            case 12:
                SwitchName("You");
                break;

            case 13:
                SpriteChange(sNeutral_Neutral);
                SwitchName(curName);
                break;

            case 14:
                SwitchName("You");
                SwitchStyle(FontStyle.Italic);
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
                SwitchStyle(FontStyle.Italic);
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
                SwitchStyle(FontStyle.Italic);        
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
                responses.Add("Yeah, sure.");
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
                break;
            case 3:
                SwitchName("");
                SwitchStyle(FontStyle.Italic);
                break;
            case 4:
                SpriteChange(sGrin_Neutral);
                SwitchStyle(FontStyle.Normal);
                SwitchName(curName);
                break;
            case 5:
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
                SwitchStyle(FontStyle.Italic);
                break;
            case 2:
                SwitchStyle(FontStyle.Normal);
                SpriteChange(sNeutral_Neutral);
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                SwitchStyle(FontStyle.Italic);
                break;
            case 6:
                SwitchStyle(FontStyle.Normal);
                SwitchName("You");
                break;
            case 7:
                SpriteChange(sNeutral_FistsRaised);
                SwitchName(curName);
                break;
            case 8:
                SwitchName("You");
                break;
            case 9:
                SpriteChange(sGrin_Peace);
                SwitchName(curName);
                break;
            case 10:
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
                break;
            case 3:
                SwitchName("You");
                break;
            case 4:
                SpriteChange(sGrin_Peace);
                SwitchName(curName);
                break;
            case 5:
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
                SwitchStyle(FontStyle.Italic);
                SwitchName("");
                break;
            case 3:
                SwitchStyle(FontStyle.Normal);
                SwitchName(curName);
                break;
            case 4:
                EndTalk();
                break;
        }
        
    }

    private void play3(){
        lines = sequence3;
        curSeq = "3";

        switch(curLine){
            case 0:
                SpriteChange(sSob_Neutral);
                SwitchName(curName);
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
                SpriteChange(sDetermined_FistsRaised);
                SwitchName(curName);
                break;
            case 5:
                SwitchStyle(FontStyle.Italic);
                SwitchName("You");
                break;
            case 6:
                SwitchStyle(FontStyle.Normal);
                SwitchName("You");
                break;
            case 7:
                SpriteChange(sGrin_FistsRaised);
                SwitchName(curName);
                break;
            case 8:
                SwitchName("You");
                break;
            case 9:
                SpriteChange(sNeutral_Neutral);
                SwitchName(curName);
                break;
            case 10:
                SpriteChange(sDetermined_FistsRaised);
                SwitchName(curName);
                break;
            case 11:
                SwitchName("You");
                break;
            case 12:
                SpriteChange(sGrin_Peace);
                SwitchName(curName);
                break;
            case 13:
                SpriteChange(sDetermined_FistsRaised);
                break;
            case 14:
                break;
            case 15:
                SpriteChange(sSob_Neutral);
                break;
            case 16:
                SpriteChange(sDetermined_FistsRaised);
                break;
            case 17:
                SwitchName("You");
                break;
            case 18:
                SwitchName(curName);
                break;

            case 19:
                SwitchName("");
                SwitchStyle(FontStyle.Italic);
                break;
            case 20:
                SwitchName(curName);
                SwitchStyle(FontStyle.Normal);
                break;
            case 21:
                SwitchName("");
                SwitchStyle(FontStyle.Italic);
                break;
            case 22:
                SwitchStyle(FontStyle.Normal);
                SwitchName("You");
                break;
            case 23:
                SpriteChange(sGrin_FistsRaised);
                SwitchName(curName);
                break;
            case 24:
                SwitchName("You");
                break;
            case 25:
                SpriteChange(sGrin_Peace);
                SwitchName(curName);
                break;
            case 26:
                SwitchStyle(FontStyle.Italic);
                SwitchName("");
                break;
            case 27:
                SpriteChange(sDetermined_FistsRaised);
                SwitchStyle(FontStyle.Normal);
                SwitchName(curName);
                break;
            case 28:
                SwitchName("You");
                break;
            case 29:
                SpriteChange(sGrin_FistsRaised);
                SwitchName(curName);
                break;
            case 30:
                SpriteChange(sGrin_Neutral);
                break;
            case 31:
                SwitchName("You");
                break;
            case 32:
                SpriteChange(sNeutral_Peace);
                SwitchName(curName);
                break;
            case 33:
                SwitchName("You");
                break;
            case 34:
                SpriteChange(sGrin_Neutral);
                SwitchName(curName);
                break;
            case 35:
                EndTalk();
                break;
        }
        
    }

    private void play4(){
        lines = sequence4;
        curSeq = "4";

        switch(curLine){
            case 0:
                SpriteChange(sGrin_Peace);
                SwitchName(curName);
                break;
            case 1:
                SwitchName("You");
                break;
            case 2:
                SpriteChange(sWorry_FistsRaised);
                SwitchName(curName);
                break;
            case 3:
                SwitchName("You");
                break;
            case 4:
                SpriteChange(sWorry_Neutral);
                SwitchName(curName);
                break;
            case 5:
                SpriteChange(sNeutral_Neutral);
                SwitchName(curName);
                break;
            case 6:
                SwitchName("You");
                break;
            case 7:
                SwitchName("");
                SwitchStyle(FontStyle.Italic);
                break;
            case 8:
                SpriteChange(sWorry_Neutral);
                SwitchName(curName);
                SwitchStyle(FontStyle.Normal);
                break;
            case 9:
                break;
            case 10:
                SpriteChange(sWorry_FistsRaised);
                SwitchName(curName);
                break;
            case 11:
                SwitchName("You");
                break;
            case 12:
                SpriteChange(sDetermined_FistsRaised);
                SwitchName(curName);
                break;
            case 13:
                SwitchName("You");
                break;
            case 14:
                SpriteChange(sGrin_FistsRaised);
                SwitchName(curName);
                break;
            case 15:
                SwitchName(curName);
                break;
            case 16:
                SwitchName("You");
                break;
            case 17:
                SpriteChange(sDetermined_FistsRaised);
                SwitchName(curName);
                break;
            case 18:
                SpriteChange(sGrin_Neutral);
                SwitchName(curName);
                break;
            case 19:
                SwitchStyle(FontStyle.Italic);
                SwitchName("You");
                break;
            case 20:
                SwitchStyle(FontStyle.Normal);
                SwitchName("You");
                break;
            case 21:
                SpriteChange(sNeutral_Neutral);
                SwitchName(curName);
                break;
            case 22:
                SwitchName("You");
                break;
            case 23:
                SpriteChange(sDetermined_FistsRaised);
                SwitchName(curName);
                break;
            case 24:
                SpriteChange(sNeutral_Neutral);
                break;
            case 25:
                SpriteChange(sGrin_FistsRaised);
                break;
            case 26:
                break;
            case 27:
                SpriteChange(sWorry_Neutral);
                break;
            case 28:
                SpriteChange(sNeutral_Neutral);
                break;
            case 29:
                SpriteChange(sSob_FistsRaised);
                break;
            case 30:
                break;
            case 31:
                SpriteChange(sWorry_Neutral);
                break;
            case 32:
                break;
            case 33:
                SpriteChange(sGrin_FistsRaised);
                break;
            case 34:
               
                break;
            case 35:
                
                break;
            case 36:

                break;
            case 37:
                SpriteChange(sWorry_Neutral);
                break;
            case 38:
                SpriteChange(sDetermined_FistsRaised);
                break;
            case 39:
                SwitchName("You");
                break;
            case 40:
                SpriteChange(sNeutral_Neutral);
                SwitchName(curName);
                break;
            case 41:
                SwitchName("You");
                break;
            case 42:
                SpriteChange(sGrin_Neutral);
                SwitchName(curName);
                break;
            case 43:
                SwitchName("You");
                break;
            case 44:
                SpriteChange(sGrin_Peace);
                SwitchName(curName);
                break;
            case 45:
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
