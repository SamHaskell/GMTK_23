using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public float TimerLimit;
    float _reloadTimer;

    void Update()
    {
        if(InputManager.AnyKeyDown){
            SceneManager.LoadScene(1);
        }
    }
}
