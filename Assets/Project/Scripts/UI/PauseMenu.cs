using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update    
    public PlayerControls input;
    public bool menuActive = false, optionsActive = false;
    public GameObject settingsWindow;
    public Slider MUSCSlider, SFXSlider;
    // public CinemachineVirtualCamera vcam;
    public float mouseSens = 0.1f, volume = 1.0f, shit = 1.0f;
    // public Volume postProcessingVolume;

    void Awake(){
        input = new PlayerControls();
        // input.Walking.Pause.performed += ctx => OnPause();
    }
    private void OnEnable() {
        input.Enable();
    }

    private void OnDisable(){
        input.Disable();
    }
    void Start()
    {
        
    }
    public void OnResume(){
        // vcam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = mouseSens;
        // vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = mouseSens;
        Time.timeScale = 1.0f;
        menuActive = false;
        // pauseMenu.SetActive(false);
        // cursorMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
    // public void OnMouseSensUpdate(){
    //     PlayerPrefs.SetFloat("Mouse Sensitivity Slider", sensSlider.value);
    //     mouseSens = sensSlider.value;
    // }
    public void OnVolumeUpdate(){
        PlayerPrefs.SetFloat("Music Slider", MUSCSlider.value);
        AudioManager.instance.SetVolume(MUSCSlider.value, "music");
    }
    // pause menu isn't static so this doesn't work for FMSingle to use
    // public float getVolumeSlider() {
    //     return volumeSlider.value;
    // }

    public void OnShitUpdate(){
        // shit = shitSlider.value;
        // ChromaticAberration actualShit;
        // postProcessingVolume.profile.TryGet<ChromaticAberration>(out actualShit); 
        // actualShit.intensity.value = shit;

        PlayerPrefs.SetFloat("SFX Slider", SFXSlider.value);
        AudioManager.instance.SetVolume(SFXSlider.value, "sfx");
    }
    public void OnOptions(){ 
        optionsActive = !optionsActive;
        settingsWindow.SetActive(optionsActive);
        
    }
    public void OnMainMenu(){ 
        
    }

    // void OnPause(){
    //     menuActive = !menuActive;        

    //     Debug.Log("Music Slider: " + PlayerPrefs.GetFloat("Music Slider"));

    //     sensSlider.value = PlayerPrefs.GetFloat("Mouse Sensitivity Slider");
    //     MUSCSlider.value = PlayerPrefs.GetFloat("Music Slider");
    //     SFXSlider.value =  PlayerPrefs.GetFloat("SFX Slider");

    //     switch(menuActive){
    //         case true:
    //             cursorMenu.SetActive(false);
    //             // vcam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = 0.0f;
    //             // vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = 0.0f;
    //             // input.Disable();
    //             Time.timeScale = 0.0f;
    //             pauseMenu.SetActive(true);
    //             Cursor.lockState = CursorLockMode.None;
    //         break;
    //         case false:
    //             cursorMenu.SetActive(true);
    //             // vcam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = mouseSens;
    //             // vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = mouseSens;
    //             // input.Enable();
    //             Time.timeScale = 1.0f;
    //             optionsActive = false;
    //             optionsMenu.SetActive(false);
    //             pauseMenu.SetActive(false);
    //             Cursor.lockState = CursorLockMode.Locked;
    //         break;
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
