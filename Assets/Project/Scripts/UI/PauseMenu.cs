using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{ 
    public PlayerControls Input;
    public bool MenuActive = false, OptionsActive = false;
    public GameObject SettingsWindow;
    public Slider MUSCSlider, SFXSlider;
    public float MouseSensitivity = 0.1f, Volume = 1.0f, Shit = 1.0f;
    void Awake(){
        Input = new PlayerControls();
        // input.Walking.Pause.performed += ctx => OnPause();
    }
    private void OnEnable() {
        Input.Enable();
    }

    private void OnDisable(){
        Input.Disable();
    }
    void Start()
    {
        var musicVol = PlayerPrefs.GetFloat("MusicVol", 0.8f);
        var masterVol = PlayerPrefs.GetFloat("MasterVol", 0.8f);
        MUSCSlider.value = musicVol;
        AudioManager.Instance.SetVolume(musicVol, "music");
        SFXSlider.value = masterVol;
        AudioManager.Instance.SetVolume(masterVol, "music");
    }
    public void OnResume(){
        // vcam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = mouseSens;
        // vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = mouseSens;
        Time.timeScale = 1.0f;
        MenuActive = false;
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
        AudioManager.Instance.SetVolume(MUSCSlider.value, "music");
        PlayerPrefs.SetFloat("MusicVol", MUSCSlider.value);
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
        AudioManager.Instance.SetVolume(SFXSlider.value, "sfx");
        PlayerPrefs.SetFloat("MasterVol", SFXSlider.value);
    }
    public void OnOptions(){ 
        OptionsActive = !OptionsActive;
        SettingsWindow.SetActive(OptionsActive);
        
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
