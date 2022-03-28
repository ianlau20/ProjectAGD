using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharHana : Character, IClick
{
    protected ModeManager mm;

    // Start is called before the first frame update
    void Start()
    {
        mm = FindObjectOfType<ModeManager>();
        curLine = 0;
        lines = new List<string>();
        responses = new List<List<string>>();
        lines.Add("Hey!");
        responses.Add(new List<string> {"Hi!", "..."});
        lines.Add("You should leave me alone!");
        responses.Add(new List<string> {"Sorry.", "Whatever."});
    }

    public void onClickAction() {
        // Open Dialogue
        StartTalk();
    }

    private void StartTalk(){
        mm.curPerson = this;
        mm.cameras[0].gameObject.SetActive(false);
        mm.cameras[2].gameObject.SetActive(true);
        textUI.SetActive(true);
        textBackground.SetActive(true);
        textUI.GetComponent<TMPro.TextMeshProUGUI>().text = lines[curLine];
        mm.responseButtonTexts[0].GetComponent<Text>().text = responses[curLine][0];
        mm.responseButtonTexts[1].GetComponent<Text>().text = responses[curLine][1]; 
        mm.responseButtons[0].SetActive(true);
        mm.responseButtons[1].SetActive(true);
    }

    private void AdvanceTalk(){
        curLine++;
        textUI.GetComponent<TMPro.TextMeshProUGUI>().text = lines[curLine];
        mm.responseButtonTexts[0].GetComponent<Text>().text = responses[curLine][0];
        mm.responseButtonTexts[1].GetComponent<Text>().text = responses[curLine][1]; 
    }

    private void EndTalk(){
        curLine = 0;
        mm.cameras[2].gameObject.SetActive(false);
        mm.cameras[0].gameObject.SetActive(true);
        textUI.SetActive(false);
        textBackground.SetActive(false);
        mm.responseButtons[0].SetActive(false);
        mm.responseButtons[1].SetActive(false);
    }

    public override void Response1()
    {
        if(curLine < 1){
            AdvanceTalk();
        }
        else{
            EndTalk();
        }
    }

    public override void Response2()
    {
        if(curLine < 1){
            AdvanceTalk();
        }
        else{
            EndTalk();
        }
    }

    public override void Response3()
    {
        
    }
}
