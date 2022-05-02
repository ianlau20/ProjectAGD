using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource UI_Feedback;
    public AudioClip MC_menu;

    void Start(){
        UI_Feedback.clip = MC_menu;
        UI_Feedback.volume = 0.2f;
        UI_Feedback.Play();
    }
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
