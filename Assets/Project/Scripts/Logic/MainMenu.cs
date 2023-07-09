using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
        PlayerPrefs.SetInt("Score", 0);
    }
    public void ToTutorial()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }
}
