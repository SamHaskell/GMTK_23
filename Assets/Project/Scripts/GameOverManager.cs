using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    float _reloadTimer;
    public Text text;
    public float TimerLimit;
    // Start is called before the first frame update
    void Start()
    {
        _reloadTimer = 0;
    }

    
    // Update is called once per frame
    void Update()
    {
        _reloadTimer += Time.deltaTime;
        if (_reloadTimer >= TimerLimit)
        {
            SceneManager.LoadScene("Final Scene");
        }
    }
}
