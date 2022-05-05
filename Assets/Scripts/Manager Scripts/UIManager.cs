using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject blackOutSquare;



    public void StartFade(){
        StartCoroutine(FadeBlackOutSquare());
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, int fadeSpeed = 1){
        blackOutSquare.SetActive(fadeToBlack);
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;
        if(fadeToBlack){
            while (blackOutSquare.GetComponent<Image>().color.a < 1){
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        else{
            fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
        }
        yield return new WaitForEndOfFrame();
    }
}
