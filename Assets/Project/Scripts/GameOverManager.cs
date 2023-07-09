using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    float _reloadTimer;
    public float TimerLimit;
    void Start()
    {
    }
    void Update()
    {
        if(InputManager.anyKeyDown){
            SceneManager.LoadScene(1);
        }
    }
}
