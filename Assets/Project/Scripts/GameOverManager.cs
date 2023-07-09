using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    float _reloadTimer;
    public TextMeshProUGUI text;
    public float TimerLimit;
    // Start is called before the first frame update
    void Start()
    {
        // _reloadTimer = 0;
        text.text = PlayerPrefs.GetInt("Score", 0).ToString();
    }

    
    // Update is called once per frame
    void Update()
    {
        if(InputManager.anyKeyDown){
            SceneManager.LoadScene("InitializationScene");
        }
        // _reloadTimer += Time.deltaTime;
        // if (_reloadTimer >= TimerLimit) // do this for ychai
        // {
            // SceneManager.LoadScene("InitializationScene");
        // }
    }
}
