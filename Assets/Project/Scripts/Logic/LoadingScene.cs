using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class LoadingScene : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    
    void Update()
    {

    }
}
