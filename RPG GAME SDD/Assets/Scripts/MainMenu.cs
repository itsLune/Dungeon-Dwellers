using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject playMenu;
    public GameObject settingsMenu;
    public void MultiplayerLoad(){
        SceneManager.LoadScene("Loading");
    }
    public void PlayMenu() {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        playMenu.SetActive(true);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Back(){
        playMenu.SetActive(false);
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void Settings(){
        playMenu.SetActive(false);
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void ExitGame(){
        Application.Quit();
    }
}
