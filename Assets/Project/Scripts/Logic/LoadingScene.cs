using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class LoadingScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    
    // Update is called once per frame
    void Update()
    {
        // if(AudioManager.instance.GetComponent<StudioBankLoader>() ge)

    }
}
