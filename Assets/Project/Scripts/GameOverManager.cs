using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    float _reloadTimer;
    public GameObject Text;
    public float TimerLimit;
    void Start()
    {
        Text.GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("Score", 0).ToString();
    }
    void Update()
    {
        if(InputManager.anyKeyDown){
            SceneManager.LoadScene(1);
        }
    }
}
