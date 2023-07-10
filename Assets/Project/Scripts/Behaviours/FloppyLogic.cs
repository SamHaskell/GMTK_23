using UnityEngine;
using UnityEngine.SceneManagement;

public class FloppyLogic : MonoBehaviour
{
    public void GameLose()
    {
        AudioManager.Instance.PlaySound("game over");
        AudioManager.Instance.PlayMusicLoop(false);
        SceneManager.LoadScene("GameOver");
    }
}
