using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloppyLogic : MonoBehaviour
{
    public void GameLose()
    {
        AudioManager.instance.PlaySound("game over");
        AudioManager.instance.PlayMusicLoop(false);
        SceneManager.LoadScene("GameOver");
    }
}
