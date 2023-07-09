using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string newGameSceneName1;
    public void NewGame()
    {
        SceneManager.LoadScene(newGameSceneName1, LoadSceneMode.Single);
        PlayerPrefs.SetInt("Score", 0);
    }
    public void ToTutorial(){
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
}
