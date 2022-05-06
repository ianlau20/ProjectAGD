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
    public Sprite sThinking_Neutral;
    public Sprite sNeutral_Neutral;
    public Sprite sHesitant_Punch;
    public Sprite sHesitant_Neutral;
    public Sprite sHesitant_FistsUp;
    public Sprite sHappy_Punch;
    public Sprite sHappy_Neutral;
    public Sprite sHappy_FistsUp;
    public Sprite sBlush_Neutral;
    public Sprite sAngry_Punch;
    public Sprite sAngry_Neutral;
    public Sprite sAngry_FistsUp;
 
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
        curName = "<color=#A020F0ff>???</color>";
        lines = new List<string>();
        responses = new List<string>();
        SpriteChange(sThinking_Neutral);

        // SEQUENCE 1
        sequence1.Add("In front of you is a young man, squatting on the floor and subtly nodding his head to some rock music.");
        sequence1.Add("Where did he get that radio? Did he sneak it in with him? I guess the game master doesn't mind, since they probably would have confiscated it by now.");
        sequence1.Add("You swear in the corner of your eye you see the game master nodding along with the music.");
        sequence1.Add("The boy looks up and notices you. Suddenly, he stands up.");
        sequence1.Add("The hell are you looking at!?!");
        sequence1.Add("Oh nothing! Just admiring your tunes, haha. ");
        sequence1.Add("What!? Speak up! What are ya, a mouse!?");
        sequence1.Add("He turns the volume on his radio down.");
        sequence1.Add("So, what the fuck do you want, brat?");
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
        sequence1.Add("Name’s Cade, Cade Vicious. How's it fuckin' going?");
        sequence1.Add("I’m " + mm.username + ".");
        sequence1.Add("So, other than a god-tier music taste, what else is there to know about you?");
        sequence1.Add("I’m a pretty simple man. This city is my kingdom and I’m the king. I am a pretty chill king though. Don't piss me off and I won't bash your face in. Easy. ");
        sequence1.Add("Sounds simple enough.");
        sequence1.Add("Yup, me and my gang run this town. They are my ride or dies, my family. If you can handle yourself in a fight and can ride a bike, you might fit right in.");
        sequence1.Add("And not one with pedals, this ain't mommy's brunch hour. I am talkin’ two-cylinder all gas no breaks. ");
        sequence1.Add("Well, I might have to take you up on that offer. I'll see ya around, Cade.");
        sequence1.Add("Later weenie. ");
        

        // SEQUENCE 2
        sequence2.Add("What’s up, Cade?");
        sequence2.Add("Huh? Oh, it's you. What's up, brat?");
        sequence2.Add("Still not letting go of brat, I guess.");
        sequence2.Add("Not much.");
        sequence2.Add("Yeah, that's not surprising. By the way, can you ride a bike? I don’t think I got an answer last time. ");
        sequence2.Add("Yep, I haven't used training wheels since I was, like, six either. ");
        sequence2.Add("Training wheels? NO! I’m talking about a motorcycle, fuckin' idiot!");
        sequence2.Add("Oh, no I don't have a license. I've never even sat on one either.");
        sequence2.Add("What? A license? ");
        sequence2.Add("You don't have a license either?");
        sequence2.Add("Why the hell would I need a license? I can ride a bike fine! That's all that matters anyway. ");
        sequence2.Add("I pray you never get pulled over.");
        sequence2.Add("Why are you asking by the way?");
        sequence2.Add("Simple, if you are gonna join my gang, you are gonna need to know how to ride. 1000% mandatory requirement. ");
        sequence2.Add("And you seem like the prime candidate to join. That Cody guy seems cool.");
        sequence2.Add("He even has the leather jacket, but the dude doesn't open his damn mouth.");
        sequence2.Add("I'm honored that you're asking me to join. ");
        sequence2.Add("Hey! Don’t get ahead of yourself. We aren't there yet. What did I just say?! You need to know how to ride.");
        sequence2.Add("But don’t worry, I’m the best damn teacher around. I never give up on a student unlike those damn teachers at school.");
        sequence2.Add("Alright well, how am I gonna learn? I’m guessing you didn't manage to sneak an entire motorcycle in with you like that radio. ");
        sequence2.Add("Oh no, no, no, my starry-eyed student. Before you even think about sittin' your ass on a bike, you gotta learn the history. ");
        sequence2.Add("Why do I have to know that? ");
        sequence2.Add("Are you questioning my teaching method?");
        sequence2.Add("Don’t you want to know exactly what you're sittin' on before you are going a hundred somethin' miles per hour down the highway?");
        sequence2.Add("I guess that makes sense.");
        sequence2.Add("Of course it does!");
        sequence2.Add("For your first lesson, I’m gonna give you a quick quiz to see what I’m working with here. ");
        sequence2.Add("Okay, let's go.");
        sequence2.Add("Question one: Who invented the motorcycle?");
        

        // SEQUENCE 2_1_3
        sequence2_1_3.Add("Wrong! Next question.");

        // SEQUENCE 2_2
        sequence2_2.Add("Ding dong! Congrats! Alright, next question.");

        // SEQUENCE 2_4
        sequence2_4.Add("Who was the first person to ever go 300 mph on a motorcycle?");

        // SEQUENCE 2_5_7
        sequence2_5_7.Add("Nope! Last question.");

        // SEQUENCE 2_6
        sequence2_6.Add("Bing bong! Nice job, time for the last question.");

        // SEQUENCE 2_8
        sequence2_8.Add("Are motorcycles the most badass, best, coolest, and most awesome method of transportation?");

        // SEQUENCE 2_8a
        sequence2_8a.Add("Good, very good.");

        // SEQUENCE 2_8b
        sequence2_8b.Add("How dare you!");

        // SEQUENCE 2_9
        sequence2_9.Add("I think I have a lot on my plate, but I can work with this.");
        sequence2_9.Add("So you can make me into a badass biker?");
        sequence2_9.Add("Cade puts his hand on your shoulder.");
        sequence2_9.Add("Eventually, yes, but there is much to learn, young padawan.");
        sequence2_9.Add("Class is dismissed for now.");
        sequence2_9.Add("Later, Cade.");

        // SEQUENCE 3
        sequence3.Add("Hey! I gotta ask you something important.");
        sequence3.Add("Oh sure, what's up?");
        sequence3.Add("Do you like animals?");
        sequence3.Add("Uh…");
        sequence3.Add("Why are you staring at me like that?! Answer the damn question!");
        sequence3.Add("Yeah, I like animals.");
        sequence3.Add("Okay, great, that was another test. Congrats, you passed.");
        sequence3.Add("Is there any deeper meaning behind that question?");
        sequence3.Add("Don’t worry about the “deeper meaning” right now. ");
        sequence3.Add("Okay, follow-up question: Cats or dogs?");

        // SEQUENCE 3_1
        sequence3_1.Add("Hm, I am more of a dog person, but that is an acceptable answer. ");

        // SEQUENCE 3_2
        sequence3_2.Add("Nice! Me too, dogs are way cooler than cats. ");

        // SEQUENCE 3_3
        sequence3_3.Add("Interesting… I never thought of that before.");

        // SEQUENCE 3_4
        sequence3_4.Add("Good, good. Everything is looking great so far. ");
        sequence3_4.Add("Did you have any pets growing up Cade?");
        sequence3_4.Add("Of course! I found a small dog in an alley as a kid and took it home. Had to hide it from my parents though. Named him Meatball. ");
        sequence3_4.Add("He was a mutt. I couldn't tell what breed, but he looked like he had some beagle in him.");
        sequence3_4.Add("That's nice.");
        sequence3_4.Add("He was the best, small as a shoe, but man, he was tough as nails. He didn’t take shit from nobody.");
        sequence3_4.Add("Smart little bastard too. Managed to find where I hid the treats every time I moved them.");
        sequence3_4.Add("That’s awesome!");
        sequence3_4.Add("Right! This one time he…");
        sequence3_4.Add("DAMMIT, I’M SUPPOSED TO BE QUESTIONING YOU HERE! I DON’T WANNA THINK ABOUT THIS SHIT RIGHT NOW!");
        sequence3_4.Add("WE ARE DONE FOR TODAY!");
        sequence3_4.Add("Cade puts his arm over his eyes and walks away.");
        sequence3_4.Add("OH MEATBALL, MY LITTLE WARRIOR!");

        // SEQUENCE 4
        sequence4.Add("Yo! Dude! Come here for a sec.");
        sequence4.Add("What's going on Cade?");
        sequence4.Add("Alright, after evaluating your scores, I have decided that you are worthy.");
        sequence4.Add("Sweet! I can join your gang?");
        sequence4.Add("What? No, not that, this is MUCH bigger. ");
        sequence4.Add("Bigger? What is it?");
        sequence4.Add("My true dream.");
        sequence4.Add("Your true dream?");
        sequence4.Add("What are you, a parrot?! Let me finish.");
        sequence4.Add("Right, sorry.");
        sequence4.Add("Ever since I was a kid, I loved animals, especially strays. They reminded me of myself, tossed away by society with nowhere to go. ");
        sequence4.Add("Once I left my parent's place, I only had my small apartment, so I couldn't take care of a lot. I only got about 25 pets right now.");
        sequence4.Add("25?! That seems like a lot to me.");
        sequence4.Add("But it’s not enough. I need to go bigger. I want to open up an animal shelter. ");
        sequence4.Add("That sounds like a great idea!");
        sequence4.Add("It is. It comes with two problems though. One, I don't have enough money, and two, my appearance.");
        sequence4.Add("I’ve been taking night classes in secret so I can increase my chances of getting a better job, but issue number two is still a problem.");
        sequence4.Add("I get the money, but what do you mean your appearance is a problem?");
        sequence4.Add("Isn't it obvious? I can’t be a tough-as-nails biker gang leader and like puppies kissing my face at the same time!");
        sequence4.Add("My crew will think I'm soft, and I can't have that.");
        sequence4.Add("Are you sure? I think you might be exaggerating. ");
        sequence4.Add("No way! I can’t be a guy who punches people in the face for lookin at me funny, and dresses animals up in little costumes, talks to ‘em in baby voices, ...");
        sequence4.Add("and boops their little noses…");
        sequence4.Add("Agh! You see what I mean, I can’t show any weakness or else my image falls apart. ");
        sequence4.Add("I get what you mean, but I think you are overthinking it. Your crew, aren’t they your ride or dies? I think they wouldn’t care about all that.");
        sequence4.Add("No, no, no! You don’t get it. I have to be their fearless leader. If my weakness shows, it affects everything, not just me! ");
        sequence4.Add("But aren't you tired of hiding your true self and passions? You came to me to reveal your big plan.");
        sequence4.Add("I think you know deep inside you are ready to bring it out.");
        sequence4.Add("I-I don’t.");
        sequence4.Add("If these people are important to you, Cade, I doubt they would think any less of you.");
        sequence4.Add("Besides, your dream is one of great compassion, and frankly, I admire it a lot myself.");
        sequence4.Add("…");
        sequence4.Add("DON’T BE AFRAID TO SHOW WHO YOU REALLY ARE, CADE! YOU ARE STRONG AND A GREAT LEADER.");
        sequence4.Add("You’re right. YOU’RE RIGHT, GODDAMMIT! I’LL TELL ‘EM ALL! ONCE I GET OUTTA HERE, I’LL TELL THEM THE WHOLE PLAN!");
        sequence4.Add("HELL YEAH, CHEER WITH ME! I LOVE PUPPIES AND I’M PROUD!");
        sequence4.Add("I LOVE PUPPIES AND I’M PROUD!");
        sequence4.Add("I LOVE KITTIES AND I’M PROUD!");
        sequence4.Add("I LOVE KITTIES AND I’M PROUD!");
        sequence4.Add("I LOVE ANIMALS AND I’M PROUD!");
        sequence4.Add("I LOVE ANIMALS AND I’M PROUD!");
        sequence4.Add("Well, how do you feel?");
        sequence4.Add("I feel great, so great. All that yelling made me lightheaded though.");
        sequence4.Add("Yeah me too, haha.");
        sequence4.Add("Thanks bro, I mean it. Thanks to you, I finally have the chance to live out my dream. I’m gonna think about all my future plans now, so see ya around.");
        sequence4.Add("No problem Cade. Take care.");

        // SEQUENCE SAD
        sequenceSad.Add("Oh, what's up bro? Sorry, too busy thinking of my animal empire to talk to right now. See ya.");

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
                SwitchName("");
                SwitchStyle(FontStyle.Italic);
                break;
            case 1:
                SwitchName("You");
                break;
            case 2:
            case 3:
                SwitchName("");
                break;

            case 4:
                SpriteChange(sAngry_Punch);
                SwitchStyle(FontStyle.Normal);
                SwitchName(curName);
                break;
            case 5:
                SwitchName("You");          
                break;
            case 6:
                SpriteChange(sAngry_FistsUp);
                SwitchName(curName);
                break;
            case 7:
                SwitchName("");
                SwitchStyle(FontStyle.Italic);
                break;
            case 8:
                SpriteChange(sNeutral_Neutral);
                SwitchStyle(FontStyle.Normal);
                SwitchName(curName);
                break;
            case 9:
                SwitchName("You");
                SwitchStyle(FontStyle.Italic);
                break;
            case 10:
                SwitchName("You");   
                SwitchStyle(FontStyle.Normal);       
                break;
            case 11:
                SpriteChange(sHesitant_Neutral);
                SwitchName(curName);
                break;
            case 12:
                SwitchName("You");
                SwitchStyle(FontStyle.Italic);
                break;
            case 13:
                SwitchName("You");   
                SwitchStyle(FontStyle.Normal);       
                break;
            case 14:
                SpriteChange(sNeutral_Neutral);
                SwitchName(curName);
                break;
            case 15:
                SwitchName("You");        
                break;
            case 16:
                SpriteChange(sAngry_Punch);
                SwitchName(curName);
                break;
            case 17:
                SwitchName("You");
                break;
            case 18:
                SwitchName("You");   
                SwitchStyle(FontStyle.Italic);       
                break;
            case 19:
                SpriteChange(sThinking_Neutral);
                SwitchName(curName);
                SwitchStyle(FontStyle.Normal); 
                break;
            case 20:
                SwitchName("You");        
                break;
            case 21:
                SpriteChange(sNeutral_Neutral);
                SwitchName(curName);
                break;
            case 22:
                SpriteChange(sHappy_Neutral);
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
                SpriteChange(sHappy_Punch);
                SwitchName(curName);
                break;
            case 26:
                SwitchName("You");        
                break;
            case 27:
                SpriteChange(sHappy_FistsUp);
                SwitchName(curName);
                break;
            case 28:
                SwitchName(curName);
                break;
            case 29:
                SwitchName("You");        
                break;
            case 30:
                SpriteChange(sHesitant_Neutral);
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
                SpriteChange(sNeutral_Neutral);
                SwitchName("You");
                break;
            case 1:
                SwitchStyle(FontStyle.Normal);
                SwitchName(curName);
                break;
            case 2:
                SwitchName("You");
                SwitchStyle(FontStyle.Italic);
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
                SpriteChange(sAngry_FistsUp);
                SwitchName(curName);
                break;
            case 7:
                SwitchName("You");        
                break;
            case 8:
                SpriteChange(sAngry_Neutral);
                SwitchName(curName);
                break;
            case 9:
                SwitchName("You");        
                break;
            case 10:
                SpriteChange(sAngry_Punch);
                SwitchName(curName);
                break;
            case 11:
                SwitchName("You");    
                SwitchStyle(FontStyle.Italic);    
                break;
            case 12:
                SwitchName("You");   
                SwitchStyle(FontStyle.Normal);       
                break;
            case 13:
                SpriteChange(sThinking_Neutral);
                SwitchName(curName);
                break;
            case 14:
                SpriteChange(sHappy_Neutral);
                break;
            case 15:
                break;
            case 16:
                SwitchName("You");        
                break;
            case 17:
                SpriteChange(sAngry_Neutral);
                SwitchName(curName);
                break;
            case 18:
                break;
            case 19:
                SwitchName("You");        
                break;
            case 20:
                SpriteChange(sThinking_Neutral);
                SwitchName(curName);
                break;
            case 21:
                SwitchName("You");        
                break;
            case 22:
                SpriteChange(sAngry_Punch);
                SwitchName(curName);
                break;
            case 23:
                break;
            case 24:
                SwitchName("You");        
                break;
            case 25:
                SpriteChange(sHappy_Punch);
                SwitchName(curName);
                break;
            case 26:
                SpriteChange(sHesitant_Neutral);
                break;
            case 27:
                SwitchName("You");        
                break;
            case 28:
                SpriteChange(sNeutral_Neutral);
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
                SpriteChange(sAngry_Neutral);
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
                SpriteChange(sHappy_FistsUp);
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
                SpriteChange(sNeutral_Neutral);
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
                SpriteChange(sAngry_Neutral);
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
                SpriteChange(sHappy_FistsUp);
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
                SpriteChange(sThinking_Neutral);
                SwitchName(curName);
                break;
            case 1:
                SpriteChange(sNeutral_Neutral);
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
                SpriteChange(sThinking_Neutral);
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
                SpriteChange(sAngry_Punch);
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
                SpriteChange(sNeutral_Neutral);
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
                SpriteChange(sThinking_Neutral);
                SwitchName(curName);
                SwitchStyle(FontStyle.Normal);
                break;
            case 4:
                SpriteChange(sNeutral_Neutral);
                break;
            case 5:
                SwitchName("You");
                break;
            case 6:
                EndTalk();
                break;
        }
    }

    private void play3(){
        lines = sequence3;
        curSeq = "3";

        switch(curLine){
            case 0:
                SpriteChange(sAngry_FistsUp);
                SwitchStyle(FontStyle.Normal);
                SwitchName(curName);
                break;
            case 1:
                SwitchName("You");
                break;
            case 2:
                SwitchName(curName);
                SpriteChange(sBlush_Neutral);
                break;
            case 3:
                SwitchName("You");
                break;
            case 4:
                SpriteChange(sAngry_Punch);
                SwitchName(curName);
                break;
            case 5:
                SwitchName("You");
                break;
            case 6:
                SpriteChange(sHappy_Neutral);
                SwitchName(curName);
                break;
            case 7:
                SwitchName("You");
                break;
            case 8:
                SpriteChange(sHesitant_Punch);
                SwitchName(curName);
                break;
            case 9:
                SpriteChange(sNeutral_Neutral);
                ShowButtons();
                responses.Clear();
                responses.Add("Cats.");
                responses.Add("Dogs.");
                responses.Add("Neither.");
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
                SpriteChange(sThinking_Neutral);
                SwitchName(curName);
                break;
            case 1:
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
                SpriteChange(sHappy_FistsUp);
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
                SpriteChange(sThinking_Neutral);
                SwitchName(curName);
                break;
            case 1:
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
                SpriteChange(sNeutral_Neutral);
                SwitchName(curName);
                break;
            case 1:
                SwitchName("You");
                break;
            case 2:
                SpriteChange(sHappy_Punch);
                SwitchName(curName);
                break;
            case 3:
                SpriteChange(sHappy_Neutral);
                SwitchName(curName);
                break;
            case 4:
                SwitchName("You");
                break;
            case 5:
                SpriteChange(sHappy_FistsUp);
                SwitchName(curName);
                break;
            case 6:
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
                SpriteChange(sAngry_FistsUp);
                SwitchName(curName);
                break;
            case 10:
                SpriteChange(sAngry_Punch);
                SwitchName(curName);
                break;
            case 11:
                SwitchName("");
                SwitchStyle(FontStyle.Italic);
                break;
            case 12:
                SwitchName(curName);
                SwitchStyle(FontStyle.Normal);
                break;
            case 13:
                EndTalk();
                break;
        }
    }

    private void play4(){
        lines = sequence4;
        curSeq = "4";

        switch(curLine){
            case 0:
                SpriteChange(sHappy_FistsUp);
                SwitchName(curName);
                break;
            case 1:
                SwitchName("You");
                break;
            case 2:
                SpriteChange(sThinking_Neutral);
                SwitchName(curName);
                break;
            case 3:
                SwitchName("You");
                break;
            case 4:
                SpriteChange(sAngry_FistsUp);
                SwitchName(curName);
                break;
            case 5:
                SwitchName("You");
                break;
            case 6:
                SpriteChange(sNeutral_Neutral);
                SwitchName(curName);
                break;
            case 7:
                SwitchName("You");
                break;
            case 8:
                SpriteChange(sAngry_Neutral);
                SwitchName(curName);
                break;
            case 9:
                SwitchName("You");
                break;

            case 10:
                SpriteChange(sBlush_Neutral);
                SwitchName(curName);
                break;
            case 11:
                SpriteChange(sThinking_Neutral);
                SwitchName(curName);
                break;
            case 12:
                SwitchName("You");
                break;
            case 13:
                SpriteChange(sAngry_Punch);
                SwitchName(curName);
                break;
            case 14:
                SwitchName("You");
                break;
            case 15:
                SpriteChange(sHesitant_Neutral);
                SwitchName(curName);
                break;
            case 16:
                SwitchName(curName);
                break;
            case 17:
                SwitchName("You");
                break;
            case 18:
                SpriteChange(sAngry_FistsUp);
                SwitchName(curName);
                break;
            case 19:
                break;
            case 20:
                SwitchName("You");
                break;

            case 21:
                SpriteChange(sAngry_Punch);
                SwitchName(curName);
                break;
            case 22:
                break;
            case 23:
                SpriteChange(sAngry_FistsUp);
                SwitchName(curName);
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
                break;
            case 28:
                SpriteChange(sHesitant_FistsUp); //I don't
                SwitchName(curName);
                break;
            case 29:
                SwitchName("You");
                break;
            case 30:
                break;
            case 31:
                SpriteChange(sThinking_Neutral);
                SwitchName(curName);
                break;
            case 32:
                SwitchName("You");
                break;
            case 33:
                SpriteChange(sAngry_Punch);
                SwitchName(curName);
                break;
            case 34:
                SwitchName("You");
                break;
            case 35:
                SpriteChange(sAngry_FistsUp);
                SwitchName(curName);
                break;
            case 36:
                SwitchName("You");
                break;
            case 37:
                SwitchName(curName);
                break;
            case 38:
                SwitchName("You");
                break;
            case 39:
                SwitchName(curName);
                break;
            case 40:
                SwitchName("You");
                break;
            case 41:
                SpriteChange(sHappy_Neutral);
                SwitchName(curName);
                break;
            case 42:
                SwitchName("You");
                break;
            case 43:
                SpriteChange(sBlush_Neutral);
                SwitchName(curName);
                break;
            case 44:
                SwitchName("You");
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
                SpriteChange(sHappy_Punch);
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
            case "2":
                seqMethod = () => play2_1_3();
                AdvanceTalk();
                break;
            case "2_4":
                seqMethod = () => play2_5_7();
                AdvanceTalk();
                break;
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
