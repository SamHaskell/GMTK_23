using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaineMenu : MonoBehaviour
{
    //[SerializeField] private Scene newGameScene;
    public void NewGame(string newGameSceneName)
    {
        SceneManager.LoadScene(newGameSceneName);
    }
}
