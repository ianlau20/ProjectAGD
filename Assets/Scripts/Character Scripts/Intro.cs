using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;


public class Intro : Character
{
    protected ModeManager mm;
    protected UIManager um;
    public Sprite sNormal;
    public Sprite sCat;
    public GameObject TeaBG;
    public GameObject RestartButton;
    public GameObject NextButton;
    public SpriteRenderer self;
    public AudioSource UI_Feedback;
    public AudioClip SFX_clicked;
    public AudioClip SFX_drum;
    protected List<string> sequence1 = new List<string>();
    protected List<string> sequenceOutro = new List<string>();


    

    // LoadDialogue is called after name is input
    public override void LoadDialogue()
    {
        mm = FindObjectOfType<ModeManager>();
        um = FindObjectOfType<UIManager>();
        curLine = -1;
        session = 0;
        curSeq = "0";
        curName = "<color=#C0C0C0ff>???</color>";
        lines = new List<string>();
        responses = new List<string>();

        // SEQUENCE 1
        sequence1.Add("You find yourself standing in a small crowd; you don't recognize anyone. Everyone is standing silently in front of an old tea shop, waiting.");

        sequence1.Add("You assume they are all here for the same thing.");

        sequence1.Add("Everyone here received an invitation from a mysterious host.");

        sequence1.Add("“Dear " + mm.username + ",");
        sequence1.Add("I believe you are in need of help. Something is missing in your life, no?");
        sequence1.Add("Well, I am here to help you. If you join me and play a simple game, I will grant you any wish.");
        sequence1.Add("You can find me here: *** ********. My shop opens at 2 pm. Don’t be late.");
        sequence1.Add("Sincerely, \nA concerned friend.");

        sequence1.Add("A friend? A game? Any wishes granted?");
        sequence1.Add("So many questions, but the offer was too good to pass up.");
        sequence1.Add("It wouldn’t hurt to just check it out, right?");

        sequence1.Add("All of you stood in silence, waiting for 2 pm. Once it reached the designated time, the doors opened.");
        sequence1.Add("A masked figure steps out from the shop entrance and bows.");

        sequence1.Add("Welcome my esteemed guests. Come in, come in.");
        
        sequence1.Add("Now, I shall waste no time. You will all play my game, and the winner will have their wish granted. ");
        sequence1.Add("Do not worry. It is a simple card game where you must empty your hand to win. Whoever does that first wins the round. ");
        sequence1.Add("The person with the most cards at the end of the round, however, loses and will be eliminated.");
        sequence1.Add("If multiple people have the same amount of cards, fate will decide the loser.");
        sequence1.Add("You will continue this until there is one player left; they will be the ultimate winner. ");
        sequence1.Add("Now, I will tell you no more. It is up to you to figure out how the cards work and what they do.");
        //sequence1.Add("Ah, I almost forgot. The winner of each round can add a new rule to the game that only they will know.");
        sequence1.Add("Now, let the game begin!");

        // OUTRO
        sequenceOutro.Add("Congratulations " + mm.username + ".");
        sequenceOutro.Add("Don't worry about the other contestants. They lost, and you won.");
        sequenceOutro.Add("Now, what is your wish?");

    }

    public void StartIntro(){
        session = 0;
        mm.curPerson = this;
        mm.cameras[0].gameObject.SetActive(false);
        mm.cameras[8].gameObject.SetActive(true);
        mm.StartConversation();

        curLine = -1;
        SwitchStyle(FontStyle.Normal);

        switch(session){
            case 0:
                seqMethod = () => play1();
                break;
        }
        
        AdvanceTalk();
    }

    public void StartOutro(){
        mm.curPerson = this;
        mm.cameras[0].gameObject.SetActive(false);
        mm.cameras[1].gameObject.SetActive(true);
        mm.StartConversation();

        curLine = -1;
        SwitchStyle(FontStyle.Normal);

        seqMethod = () => playOutro();
        
        AdvanceTalk();
    }

    private void play1(){
        lines = sequence1;
        curSeq = "1";

        switch(curLine){
            case 0:
                SwitchName("");
                TeaBG.SetActive(true);
                break;
            case 13:
                SpriteChange(sCat);
                UI_Feedback.clip = SFX_drum;
                UI_Feedback.Play();
                nameUI.GetComponent<Text>().text = "<color=#ffe449ff>???</color>";
                break;
            case 14:
                mm.cameras[0].gameObject.SetActive(true);
                mm.cameras[8].gameObject.SetActive(false);
                break;
            case 21:
                EndTalk();
                break;
        }
    }

    private void playOutro(){
        lines = sequenceOutro;
        curSeq = "Outro";

        switch(curLine){
            case 0:
                SwitchName("<color=#ffe449ff>???</color>");
                break;
            case 1:
                SwitchName("<color=#ffe449ff>???</color>");
                break;
            case 2:
                SwitchName("<color=#ffe449ff>???</color>");
                NextButton.SetActive(false);
                DelayedEndGame();
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
        mm.StartChatMode();
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

    private async Task DelayedEndGame(){
        await Task.Delay(3000);
        um.StartFade();
        await Task.Delay(3000);
        RestartButton.SetActive(true);
    }

}
