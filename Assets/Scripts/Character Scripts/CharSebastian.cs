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
    public Sprite sWorry_Neutral;
    public Sprite sWorry_HandsClasped;
    public Sprite sWorry_Bow;
    public Sprite sMenacing_Bow;
    public Sprite sMenacing_Neutral;
    public Sprite sMenacing_HandsClasped;
    public Sprite sSus_Neutral;
    public Sprite sSus_HandsClasped;
    public Sprite sSus_Bow;
    public Sprite sNeutral_Neutral;
    public Sprite sNeutral_HandsClasped;
    public Sprite sNeutral_Bow;
    public Sprite sIrate_Neutral;
    public Sprite sIrate_HandsClasped;
    public Sprite sHappy_Neutral;
    public Sprite sHappy_HandsClasped;
    public Sprite sHappy_Bow;


    public SpriteRenderer self;
    public AudioSource UI_Feedback;
    public AudioClip SFX_clicked;
    protected List<string> sequence1 = new List<string>();
    protected List<string> sequence2 = new List<string>();
    protected List<string> sequence3 = new List<string>();
    protected List<string> sequence3_1 = new List<string>();
    protected List<string> sequence3_2 = new List<string>();
    protected List<string> sequence3_3 = new List<string>();
    protected List<string> sequence4 = new List<string>();
    protected List<string> sequenceSad = new List<string>();

    

    // LoadDialogue is called after name is input
    public override void LoadDialogue()
    {
        mm = FindObjectOfType<ModeManager>();
        curLine = -1;
        session = 0;
        curSeq = "0";
        curName = "<color=#15f4eeff>???</color>";
        lines = new List<string>();
        responses = new List<string>();
        SpriteChange(sNeutral_HandsClasped);

        // SEQUENCE 1
        sequence1.Add("Before you stands a tall and slender man, with perfect posture and grace. He smells like fresh flowers, and his aura oozes perfection and class.");
        sequence1.Add("Just seeing him makes you stand up straight and unclench your jaw like you got in trouble with the principal in middle school.");
        sequence1.Add("Why am I acting like this? I’m a fully grown adult here. It’s just something about them."); //bold
        sequence1.Add("Well, hello there, let me introduce myself. I am Sebastian Duke Ainsworth, head butler for the house of Windsor.");
        sequence1.Add("Oh.. um, I’m " + mm.username + " from, uh, house of… my parents");
        sequence1.Add("Well, " + mm.username + " from the house of parents, it is a pleasure to make your acquaintance. ");
        sequence1.Add("Nice to meet you, too, Sebastian Doot Ainswan, from the house of Wonka.");
        sequence1.Add("Sebastian will suffice.");
        sequence1.Add("Okay, Sebastian. ");
        sequence1.Add("Is there a reason you approached me, Master " + mm.username + "?");
        sequence1.Add("Oh, I just wanted to get to know everyone a bit better, so I am introducing myself.");
        sequence1.Add("Is that really the only reason?");
        sequence1.Add("What? Um, yeah.");
        sequence1.Add("Well, Master " + mm.username + ", is there anything you would like to know?");
        sequence1.Add("What's it like being a butler?");
        sequence1.Add("Being a butler is my calling, my destiny. I cannot see myself doing anything but this in my life.");
        sequence1.Add("I strive for greatness, excellence, and class, and nothing will stop me from completing my tasks.");
        sequence1.Add("Oh, so do-");
        sequence1.Add("Hard work, dedication, and honor are just a few things that make a butler special. It takes years of training to learn everything a family might need.");
        sequence1.Add("Like wha-");
        sequence1.Add("I’m glad you asked: cooking, cleaning, laundry, raising children, chauffeuring, shopping, tying up loose ends …");
        sequence1.Add("What was that last part?");
        sequence1.Add("If a butler cannot perform these tasks, then they do not deserve to call themselves a butler.");
        sequence1.Add("And besides, that does not even begin to scratch the surface of a butler's responsibilities.");
        sequence1.Add("Wh-");
        sequence1.Add("Not only this, but they must be perfect at every task. Simply being able to carry out these activities is not enough!");
        sequence1.Add("They must master it. Nothing but perfection is acceptable.");
        sequence1.Add("I sense some confusion coming from you Master " + mm.username + ". Shall I explain it from the top?");
        sequence1.Add("What? No, it’s totally clear! Drive the clothes and cook the kids. Got it. ");
        sequence1.Add("Well then, I will bore you with my ramblings no longer. Till another time, Master " + mm.username + ".");
        sequence1.Add("Au revoir, Sebastián.");


        // SEQUENCE 2
        sequence2.Add("Hello, Sebastian.");
        sequence2.Add("Ah, Master " + mm.username + ", I see you have survived another round, congratulations. ");
        sequence2.Add("Congrats to you for making it as well.");
        sequence2.Add("Much obliged. For the sake of my honor and pride, I cannot fail just yet.");
        sequence2.Add("Was there something else you wanted to discuss with me, Master" + mm.username + "?");
        sequence2.Add("Can you teach me your ways?");
        sequence2.Add("Teach you?");
        sequence2.Add("...");
        sequence2.Add("Etiquette and butlering is not a game; it takes years of dedication and practice. Are you sure you are up for it?");
        sequence2.Add("Yes, yes I am.");
        sequence2.Add("Very well. Clearly, we do not have years to practice, so I will just be giving you the basics of etiquette. ");
        sequence2.Add("Let's do this. ");
        sequence2.Add("At formal parties and events, always hold your drink in your left hand.");
        sequence2.Add("Why is tha-");
        sequence2.Add("This ties into another rule, always shake with your right hand. You don’t want any liquid from your glass to get onto your shaking hand.");
        sequence2.Add("This also applies to anything else you might be carrying, like purses or handbags. ");
        sequence2.Add("Got it!");
        sequence2.Add("Good.");
        sequence2.Add("Next lesson, in any event where you are given name tags, never wear your nametag over your heart.");
        sequence2.Add("Always wear it on the right side of your chest, that way it will still be visible during handshakes. ");
        sequence2.Add("Handshakes seem to be very important.");
        sequence2.Add("Extremely. I could go on for years about important handshake etiquette. But for the sake of time, I will give you one more rule. Ready?");
        sequence2.Add("Ready.");
        sequence2.Add("When giving a handshake, make sure your grip is firm, not bone-crushing.");
        sequence2.Add("Once you connect hands, the handshake should last about three seconds or three hand pumps, no more no less.");
        sequence2.Add("Ok, three pumps got it.");
        sequence2.Add("Would you like to practice your handshake, Master " + mm.username + "?");
        sequence2.Add("Yeah!");
        sequence2.Add("Very well.");
        sequence2.Add("Sebastian extends his right hand with a smile.");
        sequence2.Add("His hand firmly grasps yours, followed by one, two, three pumps.");
        sequence2.Add("Well done, Master " + mm.username + ", you have a very firm grip. It seems you have learned a lot in such a short time.");
        sequence2.Add("I’m learning from the best. What can I say?");
        sequence2.Add("I shall prepare another lesson for you if you wish to see me next time, Master " + mm.username + ".");
        sequence2.Add("Farewell, Sebastian.");

        // SEQUENCE 3
        sequence3.Add("Hello, Sebastian!");
        sequence3.Add("Ah, hello, Young Master.");
        sequence3.Add("*Sebastian extends his arm for a handshake, how do you respond?*");


        // SEQUENCE 3_1
        sequence3_1.Add("*Sebastian smiles, and shakes your hand with a firm grip.*");
        sequence3_1.Add("A pleasure, to see you again, Young Master.");

        // SEQUENCE 3_2
        sequence3_2.Add("Remember, Young Master, always shake with your right hand. ");
        sequence3_2.Add("Oops!");

        // SEQUENCE 3_3
        sequence3_3.Add("If you are seeing me again, I assume you are ready for our next lesson, yes? ");
        sequence3_3.Add("Yes, sir!");
        sequence3_3.Add("Very good. Our next lesson will be on proper table manners. ");
        sequence3_3.Add("Once you sit down, place your napkin on your lap. It shall remain there until the end of the meal unless being used. ");
        sequence3_3.Add("Never put the used napkin back on the table, is that clear?");
        sequence3_3.Add("Napkin on lap, got it.");
        sequence3_3.Add("Good, now that you have taken your seat, do not place any personal items on the table. Leave your phone, keys, etcetera in your pockets or bag. ");
        sequence3_3.Add("Any questions so far?");
        sequence3_3.Add("So far, so good!");
        sequence3_3.Add("Excellent, now onto our last lesson for this session. ");
        sequence3_3.Add("This is one of the most common rules of etiquette, but I believe it is the most important.");
        sequence3_3.Add("When eating with other people, once the food arrives, wait until everyone has their plate before you start eating. ");
        sequence3_3.Add("That seems simple enough.");
        sequence3_3.Add("Correct; however, it is the most important. Not only are you being polite, but you are showing respect to your company. ");
        sequence3_3.Add("Whether it be friends, family, or coworkers, when you are joined at the dinner table, everyone deserves respect. ");
        sequence3_3.Add("Thank you for your help, Sebastian.");
        sequence3_3.Add("It is my pleasure, Young Master. ");
        sequence3_3.Add("Do you think one day, perhaps… We could get dinner sometime?");
        sequence3_3.Add("If fate connects us after this horrid game, it would be an honor.");
        sequence3_3.Add("It’s a deal then! Later, Sebastian.");
        sequence3_3.Add("Until next time, Young Master. ");
        sequence3_3.Add("dawg");
        sequence3_3.Add("dawg");
        sequence3_3.Add("dawg");
        sequence3_3.Add("dawg");


        // SEQUENCE 4
        sequence4.Add("Hello, Sebastian! ");
        sequence4.Add("Ah, hello, Young Master.");
        sequence4.Add("I’m ready for my next lesson, is there another one you can give me?");
        sequence4.Add("Yes, the lesson.");
        sequence4.Add("…");
        sequence4.Add("I’m afraid there is no lesson this time, and frankly never again.");
        sequence4.Add("Why? Did I do something wrong?");
        sequence4.Add("No, not at all, Young Master. The problem lies with me.");
        sequence4.Add("With you? What happened?");
        sequence4.Add("I’m afraid I’ve been lying to you, Young Master.");
        sequence4.Add("I am no butler… I am a failure.");
        sequence4.Add("What? But you taught me so many things.");
        sequence4.Add("Yes, however, I failed the most important task a butler has.");
        sequence4.Add("I failed to protect my masters—my family. ");
        sequence4.Add("What happened?");
        sequence4.Add("…");
        sequence4.Add("Very well. I will tell you.");
        sequence4.Add("I was a young man in an abusive household, but that did not matter to me. ");
        sequence4.Add("I had a dream, it didn’t matter what anyone said or did to me, I would achieve that dream.");
        sequence4.Add("I wanted to become a butler. I was always fascinated by their elegance, their prestige, I wanted to be just like them. ");
        sequence4.Add("Of course, I had no money to go to a proper school and learn so I took a job as a waiter to earn money.");
        sequence4.Add("Meanwhile, I would practice on my own and read books from the library on manners and etiquette. ");
        sequence4.Add("One day, however, a couple came into the restaurant, a husband and a wife. I served their table like normal and thought nothing of it.");
        sequence4.Add("After they finished eating, I was bringing them their check and the wife asked me if I was alright.");
        sequence4.Add("I was confused at first, thinking, “Did I do something wrong?” She then said to me that I have a sad look behind my eyes.");
        sequence4.Add("I wasn’t sure what to think, were they making fun of me? I thought at first, but the look on the couple's faces seemed genuine. ");
        sequence4.Add("They even asked when I got off work, so they could talk to me.");
        sequence4.Add("Out of pure curiosity, I indulged them. I made sure to stay near the restaurant for my safety, just in case. ");
        sequence4.Add("Then, the couple asked about my story. I told them about my living situation and my dream. ");
        sequence4.Add("They said they would pay for my schooling, and if I graduated they would hire me. ");
        sequence4.Add("I couldn’t believe it, but when I got a check in the mail, my dream became a reality.");
        sequence4.Add("I worked hard and graduated top of my class. It was a short, but extensive, 10-week program and I enjoyed every second of it. ");
        sequence4.Add("The couple gave me their address, after I graduated I drove to their manor and they welcomed me with open arms. ");
        sequence4.Add("My dream finally came true. ");
        sequence4.Add("After a few years of working, the couple had a child. A daughter. I raised her as if she was my own. ");
        sequence4.Add("This family not only helped me fulfill my dream but also gave me a chance to have a real family.");
        sequence4.Add("15 years go by, and I was living my best life. Until that one fateful day, I was staying at the manor to clean and prepare dinner, and I then received a call from the police. ");
        sequence4.Add("A drunk driver struck my family in a head-on collision. All three of them passed away. ");
        sequence4.Add("In one day, I lost everything. That is my greatest failure… I should have been there—done something to prevent it from happening.");
        sequence4.Add("But I wasn’t.");
        sequence4.Add("I am unfit to call myself a butler until I fix this.");
        sequence4.Add("Sebastian, I am so sorry.");
        sequence4.Add("I do not need your pity, Young Master. I need to win. ");
        sequence4.Add("It is not just my life on the line here. If I fail, my family will be gone forever, too. ");
        sequence4.Add("Unfortunately, that means you need to lose, too, Young Master.");
        sequence4.Add("You and I both know how this game works. ");
        sequence4.Add("I couldn’t lie to you anymore, pretending that everything was alright, knowing that in order to bring my family back… You would have to die.");
        sequence4.Add("I don’t—");
        sequence4.Add("Please, don't say anything. I can’t do this anymore. I am so sorry this is how we met, under other circumstances… You would make a great apprentice and even… A friend.");
        sequence4.Add("Goodbye, Young Master… Whatever afterlife there is, I hope it's kinder than this.");

        // SEQUENCE SAD
        sequenceSad.Add("…");

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
            case 1:
                SwitchName("");
                SwitchStyle(FontStyle.Italic);
                break;
            case 2:
                SwitchName("You");
                SwitchStyle(FontStyle.Italic);         
                break;
            case 3:
                SpriteChange(sNeutral_Bow);
                curName = "<color=#15f4eeff>Sebastian</color>";
                SwitchStyle(FontStyle.Normal);
                SwitchName(curName);
                break;
            case 4:
                SwitchName("You");          
                break;
            case 5:
                SpriteChange(sHappy_Bow);
                SwitchName(curName);
                break;
            case 6:
                SwitchName("You");          
                break;
            case 7:
                SpriteChange(sHappy_HandsClasped);
                SwitchName(curName);
                break;
            case 8:
                SwitchName("You");          
                break;
            case 9:
                SpriteChange(sNeutral_HandsClasped);
                SwitchName(curName);
                break;
            case 10:
                SwitchName("You");          
                break;
            case 11:
                SpriteChange(sIrate_HandsClasped);
                SwitchName(curName);
                break;
            case 12:
                SwitchName("You");          
                break;
            case 13:
                SpriteChange(sHappy_Bow);
                SwitchName(curName);
                break;
            case 14:
                SwitchName("You");          
                break;
            case 15:
                SpriteChange(sHappy_HandsClasped);
                SwitchName(curName);
                break;
            case 16:
                break;
            case 17:
                SwitchName("You");          
                break;
            case 18:
                SpriteChange(sNeutral_HandsClasped);
                SwitchName(curName);
                break;
            case 19:
                SwitchName("You");          
                break;
            case 20:
                SpriteChange(sIrate_HandsClasped);
                SwitchName(curName);
                break;
            case 21:
                SwitchName("You");          
                break;
            case 22:
                SwitchName(curName);
                break;
            case 23:
                break;
            case 24:
                SwitchName("You");          
                break;
            case 25:
            case 26:
            case 27:
                SpriteChange(sIrate_Neutral);
                SwitchName(curName);
                break;
            case 28:
                SwitchName("You");          
                break;
            case 29:
                SpriteChange(sNeutral_Bow);
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


    private void play2(){
        lines = sequence2;
        curSeq = "2";
        SwitchStyle(FontStyle.Normal);

        switch(curLine){
            case 0:
                SpriteChange(sNeutral_Neutral);
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
                SpriteChange(sHappy_Bow);
                SwitchName(curName);
                break;
            case 5:
                SwitchName("You");          
                break;
            case 6:
            case 7:
            case 8:
                SpriteChange(sIrate_Neutral);
                SwitchName(curName);
                break;
            case 9:
                SwitchName("You");          
                break;
            case 10:
                SpriteChange(sHappy_Bow);
                SwitchName(curName);
                break;
            case 11:
                SwitchName("You");          
                break;
            case 12:
                SpriteChange(sNeutral_Bow);
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
                SwitchName(curName);
                break;
            case 18:
                SpriteChange(sHappy_Bow);
                SwitchName(curName);
                break;
            case 19:
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
                SpriteChange(sHappy_HandsClasped);
                SwitchName(curName);
                break;
            case 24:
                break;
            case 25:
                SwitchName("You");          
                break;
            case 26:
                SpriteChange(sNeutral_HandsClasped);
                SwitchName(curName);
                break;
            case 27:
                SwitchName("You");     
                break;
            case 28:
                SwitchName(curName);
                break;
            case 29:
            case 30:
                SwitchName("");
                SwitchStyle(FontStyle.Italic);
                break;
            case 31:
                SpriteChange(sNeutral_Neutral);
                SwitchName(curName);
                SwitchStyle(FontStyle.Normal);
                break;
            case 32:
                SwitchName("You");     
                break;
            case 33:
                SpriteChange(sHappy_Neutral);
                SwitchName(curName);
                break;
            case 34:
                SwitchName("You");     
                break;
            case 35:
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
                SwitchName(curName);
                SpriteChange(sHappy_HandsClasped);
                break;
            case 2:
                SwitchStyle(FontStyle.Italic);
                SwitchName("");

                ShowButtons();
                responses.Clear();
                responses.Add("Extend right arm");
                responses.Add("Extend left arm");
                mm.responseButtonTexts[0].GetComponent<Text>().text = responses[0];
                mm.responseButtonTexts[1].GetComponent<Text>().text = responses[1]; 
                break;
        }
    }

      private void play3_1(){
        lines = sequence3_1;
        curSeq = "3_1";

        switch(curLine){
            case 0:
                SpriteChange(sNeutral_Neutral);
                SwitchStyle(FontStyle.Italic);
                SwitchName("");
                break;
            case 1:
                SwitchStyle(FontStyle.Normal);
                SwitchName(curName);
                break;
            case 2:
                curLine = -1;
                seqMethod = () => play3_3();
                AdvanceTalk();
                break;
        }
    }

    private void play3_2(){
        lines = sequence3_2;
        curSeq = "3_2";
        SwitchStyle(FontStyle.Normal);

        switch(curLine){
            case 0:
                SpriteChange(sIrate_Neutral);
                SwitchName(curName);
                break;
            case 1:
                SwitchName("You");
                break;
            case 2:
                curLine = -1;
                seqMethod = () => play3_3();
                AdvanceTalk();
                break;
        }
    }

    private void play3_3(){
        lines = sequence3_3;
        curSeq = "3_3";
        SwitchStyle(FontStyle.Normal);

        switch(curLine){
            case 0:
                SpriteChange(sHappy_HandsClasped);
                SwitchName(curName);
                break;
            case 1:
                SwitchName("You");
                break;
            case 2:
                SpriteChange(sNeutral_Bow);
                SwitchName(curName);
                break;
            case 3:
                SwitchName(curName);
                break;
            case 4:
                SwitchName(curName);
                break;
            case 5:
                SwitchName("You");
                break;
            case 6:
                SpriteChange(sHappy_HandsClasped);
                SwitchName(curName);
                break;
            case 7:
                SwitchName(curName);
                break;
            case 8:
                SwitchName("You");
                break;
            case 9:
                SpriteChange(sHappy_Neutral);
                SwitchName(curName);
                break;
            case 10:
                SpriteChange(sHappy_Bow);
                SwitchName(curName);
                break;
            case 11:
                SpriteChange(sNeutral_HandsClasped);
                SwitchName(curName);
                break;
            case 12:
                SwitchName("You");
                break;
            case 13:
                SpriteChange(sHappy_HandsClasped);
                SwitchName(curName);
                break;
            case 14:
                SwitchName(curName);
                break;
            case 15:
                SwitchName("You");
                break;
            case 16:
                SpriteChange(sNeutral_HandsClasped);
                SwitchName(curName);
                break;
            case 17:
                SwitchName("You");
                break;
            case 18:
                SpriteChange(sNeutral_Bow);
                SwitchName(curName);
                break;
            case 19:
                SwitchName("You");
                break;
            case 20:
                SpriteChange(sHappy_Bow);
                SwitchName(curName);
                break;
            case 21:
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
                SpriteChange(sWorry_HandsClasped);
                SwitchName("You");
                break;
            case 1:
                SwitchName(curName);
                break;
            case 2:
                SwitchName("You");
                break;
            case 3:
                SpriteChange(sWorry_Neutral);
                SwitchName(curName);
                break;
            case 4:
                SpriteChange(sMenacing_Neutral);
                SwitchName(curName);
                break;
            case 5:
                SpriteChange(sWorry_Neutral);
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
                SpriteChange(sWorry_HandsClasped);
                SwitchName(curName);
                break;
            case 10:
                SpriteChange(sWorry_Neutral);
                SwitchName(curName);
                break;
            case 11:
                SwitchName("You");
                break;
            case 12:
                SwitchName(curName);
                break;
            case 13:
                SwitchName(curName);
                break;
            case 14:
                SwitchName("You");
                break;
            case 15:
                SpriteChange(sWorry_Bow);
                SwitchName(curName);
                break;
            case 16:
                SpriteChange(sIrate_Neutral);
                break;
            case 17:
            case 18:
                SpriteChange(sWorry_Bow);
                break;
            
            case 19:
                SpriteChange(sWorry_Neutral);
                break;
            case 20:
            case 21:
                SpriteChange(sNeutral_Neutral);
                break;
            
            case 22:
            case 23:
            case 24:
            case 25:
            case 26:
                SpriteChange(sWorry_Neutral);
                break;
            
            case 27:
            case 28:
                SpriteChange(sNeutral_Neutral);
                break;
            
            case 29:
                SpriteChange(sHappy_Bow);
                break;
            case 30:
                SpriteChange(sHappy_HandsClasped);
                break;
            case 31:
                SpriteChange(sNeutral_Neutral);
                break;
            case 32:
            case 33:
                SpriteChange(sHappy_HandsClasped);
                break;
            
            case 34:
            case 35:
            case 36:
                SpriteChange(sNeutral_Neutral);
                break;
            
            case 37:
            case 38:
            case 39:
                SpriteChange(sWorry_Neutral);
                break;
            
            case 40:
                SwitchName(curName);
                break;
            case 41:
                SwitchName("You");
                break;
            case 42:
            case 43:
                SwitchName(curName);
                SpriteChange(sIrate_Neutral);
                break;
            
            case 44:
                SpriteChange(sMenacing_HandsClasped);
                SwitchName(curName);
                break;
            case 45:
            case 46:
                SpriteChange(sWorry_Neutral);
                SwitchName(curName);
                break;
            case 47:
                SwitchName("You");
                break;
            case 48:
                SwitchName(curName);
                SpriteChange(sIrate_HandsClasped);
                break;
            case 49:
                SpriteChange(sWorry_Bow);
                SwitchName(curName);
                break;
            case 50:
                EndTalk();
                break;
        }
    }

    private void playSad(){
        lines = sequenceSad;
        curSeq = "Sad";
        SwitchStyle(FontStyle.Normal);

        switch(curLine){
            case 0:
                SpriteChange(sWorry_Neutral);
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
        mm.cameras[5].gameObject.SetActive(false);
        mm.cameras[0].gameObject.SetActive(true);
        mm.EndConversation();
    }

    public override void Response1()
    {
        mm.responseButtons[0].SetActive(false);
        mm.responseButtons[1].SetActive(false);
        curLine = -1;

        switch(curSeq){
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
        curLine = -1;

        switch(curSeq){
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
